using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public abstract class Fruit
    {
        public string Name { get; set; } // ime na ovosjeto
        public Point Location { get; set; } // momentalna polozba na ovosjeto vo formata
        public static Image FruitImage { get;} // slika na ovosjeto
        public float Velocity { get; set; } // so koja brzina ke se dvizi samoto ovosje
        public int Direction { get; set; } // -1 -> od levo kon desno, 1 -> od desno kon levo
        public static float Radius { get; set; } // Sekoe ovosje kje ni bide vo vid na elipsa, i zatoa ke cuvame promenliva radius
        public bool IsHit { get; set; } // promenliva koja ke cuva vrednost true ili false, vo zavisnost od toa dali nekoe ovosje e preseceno
        public static Image FruitImageAfterHit { get;} // druga slika za ovosjeto otkako ke se presece
        public static float Points { get;} // Sekoe ovosje ke nosi razlicen broj na poeni
        public Fruit(string Name, Point Location, int Direction)
        {
            this.Name = Name;
            this.Location = Location;
            this.Direction = Direction;
            this.IsHit = false;
        }
        public abstract void Move(float velocity, int direction); // Metod koj ke ni go dvizi ovosjeto
        public abstract bool IsHitByUser(Point p); // metod koj ke proveruva dali korisnikot go presekol ovosjeto
    }
}
