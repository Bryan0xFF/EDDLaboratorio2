using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB02_1252016_1053016.Models
{
    public class Pais: IComparable<Pais>
    {
        public string NombrePais { get; set; }
        public string Grupo  { get; set; }

        public int CompareTo(Pais other)
        {
            return this.Grupo.CompareTo(other.Grupo);
        }
    }
}