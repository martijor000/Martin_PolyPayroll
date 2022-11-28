using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_PolyPayroll
{
    class HourlyEmployee : Employee
    {
        private int _regularHours = 40;
        private decimal _divideHalf = 0.5M;
        private decimal _hourlywage;
        private decimal _hoursWorked;
        private decimal _earnings;

        public HourlyEmployee(string FirstName, string LastName, string SSN, decimal HourlyWage, decimal HoursWorked) : base (FirstName, LastName, SSN)
        {
            _hourlywage = HourlyWage;
            _hoursWorked = HoursWorked;
            base.Type = PayrollType.Hourly;
            base.SetPayableAmount = Earnings();
        }

        private decimal Earnings()
        {
            if (_hoursWorked <= _regularHours)
            {
                _earnings = _hoursWorked * _hourlywage;
                return _earnings;
            }
            else
            {
                _earnings = _hoursWorked * _regularHours + ((_hoursWorked - _regularHours) * ((_hourlywage * _divideHalf) + (_hourlywage)));
                return _earnings;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
            "Hourly wage Salary: " + _hourlywage.ToString("C") + "\n" +
            "Hours Worked: " + _hoursWorked + "\n" +
            "Earned: " + Earnings().ToString("C") + "\n";

        }

    }
}
