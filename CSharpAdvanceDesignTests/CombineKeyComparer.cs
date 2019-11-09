using System;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer<TKey> : IComparer<Employee>
    {
        public CombineKeyComparer(Func<Employee, TKey> keySelector, IComparer<TKey> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        private Func<Employee, TKey> KeySelector { get; set; }
        private IComparer<TKey> KeyComparer { get; set; }

        public int Compare(Employee x, Employee y)
        {
            var compare = KeyComparer.Compare(KeySelector(x), KeySelector(y));
            return compare;
        }
    }
}