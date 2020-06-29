using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SliceMaster
{
    public abstract class Fruit
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public Image FruitImage { get; set; }
        public float Radius { get; set; }
        public bool IsHit { get; set; }
        public int Points { get; set; }
        public int Direction { get; set; }
        public bool UpOrDown { get; set; }
        public WindowsMediaPlayer FruitSlicedSound { get; set; }
        public float Velocity { get; set; }
        public Random VelocityPicker;
        public int State { get; set; }
        public Fruit(string Name, Point Location, int Direction, int Radius)
        {
            this.Radius = Radius;
            UpOrDown = true;
            this.Direction = Direction;
            this.Name = Name;
            this.Location = Location;
            this.IsHit = false;
            VelocityPicker = new Random();
            this.Velocity = VelocityPicker.Next(6, 8);
            this.State = 1;
            FruitSlicedSound = new WindowsMediaPlayer();
        }

        
        public abstract void MoveUp(float velocity);
        public abstract void MoveDown(float velocity); 
        public abstract void Draw(Graphics g); 
        public abstract void IsHitByUser(Point p1); 
    }
}
