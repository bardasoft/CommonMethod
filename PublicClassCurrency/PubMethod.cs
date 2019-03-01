using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    public class PubMethod
    {
        public static object GetDictionaryFirstKey(System.Collections.IDictionary dic)
        {
            foreach (System.Collections.DictionaryEntry entry in dic)
            {
                return entry.Key;
            }
            return null;
        }
        public static object GetDictionaryFirstValue(System.Collections.IDictionary dic)
        {
            foreach (System.Collections.DictionaryEntry entry in dic)
            {
                return entry.Value;
            }
            return null;
        }
    }
}
