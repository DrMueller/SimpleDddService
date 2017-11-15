using System;
using System.Linq.Expressions;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance.Handlers;

namespace SimpleDddService.Infrastructure.DomainExtensions.Invariance
{
    public static class Guard
    {
        public const string NullObjectExceptionMessage = "Object {0} must not be null.";
        public const string StringNullOrEmptyExceptionMessage = "String {0} must not be null or empty.";

        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj != null)
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(NullObjectExceptionMessage, propertyName);
            throw new ArgumentException(exceptionMessage);
        }

        public static void StringNotNullOrEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (!string.IsNullOrEmpty(stringValue))
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(StringNullOrEmptyExceptionMessage, propertyName);
            throw new ArgumentException(exceptionMessage);
        }
    }
}