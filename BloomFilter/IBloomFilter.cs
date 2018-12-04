using System;
using System.Collections.Generic;

namespace Bloom
{
    public interface IBloomFilter<T> : IProbabilisticSet<T>
    {
        // Clear the set to make it contain zero elements
        void Clear();

        // Resize the set to a new size and erase all existing elements (larger size improves accuracy) 
        void Resize(int newSize);

        // Start using a new set of hash functions. Implicitly clears the existing members.
        void SetHashFunctions(IList<BloomHashFunction> hashFunctions);
    }
}