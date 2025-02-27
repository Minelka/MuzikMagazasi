using MuzikMagazasi.Context.Abstract;

namespace MuzikMagazasi.Context.Entities
{
    public class Tarz: BaseEntity
    {
        public string Ad { get; set; }

        public string Aciklama { get; set; }

        //public virtual ICollection<Sarkilar> Sarkilars { get; set; }

        //public virtual ICollection<Album> Albumlers { get; set; }
    }
}
