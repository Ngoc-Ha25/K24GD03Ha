using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Lab10
{



    internal class Program
    {
        public class Customer
        {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            List<Customer> MyCustomerList = new List<Customer>
            {
        new Customer {CustomerID = "ALFKI", ContactName = "Maria", City = "HCM"},
        new Customer {CustomerID = "ANATR", ContactName = "Ana", City = "HN"},
        new Customer {CustomerID = "ANTON", ContactName = "Antonio", City = "HN"}
             };
            var query = from c in MyCustomerList
                        where c.City == "HN"
                        select new { c.City, c.ContactName };
            foreach (var c in query)
                Console.WriteLine($"{c.ContactName} - {c.City}");




            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var sortedNumbers = list.OrderBy(n => n);
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }




            List<int> list2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var groupedNumbers = list.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");

            foreach (var group in groupedNumbers)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var num in group)
                {
                    Console.WriteLine(num);
                }
                
            }


            List<int> list3 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<Person> people = GenerateListOfPeople();
            var companies = GenerateCompanies();
            var peoplewithCompanies
                =people.Join(companies, person => person.CompanyId, conpany => conpany.Id,
                                        (person, company) =>
                                        new {person.FirstName, company.Name});
            var peoplewithCompaniesQuery = from p in people
                                           join c in companies on p.CompanyId equals c.Id
                                           select new {p.FirstName, c.Name};



            IEnumerable<string> allFirstNames = people.Select(x => x.FirstName);
            foreach (var p in allFirstNames) Console.WriteLine(p);
            bool thereArePeople = people.Any();
            bool anyDevsOver30 = people.Any(x => x.Occupation == "Dev" && x.Age > 30);
            var Lab10 = people.Where(p => p.Occupation == "Dev" && p.Age > 25)
                .OrderBy(p => p.FirstName)
                .Select(p => $"{p.FirstName} {p.LastName}")
                .ToList();

            Console.WriteLine("\nDev co kinh nghiem sap xep theo ten");
            foreach (var name in Lab10)
            {
                Console.WriteLine($"- {name}");
            }


            var 

            Console.ReadLine();
        }

              public class Person
                {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Occupation { get; set; }


            public int Age { get; set; }
            public int CompanyId { get; set; }
                }


        public static List<Person> GenerateListOfPeople()
        {
            var people = new List<Person>();
            people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1, });
            people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 });
            people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 });
            people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 });
            people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 });
            return people;

            
        }
        
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static List<Company> GenerateCompanies()
        {
            return new List<Company> {
                new Company { Id = 1, Name = "Microsoft" },
                new Company { Id = 2, Name = "Google" },
                new Company { Id = 3, Name = "Apple" }
            };
        }
    }
}




           