# Bloom filter

Bloom filter is a fast, space efficient, probabilistic set data structure that has following properties
1. Provides two methods `Put` and `Exist` which can be used for inserting elements in the set and checking if an object exists in the set.
2. The Exist method returns a boolean. It can return false positives but no false negatives. This means that, if it returns true for an object, that object may or may not exist in the set. But if it returns false, that object definitely does not exist in the set.

# How it works

It uses a bit vector for recording membership in the set. A series of hash functions are executed that return various indexes in the set to be marked.

# How to use?

This implementation can be used by providing an underlying size and a list of hash functions. For convenience, three very simple hash functions have been provided and `Program.cs` file contains a sample execution. The BloomFilter interface also has been extended to provide a couple of other convenience methods like Resize and SetHashFunctions.

To run the example run `dotnet run` in a console. Please ensure, dotnet SDK is installed.
