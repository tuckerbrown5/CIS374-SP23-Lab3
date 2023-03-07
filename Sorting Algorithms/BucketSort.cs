using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A bucket sort implementation.
    /// </summary>
    public class BucketSort : ISortableInt
    {
        /// <summary>
        /// Sort given integers using bucket sort with merge sort as sub sort.
        /// </summary>
        public int[] Sort(int[] array)
        {
            int bucketSize = array.Length;

            if (bucketSize < 0 || bucketSize > array.Length)
            {
                throw new Exception("Invalid bucket size.");
            }

            var buckets = new Dictionary<int, List<int>>();

            int i;
            for (i = 0; i < array.Length; i++)
            {
                if (bucketSize == 0)
                {
                    continue;
                }

                var bucketIndex = array[i] / bucketSize;

                if (!buckets.ContainsKey(bucketIndex))
                {
                    buckets.Add(bucketIndex, new List<int>());
                }

                buckets[bucketIndex].Add(array[i]);
            }

            i = 0;
            var bucketKeys = new int[buckets.Count];
            foreach (var bucket in buckets.ToList())
            {
                var bucketsArray = Sort(bucket.Value.ToArray());
                buckets[bucket.Key] = new List<int>(bucketsArray.AsEnumerable());

                bucketKeys[i] = bucket.Key;
                i++;
            }

            bucketKeys = Sort(bucketKeys);

            var result = new int[array.Length];

            i = 0;
            foreach (var bucketKey in bucketKeys)
            {
                var bucket = buckets[bucketKey];
                Array.Copy(bucket.ToArray(), 0, result, i, bucket.Count);
                i += bucket.Count;
            }

            return result;
        }
    }

}
