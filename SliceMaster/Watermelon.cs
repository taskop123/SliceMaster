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
        public Watermelon(string Name, Point Location) : base(Name, Location)
        {
            Radius = 50;
            FruitImage = Properties.Resources.watermelon;
            Points = 3;
            //FruitImageAfterHit 

        }
        public override bool IsHitByUser(Point p1, Point p2)
        // za voa metod moze ke treba dve tocki, pa da naprajme linija od
        //tie dve tocki i proverme dali linijata ja sece elipsata ? mouseclick i mouseleave msm oti e koa ke pustis
        {
            throw new NotImplementedException();
        }

        public override void MoveUp(float velocity, int direction)
        {
            if (direction == 1)
            {
                // od desno kon levo i vo koso, x se namaluva, y se zgolemuva
                this.Location = new Point((int)(Location.X - velocity), (int)(Location.Y + velocity));
            }
            else
            {
                // od levo kon desno, x se zgolemuva, y se zgolemuva
                this.Location = new Point((int)(Location.X + velocity), (int)(Location.Y + velocity));
            }
        }
        public override void MoveDown(float velocity, int direction)
        {
            if (direction == 1)
            {
                // od desno kon levo i vo koso, x se namaluva, y se namaluva
                this.Location = new Point((int)(Location.X - velocity), (int)(Location.Y - velocity));
            }
            else
            {
                // od levo kon desno, x se zgolemuva, y se namaluva
                this.Location = new Point((int)(Location.X + velocity), (int)(Location.Y - velocity));
            }
        }

        public override void Draw(Graphics g)
        {
            Bitmap bitmap = new Bitmap(FruitImage);
            bitmap.MakeTransparent();
            g.DrawImage(bitmap, new Rectangle(Location.X, Location.Y, (int)Radius * 2, (int)Radius * 2));
        }
    }
}
