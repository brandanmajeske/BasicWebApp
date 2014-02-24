using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicWebApp.Models
{
	public class Photo
	{
		public int PhotoId { get; set; }
		public string Title { get; set; }
		
		[DisplayName("Picture")]
		public byte[] PhotoFile { get; set; }

		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		
		[DataType(DataType.DateTime)]
		[DisplayName("Created Date")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
		public DateTime CreatedDate { get; set; }
		//public string Owner { get; set; }
		//public virtual List<Comment> Comments  { get; set; }
	}
}