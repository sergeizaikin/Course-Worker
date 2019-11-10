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
            //Department data
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter department's name: ");
            string dptName = Console.ReadLine();
            Department department = new Department(dptName);

            //Worker's data
            Console.WriteLine("Enter worker's data: ");
            Console.ResetColor();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Worker worker1 = new Worker(name, level, salary, department);
            Console.WriteLine();

            //Contracts data
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("How many contracts this worker has?: ");
            Console.ResetColor();
            int qtdContracts = int.Parse(Console.ReadLine());
            List<HourContract> contracts = new List<HourContract>();

            for (int i = 0; i < qtdContracts; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Enter contract #{i+1} data:");
                Console.ResetColor();
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valPerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();
                worker1.AddContract(new HourContract(date, valPerHour, duration));
                
            }

            //Test output
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            Console.ResetColor();

            //string[] dateIncome = Console.ReadLine().Split('/');
            //int month = int.Parse(dateIncome[0]);
            //int year = int.Parse(dateIncome[1]);

            string dateIncome = Console.ReadLine();
            int month = int.Parse(dateIncome.Substring(0, 2));
            int year = int.Parse(dateIncome.Substring(3, 4));

            Console.WriteLine($"Name: {worker1.Name}");
            Console.WriteLine($"Department: {worker1.Department.Name}");
            Console.WriteLine($"Income for {dateIncome}: {worker1.Income(year,month)}");

        }

    }
}
