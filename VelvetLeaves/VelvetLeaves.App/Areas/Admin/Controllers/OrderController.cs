using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class OrderController : Controller
	{
		public IActionResult All()
		{
			return View();
		}

		public IActionResult Details(string orderId)
		{
			return View();
		}

		public IActionResult Complete(string orderId)
		{
			throw new NotImplementedException();
		}

		public IActionResult Decline(string orderId)
		{
			throw new NotImplementedException();
		}
	}
}
