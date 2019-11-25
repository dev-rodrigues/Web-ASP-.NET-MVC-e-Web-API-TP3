using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Friend {
        public int Id {
            get; set;
        }
        public string Nome {
            get; set;
        }
        public string Sobrenome {
            get; set;
        }
        public string Telefone {
            get; set;
        }
        public string Email {
            get; set;
        }
        public DateTime Aniversario {
            get; set;
        }
    }
}
