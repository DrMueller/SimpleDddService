using System;
using System.Linq.Expressions;

namespace SimpleDddService.Infrastructure.DomainExtensions.Invariance.Handlers
{
    internal static class ExpressionHandler
    {
        internal static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = GetMemberExpression(propertyExpression);
            var result = memberExpression.Member.Name;

            return result;
        }

        private static MemberExpression GetMemberExpression<T>(Expression<Func<T>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression result))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return result;
        }
    }
}