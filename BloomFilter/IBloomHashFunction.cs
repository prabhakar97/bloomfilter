using System;

namespace Bloom
{
    // The hash function interface
    public interface IBloomHashFunction
    {
        // Hash algorithm that takes an object in and returns a positive unsigned integer.
        uint Hash(Object obj);
    }
}