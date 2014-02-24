using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace BasicWebApp.Models
{
	public class ConferenceContextInitializer : DropCreateDatabaseAlways<ConferenceContext>
	{
		protected override void Seed(ConferenceContext context)
		{
			context.Sessions.Add(new Session()
			{
				Title = "I want spaghetti", 
				Abstract = "The life and times of a spaghetti lover",
				Speaker = context.Speakers.Add(
					new Speaker()
					{
						Name = "Jon Galloway",
						EmailAddress = "jong@gmail.com"
					})
			});
			//base.Seed(context);
			context.SaveChanges();
		}
	}
}