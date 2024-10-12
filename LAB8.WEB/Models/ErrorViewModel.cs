using LAB8.DATA.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LAB8.WEB.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    }
    //public class Template
    //{
    //    public class PeopleController : Controller
    //    {

    //        //public IActionResult Template()
    //        //{
    //        //    var lstCar = new List<Car>();
    //        //    var lstLaptop = new List<Laptop>();
    //        //    var lstPeople = new List<People>();
    //        //    using (var https = new HttpClient())
    //        //    {

    //        //        using (var respon = await https.GetAsync("https://localhost:7087/api/Cars"))
    //        //        {
    //        //            var apiRespon = await respon.Content.ReadAsStringAsync();
    //        //            lstCar = JsonConvert.DeserializeObject<List<Car>>(apiRespon);
    //        //        }
    //        //        TempData["lstCar"] = JsonConvert.SerializeObject(lstCar);

    //        //        // lấy danh sách Laptop

    //        //        using (var respon = await https.GetAsync("https://localhost:7087/api/Laptops"))
    //        //        {
    //        //            var apiRespon = await respon.Content.ReadAsStringAsync();
    //        //            lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(apiRespon);
    //        //        }
    //        //        TempData["lstLaptop"] = JsonConvert.SerializeObject(lstLaptop);


    //        //        //lấy danh sách người dùng

    //        //        using (var respon = await https.GetAsync("https://localhost:7087/api/People"))
    //        //        {
    //        //            var apiRespon = await respon.Content.ReadAsStringAsync();
    //        //            lstPeople = JsonConvert.DeserializeObject<List<People>>(apiRespon);
    //        //        }
    //        //    }
    //        //}
    //        // GET: People
    //        public async Task<IActionResult> Index()
    //        {
    //            // lấy danh sách Car
    //            var lstCar = new List<Car>();
    //            var lstLaptop = new List<Laptop>();
    //            var lstPeople = new List<People>();
    //            using (var https = new HttpClient())
    //            {

    //                using (var respon = await https.GetAsync("https://localhost:7087/api/People"))
    //                {
    //                    var apiRespon = await respon.Content.ReadAsStringAsync();
    //                    lstPeople = JsonConvert.DeserializeObject<List<People>>(apiRespon);
    //                }
    //            }
    //            return View(lstPeople);
    //        }

    //        // GET: People/Details/5
    //        public async Task<IActionResult> Details(int? id)
    //        {
    //            People DetailP = new People();
    //            using (var https = new HttpClient())
    //            {

    //                using (var respon = await https.GetAsync($"https://localhost:7087/api/People/{id}"))
    //                {
    //                    var apiRespon = await respon.Content.ReadAsStringAsync();
    //                    DetailP = JsonConvert.DeserializeObject<People>(apiRespon);
    //                }
    //            }
    //            return View(DetailP);
    //        }

    //        // GET: People/Create
    //        public async Task<IActionResult> Create()
    //        {
    //            var lstCar = new List<Car>();
    //            var lstLaptop = new List<Laptop>();
    //            var lstPeople = new List<People>();
    //            using (var https = new HttpClient())
    //            {

    //                using (var respon = await https.GetAsync("https://localhost:7087/api/Cars"))
    //                {
    //                    var apiRespon = await respon.Content.ReadAsStringAsync();
    //                    lstCar = JsonConvert.DeserializeObject<List<Car>>(apiRespon);
    //                }
    //                TempData["lstCar"] = JsonConvert.SerializeObject(lstCar);

    //                // lấy danh sách Laptop

    //                using (var respon = await https.GetAsync("https://localhost:7087/api/Laptops"))
    //                {
    //                    var apiRespon = await respon.Content.ReadAsStringAsync();
    //                    lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(apiRespon);
    //                }
    //                TempData["lstLaptop"] = JsonConvert.SerializeObject(lstLaptop);


    //                //lấy danh sách người dùng

    //                using (var respon = await https.GetAsync("https://localhost:7087/api/People"))
    //                {
    //                    var apiRespon = await respon.Content.ReadAsStringAsync();
    //                    lstPeople = JsonConvert.DeserializeObject<List<People>>(apiRespon);
    //                }

    //            }
    //            ViewData["IdCar"] = new SelectList(lstCar, "Id", "Name");
    //            ViewData["IdLaptop"] = new SelectList(lstLaptop, "Id", "Name");
    //            return View();
    //        }

    //        // POST: People/Create
    //        // To protect from overposting attacks, enable the specific properties you want to bind to.
    //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<IActionResult> Create(People people)
    //        {
    //            List<Car> lstCar = JsonConvert.DeserializeObject<List<Car>>(TempData["IdCar"]?.ToString() ?? "[]");
    //            List<Laptop> lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(TempData["IdLatop"]?.ToString() ?? "[]");
    //            People NewPeople = new People();
    //            using (var https = new HttpClient())
    //            {
    //                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(people),
    //                    Encoding.UTF8, "application/json");
    //                using (var respon = await https.PostAsync("https://localhost:7087/api/People", stringContent))
    //                {
    //                    if (respon.StatusCode == System.Net.HttpStatusCode.OK)
    //                    {
    //                        var apiRespon = await respon.Content.ReadAsStringAsync();
    //                        NewPeople = JsonConvert.DeserializeObject<People>(apiRespon);
    //                    }
    //                    else
    //                    {
    //                        ViewBag.Error = respon.StatusCode;
    //                    }
    //                }
    //            }
    //            ViewData["IdCar"] = new SelectList(lstCar, "Id", "Name", people.IdCar);
    //            ViewData["IdLaptop"] = new SelectList(lstLaptop, "Id", "Name", people.IdLaptop);
    //            return RedirectToAction("Index");
    //        }

    //    }
    //}
}

