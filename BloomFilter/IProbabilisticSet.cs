using System;

namespace Bloom
{
    // An abstract set data type exposing Put and Get where false positive for membership check is acceptable 
    public interface IProbabilisticSet<T>
    {
        // Put an object to the set
        void Put(T obj);

        // Check membership
        bool DoesExist(T obj);
    }
}