using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMIC.CONTROLLERS.Ultils
{
    public class Validations
    {
        private static Regex m_objRegex;
        public static bool IsFilled(string strString)
        {
            return (strString.Trim().Length > 0) ? true : false;
        }

        public static bool CheckEmail(string email)
        {
            const string EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
                                                                    + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            m_objRegex = new Regex(EMAIL_PATTERN);
            return m_objRegex.IsMatch(email);
        }

        public static bool CheckImage(string fileName)
        {
            const string IMAGE_PATTERN = "([^\\s]+(\\.(?i)(jpg|png|gif|bmp))$)";
            m_objRegex = new Regex(IMAGE_PATTERN);
            return m_objRegex.IsMatch(fileName);
        }

        public static bool isNumeric(string number)
        {
            const string NUMERICS_PATTERN = "^[-+]?[0-9]*\\.?[0-9]+$";
            m_objRegex = new Regex(NUMERICS_PATTERN);
            return m_objRegex.IsMatch(number);
        }

        public static bool CheckIsInteger(string number)
        {
            const string NUMBER_PATTERN = "^[0-9.-]{1,20}$";
            m_objRegex = new Regex(NUMBER_PATTERN);
            return m_objRegex.IsMatch(number);
        }

        public static bool CheckIsIntegerOfNegative(string number)
        {
            const string NUMBER_PATTERN = "^[0-9]{1,20}$";
            m_objRegex = new Regex(NUMBER_PATTERN);
            return m_objRegex.IsMatch(number);
        }

        public static bool IsAlpha(string strToCheck)
        {
            const string ALPHA_PATTERN = "[^a-zA-Z]";
            m_objRegex = new Regex(ALPHA_PATTERN);
            return m_objRegex.IsMatch(strToCheck);
        }

        public static bool IsAlphaNumeric(string strToCheck)
        {
            const string ALPHA_PATTERN = "[^a-zA-Z0-9]";
            m_objRegex = new Regex(ALPHA_PATTERN);
            return m_objRegex.IsMatch(strToCheck);
        }

        public static bool CheckUserName(string userName)
        {
            const string USERNAME_PATTERN = "^[a-z0-9_-]{3,15}$";
            m_objRegex = new Regex(USERNAME_PATTERN);
            return m_objRegex.IsMatch(userName);
        }

        public static bool CheckPassWord(string passWord)
        {
            const string PASSWORD_PATTERN = "((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})";
            m_objRegex = new Regex(PASSWORD_PATTERN);
            return m_objRegex.IsMatch(passWord);
        }

        public static bool isPhoneNumberValid(string phoneNumber)
        {
            const string PHONE_PATTERN = "^\\(?(\\d{3})\\)?[- ]?(\\d{3})[- ]?(\\d{4})$";
            m_objRegex = new Regex(PHONE_PATTERN);
            return m_objRegex.IsMatch(phoneNumber);
        }

        public static bool isSSNValid(string ssn)
        {           
            /*
             * SSN format xxx-xx-xxxx, xxxxxxxxx, xxx-xxxxxx; xxxxx-xxxx: ^\\d{3}:
             * Starts with three numeric digits. [- ]?: Followed by an optional "-"
             * \\d{2}: Two numeric digits after the optional "-" [- ]?: May contain
             * an optional second "-" character. \\d{4}: ends with four numeric
             * digits.
             * 
             * Examples: 879-89-8989; 869878789 etc.
             */
            const string SSN_PATTERN = "^\\d{3}[- ]?\\d{2}[- ]?\\d{4}$";
            m_objRegex = new Regex(SSN_PATTERN);
            return m_objRegex.IsMatch(ssn);
        }

        public static bool isValidOfFullName(string strString)
        {
            const string FNAME_PATTERN01 = "[a-zA-Z][a-zA-Z ]*"; //regular
            const string FNAME_PATTERN02 = "^[\\p{L} .'-]+$";  //unicode
            Regex objR01 = new Regex(FNAME_PATTERN01);
            Regex objR02 = new Regex(FNAME_PATTERN02);
            if (objR01.IsMatch(strString) && objR02.IsMatch(strString))           
                return true;
            return false;
        }
    }
}
