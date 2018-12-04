using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bloom
{
    public class StringBloomHashFunction : BloomHashFunction
    {
        public uint Hash(object obj)
        {
            if (obj == null)
                throw new Exception("Cannot hash a null object.");
            char[] line = convertToString(obj).ToCharArray();
            int result = 0;
            for (int i = 0; i < line.Length; i++)
            {
                result += line[i];
            }
            return (uint) result;
        }

        private string convertToString(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToString();
            }
        }
    }
}