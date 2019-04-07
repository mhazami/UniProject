﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utility
{
    public static class EnumUtils
    {
        public static string GetDescription(this Enum enumerator)
        {
            //get the enumerator type
            Type type = enumerator.GetType();

            //get the member info
            MemberInfo[] memberInfo = type.GetMember(enumerator.ToString());

            //if there is member information
            if (memberInfo != null && memberInfo.Length > 0)
            {
                //we default to the first member info, as it's for the specific enum value
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                //return the description if it's found
                if (attributes != null && attributes.Length > 0)
                    return ((DescriptionAttribute)attributes[0]).Description;
            }

            //if there's no description, return the string value of the enum
            return enumerator.ToString();
        }

        public static List<KeyValuePair<string, string>> ConvertEnumToIEnumerable<TEnum>()
        {
            var result = new List<KeyValuePair<string, string>>();
            var fieldInfos = typeof(TEnum).GetFields().Where(f => f.IsLiteral).ToList();
            for (var i = 0; i < fieldInfos.Count; i++)
            {
                var value = "";
                var attributes = fieldInfos[i].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var key = fieldInfos[i].Name;
                if (attributes != null && attributes.Length > 0)
                    value = ((DescriptionAttribute)attributes[0]).Description;
                if (!string.IsNullOrEmpty(value))
                    result.Add(new KeyValuePair<string, string>(key, value));
            }
            return result;
        }

        public static List<KeyValuePair<string, string>> ConvertEnumToIEnumerable<TEnum>(int startIndex)
        {
            var result = new List<KeyValuePair<string, string>>();
            var fieldInfos = typeof(TEnum).GetFields().Where(f => f.FieldType.FullName.Equals(typeof(TEnum).FullName)).ToList();
            for (var i = startIndex; i < fieldInfos.Count; i++)
            {
                var value = "";
                var attributes = fieldInfos[i].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var key = fieldInfos[i].Name;
                if (attributes != null && attributes.Length > 0)
                    value = ((DescriptionAttribute)attributes[0]).Description;
                result.Add(new KeyValuePair<string, string>(key, value));
            }
            return result;
        }
    }
}
