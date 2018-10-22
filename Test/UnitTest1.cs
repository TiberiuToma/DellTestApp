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
            var result = service1.AddCustomer(new Customer { Fname = "Andrew", Lname = "Steve", Email = "andrew2.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void AddCustomer_InsertCustomerInDb_ResultFail()
        {
            var service1 = new Service1();
            //using an email that already exists
            var result = service1.AddCustomer(new Customer { Fname = "Andrew", Lname = "Steve", Email = "andrew.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerInDb_ResultOK()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.AddCustomer(new Customer { Fname = "Lenka", Lname = "Steve", Email = "andrew2.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerInDb_ResultFail()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.AddCustomer(new Customer { Fname = "Lenka", Lname = "Steve", Email = "andrew4.steve@gmail.com" });

            Trace.Assert(result == 1);
        }

        [TestMethod]
        public void ReturnId_GetCustomerID_ResultOK()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.ReturnId("andrew.steve@gmail.com");

            Trace.Assert(result == 13);
        }

        [TestMethod]
        public void ReturnId_GetCustomerID_ResultFail()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.ReturnId("andrew3.steve@gmail.com");

            Trace.Assert(result == 13);
        }

        [TestMethod]
        public void AlreadyExists_CheckIfCustomerExists_ResultTrue()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.AlreadyExists("andrew2.steve@gmail.com");

            Trace.Assert(result>0);
        }

        [TestMethod]
        public void AlreadyExists_CheckIfCustomerExists_ResultFalse()
        {
            var service1 = new Service1();
            // using a new email every time
            var result = service1.AlreadyExists("andrew3.steve@gmail.com");

            Trace.Assert(result == 0);
        }
    }
}
