using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class People
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Range(0, 120, ErrorMessage = "Tuổi phải nằm trong khoảng từ 0 đến 120")]
        public int Age { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 200 ký tự")]
        public string? MoTa { get; set; }

        public List<int>? IdCar { get; set; }
        public ICollection<Car_People>? Car_Peoples { get; set; }
        public List<int>? IdLaptop { get; set; }
        public ICollection<Laptop_People>? Laptop_Peoples { get; set; }

    }
}
