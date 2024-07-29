using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS8714

namespace Challenges
{
    public interface IMultiValueDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        /// <summary>
        /// Adds a value to either existing key or creates a new key and adds the value to it if the key value pair does not already exist
        /// </summary>
        /// <param name="key">Key to add value to</param>
        /// <param name="value">Value to add</param>
        /// <returns>true if the underlying collection has changed; false otherwise</returns>
        bool Add(K key, V value);

        /// <summary>
        /// Returns a sequence of values for the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> Get(K key);

        /// <summary>
        /// Returns a sequence of values for the given key. returns empty sequence if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> GetOrDefault(K key);

        /// <summary>
        /// Removes the value from the values associated with the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key which values need to be adjusted</param>
        /// <param name="value">value to remove from the values for the given key</param>
        void Remove(K key, V value);

        /// <summary>
        /// Removes the given key from the dictionary with all the values associated with it
        /// </summary>
        /// <param name="key">key to remove from the dictionary</param>
        void Clear(K key);

        /// <summary>
        /// Returns a sequence of items of KeyValuePair<K, V> type, flattening the internal collection.
        /// </summary>
        ///
        /// <example>
        /// var creatures = new MultiValueDictionary<string, string>();
        /// creatures.Add("birds", "eagle");
        /// creatures.Add("birds", "dove");
        /// creatures.Add("animals", "tiger");
        ///
        /// foreach (KeyValuePair<string, string> pair in creatures.Flatten()) {
        ///     Console.WriteLine($"<{pair.Key}, {pair.Value}>");
        /// }
        ///
        /// This will print 3 pairs:
        /// <birds, eagle>
        /// <birds, dove>
        /// <animals, tiger>
        ///
        /// </example>
        /// <references>
        /// KeyValuePair<TKey, TValue>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=netframework-4.7.2
        /// IEnumerable<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netframework-4.7.2
        /// </references>
        IEnumerable<KeyValuePair<K, V>> Flatten();
    }

    public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>
    {
        public Dictionary<K, HashSet<V>> MyCollection = new Dictionary<K, HashSet<V>>();

        public bool Add(K key, V value)
        {
            bool flag = false;
            if (!MyCollection.ContainsKey(key))
            {
                MyCollection.Add(key, new HashSet<V>() { value });
                flag = true;
            }
            else if (!MyCollection[key].Contains(value))
            {
                MyCollection[key].Add(value);
                flag = true;
            }
            return flag;
        }

        public IEnumerable<V> Get(K key)
        {
            return MyCollection[key].Select(i => i);
        }

        public IEnumerable<V> GetOrDefault(K key)
        {
            IEnumerable<V> result = null;
            if (MyCollection.TryGetValue(key, out var set))
            {
                return set.Select(i => i);
            }
            else {
                return Enumerable.Empty<V>();
            }
            try
            {
                result = MyCollection[key];
            }
            catch (KeyNotFoundException)
            {
                result = Enumerable.Empty<V>();
            }
            return result;
        }

        public void Remove(K key, V value)
        {
            MyCollection[key].Remove(value);
        }

        public void Clear(K key)
        {
            MyCollection.Remove(key);
        }
        public IEnumerable<KeyValuePair<K, V>> Flatten() => throw new NotImplementedException();

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }









    /*********************************************************************************************************
      *
      * Main Program / Test Cases
      *
      **********************************************************************************************************/

    public class MultiValueDictionaryTests
    {
        private IMultiValueDictionary<string, string> items;

        public void Run()
        {
            InvokeTest(Add_NewKeyNewItem_True);
            InvokeTest(Add_SameKeyDifferentItems_True);
            InvokeTest(Add_SameKeySameItem_False);

            InvokeTest(Remove_ExistingKeyExistingItem);
            InvokeTest(Remove_ExistingKeyNonexistingItem);
            InvokeTest(Remove_NonexistingKeyExistingItem_ThrowsKeyNotFoundException);
            InvokeTest(Remove_NonexistingKeyNonxistingItem_ThrowsKeyNotFoundException);

            InvokeTest(Get_OneKeyOneValue);
            InvokeTest(Get_OneKeyTwoValues);
            InvokeTest(Get_TwoKeysTwoValues);
            InvokeTest(Get_NonexistingKey_ThrowsKeyNotFoundException);

            InvokeTest(GetOrDefault_OneKeyOneValue);
            InvokeTest(GetOrDefault_OneKeyTwoValues);
            InvokeTest(GetOrDefault_TwoKeysTwoValues);
            InvokeTest(GetOrDefault_NonexistingKey);

            InvokeTest(Clear_ExistingKey);
            InvokeTest(Clear_NonexistingKey);

            InvokeTest(Flatten_OneKeyOneValue);
            InvokeTest(Flatten_TwoKeysTwoValues);

            InvokeTest(GetEnumerator_OneKeyOneValue);
            InvokeTest(GetEnumerator_TwoKeysTwoValues);
            InvokeTest(GetEnumeratorNonGeneric_TwoKeysTwoValues);
        }

        private void Add_NewKeyNewItem_True()
        {
            Assert(items.Add("animals", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Add_SameKeyDifferentItems_True()
        {
            Assert(items.Add("animals", "tiger"));
            Assert(items.Add("animals", "lion"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 2);
            Assert(result.Contains("tiger"));
            Assert(result.Contains("lion"));
        }

        private void Add_SameKeySameItem_False()
        {
            Assert(items.Add("animals", "tiger"));
            Assert(!items.Add("animals", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_ExistingKeyExistingItem()
        {
            items.Add("animals", "tiger");
            items.Remove("animals", "tiger");

            var result = items.GetOrDefault("animals").ToList();

            Assert(result.Count == 0);
        }

        private void Remove_ExistingKeyNonexistingItem()
        {
            items.Add("animals", "tiger");
            items.Remove("animals", "lion");

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_NonexistingKeyExistingItem_ThrowsKeyNotFoundException()
        {
            items.Add("animals", "tiger");
            AssertFails<KeyNotFoundException>(
                () => items.Remove("fish", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_NonexistingKeyNonxistingItem_ThrowsKeyNotFoundException()
        {
            items.Add("animals", "tiger");
            AssertFails<KeyNotFoundException>(
                () => items.Remove("fish", "shark"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Get_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 1);
            Assert(values[0] == "tiger");
        }

        private void Get_OneKeyTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));
        }

        private void Get_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));

            values = items.Get("birds").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "eagle"));
            Assert(values.Any(i => i == "dove"));
        }

        private void Get_NonexistingKey_ThrowsKeyNotFoundException()
        {
            AssertFails<KeyNotFoundException>(
                () => items.Get("animals"));
        }

        private void GetOrDefault_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 1);
            Assert(values[0] == "tiger");
        }

        private void GetOrDefault_OneKeyTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));
        }

        private void GetOrDefault_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));

            values = items.GetOrDefault("birds").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "eagle"));
            Assert(values.Any(i => i == "dove"));
        }

        private void GetOrDefault_NonexistingKey()
        {
            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 0);
        }

        private void Clear_ExistingKey()
        {
            items.Add("animals", "tiger");
            items.Clear("animals");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 0);
        }

        private void Clear_NonexistingKey()
        {
            items.Add("animals", "tiger");
            items.Clear("fish");

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Flatten_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var result = items.Flatten().ToList();

            Assert(result.Count == 1);
            Assert(result[0].Key == "animals");
            Assert(result[0].Value == "tiger");
        }

        private void Flatten_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = items.Flatten().ToList();

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }

        private void GetEnumerator_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in items)
                result.Add(item);

            Assert(result.Count == 1);
            Assert(result[0].Key == "animals");
            Assert(result[0].Value == "tiger");
        }

        private void GetEnumerator_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in items)
                result.Add(item);

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }

        private void GetEnumeratorNonGeneric_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in (IEnumerable)items)
                result.Add((KeyValuePair<string, string>)item);

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }



        // helpers

        private void InvokeTest(Action test)
        {
            items = new MultiValueDictionary<string, string>();
            var testName = test.Method.Name;

            try
            {
                test();
                Console.WriteLine($"> {testName}: OK");
            }
            catch (Exception e)
            {
                if (e is AggregateException)
                    e = e.InnerException;
                Console.WriteLine($"> {testName}: FAILED ({e.Message})");
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void Assert(bool result)
        {
            if (!result)
                throw new Exception("Assertion failed.");
        }

        private static void AssertFails<TException>(Action action)
            where TException : Exception
        {
            AssertFails(action, typeof(TException));
        }

        private static void AssertFails(Action action, Type exceptionType)
        {
            try
            {
                action();
                throw new Exception($"Assertion failed: {exceptionType} wasn't thrown.");
            }
            catch (Exception e)
            {
                Assert(exceptionType.IsInstanceOfType(e));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new MultiValueDictionaryTests().Run();
        }
    }

}