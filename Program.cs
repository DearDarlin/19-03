using System;
using System.Linq;

namespace FirmsApp
{
    

    public class Employee
    {
        public string FullName { get; set; }     
        public string Position { get; set; }     
        public string Phone { get; set; }        
        public string Email { get; set; }        
        public decimal Salary { get; set; }      
    }

    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BisinessProfile { get; set; }
        public string Director { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

    }

    class Program
    {
        static void Main(string[] args)
        {
            Firm[] firms =
            {
                new Firm { Name = "White Solutions", FoundationDate = new DateTime(2005, 3, 15), BisinessProfile = "IT", Director = "Alice Black", NumberOfEmployees = 3, Address = "123 Tech St.", 
                    Employees = new List<Employee>
                    {
                        new Employee { FullName="Lionel Messi", Position="Manager", Phone="231234567", Email="lionel@gmail.com", Salary=3000 },
                        new Employee { FullName="Cristiano Ronaldo", Position="Developer", Phone="441234567", Email="cr7@gmail.com", Salary=5000 },
                        new Employee { FullName="John Smith", Position="Analyst", Phone="239876543", Email="john@gmail.com", Salary=2500 }
                    } },

                 new Firm
                {
                    Name="ITGlobal", FoundationDate=new DateTime(2018,7,10), BisinessProfile="IT", Director="Sarah Green", NumberOfEmployees=2, Address="London, Oxford Street",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName="Lionel Richie", Position="Designer", Phone="221234567", Email="di.richie@itglobal.com", Salary=2800 },
                        new Employee { FullName="David Black", Position="Manager", Phone="239999999", Email="david@itglobal.com", Salary=4000 }
                    }
                }

            };

            //1
            var employees = firms
                .Where(f => f.Name == "White Solutions")
                .SelectMany(f => f.Employees);

            //2
            var highSalary = firms
                .Where(f => f.Name == "ITGlobal")
                .SelectMany(f => f.Employees)
                .Where(e => e.Salary > 3000);

            //3
            var managers = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Position == "Manager");

            //4
            var phone23 = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Phone.StartsWith("23"));

            //5
            var emailDi = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Email.StartsWith("di"));

            //6
            var lionels = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.FullName.Split(' ')[0] == "Lionel");

            Print("Employees of White Solutions:", employees);
            Print("Employees of ITGlobal with salary > 3000:", highSalary);
            Print("All Managers:", managers);
            Print("Employees with phone starting with '23':", phone23);
            Print("Employees with email starting with 'di':", emailDi);
            Print("Employees named Lionel:", lionels);

        }

        static void Print(string title, IEnumerable<Employee> employees)
        {
            Console.WriteLine(title);
            foreach (var e in employees)
            {
                Console.WriteLine($"Name: {e.FullName}, Position: {e.Position}, Phone: {e.Phone}, Email: {e.Email}, Salary: {e.Salary}");
            }
            Console.WriteLine();
        }
    }
}