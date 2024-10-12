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
using System.Runtime.ConstrainedExecution;

namespace LAB8.WEB.Controllers
{
    public class LaptopsController : Controller
    {


        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var lstLap = new List<Laptop>();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync("https://localhost:7087/api/Laptops"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    lstLap = JsonConvert.DeserializeObject<List<Laptop>>(apiRespon);
                }
            }
            return View(lstLap);
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var DetailP = new Laptop();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/Laptops/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<Laptop>(apiRespon);
                }
            }
            return View(DetailP);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HangMay,NgaySanXuat,MaLaptop,Desception")] Laptop laptop)
        {
            var NewL = new Laptop();
            using (var https = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(laptop),
                    Encoding.UTF8, "application/json");
                using (var repon = await https.PostAsync("https://localhost:7087/api/Laptops", stringContent))
                {
                    var apiRespon = await repon.Content.ReadAsStringAsync();
                    NewL = JsonConvert.DeserializeObject<Laptop>(apiRespon);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var DetailP = new Laptop();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/Laptops/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<Laptop>(apiRespon);
                }
            }
            return View(DetailP);
            
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HangMay,NgaySanXuat,MaLaptop,Desception")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            using (var https = new HttpClient())
            {
                // Convert đối tượng chucVu thành JSON string
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(laptop),
                    Encoding.UTF8, "application/json");

                // Gửi yêu cầu PUT để cập nhật dữ liệu
                using (var repon = await https.PutAsync($"https://localhost:7087/api/Laptops/{id}", stringContent))
                {
                    // Kiểm tra nếu yêu cầu cập nhật thành công
                    if (repon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // Lấy phản hồi từ API
                        var apiRespon = await repon.Content.ReadAsStringAsync();
                        var editCar = JsonConvert.DeserializeObject<Laptop>(apiRespon);
                    }
                    else
                    {
                        // Trả về trang view kèm mã lỗi nếu không thành công
                        ViewBag.StatusCode = repon.StatusCode;
                        return View(laptop);
                    }
                }
            }

            // Nếu thành công, điều hướng về trang Index
            return RedirectToAction("Index");
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var DetailP = new Laptop();
            using (var https = new HttpClient())
            {

                using (var respon = await https.GetAsync($"https://localhost:7087/api/Laptops/{id}"))
                {
                    var apiRespon = await respon.Content.ReadAsStringAsync();
                    DetailP = JsonConvert.DeserializeObject<Laptop>(apiRespon);
                }
            }
            return View(DetailP);
           
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var https = new HttpClient())
            {
                // Gửi yêu cầu DELETE đến API với id của đối tượng cần xóa
                using (var repon = await https.DeleteAsync($"https://localhost:7087/api/Laptops/{id}"))
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

            
            return RedirectToAction("Index");

        
        }


    }
}
