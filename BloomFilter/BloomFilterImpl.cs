using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Bloom
{
    public class BloomFilterImpl<T> : BloomFilter<T>
    {

        private ImmutableList<BloomHashFunction> hashFunctions;

        private BitArray bitArray;

        private uint vectorSize;

        public void Put(T obj)
        {
            checkHashFunctions(hashFunctions);
            foreach (BloomHashFunction hashFunction in hashFunctions)
            {
                uint result = hashFunction.Hash(obj);
                bitArray.Set((int) (result % bitArray.Count), true);
            }
        }

        // Caller must not change a hash function between Put and DoesExist calls ever
        public bool DoesExist(T obj)
        {
            return hashFunctions.TrueForAll(f => bitArray.Get((int) (f.Hash(obj) % bitArray.Count)));
        }

        public void Clear()
        {
            Resize(this.bitArray.Count);
        }

        public void Resize(int newSize)
        {
            this.bitArray = new BitArray((int) vectorSize);
        }

        public ImmutableList<BloomHashFunction> HashFunctions
        { 
            set
            {
                checkHashFunctions(value);
                this.hashFunctions = value; 
            }
        }

        public BloomFilterImpl(IList<BloomHashFunction> hashFunctions, int vectorSize = 65536)
        {
            if (vectorSize <= 0)
            {
                throw new Exception("Impossible size of underlying bitarray requested: " + vectorSize);
            }
            this.vectorSize = (uint) vectorSize;
            Resize(vectorSize);
            SetHashFunctions(hashFunctions);
        }

        public void SetHashFunctions(IList<BloomHashFunction> hashFunctions)
        {
            Clear();
            HashFunctions = hashFunctions.ToImmutableList();
        }

        private void checkHashFunctions(IList<BloomHashFunction> hashFunctions)
        {
            if (hashFunctions == null || hashFunctions.Count == 0)
            {
                throw new Exception("At least one hash function must be provided.");
            }
        }

    }
}