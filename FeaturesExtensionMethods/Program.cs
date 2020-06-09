using System;
using System.Collections.Generic;
using System.Linq;

namespace FeaturesExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new List<Employee>()
            { 
                new Employee() {Id = 1, Name = "mahmoud"},
                new Employee() {Id = 2, Name = "youssef"}
            };

            foreach (var developer in developers)
                Console.WriteLine(developer.Name);

            Console.WriteLine(developers.Count()); // Count ExtensionMethod
            // Named Method
            var mDevelopers = developers.Where(StartsWithM);
            // Annonymous Method
            mDevelopers = developers.Where(delegate (Employee employee) 
                {
                    return employee.Name.StartsWith("m");
                });
            // Lambda Expression
            mDevelopers = developers.Where(e => e.Name.StartsWith("m"));
            // Func 
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3, 5)));
        }

        private static bool StartsWithM(Employee employee)
        {
            return employee.Name.StartsWith("m");
        }
    }
}
