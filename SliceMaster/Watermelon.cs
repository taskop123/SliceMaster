using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public class Watermelon : Fruit
    {
        public Watermelon(string Name, Point Location, int Direction, int Radius) :
            base(Name, Location, Direction, Radius)
        {
            FruitImage = Properties.Resources.watermelon2;
            Points = 3;
        }
        public override void IsHitByUser(Point p1)
        // za voa metod moze ke treba dve tocki, pa da naprajme linija od
        //tie dve tocki i proverme dali linijata ja sece elipsata ? mouseclick i mouseleave msm oti e koa ke pustis
        {
            float Distance = (p1.X - this.Location.X) * (p1.X - this.Location.X) + (p1.Y - this.Location.Y) * (p1.Y - this.Location.Y);
            if (Distance <= Radius * Radius)
            {
                this.IsHit = true;
                FruitSlicedSound.URL = "fruit_cut.mp3";
                FruitSlicedSound.controls.play();
            }
        }

        public override void MoveDown(float velocity)
        {
            if (this.Direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity * 2), (int)(Location.Y - velocity - 2));
            }
            else
            {
                this.Location = new Point((int)(Location.X + velocity * 2), (int)(Location.Y - velocity - 2));
            }
        }

        public override void MoveUp(float velocity)
        {
            if (this.Direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity * 2), (int)(Location.Y + velocity - 2));
            }
            else
            {
                this.Location = new Point((int)(Location.X + velocity * 2), (int)(Location.Y + velocity - 2));
            }
        }

        public override void Draw(Graphics g)
        {
            Bitmap bitmap = new Bitmap(FruitImage);
            bitmap.MakeTransparent();
            g.DrawImage(bitmap, new Rectangle(Location.X - (int)Radius, Location.Y - (int)Radius, (int)Radius * 2, (int)Radius * 2));
            bitmap.Dispose();
        }
    }
}
