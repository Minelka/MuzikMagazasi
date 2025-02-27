using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Models
{
    public class SarkilarViewModel : BaseViewModel
    {
        public SarkilarViewModel() : base(0) { }

        [Display(Name = "Şarkı Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Şarkıcısı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sarkicisi { get; set; }

        public int SarkicilarId { get; set; }

        [Display(Name = "Şarkı Tarzı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Tarz { get; set; }

        public int TarzId { get; set; }

        [Display(Name = "Şarkı Süresi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sure { get; set; }

        [Display(Name = "Şarkı Sözü")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sozu { get; set; }

        [Display(Name = "Şarkı Yazarı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Yazari { get; set; }

        [Display(Name = "Şarkı Bestecisi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Besteci { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}
