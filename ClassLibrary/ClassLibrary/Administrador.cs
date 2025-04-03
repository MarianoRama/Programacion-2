using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    // CONSTRUCTOR
    public class Administrador : Usuario
    {
        public Administrador(string unNombre, string unApellido, string unEmail, string unaContrasenia)
            : base(unNombre, unApellido, unEmail, unaContrasenia)
        {
        }
    }
}
