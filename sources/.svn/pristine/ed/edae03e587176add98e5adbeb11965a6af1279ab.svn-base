using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SIACGral.Models;
using System.ComponentModel.DataAnnotations;

namespace SIACGral.Models
{
    [MetadataType(typeof(SeniasParticularesMetadata))]
    public partial class SeniasParticulares{

        internal sealed class SeniasParticularesMetadata
        {
            private SeniasParticularesMetadata()
            { }
            public enum SortDirection { Ascending, Descending }
            public void Sort<TKey>(ref List<SeniasParticulares> list,
                                   Func<SeniasParticulares, TKey> sorter, SortDirection direction)
            {
                if (direction == SortDirection.Ascending)
                    list = (List<SeniasParticulares>) list.OrderBy(sorter);
                else
                    list = (List<SeniasParticulares>) list.OrderByDescending(sorter);
            }

        }
        
    }

    }



