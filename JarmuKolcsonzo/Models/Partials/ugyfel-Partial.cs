using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.Models
{
    public partial class ugyfel
    {
        public ugyfel(
            string vnev,
            string knev,
            string varos,
            //TODO: Hiányzó elem
            string telefonszam,
            string email,
            int pont)
        {
            this.vezeteknev = vnev;
            this.keresztnev = knev;
            this.varos = varos;
            this.telefonszam = telefonszam;
            this.email = email;
            this.pont = pont;
        }

        public ugyfel()
        {

        }
    }
}
