using ASH.WorkerManagement.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace ASH.WorkerManagement.Domain
{
    public class Address : ValueObject
    {
        public string AddressLine1 { get; private set; }

        // Could be extended with following properties

        //public string AddressLine2 { get; private set; }
        //public string City { get; private set; }
        //public string State { get; private set; }
        //public string PostalCode { get; private set; }

        private Address(string addressLine1)
        {
            this.AddressLine1 = addressLine1;
        }

        public static Address Create(string addressLine1)
        {
            // Validations
            if (String.IsNullOrWhiteSpace(addressLine1))
            {
                throw new ArgumentNullException(nameof(addressLine1));
            }

            return Address.Create(addressLine1.Trim());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.AddressLine1;
        }
    }
}
