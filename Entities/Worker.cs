using Course.Entities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker() { }

        public Worker(string workerName, WorkerLevel level, double baseSalary, Department department)
        {
            Name = workerName;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double incomeSum = BaseSalary;
            foreach (var contract in Contracts.Where(x => x.Date.Month == month && x.Date.Year == year))
            {
                incomeSum += contract.TotalValue();
            }

            return incomeSum;
        }
    }
}
