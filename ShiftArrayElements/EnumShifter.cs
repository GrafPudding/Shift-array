using System;

namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions == null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            for (int i = 0; i < directions.Length; i++)
            {                
                switch (directions[i])
                {
                    case Direction.Left:
                        source = ShifLeft(source);
                        break;

                    case Direction.Right:
                        source = ShiftRight(source);
                        break;

                    default:
                        throw new InvalidOperationException($"Incorrect {directions} enum value.");
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
