﻿using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public class ComboComparer : IComparer<Employee>
    {
        public ComboComparer(IComparer<Employee> firstComparer, IComparer<Employee> secondComparer)
        {
            FirstComparer = firstComparer;
            SecondComparer = secondComparer;
        }

        public IComparer<Employee> FirstComparer { get; private set; }
        public IComparer<Employee> SecondComparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firstResult = FirstComparer.Compare(x, y);
            if (firstResult != 0)
            {
                return firstResult;
            }

            return SecondComparer.Compare(x, y);
        }
    }
}