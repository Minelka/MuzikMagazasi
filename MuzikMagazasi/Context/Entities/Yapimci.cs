using MuzikMagazasi.Context.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MuzikMagazasi.Context.Entities
{
    public class Yapimci: BaseEntity
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public DateTime DogumTarihi { get; set; }

        public bool SahismiSirketmi { get; set; }

        public string? SirketAdi { get; set; }

        public bool Status { get; set; }
    }
}
