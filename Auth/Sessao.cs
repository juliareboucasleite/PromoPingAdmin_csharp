using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel_Admin.Auth
{
    public static class Sessao
    {
        public static string UserId { get; set; } // ReferenciaID
        public static string Nome { get; set; }
        public static string Email { get; set; }
    }
}
