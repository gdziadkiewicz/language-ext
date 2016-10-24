﻿using LanguageExt.TypeClasses;
using static LanguageExt.TypeClass;

namespace LanguageExt.Instances
{
    /// <summary>
    /// Equality and ordering
    /// </summary>
    public struct OrdArray<ORD, A> : Ord<A[]>
        where ORD : struct, Ord<A>
    {
        public static readonly OrdArray<ORD, A> Inst = default(OrdArray<ORD, A>);

        /// <summary>
        /// Equality test
        /// </summary>
        /// <param name="x">The left hand side of the equality operation</param>
        /// <param name="y">The right hand side of the equality operation</param>
        /// <returns>True if x and y are equal</returns>
        public bool Equals(A[] x, A[] y) =>
            default(EqArray<ORD, A>).Equals(x, y);

        /// <summary>
        /// Compare two values
        /// </summary>
        /// <param name="x">Left hand side of the compare operation</param>
        /// <param name="y">Right hand side of the compare operation</param>
        /// <returns>
        /// if x greater than y : 1
        /// if x less than y    : -1
        /// if x equals y       : 0
        /// </returns>
        public int Compare(A[] mx, A[] my)
        {
            if (ReferenceEquals(mx, my)) return 0;
            if (ReferenceEquals(mx, null)) return -1;
            if (ReferenceEquals(my, null)) return 1;

            var cmp = mx.Length.CompareTo(my.Length);
            if (cmp == 0)
            {
                for(var i = 0; i < mx.Length; i++)
                {
                    cmp = default(ORD).Compare(mx[i], my[i]);
                    if (cmp != 0) return cmp;
                }
                return 0;
            }
            else
            {
                return cmp;
            }
        }
    }
}
