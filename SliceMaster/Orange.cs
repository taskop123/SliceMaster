using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public class Orange : Fruit
    {
        public Orange(string Name, Point Location) : base(Name, Location)
        {
            Radius = 35;
            Points = 4;
            FruitImage = Properties.Resources.orange;
        }

        public override void Draw(Graphics g)
        {
            Bitmap bitmap = new Bitmap(FruitImage);
            bitmap.MakeTransparent();
            g.DrawImage(bitmap, new Rectangle(Location.X, Location.Y, (int)Radius * 2, (int)Radius * 2));
        }

        public override bool IsHitByUser(Point p1, Point p2)
        {
            throw new NotImplementedException();
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
    }
}
