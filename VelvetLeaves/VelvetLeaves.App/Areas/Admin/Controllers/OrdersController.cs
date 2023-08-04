using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Common.Enums;
using VelvetLeaves.Services.Contracts;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = $"{AdminRoleName},${ModeratorRoleName}")]
	public class OrdersController : Controller
	{

		private readonly IOrderService _orderService;
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		public async Task<IActionResult> All(OrderStatus status = OrderStatus.Pending)
		{
			var model = await _orderService.AllAsync(status);

			return View(model);
		}

		public async Task<IActionResult> Details(string orderId)
		{
			var model = await _orderService.DetailsAsync(orderId);
			return View(model);
		}

        [HttpGet]
		public async Task<IActionResult> Process (string orderId, OrderStatus status)
        {
			await _orderService.ChangeStatusAsync(orderId, status);
			return RedirectToAction("All", "Orders", new { Area = "Admin" });
        }

        [HttpGet]
		public async Task<IActionResult> FetchOrders(OrderStatus status)
        {
			var model = await _orderService.AllAsync(status);
			return PartialView("_OrderList", model);
        }

	

	
	}
}
