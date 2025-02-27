using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class AlbumViewModel: BaseViewModel
    {
        public AlbumViewModel() : base(0) { }

        [Display(Name = "Şarkı Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Şarkı Tarzı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Tarz { get; set; }

        public int TarzId { get; set; }

        [Display(Name = "Şarkı Süresi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sure { get; set; }

        [Display(Name = "Yapımcılar")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Yapimcilar { get; set; }

        public int YapimcilarId { get; set; }

        [Display(Name = "Dili")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Dili { get; set; }

        [Display(Name = "Çıkış Yılı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Yili { get; set; }

        [Display(Name = "Şarkıları")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sarkilari { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}
