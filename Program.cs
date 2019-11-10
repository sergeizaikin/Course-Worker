using System;
using System.Collections.Generic;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Department's name: ");
            string dptName = Console.ReadLine();
            Department department = new Department(dptName);

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Worker worker1 = new Worker(name, level, salary, department);

            Console.Write("How many contracts this worker has?: ");
            int qtdContracts = int.Parse(Console.ReadLine());
            List<HourContract> contracts = new List<HourContract>();

            for (int i = 0; i < qtdContracts; i++)
            {
                Console.WriteLine($"Enter contract #{i+1} data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valPerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                contracts.Add(new HourContract(date, valPerHour, duration));
            }

            foreach (var contract in contracts)
            {
                worker1.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string[] dateIncome = Console.ReadLine().Split('/');
            int month = int.Parse(dateIncome[0]);
            int year = int.Parse(dateIncome[1]);

            Console.WriteLine($"Name: {worker1.Name}");
            Console.WriteLine($"Department: {worker1.Department.Name}");
            Console.WriteLine($"Income: {worker1.Income(year,month)}");




        }

    }
}
