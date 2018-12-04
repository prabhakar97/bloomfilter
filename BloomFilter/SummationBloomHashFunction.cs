using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bloom
{
    public class SummationBloomHashFunction : BloomHashFunction
    {
        public uint Hash(object obj)
        {
            if (obj == null)
                throw new Exception("Cannot hash a null object.");
            byte[] bytes = convertToBytes(obj);
            int result = 0;
            for (int i = 0; i < bytes.Length; i += 2)
            {
                result += BitConverter.ToInt16(bytes, i);
            }
            return (uint) result;
        }

        private byte[] convertToBytes(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}