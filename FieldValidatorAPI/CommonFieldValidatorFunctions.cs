using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    // Delegate types defining the signatures of validation methods
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string filedValCompare);

    // Class containing common field validation functions
    public class CommonFieldValidatorFunctions
    {
        // Delegate instances to hold validation methods
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringlengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        // Property providing access to the RequiredValidDel delegate instance with lazy initialization
        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        // Property providing access to the StringlengthValidDel delegate instance with lazy initialization
        public static StringLengthValidDel StringlengthFieldValidDel
        {
            get
            {
                if (_stringlengthValidDel == null)
                    _stringlengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringlengthValidDel;
            }
        }

        // Property providing access to the DateValidDel delegate instance with lazy initialization
        public static DateValidDel DateFiledValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        // Property providing access to the PatternMatchValidDel delegate instance with lazy initialization
        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);

                return _patternMatchValidDel;
            }
        }

        // Property providing access to the CompareFieldsValidDel delegate instance with lazy initialization
        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }

        // Required field validation method
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }

        // String length validation method
        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }

        // Date field validation method
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;

            return false;
        }

        // Pattern match validation method using regular expressions
        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fieldVal))
                return true;

            return false;
        }

        // Field comparison validation method
        private static bool FieldComparisonValid(string fieldVal1, string fieldVal2)
        {
            if (fieldVal1.Equals(fieldVal2))
                return true;

            return false;
        }
    }
}
