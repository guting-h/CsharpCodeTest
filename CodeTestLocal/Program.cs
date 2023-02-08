using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeTestLocal
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("[1] Read data from file");
            Console.WriteLine("[2] Enter new inputs");
            
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Please enter the name of the file you want to read: ");
                string file = Console.ReadLine();
                string Path = @"../../" + file;

                while (!File.Exists(Path))
                {
                    Console.WriteLine("Please verify that the entered name is correct and that the file is located in the root folder of the project.");
                    file = Console.ReadLine();
                    Path = @"../../" + file;
                }

                StreamReader reader =
                       new StreamReader(
                       new FileStream(Path, FileMode.Open, FileAccess.Read));

                reader.ReadLine();

                try
                {
                    int counter = 1;

                    while (reader.Peek() != 0 && reader.Peek() != '.')
                    {
                        //Note that the decimal separator must be '.'
                        string row = reader.ReadLine();
                        string[] customers = InputConverter.ConvertInput(row);

                        // check that the read line is not empty
                        if (customers.Length == 4)
                        {
                            string name = customers[0];
                            double loan = Convert.ToDouble(customers[1]);
                            double nYears = Convert.ToDouble(customers[3]);
                            double interest = Convert.ToDouble(customers[2]);
                            double amount = Mortgage.monthlyPay(loan, nYears, interest);

                            Console.WriteLine($"prospect {counter}: {name} wants to borrow {loan} Euro for a period of {nYears} years and pay {amount} Euro each month.");
                            counter++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    reader.Close();
                }
            } else if (option == "2")
            {
                try
                {
                    Console.WriteLine("Customer name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Total loan (Euro): ");
                    double loan = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Number of years: ");
                    double nYears = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Interest rate (e.g. 6% yearly => enter '6'): ");
                    double interest = Convert.ToDouble(Console.ReadLine());
                
                    double amount = Mortgage.monthlyPay(loan, nYears, interest);

                    Console.WriteLine($"{name} wants to borrow {loan} Eurofor a period of {nYears} years and pay {amount} Euro each month.");
                } catch(Exception ex)
                {
                    Console.WriteLine("Please check your inputs.");
                    Console.WriteLine("- Inputs must not be negative.");
                    Console.WriteLine("- Total loan, number of years, and interest must be numbers");
                }
                
            } else
            {
                Console.WriteLine("Unknown option.");
                Console.WriteLine("Have a nice day!");
            }
        }

    }
}
