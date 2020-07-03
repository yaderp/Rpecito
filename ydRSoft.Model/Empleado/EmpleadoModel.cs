using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ydRSoft.Model
{
    public class EmpleadoModel
    {
        public int ID { set; get; }
        public string DNI { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public int  ID_Cargo { set; get; }
        public string Cargo { set; get; }
        public string Correo { set; get; }
        public int ID_Sexo { set; get; }
        public EmpleadoModel() {
            this.ID_Cargo = 0;
            
        }

        private class isValidoDNI : ValidationAttribute {
            List<string> lst = new List<string>() { "43114343", "19191919" };
            public override bool IsValid(object value)
            {
                if (lst.Contains(value))
                    return false;
                return true;
            }
        }

        private class NumDNI : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value != null) {
                    string letra = value.ToString();
                    if (letra.Count() == 8)
                        return true;
                }

                return false;
            }


        }

    }
}
