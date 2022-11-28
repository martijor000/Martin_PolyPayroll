using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_PolyPayroll
{
    class Invoice: IPayable
    {

        private decimal _price;
        private int _quantity;
        private string _partNumber;
        private string _partDescription;    
        private decimal _totalAmount;
        private PayrollType _payrollType;

        public Invoice(string partNumber, string partDescription, decimal price, int quantity)
        {
            _partNumber = partNumber;
            _quantity = quantity;
            _partDescription = partDescription;
            _price = price;
            _totalAmount = _quantity * _price;
            _payrollType = PayrollType.Invoice;
        }

        public decimal GetPayableAmount
        {
            get => _totalAmount;
        }

        public PayrollType Type
        {
            set { _payrollType = value; }
            get { return _payrollType; }
        }

        public override string ToString()
        {
            return "Invoice: " + _partNumber + "\n"
                + "Quantity: " + _quantity + "\n"
                + "Part Description: " + _partDescription + "\n"
                + "Unit Price: " + _price.ToString("C") + "\n"
                + "Extended Price: " + _totalAmount.ToString("C") + "\n";
            
        }
    }
}
