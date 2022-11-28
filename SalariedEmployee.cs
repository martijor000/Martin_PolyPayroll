using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_PolyPayroll
{
    class SalariedEmployee : Employee
    {
        private decimal _weeklySalary;

        public SalariedEmployee(string FirstName, string LastName, string ssn, decimal WeeklySalary) : base(FirstName, LastName, ssn)
        {
            _weeklySalary = WeeklySalary;
            base.Type = PayrollType.Salaried;
            base.SetPayableAmount =+ _weeklySalary;
        }

        public override string ToString()
        {
            return base.ToString() +
            "Weekly Salary: " + _weeklySalary.ToString("C") + " " + "Earned: " + base.GetPayableAmount.ToString("C") + "\n";

        }
    }
}
