using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChallengeAPI.Models;

namespace ChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly challengeContext _context;

        public OrdersController(challengeContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("Total/{orderdate}/{custid}/{prodid}")]
        public async Task<ActionResult<List<Order?>>> GetTotalOrderValue(DateTime orderdate, string custid, string prodid)
        {

            try
            {
                var orderList = await _context.Orders.FindAsync(orderdate, custid, prodid);
                double totalCost;
                if (orderList.ProdId == "FUR-BO-10001798") 
                {
                    totalCost = orderList.Quantity * 261.96;
                }
                else if(orderList.ProdId == "FUR-CH-10000454") 
                {
                    totalCost = orderList.Quantity * 731.94;
                }
                else
                {
                    totalCost = orderList.Quantity * 14.62;
                }
                

                // int sum = 0;
                // int Qty = 0;
                // for (int i = 0; i < orderList.Count; i++)
                // {
                //     sum = Qty += orderList[i].Quantity;
                // }
                return Ok( new {totalCost} );
            }
        catch (Exception ex)
            {

                return StatusCode(500, ex.ToString());
            }

        }

        [HttpGet("GST/{orderdate}/{custid}/{prodid}")]
        public async Task<ActionResult<List<Order?>>> GetOrderGST(DateTime orderdate, string custid, string prodid)
        {

            try
            {
                var orderList = await _context.Orders.FindAsync(orderdate, custid, prodid);
                double totalGST;
                double payableGST;
                if (orderList.ProdId == "FUR-BO-10001798") 
                {
                    totalGST = (orderList.Quantity * 261.96) * 1.1;
                    payableGST = totalGST/11;
                }
                else if(orderList.ProdId == "FUR-CH-10000454") 
                {
                    totalGST = (orderList.Quantity * 731.94) * 1.1;
                    payableGST = totalGST/11;
                }
                else
                {
                    totalGST = (orderList.Quantity * 14.62) * 1.1;
                    payableGST = totalGST/11;
                }
                

                // int sum = 0;
                // int Qty = 0;
                // for (int i = 0; i < orderList.Count; i++)
                // {
                //     sum = Qty += orderList[i].Quantity;
                // }
                return Ok( new {totalGST, payableGST} );
            }
        catch (Exception ex)
            {

                return StatusCode(500, ex.ToString());
            }

        }



        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order request)
        {
            var dbOrder = await _context.Orders.FindAsync(request.OrderDate, request.CustId, request.ProdId );
            if (dbOrder == null)
                return BadRequest("Treatment not found.");

            dbOrder.Quantity = request.Quantity;
            dbOrder.ShipDate = request.ShipDate;
            dbOrder.ShipMode = request.ShipMode;


            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }


        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }

        // DELETE: api/Orders/5
        [HttpDelete("{orderdate}/{custid}/{prodid}")]
        public async Task<IActionResult> DeleteOrder(DateTime orderdate, string custid, string prodid)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(orderdate, custid, prodid);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }

        private bool OrderExists(DateTime id)
        {
            return (_context.Orders?.Any(e => e.OrderDate == id)).GetValueOrDefault();
        }
    }
}
