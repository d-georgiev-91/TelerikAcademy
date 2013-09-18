namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculates MD5 hash for a given string
        /// </summary>
        /// <param name="input">The string whose MD5 value will be computed</param>
        /// <returns>128-bit (16-byte) hash value of the given string</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToMD5Hash"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Pesho"; 
        ///         Console.WriteLine(exampleString.ToMD5Hash());
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="http://en.wikipedia.org/wiki/Md5"/>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if given a string can be interpreted as <see cref="System.Boolean"/>
        /// 'true' value.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <returns>True if the given string can be interpreted <see cref="System.Boolean"/> 'true'.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToBoolean"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "ok"; 
        ///         Console.WriteLine(exampleString.ToBoolean());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a given string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">The given string to convert.</param>
        /// <returns>The string value if the string can be converted to <see cref="System.Int16"/> else returns 0.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToShort"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "42"; 
        ///         Console.WriteLine(exampleString.ToShort()); // This will return 42.
        ///         
        ///         exampleString = "Pesho"; 
        ///         Console.WriteLine(exampleString.ToShort()); // This will return 0.
        ///     }
        /// }
        /// </code>
        /// </example>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a given string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">The given string to convert.</param>
        /// <returns>The string value if the string can be converted to <see cref="System.Int32"/> else returns 0.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToInteger"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "42"; 
        ///         Console.WriteLine(exampleString.ToInteger()); // This will return 42.
        ///         
        ///         exampleString = "Pesho"; 
        ///         Console.WriteLine(exampleString.ToInteger()); // This will return 0.
        ///     }
        /// }
        /// </code>
        /// </example>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a given string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">The given string to convert.</param>
        /// <returns>The string value if the string can be converted to <see cref="System.Int64"/> else returns 0.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToLong"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "42"; 
        ///         Console.WriteLine(exampleString.ToLong()); // This will return 42.
        ///         
        ///         exampleString = "Pesho"; 
        ///         Console.WriteLine(exampleString.ToLong()); // This will return 0.
        ///     }
        /// }
        /// </code>
        /// </example>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a given string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">The given string to convert.</param>
        /// <returns>The string value if the string can be converted to <see cref="System.DateTime"/> else 01.01.0001 г. 00:00:00 ч.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToDateTime"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = ""2012/12/30 13:37:00""; 
        ///         Console.WriteLine(exampleString.ToDateTime()); // This will return 30.12.2012 г. 13:37:00 ч.
        ///         
        ///         exampleString = "Pesho"; 
        ///         Console.WriteLine(exampleString.ToDateTime()); // This will return  01.01.0001 г. 00:00:00 ч.
        ///     }
        /// }
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Returns a copy of this string with its first letter converted to uppercase.
        /// </summary>
        /// <param name="input">This string, whose first letter will be capitalized.</param>
        /// <returns>Copy of the given string starting with capital letter.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="CapitalizeFirstLetter"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string stringExample = "pesho";
        ///         Console.WriteLine(stringExample.CapitalizeFirstLetter());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a substring between <paramref name="startString"/> and <paramref name="endString"/>. 
        /// The search beggins from <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">The string to be searche in it.</param>
        /// <param name="startString">The left boundry of the result string.</param>
        /// <param name="endString">The right boundry of the result string.</param>
        /// <param name="startFrom">The start position for the searching.</param>
        /// <returns>A subsstring between <paramref name="startString"/> and <paramref name="endString"/> 
        /// searching from <paramref name="startFrom"/>, if given such or starts from the beggining, 
        /// or <see cref="System.String.Empty"/> if <paramref name="startString"/> or 
        /// <paramref name="endString"/> are not found in the given string</returns>
        /// <example>
        /// This sample shows how to call the <see cref="GetStringBetween"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Pesho qde banica s praz.";
        ///         Console.WriteLine(exampleString.GetStringBetween("banica", "praz"));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Returns a string with all letters converted from Cyrillic letters to their Latin corresponding.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>String with all letter converted to Latin letters.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ConvertCyrillicToLatinLetters"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Ял Пешо баница с праз...";
        ///         Console.WriteLine(exampleString.ConvertCyrillicToLatinLetters());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Returns a string with all letters converted from Latin letters to their their Cyrillic corresponding.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>String with all letter converted to Cyrillic letters.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ConvertLatinToCyrillicKeyboard"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Pesho yade banitza s praz luk!";
        ///         Console.WriteLine(exampleString.ConvertCyrillicToLatinLetters());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a valid user name in Latin letters using <see cref="ConvertCyrillicToLatinLetters"/>
        /// and removes invalid characters.
        /// All non numeric characters except "." and "_" are invalid and are removed.
        /// </summary>
        /// <param name="input">String containging the user name to be validated.</param>
        /// <returns>String representing valid user name.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToValidUsername"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Пешо.Стаматов";
        ///         Console.WriteLine(exampleString.ToValidUsername());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a valid file name in Latin letters using <see cref="ConvertCyrillicToLatinLetters"/> 
        /// and removes invalid characters.
        /// All non numeric characters except ".", "-" and "_" are invalid and are removed.
        /// </summary>
        /// <param name="input">String containging the file name to be validated.</param>
        /// <returns>String representing valid file name.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToValidLatinFileName"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "снимка-планина-021";
        ///         Console.WriteLine(exampleString.ToValidLatinFileName());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Get the first characters 'n' determined by <paramref name="charsCount"/> of a given string.
        /// </summary>
        /// <param name="input">String whos first charactes will be returned.</param>
        /// <param name="charsCount">Count of the returning character.</param>
        /// <returns>The first 'n' characters if <paramref name="charsCount"/> 
        /// is lesser then the <paramref name="input"/> else the whole string.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="GetFirstCharacters"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "Pesho";
        ///         Console.WriteLine(exampleString.GetFirstCharacters(5));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Get the file extension of file in a string format
        /// </summary>
        /// <param name="fileName">The given file name with extension.</param>
        /// <returns>
        /// Substring of the given file name representing file extension if such exists 
        /// or file name isn't empty string, else returns <see cref="System.String.Empty"/>
        /// </returns>
        /// <example>
        /// This sample shows how to call the <see cref="GetFileExtension"/> method.
        /// <code>
        /// Using System;
        /// using Telerik.ILS.Common;
        /// 
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "MyMovie.avi";
        ///         Console.WriteLine(exampleString.GetFileExtension());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }


        /// <summary>
        /// Returns the corresponding content type for the given file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension excluding "." symbol.</param>
        /// <returns>The content type as a string.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToContentType"/> method.
        /// <code>
        /// class Example
        /// {
        ///     static void Main()
        ///     {
        ///         string exampleString = "jpg";
        ///         Console.WriteLine(exampleString.ToContentType());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a set of characters from the specified character array into a sequence of bytes.
        /// </summary>
        /// <param name="input">The given string.</param>
        /// <returns>A byte array containing the specified set of characters.</returns>
        /// <example>
        /// This sample shows how to call the <see cref="ToByteArray"/> method.
        /// <code>
        /// using System;
        /// using Telerik.ILS.Common;
        ///
        /// class Example
        /// {
        ///    public static void Main()
        ///    {
        ///         string exampleString = "This is some test string";
        ///         var exampleByteArray = value.ToByteArray();
        ///         foreach (var element in exampleByteArray)
        ///         {
        ///             Console.Write(element);
        ///         }
        ///     }
        /// }
        ///
        /// </code>
        /// </example>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}