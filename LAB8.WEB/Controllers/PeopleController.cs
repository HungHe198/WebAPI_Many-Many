using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB8.DATA.Models;
using Newtonsoft.Json;
using System.Text;

namespace LAB8.WEB.Controllers
{
    public class PeopleController : Controller
    {

        // GET: People
        public async Task<IActionResult> Index()
        {
            var lstPeople = new List<People>();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync("https://localhost:7087/api/People"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstPeople = JsonConvert.DeserializeObject<List<People>>(apiRespon);
                }
            }
            return View(lstPeople);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            People DetailP = new People();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/People/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<People>(apiRespon);
                }
            }
            return View(DetailP);
        }

        // GET: People/Create
        public async Task<IActionResult> Create()
        {
            var lstCar = new List<Car>();
            var lstLaptop = new List<Laptop>();
            var lstPeople = new List<People>();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync("https://localhost:7087/api/Cars"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstCar = JsonConvert.DeserializeObject<List<Car>>(apiRespon);
                }


                // lấy danh sách Laptop

                using (var respon = await https.GetAsync("https://localhost:7087/api/Laptops"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(apiRespon);
                }



                //lấy danh sách người dùng

                using (var respon = await https.GetAsync("https://localhost:7087/api/People"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstPeople = JsonConvert.DeserializeObject<List<People>>(apiRespon);
                }

            }
            TempData["lstCar"] = JsonConvert.SerializeObject(lstCar);
            TempData["lstLaptop"] = JsonConvert.SerializeObject(lstLaptop);

            //ViewData["IdCar"] = new SelectList(lstCar, "Id", "Name");
            //ViewData["IdLaptop"] = new SelectList(lstLaptop, "Id", "Name");
            ViewData["IdCar"] = lstCar;
            ViewData["IdLaptop"] = lstLaptop;
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Phone,MoTa,IdCar,IdLaptop")] People people)
        {
            List<Car> lstCar = JsonConvert.DeserializeObject<List<Car>>(TempData["IdCar"]?.ToString() ?? "[]");
            List<Laptop> lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(TempData["IdLatop"]?.ToString() ?? "[]");
            People NewPeople = new People();
            using (var https = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(people),
                    Encoding.UTF8, "application/json");
                using (var respon = await https.PostAsync("https://localhost:7087/api/People", stringContent))
                {
                    if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apiRespon = await respon.Content.ReadAsStringAsync();
                        NewPeople = JsonConvert.DeserializeObject<People>(apiRespon);
                    }
                    else
                    {
                        ViewBag.Error = respon.StatusCode;
                    }
                }
                int IdP = people.ID;

                //foreach (var item in people.IdCar)
                //{
                //    Car updateCar = lstCar.FirstOrDefault(x => x.Id == item);
                //    if (updateCar != null)
                //    {
                //        updateCar.IdPeople.Add(IdP);
                //        StringContent stringContent_UC = new StringContent(JsonConvert.SerializeObject(updateCar),
                //        Encoding.UTF8, "application/json");
                //        using (var respon = await https.PutAsync($"https://localhost:7087/api/Cars/{item}", stringContent_UC))
                //        {
                //            // Kiểm tra nếu phản hồi từ API là thành công
                //            if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                //            {
                //                // Lấy nội dung phản hồi từ API
                //                var apirespon = await respon.Content.ReadAsStringAsync();
                //                Car updatedEmployee = JsonConvert.DeserializeObject<Car>(apirespon);

                //                // Điều hướng lại trang Index sau khi cập nhật thành công
                //                return RedirectToAction("Index");
                //            }
                //            else
                //            {
                //                // Ghi lại lỗi nếu việc cập nhật thất bại
                //                ViewBag.ErrorMessage = $"Update failed: {respon.StatusCode}";
                //            }
                //        }

                //    }

                //}
                // cập nhật dữ liệu vào bảng Car

                // thêm dữ liệu vào bảng phụ 1 - n Car_P

                //int IdP = people.ID;
                //foreach (var item in people.IdCar)
                //{
                //    Car_People newCP = new Car_People() { CarId = item, PeopleId = IdP};
                //    StringContent stringContent2 = new StringContent(JsonConvert.SerializeObject(newCP),
                //    Encoding.UTF8, "application/json");
                //    using (var respon = await https.PostAsync("https://localhost:7087/api/Car_People", stringContent))
                //    {
                //        if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                //        {
                //            var apiRespon = await respon.Content.ReadAsStringAsync();
                //            newCP = JsonConvert.DeserializeObject<Car_People>(apiRespon);
                //        }
                //        else
                //        {
                //            ViewBag.Error = respon.StatusCode;
                //        }
                //    }
                //}
                // thêm dữ liệu vào bảng phụ 1 - n Lap_P
                //foreach (var item in people.IdLaptop)
                //{
                //    Laptop_People newCP = new Laptop_People() { LaptopId = item, PeopleId = IdP };
                //    StringContent stringContent2 = new StringContent(JsonConvert.SerializeObject(newCP),
                //    Encoding.UTF8, "application/json");
                //    using (var respon = await https.PostAsync("https://localhost:7087/api/Laptop_People", stringContent))
                //    {
                //        if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                //        {
                //            var apiRespon = await respon.Content.ReadAsStringAsync();
                //            newCP = JsonConvert.DeserializeObject<Laptop_People>(apiRespon);
                //        }
                //        else
                //        {
                //            ViewBag.Error = respon.StatusCode;
                //        }
                //    }
                //}

            }
            //ViewData["IdCar"]     = new SelectList(lstCar, "Id", "Name", people.IdCar);
            //ViewData["IdLaptop"]  = new SelectList(lstLaptop, "Id", "Name", people.IdLaptop);
            ViewData["IdCar"] = lstCar;
            ViewData["IdLaptop"] = lstLaptop;


            return RedirectToAction("Index");
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var DetailP = new People();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/People/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<People>(apiRespon);
                }
            }
            var lstCar = new List<Car>();
            var lstLaptop = new List<Laptop>();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync("https://localhost:7087/api/Cars"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstCar = JsonConvert.DeserializeObject<List<Car>>(apiRespon);
                }


                // lấy danh sách Laptop

                using (var respon = await https.GetAsync("https://localhost:7087/api/Laptops"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(apiRespon);
                }

            }
            TempData["lstCar"] = JsonConvert.SerializeObject(lstCar);
            TempData["lstLaptop"] = JsonConvert.SerializeObject(lstLaptop);

            ViewData["IdCar"] = lstCar;
            ViewData["IdLaptop"] = lstLaptop;
            return View(DetailP);

        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Phone,MoTa,IdCar,IdLaptop")] People people)
        {
            if (id != people.ID)
            {
                return NotFound();
            }

            try
            {
                using (var https = new HttpClient())
                {
                    StringContent stringContent2 = new StringContent(JsonConvert.SerializeObject(people), Encoding.UTF8, "application/json");

                    var repon = await https.PutAsync($"https://localhost:7087/api/People/{id}", stringContent2);
                    if (!repon.IsSuccessStatusCode)
                    {
                        ViewBag.StatusCode = repon.StatusCode;
                        return View(people);
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi và thông báo cho người dùng
                ModelState.AddModelError(string.Empty, $"Có lỗi xảy ra: {ex.Message}");
                return View(people);
            }

            // Sử dụng lại TempData nếu có
            var lstCar = JsonConvert.DeserializeObject<List<Car>>(TempData["lstCar"]?.ToString() ?? "[]");
            var lstLaptop = JsonConvert.DeserializeObject<List<Laptop>>(TempData["lstLaptop"]?.ToString() ?? "[]");

            ViewData["IdCar"] = lstCar;
            ViewData["IdLaptop"] = lstLaptop;

            return RedirectToAction("Index");
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var DetailP = new People();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/People/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<People>(apiRespon);
                }
            }
            return View(DetailP);

        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var https = new HttpClient())
            {
                // Gửi yêu cầu DELETE đến API với id của đối tượng cần xóa
                using (var repon = await https.DeleteAsync($"https://localhost:7087/api/People/{id}"))
                {
                    // Kiểm tra nếu yêu cầu xóa thành công
                    if (repon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // Phản hồi từ API không cần thiết nếu không có dữ liệu trả về, chỉ kiểm tra trạng thái OK
                    }
                    else
                    {
                        // Lưu mã lỗi nếu quá trình xóa thất bại
                        ViewBag.StatusCode = repon.StatusCode;
                        return RedirectToAction("Delete", new { id = id }); // Điều hướng về lại trang Delete nếu lỗi
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
