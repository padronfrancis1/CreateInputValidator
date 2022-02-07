using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainModel
{
    public class InputValidator<T> : IInputValidator
        where T : INotifyDataErrorInfo
    {
        private T _source;
        private static Dictionary<string, KeyValuePair<Func<T, object>, ValidationAttribute[]>> _mAllValidators;

        // STATIC CONSTRUCTORS AUTOMATICALLY CALLED ONCE
        static InputValidator()
        {
            _mAllValidators = new Dictionary<string, KeyValuePair<Func<T, object>, ValidationAttribute[]>>();
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                var validations = GetValidations(property);
                if (validations.Length > 0)
                {
                    _mAllValidators.Add(
                        property.Name,
                        new KeyValuePair<Func<T, object>, ValidationAttribute[]>(
                            CreateValueGetter(property), validations));
                }
            }
        
        }

        public InputValidator(T source)
        {
            _source = source;
        }

        public string Validate(string columnName)
        {
            KeyValuePair<Func<T, object>, ValidationAttribute[]> validators;

            if (_mAllValidators.TryGetValue(columnName, out validators))
            {
                var value = validators.Key(_source);
                ValidationContext context = new ValidationContext(_source);
                context.MemberName = columnName;
                var validationResults = new List<ValidationResult>();

                if (_source is IServiceValidateable validatable && validatable.ValidationService?.ValidationTypesToDisable != null)
                {
                    Validator.TryValidateValue(value, context, validationResults, validators.Value.Where(x => !validatable.ValidationService.ValidationTypesToDisable.Any(y => y.IsAssignableFrom(x.GetType()))));
                }
                else
                {
                    Validator.TryValidateValue(value, context, validationResults, validators.Value);
                }
                var errors = validationResults.Select(x => x.ErrorMessage);
                return String.Join(Environment.NewLine, errors);
            }
            return string.Empty;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return GetAllErrors();
            }

            KeyValuePair<Func<T, object>, ValidationAttribute[]> validators;

            if (_mAllValidators.TryGetValue(propertyName, out validators))
            {
                var value = validators.Key(_source);
                ValidationContext context = new ValidationContext(_source);
                context.MemberName = propertyName;
                var validationResults = new List<ValidationResult>();

                if (_source is IServiceValidateable validatable && validatable.ValidationService?.ValidationTypesToDisable != null)
                {
                    Validator.TryValidateValue(value, context, validationResults, validators.Value.Where(x => !validatable.ValidationService.ValidationTypesToDisable.Any(y => y.IsAssignableFrom(x.GetType()))));
                }
                else
                {
                    Validator.TryValidateValue(value, context, validationResults, validators.Value);
                }
                return validationResults.Select(x => x.ErrorMessage);
            }
            return new List<string>();
        }

        public ICollection<string> GetAllErrors()
        {
            List<string> messages = new List<string>();
            foreach (var pair in _mAllValidators)
            {
                string message = Validate(pair.Key);
                if (!String.IsNullOrEmpty(message))
                {
                    messages.AddRange(Regex.Split(message.Trim(), Environment.NewLine));
                }
            }
            return messages.Distinct().ToList();
        }

        public Dictionary<string, string> GetErrorDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (var pair in _mAllValidators)
            {
                string message = Validate(pair.Key);
                if (!String.IsNullOrEmpty(message))
                {
                    dict.Add(pair.Key, message);
                }
            }
            return dict;
        }

        //Custom
        private static ValidationAttribute[] GetValidations(PropertyInfo property)
        {
            return property.GetCustomAttributes<ValidationAttribute>(false).ToArray();
        }

        private static Func<T, object> CreateValueGetter(PropertyInfo property)
        {
            var instance = Expression.Parameter(typeof(T), "i");
            var cast = Expression.TypeAs(Expression.Property(instance, property), typeof(object));
            return (Func<T, object>)Expression.Lambda(cast, instance).Compile();
        }
    }
}
