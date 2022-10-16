using System;
using System.Collections.Generic;

namespace ProjetoCopa.Models
{
    public partial class FaseCampeonato
    {
        public FaseCampeonato()
        {
            Jogos = new HashSet<Jogo>();
        }

        public int IdFase { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
