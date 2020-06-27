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
            FruitImage = Properties.Resources.watermelon;
            Points = 3;
        }
        public override bool IsHitByUser(Point p1, Point p2)
        // za voa metod moze ke treba dve tocki, pa da naprajme linija od
        //tie dve tocki i proverme dali linijata ja sece elipsata ? mouseclick i mouseleave msm oti e koa ke pustis
        {
            throw new NotImplementedException();
        }

        public override void MoveDown(float velocity)
        {
            if (this.Direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity * 2), (int)(Location.Y - velocity-2));
            }
            else
            {
                this.Location = new Point((int)(Location.X + velocity * 2), (int)(Location.Y - velocity-2));
            }
        }

        public override void MoveUp(float velocity)
        {
            if (this.Direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity * 2), (int)(Location.Y + velocity-2));
            }
            else
            {
                this.Location = new Point((int)(Location.X + velocity * 2), (int)(Location.Y + velocity-2));
            }
        }

        public override void Draw(Graphics g)
        {
            Bitmap bitmap = new Bitmap(FruitImage);
            bitmap.MakeTransparent();
            g.DrawImage(bitmap, new Rectangle(Location.X, Location.Y, (int)Radius * 2, (int)Radius * 2));
            bitmap.Dispose();
        }
    }
}
