using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News24.Web.Extensions
{
    public static class StringExtension
    {
        public static List<string> ToListSplit(this string str)
        {
            var searcValuesArray = str.Split(',');
            var listSearcValue = new List<string>();
            foreach (var item in searcValuesArray)
            {
                listSearcValue.Add(item);
            }
            return listSearcValue;

        }
    }
}