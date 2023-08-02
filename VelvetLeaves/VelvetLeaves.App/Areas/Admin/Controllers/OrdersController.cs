using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Common.Enums;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class OrdersController : Controller
	{

		private readonly IOrderService _orderService;
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		public async Task<IActionResult> All(int? orderStatus)
		{
			var model = await _orderService.AllAsync(orderStatus);

			return View(model);
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
