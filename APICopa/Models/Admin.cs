using System;
using System.Collections.Generic;

namespace ProjetoCopa.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
