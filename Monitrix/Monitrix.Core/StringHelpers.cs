using System;

namespace Monitrix.Core
{
    public static class StringHelpers
    {
        /// <summary>
        /// Finds the next char (left or right) to a given target
        /// </summary>
        /// <param name="src">Source string</param>
        /// <param name="charTarget">Char to search next to</param>
        /// <param name="left">Left default</param>
        /// <returns></returns>
        public static string NextTo(this string src, char charTarget, bool left = true)
        {
            string res = src;
            int idx = src.IndexOf(charTarget);
            int searchSpace = left ? -1 : +1;

            if (idx != searchSpace)
            {
                res = src.Substring(0, idx);
            }

            return res;
        }

        /// <summary>
        ///  Replaces the format item in a specified System.String with the text equivalent
        ///  of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="arg0">An System.Object to format</param>
        /// <returns>A copy of format in which the first format item has been replaced by the
        /// System.String equivalent of arg0</returns>
        public static string Format(this string value, object arg0)
        {
            return string.Format(value, arg0);
        }

        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
            {
                if (string.Compare(value, otherValue) == 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Converts string to enum object
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Levistein distance to a string target from a -> b 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int LevisteinDistanceTo(this string source, string target)
        {
            var srcLengthA = source.Length;
            var srcLengthB = target.Length;

            var mtx = new int[srcLengthA + 1, srcLengthB + 1];
            
            if (srcLengthA == 0)
                return srcLengthB;

            if (srcLengthB == 0)
                return srcLengthA;

            for (var i = 0; i <= srcLengthA; mtx[i, 0] = i++) { }
            for (var j = 0; j <= srcLengthB; mtx[0, j] = j++) { }

            for (var i = 1; i <= srcLengthA; i++)
            {
                for (var j = 1; j <= srcLengthB; j++)
                {
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    mtx[i, j] = Math.Min(Math.Min(mtx[i - 1, j] + 1, mtx[i, j - 1] + 1),mtx[i - 1, j - 1] + cost);
                }
            }
            
            return mtx[srcLengthA, srcLengthB];
        }
    }
}
