using System;
using System.Collections.Generic;

namespace CSharp.Activity.Collections
{
    public class CustomerInfoCollection
    {
        private readonly List<CustomerInfo> infos = new();
        /// <summary>
        /// Adds the CustomerInfo object to the collection.
        /// </summary>
        /// <param name="info">Object to add.</param>
        /// <returns>The index at which the argument was added to the collection, or -1 if the object already is in the collection.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the input argument is null.</exception>
        public int Add(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (Contains(info))
            {
                return -1;
            }

            // N.B. not thread-safe
            // topic of race conditions.
            infos.Add(info);
            return infos.Count - 1;
        }

        /// <summary>
        /// Inserts the CustomerInfo object at the specified index in the collection.
        /// If the object to be inserted already is present in the collection, do nothing.
        /// </summary>
        /// <param name="index">Index at which the argument should be added.</param>
        /// <param name="info">Object to add.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the input argument is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the index at which to insert the object is less than zero.</exception>
        public void Insert(int index, CustomerInfo info)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (Contains(info))
            {
                return;
            }

            infos.Insert(index, info);
        }

        /// <summary>
        /// Removes the CustomerInfo object from the collection.
        /// </summary>
        /// <param name="info">Object to remove.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the input argument is null.</exception>
        public void Remove(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            infos.Remove(info);
        }

        /// <summary>
        /// Checks if the input CustomerInfo object exists in the collection.
        /// </summary>
        /// <param name="info">Object to check.</param>
        /// <returns>true if the input object exists in the collection, and false otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the input argument is null.</exception>
        public bool Contains(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            return infos.Contains(info);
        }

        /// <summary>
        /// Method to find the index of the input CustomerInfo object in the collection.
        /// </summary>
        /// <param name="info">Object to find.</param>
        /// <returns>The index at which the argument can be found in the collection, or -1 if it can't be found.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the input argument is null.</exception>
        public int IndexOf(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            return infos.IndexOf(info);
        }

        /// <summary>
        /// Indexer property.
        /// </summary>
        /// <param name="index">Specified index.</param>
        /// <returns>CustomerInfo object from the collection.</returns>
        public CustomerInfo this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return infos[index];
            }
            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (Contains(value))
                {
                    throw new InvalidOperationException("Value already added to collection.");
                }

                infos[index] = value;
            }
        }
    }
}
