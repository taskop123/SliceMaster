﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public class Apple : Fruit
    {
        public Apple(string Name, Point Location) : base(Name, Location)
        {
            Radius = 30;
            Points = 4;
            // Images/apple.png
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override bool IsHitByUser(Point p1,Point p2)
        {
            throw new NotImplementedException();
        }

        public override void MoveDown(float velocity, int direction)
        {
            if (direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity), (int)(Location.Y - velocity));
            }
            else
            {
                this.Location = new Point((int)(Location.X + velocity), (int)(Location.Y - velocity));
            }
        }

        public override void MoveUp(float velocity, int direction)
        {
            if (direction == 1)
            {
                this.Location = new Point((int)(Location.X - velocity), (int)(Location.Y + velocity));
            }
            else
            {
                this.Location = new Point((int)(Location.X - velocity), (int)(Location.Y + velocity));
            }
        }
    }
}
