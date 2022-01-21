using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Bit.Domain.Utils
{
    public class ListUtils
    {
        public static IEnumerable<T> OrderByCustom<T>(IEnumerable<T> data,string orderBy, string sort) {
            
            return data.AsQueryable().OrderBy($"{orderBy} {sort}").ToList();
        }
    }
}
