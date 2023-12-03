﻿using AutoMapper.QueryableExtensions;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = _context.Items.Select(x => x.Id).ToList(),
                Employees = _context.Employees.Select(x => x.Id).ToList(),
            };

            return View(viewOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var order = new Order()
            {
                Customer = model.Customer,
                EmployeeId = model.EmployeeId,
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Orders");
        }

        public async Task<IActionResult> All()
        {
            var orders = await _context.Orders
                .Select(x=> new OrderAllViewModel()
                {
                    OrderId = x.Id,
                    Customer = x.Customer,
                    Employee = x.Employee.Name,
                    DateTime = x.DateTime.ToString()
                })
                .ToArrayAsync();

            return View(orders);
        }
    }
}