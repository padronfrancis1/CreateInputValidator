using JPLease.PrairieDog.DomainModel.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DomainModel.Helpers
{
    public class ValidationAttributeHelper
    {
        public static string GetErrorMessageForProperty(Type type, Type attributeType, string property)
        {
            ValidationAttribute attribute = type.GetProperty(property)
                                                .GetCustomAttributes(false)
                                                .OfType<ValidationAttribute>()
                                                .First(x => x.GetType() == attributeType);
            return attribute.FormatErrorMessage(property);
        }

        public static string GetErrorMessageForPropertyForRequiredWhenBooleanIsTrue(Type type, string property, string booleanProperty)
        {
            RequiredWhenBooleanIsTrueAttribute attribute = type.GetProperty(property)
                .GetCustomAttributes(false)
                .OfType<RequiredWhenBooleanIsTrueAttribute>()
                .First(x => x.GetBooleanProperty() == booleanProperty);
            return attribute.FormatErrorMessage(property);
        }
    }
}
