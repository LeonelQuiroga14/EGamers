using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class Cuenta
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Resultado { get; set; }


        public Cuenta(int num1,int num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }
        public int Sumar()
        {
            return this.Resultado = this.Num1 + this.Num2;
        }
        public int Restar()
        {
            return this.Resultado = this.Num1 - this.Num2;
        }
    }
}