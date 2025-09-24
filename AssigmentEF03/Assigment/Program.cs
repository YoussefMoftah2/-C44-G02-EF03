using Assigment.Models;
using testAss.DatabaseContext;

namespace Assigment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q02
            using (var context = new AirlineDbContext())
            {
                // a. Insert a new airline
                var egyptAir = new Airline
                {
                    Name = "EgyptAir",
                    ContactPerson = "Ahmed Ali",
                    Phones = "0123456789, 0113654789",
                    Address = "Cairo"
                };
                context.Airlines.Add(egyptAir);
                context.SaveChanges();

                // b. Add a new aircraft for EgyptAir
                var aircraft = new AirCraft
                {
                    Model = "Model01",
                    Capacity = 180,
                    AirlineId = egyptAir.Id
                };
                context.AirCrafts.Add(aircraft);
                context.SaveChanges();

                // c. Record a new transaction for EgyptAir
                var transaction = new Transaction
                {
                    Description = "Tickets",
                    Amount = 50000,
                    Date = DateTime.Now,
                    AirlineId = egyptAir.Id
                };
                context.Transactions.Add(transaction);
                context.SaveChanges();

                // d. Select all employees who work in EgyptAir
                var employees = context.Employees
                    .Where(e => e.AirlineId == egyptAir.Id)
                    .ToList();

                Console.WriteLine("Employees in EgyptAir:");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Name} - {emp.Position}");
                }

                // e. Show all transactions recorded by EgyptAir
                var transactions = context.Transactions
                    .Where(t => t.AirlineId == egyptAir.Id)
                    .Select(t => new { t.Id, t.Description, t.Amount })
                    .ToList();

                Console.WriteLine("Transactions of EgyptAir:");
                foreach (var tr in transactions)
                {
                    Console.WriteLine($"{tr.Id} - {tr.Description} - {tr.Amount}");
                }

                // f. Get the total number of employees working in each airline
                var employeeCounts = context.Employees
                    .GroupBy(e => e.Airline.Name)
                    .Select(g => new { AirlineName = g.Key, EmployeeCount = g.Count() })
                    .ToList();

                Console.WriteLine("Employee count per Airline:");
                foreach (var ec in employeeCounts)
                {
                    Console.WriteLine($"{ec.AirlineName} : {ec.EmployeeCount}");
                }

                // g. Change the capacity of the “Model01” aircraft to 200
                var model01 = context.AirCrafts.FirstOrDefault(a => a.Model == "Model01");
                if (model01 != null)
                {
                    model01.Capacity = 200;
                    context.SaveChanges();
                    Console.WriteLine("Updated Model01 capacity to 200.");
                }

                // h. Delete all transactions older than 2020
                var oldTransactions = context.Transactions
                    .Where(t => t.Date.Year < 2020)
                    .ToList();

                context.Transactions.RemoveRange(oldTransactions);
                context.SaveChanges();

                Console.WriteLine("Deleted all transactions older than 2020.");
            } 
            #endregion
        }
    }
}
