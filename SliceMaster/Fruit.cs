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
        public static Image FruitImage { get; set; } // slika na ovosjeto
        public static float Radius { get; set; } // Sekoe ovosje kje ni bide vo vid na elipsa, i zatoa ke cuvame promenliva radius
        public bool IsHit { get; set; } // promenliva koja ke cuva vrednost true ili false, vo zavisnost od toa dali nekoe ovosje e preseceno
        public static Image FruitImageAfterHit { get; set; } // druga slika za ovosjeto otkako ke se presece
        public static float Points { get; set; } // Sekoe ovosje ke nosi razlicen broj na poeni
        public Fruit(string Name, Point Location)
        {
            this.Name = Name;
            this.Location = Location;
            this.IsHit = false;
        }
        public abstract void MoveUp(float velocity, int direction); // Metod koj ke ni go dvizi ovosjeto nagore
        public abstract void MoveDown(float velocity, int direction); // Metod koj ke ni go dvizi ovosjeto nadole
        public abstract void Draw(Graphics g); // crtanje na ovosjeto
        public abstract bool IsHitByUser(Point p1, Point p2); // metod koj ke proveruva dali korisnikot go presekol ovosjeto
    }
}
