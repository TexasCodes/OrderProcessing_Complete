using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderProcessing_Complete.Models;


namespace OrderProcessing_Complete.Controllers
{
    public class OrderController : ApiController
    {

        orderEntities dbConnect = new orderEntities();

        public IHttpActionResult GetOrderDetails()
        {
            var results = dbConnect.sp_OrderDetailsUpdate(0, null, "", "", "", "", "", 0, 0, 0, "", "", "Get").ToList();
            return Ok(results);

        }
        public IHttpActionResult insertOrderDetails(OrderDetail odInsert)
        {
            var insertResults = dbConnect.sp_OrderDetailsUpdate(+1, odInsert.OrderDate, odInsert.CustomerName, odInsert.CustomerAddress, odInsert.CustomerPhone, odInsert.TShirtColor, odInsert.TShirtSize, odInsert.TShirtPrice, odInsert.Quantity, odInsert.OrderTotal, odInsert.OrderStatusID, odInsert.Notes, "Insert").ToList();
            return Ok(insertResults);
        }

        public IHttpActionResult getOrderID(int id)
        {
            var orderDetails = dbConnect.sp_OrderDetailsUpdate(id, null, "", "", "", "", "", 0, 0, 0, "", "", "GetOrderID").Select(x => new orderClass()
            {
                OrderID = x.OrderID,
                OrderDate = x.OrderDate.ToString(),
                CustomerName = x.CustomerName,
                CustomerAddress = x.CustomerAddress,
                CustomerPhone = x.CustomerPhone,
                TShirtColor = x.TShirtColor,
                TShirtSize = x.TShirtSize,
                TShirtPrice = x.TShirtPrice.ToString(),
                Quantity = x.Quantity.ToString(),
                OrderTotal = Convert.ToInt32(x.OrderTotal),
                OrderStatusID = x.OrderStatusID,
                Notes = x.Notes

            }).FirstOrDefault<orderClass>();
            return Ok(orderDetails);
        }

        public IHttpActionResult Put(orderClass oc)
        {
            var updateOrderRecord = dbConnect.sp_OrderDetailsUpdate(oc.OrderID, Convert.ToDateTime(oc.OrderDate), oc.CustomerName, oc.CustomerAddress, oc.CustomerPhone, oc.TShirtColor, oc.TShirtSize, Convert.ToInt32(oc.TShirtPrice), Convert.ToInt32(oc.Quantity), oc.OrderTotal, oc.OrderStatusID, oc.Notes, "Update").ToList();
            return Ok(updateOrderRecord);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleteRecord = dbConnect.sp_OrderDetailsUpdate(id, null, "", "", "", "", "", 0, 0, 0, "", "", "Delete").Select(x => new orderClass()
            {
                OrderID = x.OrderID,
                OrderDate = x.OrderDate.ToString(),
                CustomerName = x.CustomerName,
                CustomerAddress = x.CustomerAddress,
                CustomerPhone = x.CustomerPhone,
                TShirtColor = x.TShirtColor,
                TShirtSize = x.TShirtSize,
                TShirtPrice = x.TShirtPrice.ToString(),
                Quantity = x.Quantity.ToString(),
                OrderTotal = Convert.ToInt32(x.OrderTotal),
                OrderStatusID = x.OrderStatusID,
                Notes = x.Notes
            }).FirstOrDefault<orderClass>();
            dbConnect.SaveChanges();
            return Ok();
        }

    }
}
