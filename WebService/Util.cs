using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Util
    {
        public static string autoGenerationCode(string prefix, string lastestCode)
        {
            try
            {
                int num = int.Parse(lastestCode.Substring(prefix.Length));
                num++;
                return prefix + num.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return "N/A";
            }
        }
    }
}