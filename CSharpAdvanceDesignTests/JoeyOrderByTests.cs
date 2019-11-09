﻿using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyOrderByTests
    {
        //        [Test]
        //        public void orderBy_lastName()
        //        {
        //            var employees = new[]
        //            {
        //                new Employee {FirstName = "Joey", LastName = "Wang"},
        //                new Employee {FirstName = "Tom", LastName = "Li"},
        //                new Employee {FirstName = "Joseph", LastName = "Chen"},
        //                new Employee {FirstName = "Joey", LastName = "Chen"},
        //            };
        //
        //            var actual = JoeyOrderByLastName(employees);
        //
        //            var expected = new[]
        //            {
        //                new Employee {FirstName = "Joseph", LastName = "Chen"},
        //                new Employee {FirstName = "Joey", LastName = "Chen"},
        //                new Employee {FirstName = "Tom", LastName = "Li"},
        //                new Employee {FirstName = "Joey", LastName = "Wang"},
        //            };
        //
        //            expected.ToExpectedObject().ShouldMatch(actual);
        //        }

        [Test]
        public void orderBy_lastName_and_firstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var firstComparer = new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default);
            var secondComparer = new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default);

            var actual = employees.JoeyOrderByComboComparer(new ComboComparer(firstComparer, secondComparer));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_firstName_Age()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
            };

            //var firstKeyComparer =
            //    new CombineKeyComparer<string>(element => element.LastName, Comparer<string>.Default);
            //var lastKeyComparer =
            //    new CombineKeyComparer<string>(element => element.FirstName, Comparer<string>.Default);

            //var untilNowComparer = new ComboComparer(firstKeyComparer, lastKeyComparer);

            //var lastComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);

            //var comboComparer = new ComboComparer(untilNowComparer, lastComparer);

            var actual = employees.JoeyOrderBy(e => e.LastName)
                .JoeyThenBy(e => e.FirstName)
                .JoeyThenBy(e => e.Age);

            //var actual = employees.JoeyOrderByComboComparer(comboComparer);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }



        private IEnumerable<Employee> JoeyOrderByLastName(IEnumerable<Employee> employees)
        {
            //bubble sort
            var stringComparer = Comparer<string>.Default;
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (stringComparer.Compare(elements[i].LastName, minElement.LastName) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}