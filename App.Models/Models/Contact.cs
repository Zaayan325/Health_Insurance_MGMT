using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
	public class Contact
	{
		[Key]
        public int Contact_Id { get; set; }

		[Required]
        public string Name { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }


		[Required]
		[MaxLength(50)]
		public string Subject { get; set; }

		[Required]
		[MaxLength(250)]
		public string  Message { get; set; }

        public DateTime Contact_Added { get; set; } = DateTime.Now;
    }
}
