using System;
using System.Linq;

namespace FirmsApp
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BisinessProfile { get; set; }
        public string Director { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Firm[] firms =
            {
                new Firm { Name = "White Solutions", FoundationDate = new DateTime(2005, 3, 15), BisinessProfile = "IT", Director = "Alice Black", NumberOfEmployees = 150, Address = "123 Tech St." },
                new Firm { Name = "Green Energy", FoundationDate = new DateTime(2010, 7, 22), BisinessProfile = "Renewable Energy", Director = "Bob Smith", NumberOfEmployees = 80, Address = "456 London Ave." },
                new Firm { Name = "Health Plus", FoundationDate = new DateTime(2000, 1, 10), BisinessProfile = "Healthcare Services", Director = "Carol White", NumberOfEmployees = 200, Address = "789 Health Blvd." },
                new Firm { Name = "EduWorld", FoundationDate = new DateTime(2025, 8, 5), BisinessProfile = "Marketing", Director = "David Brown", NumberOfEmployees = 50, Address = "321 Edu Rd." },
                new Firm { Name = "AutoDrive", FoundationDate = new DateTime(1998, 11, 30), BisinessProfile = "Automotive Manufacturing", Director = "Eva Green", NumberOfEmployees = 300, Address = "654 Auto Ln." },
                new Firm { Name = "Food Area", FoundationDate = new DateTime(2025, 5, 18), BisinessProfile = "Food Delivery", Director = "Frank Black", NumberOfEmployees = 120, Address = "987 London Ct." }
            };

            //1
            var allFirms = firms.Select(f => f);

            //2
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));

            //3
            var marketingFirms = firms.Where(f => f.BisinessProfile == "Marketing");

            //4
            var marketingOrIT = firms.Where(f => f.BisinessProfile == "Marketing" || f.BisinessProfile == "IT");

            //5
            var moreThan100 = firms.Where(f => f.NumberOfEmployees > 100);

            //6
            var range100to300 = firms.Where(f => f.NumberOfEmployees >= 100 && f.NumberOfEmployees <= 300);

            //7
            var londonFirms = firms.Where(f => f.Address.Contains("London"));

            //8
            var directorWhite = firms.Where(f => f.Director.Split(' ').Last() == "White");

            //9
            var olderThan2Years = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2);

            //10
            var founded123Days = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays >= 123);

            //11
            var directorBlackAndNameWhite = firms.Where(f => f.Director.Split(' ').Last() == "Black" && f.Name.Contains("White"));


            Print("All Firms:", allFirms);
            Print("Firms with 'Food' in Name:", foodFirms);
            Print("Firms in Marketing Profile:", marketingFirms);
            Print("Firms in Marketing or IT Profile:", marketingOrIT);
            Print("Firms with more than 100 Employees:", moreThan100);
            Print("Firms with 100 to 300 Employees:", range100to300);
            Print("Firms located in London:", londonFirms);
            Print("Firms with Director's last name 'White':", directorWhite);
            Print("Firms older than 2 years:", olderThan2Years);
            Print("Firms founded at least 123 days ago:", founded123Days);
            Print("Firms with Director's last name 'Black' and 'White' in Name:", directorBlackAndNameWhite);


        }
        static void Print(string title, IEnumerable<Firm> firms)
        {
            Console.WriteLine(title);
            foreach (var firm in firms)
            {
                Console.WriteLine($"Name: {firm.Name}, Foundation Date: {firm.FoundationDate.ToShortDateString()}, Business Profile: {firm.BisinessProfile}, Director: {firm.Director}, Number of Employees: {firm.NumberOfEmployees}, Address: {firm.Address}");
            }
            Console.WriteLine();
        }
    }
}