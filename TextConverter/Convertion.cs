using System;
using System.Text.RegularExpressions;

namespace TextConverter
{
    /// <summary>
    /// Class for text conversion from one alphabet to another
    /// </summary>
    public class ConvertMessage
    {
        /// <summary>
        /// Covernt message into one of the two alphabets
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Converted Message</returns>
        public string Convert(string message)
        {
            Dictionaries dictionary = new Dictionaries();

            if (!Regex.IsMatch(message, @"\P{IsCyrillic}"))
            {
                foreach (var letter in dictionary.RusToEng.Keys)
                {
                    message = message.Replace(letter, dictionary.RusToEng[letter]);
                }

                return message;

            }
            else
            {
                foreach (var letter in dictionary.EngToRus.Keys)
                {
                    message= message.Replace(letter, dictionary.EngToRus[letter]);
                }

                return message;

            }

            throw new Exception("Nor Cyrillic, nor Latin. Check your input.");
        }
    }
}
