using ASH.WorkerManagement.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace ASH.WorkerManagement.Domain
{
    public class PayRate : ValueObject
    {
        public PayPeriod PayPeriod { get; private set; }

        public double Amount { get; private set; }

        private PayRate(PayPeriod period, double amount)
        {
            this.PayPeriod = period;
            this.Amount = amount;
        }

        public static PayRate CreateAnnualSalary(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentNullException(nameof(amount));
            }

            return new PayRate(PayPeriod.Yearly, amount);
        }

        public static PayRate CreateHourlyPay(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentNullException(nameof(amount));
            }

            return new PayRate(PayPeriod.Hourly, amount);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.PayPeriod;
            yield return this.Amount;
        }
    }
}
