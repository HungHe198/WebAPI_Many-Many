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
    public class CarsController : Controller
    {

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var lstCar = new List<Car>();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync("https://localhost:7087/api/Cars"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstCar = JsonConvert.DeserializeObject<List<Car>>(apiRespon);
                }
            }
            return View(lstCar);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Car DetailP = new Car();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/Cars/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<Car>(apiRespon);
                }
            }
            return View(DetailP);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HangXe,NgaySanXuat,Desception")] Car car)
        {
            Car NewC = new Car();
            using (var https = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(car),
                    Encoding.UTF8, "application/json");
                using (var repon = await https.PostAsync("https://localhost:7087/api/Cars", stringContent))
                {
                    var apiRespon = await repon.Content.ReadAsStringAsync();
                    NewC = JsonConvert.DeserializeObject<Car>(apiRespon);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Car editCar = new Car();
            using (var https = new HttpClient())
            {
                using (var respon = await https.GetAsync($"https://localhost:7087/api/Cars/{id}"))
                {
                    if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apirespon = await respon.Content.ReadAsStringAsync();
                        editCar = JsonConvert.DeserializeObject<Car>(apirespon);
                    }
                    else
                    {
                        ViewBag.StudentId = respon.StatusCode;
                    }
                }
            }
            return View(editCar);

        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HangXe,NgaySanXuat,Desception")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            using (var https = new HttpClient())
            {
                // Convert đối tượng chucVu thành JSON string
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(car),
                    Encoding.UTF8, "application/json");

                // Gửi yêu cầu PUT để cập nhật dữ liệu
                using (var repon = await https.PutAsync($"https://localhost:7087/api/Cars/{id}", stringContent))
                {
                    // Kiểm tra nếu yêu cầu cập nhật thành công
                    if (repon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // Lấy phản hồi từ API
                        var apiRespon = await repon.Content.ReadAsStringAsync();
                        var editCar = JsonConvert.DeserializeObject<Car>(apiRespon);
                    }
                    else
                    {
                        // Trả về trang view kèm mã lỗi nếu không thành công
                        ViewBag.StatusCode = repon.StatusCode;
                        return View(car);
                    }
                }
            }

            // Nếu thành công, điều hướng về trang Index
            return RedirectToAction("Index");

        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Car editCar = new Car();
            using (var https = new HttpClient())
            {
                using (var respon = await https.GetAsync($"https://localhost:7087/api/Cars/{id}"))
                {
                    if (respon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apirespon = await respon.Content.ReadAsStringAsync();
                        editCar = JsonConvert.DeserializeObject<Car>(apirespon);
                    }
                    else
                    {
                        ViewBag.StudentId = respon.StatusCode;
                    }
                }
            }
            return View(editCar);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var https = new HttpClient())
            {
                // Gửi yêu cầu DELETE đến API với id của đối tượng cần xóa
                using (var repon = await https.DeleteAsync($"https://localhost:7087/api/Cars/{id}"))
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

            // Nếu thành công, điều hướng về trang Index
            return RedirectToAction("Index");

        }


    }
}
