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
        static private string regexLogin = @"^(?!^[0-9]*$)^([a-zA-z0-9]{3,15})$";
        static public bool RegexLoginFunc(string str) {
            return Regex.IsMatch(str, regexLogin, RegexOptions.None);
        }

        static private string regexPassword = @"^(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-z0-9]{6,20})$";
        static public bool RegexPasswordFunc(string str){
            return Regex.IsMatch(str, regexPassword, RegexOptions.None);
        }
    }
}