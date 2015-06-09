using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ISICWeb.Infrastructure
{

    public class NumericLessThanAttribute : ValidationAttribute, IClientValidatable
    {
        private const string lessThanErrorMessage = "{0} must be less than {1}.";
        private const string lessThanOrEqualToErrorMessage = "{0} must be less than or equal to {1}.";

        public string OtherProperty { get; private set; }

        private bool allowEquality;

        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;

                // Set the error message based on whether or not
                // equality is allowed
                this.ErrorMessage = (value ? lessThanOrEqualToErrorMessage : lessThanErrorMessage);
            }
        }

        public NumericLessThanAttribute(string otherProperty)
            : base(lessThanErrorMessage)
        {
            if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
            this.OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            decimal decValue;
            decimal decOtherPropertyValue;

            if ((value == null || value.ToString().Trim() == "" ) && (otherPropertyValue==null || otherPropertyValue.ToString().Trim()==""))
                return null;

            // Check to ensure the validating property is numeric
            if (!decimal.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
            }

            // Check to ensure the other property is numeric
            if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
            }

            // Check for equality
            if (AllowEquality && decValue == decOtherPropertyValue)
            {
                return null;
            }
            // Check to see if the value is greater than the other property value
            else if (decValue > decOtherPropertyValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationNumericLessThanRule(FormatErrorMessage(metadata.DisplayName), FormatPropertyForClientValidation(this.OtherProperty), this.AllowEquality);
        }
    }

    public class ModelClientValidationNumericLessThanRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericLessThanRule(string errorMessage, object other, bool allowEquality)
        {
            ErrorMessage = errorMessage;
            ValidationType = "numericlessthan";
            ValidationParameters["other"] = other;
            ValidationParameters["allowequality"] = allowEquality;
        }
    }


    public class NumericGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private const string greaterThanErrorMessage = "{0} debe ser superior a {1}.";
        private const string greaterThanOrEqualToErrorMessage = "{0} debe ser igual o superior a {1}.";

        public string OtherProperty { get; private set; }

        private bool allowEquality;

        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;

                // Set the error message based on whether or not
                // equality is allowed
                this.ErrorMessage = (value ? greaterThanOrEqualToErrorMessage : greaterThanErrorMessage);
            }
        }

        public NumericGreaterThanAttribute(string otherProperty)
            : base(greaterThanErrorMessage)
        {
            if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
            this.OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "No se pudo encontrar propiedad con nombre {0}.", OtherProperty));
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            decimal decValue;
            decimal decOtherPropertyValue;

            if ((value == null || value.ToString().Trim() == "") && (otherPropertyValue == null || otherPropertyValue.ToString().Trim() == ""))
                return null;


            // Check to ensure the validating property is numeric
            if (!decimal.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
            }

            // Check to ensure the other property is numeric
            if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
            }

            // Check for equality
            if (AllowEquality && decValue == decOtherPropertyValue)
            {
                return null;
            }
            // Check to see if the value is greater than the other property value
            else if (decValue < decOtherPropertyValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationNumericGreaterThanRule(FormatErrorMessage(metadata.DisplayName), FormatPropertyForClientValidation(this.OtherProperty), this.AllowEquality);
        }
    }

    public class ModelClientValidationNumericGreaterThanRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericGreaterThanRule(string errorMessage, object other, bool allowEquality)
        {
            ErrorMessage = errorMessage;
            ValidationType = "numericgreaterthan";
            ValidationParameters["other"] = other;
            ValidationParameters["allowequality"] = allowEquality;
        }
    }

    public sealed class IsDateAfterAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _testedPropertyName;
        private readonly bool _allowEqualDates;
        private readonly bool _allowOneEmpty;

        public IsDateAfterAttribute(string testedPropertyName, bool allowEqualDates = false, bool allowOneEmpty=true)
        {
            _testedPropertyName = testedPropertyName;
            _allowEqualDates = allowEqualDates;
            _allowOneEmpty = allowOneEmpty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(_testedPropertyName);


            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", _testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            DateTime d;
            if ((_allowOneEmpty) && (value == null ^ propertyTestedValue == null))
            {
                return ValidationResult.Success;
            }

            if (value == null || DateTime.TryParse(value.ToString(), out d) == false)
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || DateTime.TryParse(propertyTestedValue.ToString(), out d) == false)
            {
                return ValidationResult.Success;
            }
            DateTime valor = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime valorTesteado = DateTime.ParseExact(propertyTestedValue.ToString(), "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            // Compare values
            if (valor >= valorTesteado)
            {
                if (_allowEqualDates && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if (valor > valorTesteado)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessageString,
                ValidationType = "isdateafter"
            };
            rule.ValidationParameters["propertytested"] = _testedPropertyName;
            rule.ValidationParameters["allowequaldates"] = _allowEqualDates;
            rule.ValidationParameters["allowoneempty"] = _allowOneEmpty;
            yield return rule;
        }
    }


    public sealed class IsDateBeforeAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _testedPropertyName;
        private readonly bool _allowEqualDates;
        private readonly bool _allowOneEmpty;

        public IsDateBeforeAttribute(string testedPropertyName, bool allowEqualDates = false, bool allowOneEmpty=false)
        {
            _testedPropertyName = testedPropertyName;
            _allowEqualDates = allowEqualDates;
            _allowOneEmpty = allowOneEmpty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(_testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", _testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            DateTime d;
            if ((_allowOneEmpty)&& (value==null ))
            if (value == null || DateTime.TryParse(value.ToString(), out d) == false)
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || DateTime.TryParse(propertyTestedValue.ToString(), out d) == false)
            {
                return ValidationResult.Success;
            }
            DateTime valorTesteado = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime valor = DateTime.ParseExact(propertyTestedValue.ToString(), "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            // Compare values
            if (valor >= valorTesteado)
            {
                if (_allowEqualDates && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if (valor > valorTesteado)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessageString,
                ValidationType = "isdatebefore"
            };
            rule.ValidationParameters["propertytested"] = _testedPropertyName;
            rule.ValidationParameters["allowequaldates"] = _allowEqualDates;
            rule.ValidationParameters["allowoneempty"] = _allowOneEmpty;
            yield return rule;
        }
    }



    public class LetraCodigoBarrasAttribute : ValidationAttribute,
        IClientValidatable
    {

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                string codigoBarras = value.ToString();
                string letra = BuscarLetra(codigoBarras);

                if (letra != codigoBarras.Substring(12, 1).ToUpper())
                {
                    return
                        new ValidationResult(string.Format("Letra del Código de Barras incorrecta. Debería ser: {0}",
                            letra));

                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            //rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            //rule.ValidationParameters.Add("letra", CodigoBarras);
            rule.ValidationType = "letracodbarras";
            yield return rule;
        }

        private string BuscarLetra(string cb)
        {
            string codigo;
            int i;
            int j;
            string letra;
            var expo = new[] {0, 1, 2, 4, 8};
            if (cb.Count() != 13)
                return "";
            else
                codigo = cb.Substring(0, 12);
            int n;
            if (int.TryParse(codigo, out n))
                return "";
            var suma = 0;
            for (i = 1; i <= 3; i++)
            {
                for (j = 1; j <= 4; j++)
                {
                    suma += (Convert.ToInt32((codigo.Substring((i - 1)*4 + j - 1, 1))) + 48)*expo[j];
                }
            }
            letra = "ABCDEFGHIJKMNPRSTUVWXYZ".Substring(((suma%23)), 1);
            letra = letra.ToUpper();
            return letra;
        }
    }
}