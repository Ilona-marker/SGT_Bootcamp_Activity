using System;

namespace CSharp.Activity.Datastore
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {
        public ArrayStore() { }

        public ArrayStore(int arraySize) : base(arraySize) { }

        /// <summary>
        /// Adds the object 'argToAdd' to the end of the structure
        /// on the condition that the structure isn’t full.
        ///
        /// If T is reference type, trying to add a null object to
        /// the structure should throw an ArgumentNullException.
        /// </summary>
        /// <param name="argToAdd">Object to add to end of the structure.</param>
        /// <returns>index if the add is successful, or NOT_IN_STRUCTURE if the conditions for adding are not met.</returns>
        public override int Add(T argToAdd)
        {
            if (!typeof(T).IsValueType && argToAdd == null)
            {
                throw new ArgumentNullException(nameof(argToAdd));
            }

            if (IsFull())
            {
                return NOT_IN_STRUCTURE; // -1
            }

            int i = Count++;
            this[i] = argToAdd;
            return i;
        }

        /// <summary>
        /// This inserts the object argToInsert at the specified index.
        /// 
        /// As with Add(T argToAdd) method, the structure must not be full.
        /// 
        /// Trying to add a null object should throw an ArgumentNullException,
        /// or if inserting with an invalid index (outside range [0..Count))
        /// then should throw an ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argToInsert">Object to insert.</param>
        /// <param name="indexToInsert">Specified index to insert at.</param>
        /// <returns>index if the insert is successful, and NOT_IN_STRUCTURE if the conditions for insertion are not met.</returns>
        public override int Insert(T argToInsert, int indexToInsert)
        {
            if (argToInsert == null)
            {
                throw new ArgumentNullException(nameof(argToInsert));
            }

            if (indexToInsert < 0 || indexToInsert >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(indexToInsert));
            }

            if (IsFull())
            {
                return NOT_IN_STRUCTURE; // -1
            }

            Count++;

            for (int i = Count - 1; i > indexToInsert; i--)
            {
                this[i] = this[i - 1];
            }

            this[indexToInsert] = argToInsert;
            return indexToInsert;
        }

        /// <summary>
        /// Removes the object that is equal to argToRemove from the structure.
        /// 
        /// Make sure to compress the data inside so that there are no holes
        /// in the array after a successful remove. (You can make use of the
        /// existing base class method IndexOf() and/or the overrided method
        /// RemoveAt()).
        /// 
        /// Throw an InvalidOperationException if removal is not possible.
        /// Throw an ArgumentNullException if a null is passed and T is
        /// a reference type.
        /// </summary>
        /// <param name="argToRemove">Object to remove.</param>
        public override void Remove(T argToRemove)
        {
            if (argToRemove == null)
            {
                throw new ArgumentNullException(nameof(argToRemove));
            }

            int indexToRemove = IndexOf(argToRemove);

            if (indexToRemove == NOT_IN_STRUCTURE)
            {
                throw new InvalidOperationException("Object was not found in the structure.");
            }

            RemoveAt(indexToRemove);
        }

        /// <summary>
        /// Removes the object at the specified index.
        /// 
        /// Make sure to compress the array so that no holes remain in
        /// the structure.
        /// 
        /// If the index is out of range [0..Count) the method should
        /// throw an ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="removeObjectIndex">Specified index to remove at.</param>
        public override void RemoveAt(int removeObjectIndex)
        {
            if (removeObjectIndex < 0 || removeObjectIndex >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(removeObjectIndex));
            }

            for (int i = removeObjectIndex + 1; i < Count; i++)
            {
                this[i - 1] = this[i];
            }

            // free up what was the last spot in the array, for later GC.
            this[--Count] = default;
        }

        public override T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Invalid Index");

                return base[index];
            }
            protected set
            {
                base[index] = value;
            }
        }
    }
}
