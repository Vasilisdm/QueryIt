﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());


            using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
            {
                AddEmployees(employeeRepository);
                AddManager(employeeRepository);
                CountEmployess(employeeRepository);
                QueryEmployees(employeeRepository);
                DumpPeople(employeeRepository);
            }
        }

        private static void AddManager(IWriteOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "VSD" });
            employeeRepository.Commit();
        }

        private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine(employee.Name);
            Console.ReadKey();
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Vassilis" });
            employeeRepository.Add(new Employee { Name = "George" });
            employeeRepository.Add(new Employee { Name = "Costas" });
            employeeRepository.Commit();
        }


        private static void CountEmployess(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
            Console.ReadKey();
        }

    }
}
