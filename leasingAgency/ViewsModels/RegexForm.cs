using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace leasingAgency.ViewsModels
{
     public static class RegexForm
    {
        static private string regexModel = @"^(?!^[0-9]*$)([a-z0-9]{0,20})$";
        static public bool RegexregexModelFunc(string str)
        {
            return Regex.IsMatch(str, regexModel, RegexOptions.None);
        }

        static private string regexLogin = @"^(?!^[0-9]*$)([a-z0-9]{3,15})$";
        static public bool RegexLoginFunc(string str) {
            return Regex.IsMatch(str, regexLogin, RegexOptions.None);
        }

        static private string regexPassword = @"^(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-z0-9]{6,20})$";
        static public bool RegexPasswordFunc(string str){
            return Regex.IsMatch(str, regexPassword, RegexOptions.None);
        }

        static private string regexOnlyNumber = @"^[0-9]+$";
        static public bool RegexOnlyNumberFunc(string str)
        {
            return Regex.IsMatch(str, regexOnlyNumber, RegexOptions.None);
        }

        static private string regexPhoneNumber = @"^[0-9]{9}$";
        static public bool RegexPhoneNumberFunc(string str)
        {
            return Regex.IsMatch(str, regexPhoneNumber, RegexOptions.None);
        }

        static private string regexName = @"^([a-zA-zа-яА-я]{1,20})$";
        static public bool RegexNameFunc(string str)
        {
            return Regex.IsMatch(str, regexName, RegexOptions.None);
        }
    }
}