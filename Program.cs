using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Martin_PolyPayroll
{
    class Program
    {
        private static List<IPayable> payables = new List<IPayable>();
        private static Random rnd = new Random();

        // Main Methods

        private static void Main(string[] args)
        {
            payables.Add(new HourlyEmployee("Jordan", "Martin", "111111111", 10.33M, 32));
            payables.Add(new HourlyEmployee("Bob", "The-Builder", "222222222", 3.20M, 4));
            payables.Add(new HourlyEmployee("Rudolph", "The-Red-Nose-Reindeer", "333333333", 2M, 3));

            payables.Add(new SalariedEmployee("Cliffard", "The-Red-Dog", "444444444", 10M));
            payables.Add(new SalariedEmployee("Dora", "The-Explorer", "555555555", 10M));
            payables.Add(new SalariedEmployee("Cookie", "Monster", "666666666", 10M));

            payables.Add(new Invoice("1234", "Cookies", 3.99M, 4));
            payables.Add(new Invoice("5678", "Milk", 2.43M, 2));
            payables.Add(new Invoice("9101", "Soda", 0.99M, 3));

            OptionsMenu();
        }

        private static void OptionsMenu()
        {
            ConsoleKeyInfo userInput;

            do
            {
                Console.WriteLine("Choose from the following options:");
                Console.WriteLine("1. Add an invoice:");
                Console.WriteLine("2. Add an hourly employee:");
                Console.WriteLine("3. Add a salary employee:");
                Console.WriteLine("4. List total Weekly payout:");

                userInput = Console.ReadKey();
                Console.WriteLine("");
                Console.Clear();
                ValidateInput(userInput);

            } while (userInput.Key != ConsoleKey.D4);
        }

        private static void ValidateInput(ConsoleKeyInfo testInput)
        {
            if (!Regex.Match(testInput.Key.ToString(), ".*[1-4].*").Success)
            {
                BadInput();
            }
            else if (testInput.Key == ConsoleKey.D1)
            {
                AddInvoice();
                PressKey();
            }
            else if (testInput.Key == ConsoleKey.D2)
            {

                AddHourly();
                PressKey();

            }
            else if (testInput.Key == ConsoleKey.D3)
            {
                AddSalary();
                PressKey();
            }
            else if (testInput.Key == ConsoleKey.D4)
            {
                DisplayArray();
                Console.WriteLine("");
                DisplayTotals();

            }
        }

        // Invoice Methods

        private static void AddInvoice()
        {
            payables.Add(new Invoice(AddInvoiceNumber(), AddInvoiceProductName(), AddInvoiceProductPrice(), AddInvoiceQuantity()));
        }

        private static string AddInvoiceNumber()
        {
            return rnd.Next(1000000) + "_" + rnd.Next(10000);
        }

        private static int AddInvoiceQuantity()
        {
            Console.WriteLine("Enter the quantity: ");
            return ParsingIntVariables(Console.ReadLine());
        }

        private static string AddInvoiceProductName()
        {
            Console.WriteLine("Enter the product name: ");
            return Console.ReadLine();
        }

        private static decimal AddInvoiceProductPrice()
        {
            Console.WriteLine("Enter the products price: ");
            return ParsingDecimalVariables(Console.ReadLine());
        }

        //Employee Methods

        private static string AddLastName()
        {
            Console.WriteLine("Enter the employees last name:");
            return Console.ReadLine();
        }

        private static string AddFirstName()
        {
            Console.WriteLine("Enter the employees first name:");
            return Console.ReadLine();
        }

        private static string AddSSN()
        {
            Console.WriteLine("Enter the employees SSN:");
            return SSN_Validator(Console.ReadLine());
        }

        //Employee Hourly Methods

        private static void AddHourly()
        {
            payables.Add(new HourlyEmployee(AddFirstName(), AddLastName(), AddSSN(), AddHourlyWage(), AddHoursWorked()));
        }

        private static decimal AddHourlyWage()
        {
            Console.WriteLine("Enter the employees hourly wage: ");
            return ParsingDecimalVariables(Console.ReadLine());
        }

        private static decimal AddHoursWorked()
        {
            Console.WriteLine("Enter employees hours worked: ");
            return ParsingDecimalVariables(Console.ReadLine());
        }

        //Employee Salary Methods

        private static void AddSalary()
        {
            payables.Add(new SalariedEmployee(AddFirstName(), AddLastName(), AddSSN(), AddWeeklySal()));
        }

        private static decimal AddWeeklySal()
        {
            Console.WriteLine("Enter employees salary: ");
            return ParsingDecimalVariables(Console.ReadLine()) / 4;
        }

        // Misc Methods

        private static string SSN_Validator(string SSN_Validate)
        {

            string SSN_Number = @"^\d{3}\-?\d{2}\-?\d{4}$";
            Regex regex = new Regex(SSN_Number);
            bool is_it_the_correct_format = regex.IsMatch(SSN_Validate);

            do
            {
                if (is_it_the_correct_format)
                {
                    return SSN_Validate;
                }
                else
                {
                    SSN_Loop();
                }

            } while (!is_it_the_correct_format);

            return SSN_Validate;
        }

        private static void SSN_Loop()
        {
            Console.WriteLine("Wrong Input or Wrong amount of numbers. Please enter SSN again.");
            SSN_Validator(Console.ReadLine());
        }

        private static void DisplayArray()
        {
            for(int i=0; i < payables.Count; i++)
            {
                if(payables[i] == null)
                {
                    break;
                }

                if(payables[i].Type == PayrollType.Salaried)
                {
                    Console.WriteLine(payables[i].ToString());
                }
                else if(payables[i].Type == PayrollType.Hourly)
                {
                    Console.WriteLine(payables[i].ToString());
                }
                else if (payables[i].Type == PayrollType.Invoice)
                {
                    Console.WriteLine(payables[i].ToString());
                }
                else
                {
                    break;
                }
            }
        }

        private static void DisplayTotals()
        {
            decimal totalweekpayout = 0;
            decimal totalinvoicepayout = 0;
            decimal totalsalarypayout = 0;
            decimal totalhourlypayout = 0;

            for (int i = 0; i < payables.Count; i++)
            {
                if (payables[i] == null)
                {
                    break;
                }

                totalweekpayout +=  payables[i].GetPayableAmount;

                if(payables[i].Type == PayrollType.Invoice)
                {
                    totalinvoicepayout += payables[i].GetPayableAmount;
                }
                else if (payables[i].Type == PayrollType.Hourly)
                {
                    totalhourlypayout += payables[i].GetPayableAmount;
                }
                else if(payables[i].Type == PayrollType.Salaried)
                {
                    totalsalarypayout += payables[i].GetPayableAmount;
                }
            }
                Console.WriteLine("Total Weekly Payout: " + totalweekpayout);
                Console.WriteLine("Category Breakdown:");
                Console.WriteLine("Invoices: " + totalinvoicepayout);
                Console.WriteLine("Salaried Payroll: " + totalsalarypayout);
                Console.WriteLine("Hourly Payroll: " + totalhourlypayout);   
        }

        private static ConsoleKeyInfo BadInput()
        {
            Console.WriteLine("Bad input please enter one of the following digits.");
            OptionsMenu();
            return Console.ReadKey();
        }

        private static void PressKey()
        {
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Console.Clear();
        }

        private static decimal ParsingDecimalVariables(string testDecimal)
        {
            bool diddecimalwork = decimal.TryParse(testDecimal, out decimal decWorked);

            if (diddecimalwork)
            {
                return decWorked;
            }
            else
            {
                ParseDecimalFailed();
            }

            return decWorked;
        }

        private static void ParseDecimalFailed()
        {
                Console.WriteLine("Bad input. Please enter a numbers only.");
                ParsingDecimalVariables(Console.ReadLine());
                Console.Clear();
        }

        private static int ParsingIntVariables(string stringInt)
        {
            bool didIntWork = int.TryParse(stringInt, out int intWorked);

            if (didIntWork)
            {
                return intWorked;
            }
            else
            {
                ParseIntFailed();
            }

            return intWorked;
        }

        private static void ParseIntFailed()
        {
            Console.WriteLine("Bad input. Please enter a numbers only.");
            ParsingIntVariables(Console.ReadLine());
            Console.Clear();
        }
    }
}
 