using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_PolyPayroll
{
    interface IPayable
    {
        public decimal GetPayableAmount { get; }

        public PayrollType Type { get; set; }
    }

    public enum PayrollType
    {
        Salaried,
        Hourly,
        Invoice
    }
}
