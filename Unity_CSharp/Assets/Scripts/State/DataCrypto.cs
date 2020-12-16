using System;


namespace GeekbrainsUnityCSharp
{
    public static class DataCrypto
    {
        public static string XOR(string text, int key = 42)
        {
            var result = String.Empty;
            foreach (var symbol in text)
            {
                result += (char)(symbol ^ key);
            }
            return result;
        }
    }
}