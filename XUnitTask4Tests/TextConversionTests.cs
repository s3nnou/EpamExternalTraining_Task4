using NetEntitiesLibrary;
using System;
using System.Collections.Generic;
using TextConverter;
using Xunit;

namespace XUnitTask4Tests
{
    /// <summary>
    /// Class for text conversion tests
    /// </summary>
    public class TextConversionTests
    {
        /// <summary>
        /// Text conversion tests
        /// </summary>
        /// <param name="original">original text</param>
        /// <param name="expected">converted text</param>
        [Theory]
        [MemberData(nameof(Data))]
        public void Various_Text_Convertions_Creation(string original, string expected)
        {
            ConvertMessage convert = new ConvertMessage();

            Assert.Equal(expected, convert.Convert(original));
        }

        /// <summary>
        /// Data to test text conversions within Various_Text_Convertions_Creation method
        /// </summary>
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "privet", "привет"},
            new object[] { "мойдодыр", "moydodyir"},
            new object[] { "эльф", "el'f"},
            new object[]{ "hello", "хелло"},
            new object[] { "mama", "мама"},
        };


        /// <summary>
        /// Creates an exception to demostrate wrong message alphabet insertion
        /// </summary>
        [Fact]
        public void CreatingServer_WithWrongArguments_ThrowsException()
        {
            ConvertMessage converter = new ConvertMessage();
            Assert.Throws<Exception>(() => converter.Convert("影"));
        }
    }
}

