using System.ComponentModel.DataAnnotations;

namespace EpamRazorPages.Model
{
    public enum OrderStatus
    {
        [Display(Name = "Новый")]
        New = 0,
        [Display(Name = "Подтвержден")]
        Confirmed = 1,
        [Display(Name = "Завершен")]
        Completed = 2,
        [Display(Name = "Отменен")]
        Canceled = 3
    }
}
