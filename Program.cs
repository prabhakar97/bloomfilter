using System;
using System.Collections.Generic;
using Bloom;

namespace BloomFilterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<BloomHashFunction> bloomHashFunctions = new List<BloomHashFunction>();
            bloomHashFunctions.Add(new SimpleBloomHashFunction());
            bloomHashFunctions.Add(new SummationBloomHashFunction());
            bloomHashFunctions.Add(new StringBloomHashFunction());

            BloomFilter<string> bloomFilter = new BloomFilterImpl<string>(bloomHashFunctions);
            bloomFilter.Put("Java");
            Console.WriteLine(bloomFilter.DoesExist("C++"));
            bloomFilter.Put("C#");
            bloomFilter.Put("Ruby");
            bloomFilter.Put("Erlang");
            bloomFilter.Put("Elixir");
            Console.WriteLine(bloomFilter.DoesExist("C#"));
            Console.WriteLine(bloomFilter.DoesExist("ASP.NET"));
            Console.WriteLine(bloomFilter.DoesExist("Rust"));
        }
    }
}
