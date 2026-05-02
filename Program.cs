using System;

// ================= SRP =================

// 1. Data Class
class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
}

// 2. Salary Calculation
class SalaryCalculator
{
    public double CalculateSalary(Employee emp)
    {
        return emp.Salary;
    }
}

// 3. Database Operation
class EmployeeRepository
{
    public void Save(Employee emp)
    {
        Console.WriteLine("Saving employee to database...");
    }
}

// 4. Reporting
class ReportGenerator
{
    public void Generate(Employee emp)
    {
        Console.WriteLine("Generating employee report...");
    }
}

// ================= OCP =================

// Payment Interface
interface IPayment
{
    void Pay(double amount);
}

// UPI Payment
class UpiPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using UPI");
    }
}

// Card Payment
class CardPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using Card");
    }
}

// Wallet Payment (New feature without modifying existing code)
class WalletPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using Wallet");
    }
}

// ================= MAIN EXECUTION =================

class Program
{
    static void Main(string[] args)
    {
        // -------- SRP Execution --------
        Console.WriteLine("===== SRP EXECUTION =====");

        Employee emp = new Employee
        {
            Name = "Haritha",
            Salary = 30000
        };

        SalaryCalculator calculator = new SalaryCalculator();
        EmployeeRepository repository = new EmployeeRepository();
        ReportGenerator report = new ReportGenerator();

        Console.WriteLine("Employee Name: " + emp.Name);
        Console.WriteLine("Salary: " + calculator.CalculateSalary(emp));
        repository.Save(emp);
        report.Generate(emp);

        Console.WriteLine();

        // -------- OCP Execution --------
        Console.WriteLine("===== OCP EXECUTION =====");

        IPayment payment;

        payment = new UpiPayment();
        payment.Pay(500);

        payment = new CardPayment();
        payment.Pay(1000);

        payment = new WalletPayment(); // New extension
        payment.Pay(300);

        Console.ReadLine(); // keeps console open
    }
}
