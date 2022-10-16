using System;
using System.Collections.Generic;

namespace ProjetoCopa.Models
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public int ClubeA { get; set; }
        public int ClubeB { get; set; }
        public int? GolsClubeA { get; set; }
        public int? GolsClubeB { get; set; }
        public DateTime? JogoIniciado { get; set; }
        public DateTime? JogoFinalizado { get; set; }
        public DateTime? TempoAtual { get; set; }
        public int IdFase { get; set; }

        public virtual Clube ClubeANavigation { get; set; } = null!;
        public virtual Clube ClubeBNavigation { get; set; } = null!;
        public virtual FaseCampeonato IdFaseNavigation { get; set; } = null!;
    }
}
