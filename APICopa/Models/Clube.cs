using System;
using System.Collections.Generic;

namespace ProjetoCopa.Models
{
    public partial class Clube
    {
        public Clube()
        {
            JogoClubeANavigations = new HashSet<Jogo>();
            JogoClubeBNavigations = new HashSet<Jogo>();
        }

        public int IdClube { get; set; }
        public string Nome { get; set; } = null!;
        public string? UrlFoto { get; set; }

        public virtual ICollection<Jogo> JogoClubeANavigations { get; set; }
        public virtual ICollection<Jogo> JogoClubeBNavigations { get; set; }
    }
}
