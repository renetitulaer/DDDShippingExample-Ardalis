using System.Linq.Expressions;
using Ardalis.Specification;

namespace Domain.SeedWork;

public abstract class CriteriaSpecification<T> : Specification<T>
    where T : class
{
    protected readonly List<Expression<Func<T, bool>>> criteriaParts = new();

    public Expression<Func<T, bool>> Criteria
    {
        get
        {

            if (!criteriaParts.Any())
                return x => true;

            var combined = criteriaParts.First();
            foreach (var part in criteriaParts.Skip(1))
            {
                combined = combined.AndAlso(part);
            }

            return combined;

        }
    }
}
