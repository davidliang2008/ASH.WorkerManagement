using ASH.WorkerManagement.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace ASH.WorkerManagement.Domain
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private FullName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public static FullName Create(string firstName, string lastName)
        {
            // Validations
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            return new FullName(firstName, lastName);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.FirstName;
            yield return this.LastName;
        }
    }
}
