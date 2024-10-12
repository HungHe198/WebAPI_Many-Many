using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên laptop là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên laptop không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hãng máy là bắt buộc")]
        public string HangMay { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NgaySanXuat { get; set; }

        [Required(ErrorMessage = "Mã laptop là bắt buộc")]
        [StringLength(50, ErrorMessage = "Mã laptop không được vượt quá 50 ký tự")]
        public string MaLaptop { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 200 ký tự")]
        public string? Desception { get; set; }
        public List<int>? IdPeople { get; set; }
        public ICollection<Laptop_People>? Laptop_Peoples { get; set; }
    }
}
