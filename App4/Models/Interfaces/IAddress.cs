using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Models.Interfaces
{
	public interface IAddress
    {
	    string PostalCode { get; set;}
	    string Country { get; set; }
		string City { get; set; }
		string StreetAddress { get; set; }
	    string Number { get; set; }

    }
}
