﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.ValueObjects
{
    public abstract class BaseValueObject<T> : IEquatable<T>
    {
        bool IEquatable<T>.Equals(T other)
        {
            return this.Equals(other);
        }

        public override bool Equals(object obj)
        {
            return obj != null
                && obj is T
                && this.AnyProperyEquals((T)obj);
        }

        private bool AnyProperyEquals(T other)
        {
            bool hasSameValues = true;
            foreach (var prop in this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var propThis = prop.GetValue(this);
                var propOther = prop.GetValue(other);

                if (propThis != null)
                {
                    if (!propThis.Equals(propOther))
                    {
                        hasSameValues = false;
                        break;
                    }
                }
                else if (propOther != null)
                {
                    hasSameValues = false;
                    break;
                }
            }

            return hasSameValues || base.Equals(other);
        }

        public override int GetHashCode()
        {
            int hashCode = 1; const int multiplier = 1;
            foreach (var prop in this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var val = prop.GetValue(this);
                if (val != null)
                {
                    hashCode = hashCode * multiplier ^ val.GetHashCode();
                }
            }

            return hashCode;
        }
    }
}