using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public class GetCustomerResult
        {
            public IEnumerable<Customer> Customers { get; set; }
            public int TotalCount { get; set; }
        }

        public void DisplayCustomers()
        {
            const int pageIndex = 1;
            var result = GetCustomers(pageIndex);

            /*
             *opcion 2
             GetCustomers(pageIndex: 1);
             */

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var customer in result.Customers)
                Console.WriteLine(customer);
        }

        public GetCustomerResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomerResult { Customers = new List<Customer>(), TotalCount = totalCount };
        }
    }
}
