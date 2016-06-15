/* Problem 5. Generic class (Done) */
/* Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
 * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
 * Implement methods for adding element, accessing element by index, removing element by index,
 * inserting element at given position, clearing the list, finding element by its value and ToString().
 * Check all input parameters to avoid accessing elements at invalid positions. */

/* Problem 6. Auto-grow (Done) */
/* Implement auto-grow functionality: when the internal array is full, create a new array 
 * of double size and move all elements to it. */

/* Problem 7. Min and Max (Done) */
/* Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal
 * element in the GenericList<T>.
 * You may need to add a generic constraints for the type T. */

namespace DefiningClassesHomework2
{
    using System;

    public class TestGenericList
    {
        private static void Main(string[] args)
        {
            var intcho = new GenericList<int>();
            Console.WriteLine(intcho.Count);
            intcho.Add(5, 8, 23, 1, 45, 45, 46, 56, 1, 10, 78);
            Console.WriteLine(intcho.Count);
            intcho[11] = 2394;
            intcho[12] = 194;

            intcho.Add(90, 100, 101, 102);
            Console.WriteLine(intcho.Count);

            // intcho.Clear();

            intcho.Add(new int[] { 1, 2, 3 });
            intcho.RemoveAt(19);
            intcho.InsertAt(19, 23);
                        
            for (int i = 0; i < intcho.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i, intcho[i]);
            }

            Console.WriteLine();
            Console.WriteLine(intcho.Min());
            Console.WriteLine(intcho.Max());

            Console.WriteLine(intcho.IndexOf(1));

            Console.WriteLine(intcho);
        }
    }
}
