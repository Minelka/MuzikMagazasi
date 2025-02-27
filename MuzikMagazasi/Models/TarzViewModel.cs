using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class TarzViewModel : BaseViewModel
    {
        public TarzViewModel() : base(0) { }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Aciklama { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}
