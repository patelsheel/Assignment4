using Assignment4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreDatabase.Data;
using StoreDatabase.Entities;

namespace Assignment4MVC.Controllers
{
    public class PointOfSaleController : Controller
    {
        StoreContext _context;

        public PointOfSaleController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(int customerId)
        {
            Customer customer = await _context.Customers.FirstAsync(c => c.CustomerID == customerId);
            List<Product> products = await _context.Products.ToListAsync();

            OrderInProgress orderInProgress = new OrderInProgress
            {
                Customer = customer,
                Products = products
            };
            return View(orderInProgress);
        }


        public async Task<IActionResult> AddItem(int customerId, int orderId, int productId)
        {
            Order? order;
            if(orderId == 0)
            {
                order = new Order
                {
                    CustomerID = customerId,
                    OrderDate = DateTime.Now,

                };

                _context.Orders.Add(order);
                _context.SaveChanges();

 
            }
            else
            {
                order = await _context.Orders.Include(o => o.OrderItems) //May give a problem
                    .Where(o => o.OrderID == orderId).FirstAsync();
            }

            var product = await _context.Products.Where(p => p.ProductID == productId).FirstAsync();

            var orderItem = new OrderLineItem
            {
                OrderId = order.OrderID,
                ProductID = product.ProductID,
                Quantity = 1,
                Price = product.ProductPrice,
                Product = product
            };

            order.OrderItems.Add(orderItem);
            _context.SaveChanges();


            Customer customer = await _context.Customers.FirstAsync(c => c.CustomerID == customerId);
            List<Product> products = await _context.Products.ToListAsync();

            OrderInProgress orderInProgress = new OrderInProgress
            {
                Customer = customer,
                Products = products,
                Order = order
            };
            return View("Index", orderInProgress);
        }
    }
}