using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.IntroMVC.Entidades
{
    public interface IEstaEnPlataforma
    {
        public bool? EstaEnNetflix { get; set; }
        public bool? EstaEnDisney { get; set; }
        public bool? EstaEnAmazon { get; set; }
        public bool? EstaEnStarPlus { get; set; }
        public bool? EstaEnHBO { get; set; }
    }
}
