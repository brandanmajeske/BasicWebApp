using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicWebApp.Models;

namespace BasicWebApp.Controllers
{
    public class CommentController : Controller
    {
       ConferenceContext context = new ConferenceContext();

        public PartialViewResult _GetForSession(Int32 sessionID)
        {
	        ViewBag.SessionID = sessionID;

	        List<Comment> comments = context.Comments.Where(c => c.SessionID == sessionID).ToList();

	        return PartialView("_GetForSession", comments);
        }

	    [ChildActionOnly]
	    public PartialViewResult _CommentForm(Int32 sessionID)
	    {
		    Comment comment = new Comment() {SessionID = sessionID};
		    return PartialView("_CommentForm", comment);
	    }

	    [ValidateAntiForgeryToken]
	    public PartialViewResult _Submit(Comment comment)
	    {
		    context.Comments.Add(comment);
		    context.SaveChanges();

		    List<Comment> comments = context.Comments.Where(c => c.SessionID == comment.SessionID).ToList();
		    ViewBag.SessionID = comment.SessionID;

		    return PartialView("_GetForSession", comments);
	    }
	}
}