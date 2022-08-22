using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Models;
using System.Net.Http;



namespace EntityFramework.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<mvcCustomerModel> CustomerList;
            HttpResponseMessage respone = GlobalVariable.WebApiClient.GetAsync("Customer").Result;
            CustomerList = respone.Content.ReadAsAsync<IEnumerable<mvcCustomerModel>>().Result;
            return View(CustomerList);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if(id == 0)
            return View(new mvcCustomerModel());

            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Customer/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCustomerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcCustomerModel cust)
        {
            if (cust.CustomerID == 0)
            {


                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Customer", cust).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Customer/"+cust.CustomerID, cust).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
                return RedirectToAction("Index");
            
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Customer/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}