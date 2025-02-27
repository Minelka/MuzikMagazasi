using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class SarkicilarViewModel: BaseViewModel
    {
        public SarkicilarViewModel() : base(0) { }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Soyad { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime DogumTarihi { get; set; }

        [Display(Name = "Yaşadığı Şehir")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string YasadigiSehir { get; set; }

        [Display(Name = "Medeni Durum")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string MedeniDurum { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Cinsiyet { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}
