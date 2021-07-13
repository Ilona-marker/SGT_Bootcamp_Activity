using System;

namespace CSharp.Activity.Delegates
{
    public class Program
    {
        private static void Show(LoanApplicant applicant)
        {
            Console.WriteLine(applicant.CreditScore);
        }
        public static void Main()
        {
            LoanSystem system = new();
            system.ProcessLoanApplication(Show);
        }
    }
}
