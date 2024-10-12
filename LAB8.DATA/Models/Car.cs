using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class Car
    {
        [Key] // Đánh dấu Id là khóa chính
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên xe là bắt buộc")] // Thuộc tính bắt buộc
        [StringLength(100, ErrorMessage = "Tên xe không được vượt quá 100 ký tự")] // Giới hạn độ dài
        public string Name { get; set; }

        [Required(ErrorMessage = "Hãng xe là bắt buộc")]
        public string HangXe { get; set; }

        [DataType(DataType.Date)] // Định dạng ngày tháng
        public DateTime? NgaySanXuat { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 200 ký tự")]
        public string? Desception { get; set; }
        public List<int>? IdPeople { get; set; }
        public ICollection<Car_People>? Car_Peoples { get; set; }


    }
}
