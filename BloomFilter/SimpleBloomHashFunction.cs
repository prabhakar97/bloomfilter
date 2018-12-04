using System;

namespace Bloom
{
    public class SimpleBloomHashFunction : BloomHashFunction
    {
        public uint Hash(object obj)
        {
            if (obj == null)
                throw new Exception("Cannot hash a null object.");
            return (uint) obj.GetHashCode();
        }
    }
}