using System;
using System.Linq.Expressions;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance.Handlers;

namespace SimpleDddService.Infrastructure.DomainExtensions.Invariance
{
    public static class Guard
    {
        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj != null)
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            throw new ArgumentException($"Object {propertyName} must not be null.");
        }

        public static void StringNotNullorEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (!string.IsNullOrEmpty(stringValue))
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            throw new ArgumentException($"String {propertyName} must not be null or empty.");
        }
    }
}