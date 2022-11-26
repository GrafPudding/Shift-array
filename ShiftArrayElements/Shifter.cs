using System;

namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        source = ShifLeft(source);
                    }
                }
                else if (i % 2 != 0)
                {
                    for (int k = 0; k < iterations[i]; k++)
                    {
                        source = ShiftRight(source);
                    }
                }
            }

            return source;
        }

        public static int[] ShifLeft(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                result[i] = array[i + 1];
            }

            result[result.Length - 1] = array[0];
            return result;
        }

        public static int[] ShiftRight(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int[] result = new int[array.Length];

            for (int i = 1; i < array.Length; i++)
            {
                result[i] = array[i - 1];
            }

            result[0] = array[result.Length - 1];
            return result;
        }
    }
}
