using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheService;

namespace TheServiceUnitTests
{
    [TestClass]
    public class Service1Tests
    {
        [TestMethod]
        public void AddCustomer_InsertCustomerInDb_ResultOK()
        {
            var service1 = new Service1();
            // using a new email every time
            // will always return 1
            var result = service1.AddCustomer(new Customer { Fname = "Andrew", Lname = "Steve", Email = "andrew5.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void AddCustomer_InsertCustomerInDb_ResultFail()
        {
            var service1 = new Service1();
            // using an email that already exists
            // will always fail because of the 'UNIQUE' attribute on 'email' column
            var result = service1.AddCustomer(new Customer { Fname = "Andrew", Lname = "Steve", Email = "andrew.steve@gmail.com" });

            Trace.Assert(result == 0);
        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerInDb_ResultOK()
        {
            var service1 = new Service1();
            // using an email that already exists
            // should always return 1
            var result = service1.UpdateCustomer(new Customer { Fname = "Lenka", Lname = "John", Email = "andrew2.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerInDb_ResultFail()
        {
            var service1 = new Service1();
            // using a new email every time
            // should always return 0 
            var result = service1.UpdateCustomer(new Customer { Fname = "Lenka", Lname = "Steve", Email = "andrew3.steve@gmail.com" });

            Trace.Assert(result == 0);
        }

        [TestMethod]
        public void ReturnId_GetCustomerID_ResultOK()
        {
            var service1 = new Service1();
            // if we use an email that exists we should get the value of "CustomerID" column
            var result = service1.ReturnId("andrew.steve@gmail.com");

            Trace.Assert(result == 13);
        }

        [TestMethod]
        public void ReturnId_GetCustomerID_ResultFail()
        {
            var service1 = new Service1();
            // using an email that doesn't exist will always fail
            // this function should be called only after we make sure that the customer exists
            var result = service1.ReturnId("andrew3.steve@gmail.com");

            Trace.Assert(result == 0);
        }

        [TestMethod]
        public void AlreadyExists_CheckIfCustomerExists_ResultTrue()
        {
            var service1 = new Service1();
            // if the return value is 1 (because of the restraint on the column 'email' it can only be 1 or 0)
            // it means that the email already exists
            var result = service1.AlreadyExists("andrew2.steve@gmail.com");

            Trace.Assert(result==1);
        }

        [TestMethod]
        public void AlreadyExists_CheckIfCustomerExists_ResultFalse()
        {
            var service1 = new Service1();
            // if the email already exists the return value should be 0
            // if the test is a success it means that the entered email already exists
            var result = service1.AlreadyExists("andrew3.steve@gmail.com");

            Trace.Assert(result == 0);
        }
    }
}
