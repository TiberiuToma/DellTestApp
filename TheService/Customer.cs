using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheService
{
    [DataContract]
    
    public class Customer
    {
        [DataMember]

        public string Fname { get; set; }

        [DataMember]

        public string Lname { get; set; }

        [DataMember]

        public string Email { get; set; }

    }
}
