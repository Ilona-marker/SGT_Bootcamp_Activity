using System;

namespace CSharp.Activity.Collections
{
    public class CustomerInfo
    {
        // Property to get or set the customer ID
        public int ID { get; protected set; }

        // Property to get or set the customer name.
        public string Name { get; protected set; }

        // Property to get or set the customer adress.
        public string Address { get; protected set; }

        // Property to get or set the email address of the customer.
        public string Email { get; protected set; }

        // Constructor to initialize the member variables.
        public CustomerInfo(int id, string name, string address, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            ID = id;
            Name = name;
            Address = address;
            Email = email;
        }
    }

}


