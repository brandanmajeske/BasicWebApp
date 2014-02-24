using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicWebApp.Models
{
	public class Speaker
	{
		public Int32 SpeakerID { get; set; }

		[Required(ErrorMessage = "{0} is required")]
		[Display(Name = "Speaker name")]
		public String Name { get; set; }

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public String EmailAddress { get; set; }

		public virtual List<Session> Sessions { get; set; } 
	}
}