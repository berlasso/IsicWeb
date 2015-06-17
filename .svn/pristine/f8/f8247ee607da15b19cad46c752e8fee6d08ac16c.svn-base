using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capturer
{
    // busco un elemento en un arreglo multidimendional, devuelve la fila donde esta el elemento
    public static class ArrayHelper
    {
        public static int FindInDimensions(object[,] target,
          object searchTerm)
        {
           int  result = -1;
            var rowLowerLimit = target.GetLowerBound(0);
            var rowUpperLimit = target.GetUpperBound(0);

            var colLowerLimit = target.GetLowerBound(1);
            var colUpperLimit = target.GetUpperBound(1);

            for (int row = rowLowerLimit; row <= rowUpperLimit; row++)
            {
                for (int col = colLowerLimit; col <= colUpperLimit; col++)
                {
                    if (target[row,col].Equals(searchTerm))
                    {
                        result = row;
                    }

                }
            }

            return result;
        }
    }
}
