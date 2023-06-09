using System;
using System.Collections.Generic;
using System.Text;

namespace StandardDigitalSignature
{
    /// <summary>
    /// This class contains the operations, which are helpful in processing bytes array.
    /// </summary>

    public static class Bytes
    {
        /// <summary>
        /// Get hex from byte array.
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns> hex string</returns>
        public static string ToHex(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        /// <summary>
        /// Get byte array from hex.
        /// </summary>
        /// <param name="hex">hex string</param>
        /// <returns>byte array</returns>
        public static byte[] HexToBytes(this string hex)
        {
            var NumberChars = hex.Length;
            var bytes = new byte[NumberChars / 2];
            for (var i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// Get Base64 from byte array.
        /// </summary>
        /// <param name="me">byte array</param>
        /// <returns> Base64 string</returns>
        public static string ToBase64(this byte[] me) => Convert.ToBase64String(me);


    }
}
