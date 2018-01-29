using System;
using System.Collections.Generic;

namespace CleanCode.SwitchStatements
{
    public class MonthlyUsage
    {
        private readonly List<ICustomerType> options;
        public Customer Customer { get; set; }
        public int CallMinutes { get; set; }
        public int SmsCount { get; set; }
        public MonthlyUsage()
        {
            options = new List<ICustomerType>
            {
                new CustomerPayAsYouGo(),
                new CustomerUnlimited()
            };
        }
        public MonthlyStatement GenerateStatement()
        {
            var statement = new MonthlyStatement();
            foreach (var customerType in options)
            {
                if (customerType.IsApplicable(Customer.Type))
                    statement = customerType.GenerateStatement(CallMinutes, SmsCount);
            }
            return statement;
        }
    }

    public interface ICustomerType
    {
        bool IsApplicable(CustomerType customerType);
        MonthlyStatement GenerateStatement(Single CallMinutes, Single SmsCount);
    }

    public class CustomerPayAsYouGo : ICustomerType
    {
        public MonthlyStatement GenerateStatement(Single CallMinutes, Single SmsCount)
        {
            var statement = new MonthlyStatement
            {
                CallCost = 0.12f * CallMinutes,
                SmsCost = 0.12f * SmsCount
            };
            statement.TotalCost = statement.CallCost + statement.SmsCost;
            return statement;
        }

        public bool IsApplicable(CustomerType customerType)
        {
            return customerType == CustomerType.PayAsYouGo;
        }
    }

    public class CustomerUnlimited : ICustomerType
    {
        public MonthlyStatement GenerateStatement(Single CallMinutes, Single SmsCount)
        {
            var statement = new MonthlyStatement
            {
                TotalCost = 54.90f
            };
            return statement;
        }

        public bool IsApplicable(CustomerType customerType)
        {
            return customerType == CustomerType.Unlimited;
        }
    }
}