using System;
using System.Linq.Expressions;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;
using SimpleDddService.Infrastructure.DomainExtensions.Specifications.Handlers;

namespace SimpleDddService.Infrastructure.DomainExtensions.Specifications.Implementation
{
    public class OrSpecification<T> : SpecificationBase<T>
        where T : AggregateRoot
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public OrSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}