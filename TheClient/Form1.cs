using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheClient.ServiceReference1;

namespace TheClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new customer object and populate it with values
            Customer c = new Customer();
            
            c.Fname = textBox1.Text;
            c.Lname = textBox2.Text;
            c.Email = textBox3.Text;

            // Creating the service client
            Service1Client service = new Service1Client();

            // Check if the entered email already exists in the database
            int count_email = service.AlreadyExists(c.Email);
            if (count_email == 0)
            {
                // If the email doesn't exist in the DB then add the customer
                if (service.AddCustomer(c) == 1)
                {
                    // If the customer was added with succes to the DB then return the generated ID
                    int id = service.ReturnId(c.Email);
                    richTextBox1.Text = "The customer was succesfully added and the CustomerID is : " + id;
                }
                else
                {
                    richTextBox1.Text = "Error when trying to add user";
                }
            }
            else
            {
                // If the email already exists in the DB then only update the other fields
                service.UpdateCustomer(c);
                int id = service.ReturnId(c.Email);
                richTextBox1.Text = "The customer e-mail address already exists. The customer details were updated for customer ID : "+id;
            }
        }
    }
}
