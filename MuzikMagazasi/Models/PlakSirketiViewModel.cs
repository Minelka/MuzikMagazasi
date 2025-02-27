using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class PlakSirketiViewModel: BaseViewModel
    {
        public PlakSirketiViewModel() : base(0) { }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Kurucu Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string KurucuAd{ get; set; }

        [Display(Name = "Kurucu Soyad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string KurucuSoyad { get; set; }

        [Display(Name = "Kuruluş Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateOnly KuruluşTarihi { get; set; }
    }
}
