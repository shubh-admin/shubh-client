using System.Text.RegularExpressions;

namespace msdnh.util
{
    public class ValidationUtils
    {
        // Function to test for Positive Integers. 
        public static bool IsNaturalNumber(string strNumber)
        {
            var objNotNaturalPattern = new Regex("[^0-9]");
            var objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return objNotNaturalPattern.IsMatch(strNumber) &&
                   objNaturalPattern.IsMatch(strNumber);
        }

        // Function to test for Positive Integers with zero inclusive 
        public static bool IsWholeNumber(string strNumber)
        {
            var objNotWholePattern = new Regex("[^0-9]");
            return objNotWholePattern.IsMatch(strNumber);
        }

        // Function to Test for Integers both Positive & Negative 
        public static bool IsInteger(string strNumber)
        {
            var objNotIntPattern = new Regex("[^0-9-]");
            var objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber);
        }

        // Function to Test for Positive Number both Integer & Real 
        public static bool IsPositiveNumber(string strNumber)
        {
            var objNotPositivePattern = new Regex("[^0-9.]");
            var objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            var objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return objNotPositivePattern.IsMatch(strNumber) &&
                   objPositivePattern.IsMatch(strNumber) &&
                   objTwoDotPattern.IsMatch(strNumber);
        }

        // Function to test whether the string is valid number or not
        public static bool IsNumber(string strNumber)
        {
            var objNotNumberPattern = new Regex("[^0-9.-]");
            var objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            var objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            var strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            var strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            var objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return objNotNumberPattern.IsMatch(strNumber) &&
                   objTwoDotPattern.IsMatch(strNumber) &&
                   objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }

        // Function To test for Alphabets. 
        public static bool IsAlpha(string strToCheck)
        {
            var objAlphaPattern = new Regex("[^a-zA-Z]");
            return objAlphaPattern.IsMatch(strToCheck);
        }

        // Function to Check for AlphaNumeric.
        public static bool IsAlphaNumeric(string strToCheck)
        {
            var objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return objAlphaNumericPattern.IsMatch(strToCheck);
        }

        //Function to Check for Valid Email
        public static bool IsValidEmail(string strToChek)
        {
            var objEmailPattern = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objEmailPattern.IsMatch(strToChek);
        }
    }
}