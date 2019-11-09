﻿using Lab.Entities;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public static class MyOwnLinq
    {
        public static IEnumerable<Employee> JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Employee> JoeyThenBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Employee> JoeyOrderByComboComparer(this IEnumerable<Employee> employees,
            IComparer<Employee> comparer)
        {
            //            return MyComparerBuilder.Sort(employees, comparer);
            return new MyComparerBuilder(employees, comparer);
        }
    }
}