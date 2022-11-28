using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_PolyPayroll
{
    class Employee : IPayable
    {
        private string _firstName;
        private string _ssn;
        private string _lastName;
        private decimal _payableAmount;
        private PayrollType _payrollType;

        public Employee(string firstName, string lastName, string ssn)
        {
            _firstName = firstName;
            _ssn = ssn;
            _lastName = lastName;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string SSN
        {
            get { return _ssn; }
        }

        public decimal GetPayableAmount
        {
            get { return _payableAmount; }
        }

        public decimal SetPayableAmount
        {
            set { _payableAmount = value; }
        }

        public override string ToString()
        {
            return _payrollType + " employee: " + _firstName + " " + _lastName + "\n" +
            "SSN: " + (_ssn).Insert(5, "-").Insert(3, "-") + "\n";
        }

        public PayrollType Type
        {
            set { _payrollType = value; }
            get { return _payrollType; }
        }
    }
}
