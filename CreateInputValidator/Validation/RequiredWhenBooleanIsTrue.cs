using System;
using System.ComponentModel.DataAnnotations;

namespace JPLease.PrairieDog.DomainModel.Validation
{
    /// <summary>
    /// This validator can be used when a boolean value controls if a string field is required or not.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RequiredWhenBooleanIsTrueAttribute : ValidationAttribute
    {
        private string _booleanProperty;
        private string _idProperty;

        public RequiredWhenBooleanIsTrueAttribute(string errorMessage, string booleanProperty, string idProperty = "", bool isNullableBoolean = false)
        {
            base.ErrorMessage = errorMessage;
            _booleanProperty = booleanProperty;
            _idProperty = idProperty;
        }

        public RequiredWhenBooleanIsTrueAttribute(Type errorMessageResourceType, string errorMessageResourceName, string booleanProperty, string idProperty = "", bool isNullableBoolean = false)
        {
            ErrorMessageResourceType = errorMessageResourceType;
            ErrorMessageResourceName = errorMessageResourceName;
            _booleanProperty = booleanProperty;
            _idProperty = idProperty;
        }

        public string GetBooleanProperty()
        {
            return _booleanProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var entity = validationContext.ObjectInstance;

            bool? isBoolTrue = (bool?)entity.GetType().GetProperty(_booleanProperty)?.GetValue(entity, null);
            bool hasValue = false;
            bool hasID = false;

            if (!string.IsNullOrEmpty(_idProperty))
            {
                int? lookupID = (int?)entity.GetType().GetProperty(_idProperty).GetValue(entity, null);
                if ((lookupID ?? 0) != 0)
                {
                    hasID = true;
                }
            }

            if (value is string)
            {
                hasValue = !string.IsNullOrWhiteSpace((string)value);
            }
            else if (value is bool)
            {
                hasValue = (bool)value == true;
            }
            else
            {
                hasValue = value != null;
            }

            if (isBoolTrue == true && !hasValue && !hasID)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
