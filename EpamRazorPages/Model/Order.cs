using System;
using System.ComponentModel.DataAnnotations;

namespace EpamRazorPages.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Введите ФИО")]
        [StringLength(20, ErrorMessage = "Длина строки ФИО должна быть не более 20 символов")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"\+[0-9]{11}", ErrorMessage = "Некорректный формат номера телефона, введите в формате +цифры")]
        public string ContactNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Введите дату подачи авто")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}")]
        public DateTime? CarDeliveryTime { get; set; }
        [Required(ErrorMessage = "Введите начальную точку маршрута")]
        [StringLength(20, ErrorMessage = "Длина строки начальной точки маршрута должна быть не более 20 символов")]
        public string FromLocation { get; set; }
        [Required(ErrorMessage = "Введите конечную точку маршрута")]
        [StringLength(20, ErrorMessage = "Длина строки конечой точки маршрута должна быть не более 20 символов")]
        public string ToLocation { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
