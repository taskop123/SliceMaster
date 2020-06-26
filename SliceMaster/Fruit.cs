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
        public Image FruitImage { get; set; } // slika na ovosjeto
        public float Radius { get; set; } // Sekoe ovosje kje ni bide vo vid na elipsa, i zatoa ke cuvame promenliva radius
        public bool IsHit { get; set; } // promenliva koja ke cuva vrednost true ili false, vo zavisnost od toa dali nekoe ovosje e preseceno
        //public Image FruitImageAfterHit { get; set; } // druga slika za ovosjeto otkako ke se presece
        public float Points { get; set; } // Sekoe ovosje ke nosi razlicen broj na poeni
        public int MaxHeight { get; set; } // ovaa promenliva ke mi sodrzi vrednost za toa do kolkava visina ovosjeto ke odi nagore.
        public float Velocity { get; set; }
        public Random VelocityPicker; //Ovaa promenliva ke mi generira random vrednost za brzinata so koja edno ovosje ke se dvizi
        public Random MaxHeightPicker; // so ovaa promenliva ke odreduvame do koja visina da se dvizi ovosjeto nagore.
        public int State { get; set; } // ovaa promenliva ke ni koristi koga sakame da go unistime objektot od klasata fruit, 1 ke ni bide dodeka zivee, 0 znaci deka treba da se unisti.
        public Fruit(string Name, Point Location)
        {
            this.Name = Name;
            this.Location = Location;
            this.IsHit = false;
            VelocityPicker = new Random();
            MaxHeightPicker = new Random();
            this.Velocity = VelocityPicker.Next(5, 10); // Ovaa promenliva ke mi odreduva so koja brzina ke se dvizi ovosjeto od levo kon desno ili obratno
            this.MaxHeight = Location.Y - MaxHeightPicker.Next(150, 220); // da odi nagore do nekoja od 150 px do 220 px vrednost
            this.State = 1; // inicijalno objektot ke zivee
        }
        public abstract void MoveUp(float velocity, int direction); // Metod koj ke ni go dvizi ovosjeto nagore
        public abstract void MoveDown(float velocity, int direction); // Metod koj ke ni go dvizi ovosjeto nadole
        public abstract void Draw(Graphics g); // crtanje na ovosjeto
        public abstract bool IsHitByUser(Point p1, Point p2); // metod koj ke proveruva dali korisnikot go presekol ovosjeto
    }
}
