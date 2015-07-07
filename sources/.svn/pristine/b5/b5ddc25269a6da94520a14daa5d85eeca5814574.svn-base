using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace MPBA.SIAC.Bll
{
    public class PropertyComparer<T> : IComparer<T>
    {
        private PropertyInfo property;
        private SortDirection sortDirection;

        public PropertyComparer(string sortProperty, SortDirection sortDirection)
        {
            property = typeof(T).GetProperty(sortProperty);
            //Utils.AssertIsNotNull(
            //   string.Format("Property {0} not found on type {1}", sortProperty,
            //                  typeof(T).FullName), sortProperty);
            this.sortDirection = sortDirection;
            
        }

        public int Compare(T x, T y)
        {
            object valueX = property.GetValue(x, null);
            object valueY = property.GetValue(y, null);

            if (sortDirection == SortDirection.Ascending)
            {
                return Comparer.Default.Compare(valueX, valueY);
            }
            else
            {
                return Comparer.Default.Compare(valueY, valueX);
            }
        }
    }

}
