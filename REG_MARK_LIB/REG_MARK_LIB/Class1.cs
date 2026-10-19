using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class REG_MARK_LIB_Class
    {
        public static bool CheckMark(string mark)
        {
            string pat = @"^[A|B|E|K|M|H|O|P|C|T|Y|X]{1}[0-9]{3}[A|B|E|K|M|N|O|P|C|T|Y|X]{2}[0-9]{2,3}";

            Regex regex = new Regex(pat, RegexOptions.IgnoreCase);

            return regex.IsMatch(mark);
        }
        public static string GetNextMarkAfter(string mark)
        {
            string letters = "ABCEHKMOPTXY";

            string patLetters = @"\d";
            string patNumbers = @"\D";

            Regex regexLetters = new Regex(patNumbers, RegexOptions.IgnoreCase);
            Regex regexNumbers = new Regex(patLetters, RegexOptions.IgnoreCase);

            string onlyNumbers = regexLetters.Replace(mark, @"").Substring(0, 3);
            string onlyLetters = regexNumbers.Replace(mark, @"").ToUpper();
            string region = mark.Substring(6);

            int Numbers = int.Parse(onlyNumbers);

            if (Numbers == 999)
            {
                if (onlyLetters == "YYY")
                {
                    return "Максимальный номер";
                }
                else
                {
                    if (onlyLetters.Substring(2) == "Y")
                    {
                        if (onlyLetters[0] == 'Y')
                        {
                            string letter = onlyLetters[1].ToString();
                            letter = letters[letters.IndexOf(letter) + 1].ToString();
                            onlyLetters = onlyLetters[0] + letter + onlyLetters[2];
                        }
                        else
                        {
                            string letter = onlyLetters[0].ToString();
                            letter = letters[letters.IndexOf(letter) + 1].ToString();
                            onlyLetters = letter + onlyLetters[1] + onlyLetters[2];
                        }
                    }
                    else
                    {
                        Regex regex = new Regex(@"\w{2}");
                        string letter = regex.Replace(onlyLetters, @"");
                        onlyLetters = onlyLetters.Substring(0, 2);
                        letter = letters[letters.IndexOf(letter) + 1].ToString();
                        onlyLetters += letter;

                    }

                    onlyNumbers = "001";

                }
            }
            else
            {
                Numbers++;
                if (Numbers < 10) onlyNumbers = "00" + Numbers;
                else if (Numbers > 9 && Numbers < 100) onlyNumbers = "0" + Numbers;
                else onlyNumbers = Numbers.ToString();
            }


            return onlyLetters[0] + onlyNumbers + onlyLetters.Substring(1, 2) + region;
        }
    }
}
