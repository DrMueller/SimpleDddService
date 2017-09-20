using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions
{
    // https://lostechies.com/jimmybogard/2007/06/25/generic-value-object-equality/
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as T;
            return Equals(other);
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var currentType = GetType();
            var otherType = other.GetType();

            if (currentType != otherType)
            {
                return false;
            }

            var fields = currentType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var fields = GetFields();
            const int StartValue = 17;
            const int Multiplier = 59;
            var hashCode = StartValue;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);
                if (value == null)
                {
                    continue;
                }

                var currentHash = hashCode * Multiplier;
                hashCode = currentHash + value.GetHashCode();
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var currentType = GetType();
            var fields = new List<FieldInfo>();

            while (currentType != typeof(object))
            {
                fields.AddRange(currentType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                currentType = currentType.GetTypeInfo().BaseType;
            }

            return fields;
        }
    }
}
