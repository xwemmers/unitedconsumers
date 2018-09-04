using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examenvragen
{
    [DataContract(Namespace = "http://www.united.nl")]
    class Person
    {

        [DataMember]
        public string Lastname { get; set; }

        [DataMember(Order = 0)]
        public string Firstname { get; set; }
    }
}
