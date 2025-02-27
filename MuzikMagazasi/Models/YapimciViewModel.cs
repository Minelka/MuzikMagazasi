using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class YapimciViewModel : BaseViewModel
    {
        public YapimciViewModel() : base(0) { }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Soyad { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime DogumTarihi { get; set; }

        [Display(Name = "Şahis Mı Şirket Mi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public bool SahismiSirketmi { get; set; }

        [Display(Name = "Şirket Adı")]
        public string? SirketAdi { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}
