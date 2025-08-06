using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggrgates.CustomerAggregate
{
    public static class CustomerQueryConditions
    {
        public static IQueryable<T> ByName<T>(this IQueryable<T> queryable, string value) where T : Customer
        {
            return queryable.Where(arg => arg.Name == value);
        }
    }
}
