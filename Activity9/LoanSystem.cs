using System;

namespace CSharp.Activity.Delegates
{
    public class LoanSystem
    {
        private static readonly Random RANDOM = new();
        //                                         delegate           callback
        public void ProcessLoanApplication(Action<LoanApplicant> showApplicant)
        {
            LoanApplicant applicant = new();

            // For the scope of this activity, generate a random number
            // between 1 and 100 and use it as the credit score.
            // (Use class System.Random.)

            applicant.CreditScore = RANDOM.Next(100);

            showApplicant?.Invoke(applicant);

        }

    }
}
