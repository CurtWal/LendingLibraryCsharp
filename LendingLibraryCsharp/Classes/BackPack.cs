using LendingLibraryCsharp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibraryCsharp.Classes
{
    //create a backpact list class
    internal class BackPack<T> : IBag<T>
    {
        //create a list for object of stuff
        private readonly List<T> stuff = new List<T>();

        public void Pack (T item)
        {
            //add an item to our backpack
            stuff.Add(item);
        }

        public T Unpack(int index)
        {// find the thing we want to unpack in our list object
            T thing = stuff[index];
            //remove item by index
            stuff.RemoveAt(index);
            //return what was unpacked
            return thing;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T thing in stuff)
                yield return thing;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
