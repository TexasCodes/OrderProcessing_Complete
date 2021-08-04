using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderProcessing_Complete.Models;
using System.Net.Http;

namespace OrderProcessing_Complete.Controllers
{
    public class VerbsController : Controller
    {
        // GET: Verbs
        public ActionResult Index()
        {
            IEnumerable<OrderDetail> orderobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/Order");

            var consumeApi = hc.GetAsync("Order");
            consumeApi.Wait();

            var readData = consumeApi.Result;
            if (readData.IsSuccessStatusCode)
            {

                var displayData = readData.Content.ReadAsAsync<IList<OrderDetail>>();
                displayData.Wait();
                orderobj = displayData.Result;

            }
            return View(orderobj);
        
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetail orderInsert)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/");
            var insertRecord = hc.PostAsJsonAsync<OrderDetail>("Order", orderInsert);
            insertRecord.Wait();
            var saveRecord = insertRecord.Result;
            if (saveRecord.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            orderClass orderobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/Order");

            var consumeApi = hc.GetAsync("Order?id=" + id.ToString());
            consumeApi.Wait();

            var readData = consumeApi.Result;
            if (readData.IsSuccessStatusCode)
            {
                var displayOrderDetails = readData.Content.ReadAsAsync<orderClass>();
                displayOrderDetails.Wait();
                orderobj = displayOrderDetails.Result;
            }

            return View(orderobj);
        }

        public ActionResult Edit(int id)
        {
            orderClass orderobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/Order");

            var consumeApi = hc.GetAsync("Order?id=" + id.ToString());
            consumeApi.Wait();

            var readData = consumeApi.Result;
            if (readData.IsSuccessStatusCode)
            {
                var displayOrderDetails = readData.Content.ReadAsAsync<orderClass>();
                displayOrderDetails.Wait();
                orderobj = displayOrderDetails.Result;
            }

            return View(orderobj);
        }

        [HttpPost]
        public ActionResult Edit(orderClass oc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/Order");

            var updateRecord = hc.PutAsJsonAsync<orderClass>("Order", oc);
            updateRecord.Wait();

            var saveData = updateRecord.Result;
            if (saveData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(oc);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:58004/api/Order");

            var deleteRecord = hc.DeleteAsync("Order/" + id.ToString());
            deleteRecord.Wait();

            var saveData = deleteRecord.Result;
            if (saveData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}