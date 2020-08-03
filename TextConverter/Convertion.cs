using System;
using System.Text.RegularExpressions;

namespace TextConverter
{
    public class ConvertMessage
    {
        public void Convert(string message)
        {
            Dictionaries dictionary = new Dictionaries();

            if (Regex.IsMatch(message, @"\P{IsCyrillic}"))
            {
                foreach (string letter in dictionary.RusToEng.Keys)
                {
                    message = message.Replace(letter, dictionary.RusToEng[letter]);
                }
            }
            else
            {
                foreach (string letter in dictionary.EngToRus.Keys)
                {
                    message = message.Replace(letter, dictionary.EngToRus[letter]);
                }
            }
        }
    }
}
