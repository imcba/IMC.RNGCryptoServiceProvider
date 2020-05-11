using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace IMCBA
{
    class RNGCSP
    {
        public static void Main()
        {
            Console.WriteLine(RandomInteger(1, 15675));
        }

        // Return a random integer between a min and max value.
        private static int RandomInteger(int min, int max)
        {
            // The random number provider.
            RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }
    }
}


