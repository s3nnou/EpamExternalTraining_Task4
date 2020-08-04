using System;
using System.Collections.Generic;
using System.Text;

namespace TextConverter
{
    /// <summary>
    /// Contains dictionaries for two alphabets
    /// </summary>
    public class Dictionaries
    {
        /// <summary>
        /// Dicrtionary for storing Rus symbols and thier Eng equivalents
        /// </summary>
        public Dictionary<string, string> RusToEng = new Dictionary<string, string>
        {
            {"а", "a"},
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"ж", "zh"},
            {"з", "z"},
            {"и", "i"},
            {"й", "y"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"х", "h"},
            {"ц", "c"},
            {"ч", "ch"},
            {"ш", "sh"},
            {"щ", "sh"},
            {"ъ", "'"},
            {"ы", "yi"},
            {"ь", "'"},
            {"э", "e"},
            {"ю", "yu"},
            {"я", "ya"}
        };

        /// <summary>
        /// Dicrtionary for storing Eng symbols and thier Rus equivalents
        /// </summary>
        public Dictionary<string, string> EngToRus = new Dictionary<string, string>
        {
            {"a", "а"},
            {"b", "б"},
            {"c", "ц"},
            {"d", "д"},
            {"e", "е"},
            {"f", "ф"},
            {"g", "г"},
            {"h", "х"},
            {"i", "и"},
            {"j", "дж"},
            {"k", "к"},
            {"l", "л"},
            {"m", "м"},
            {"n", "н"},
            {"o", "о"},
            {"p", "п"},
            {"q", "кью"},
            {"r", "р"},
            {"s", "с"},
            {"t", "т"},
            {"u", "у"},
            {"v", "в"},
            {"w", "в"},
            {"x", "икс"},
            {"y", "и"},
            {"z", "з"},
        };

    }
}
