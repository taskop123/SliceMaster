using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SliceMaster
{
    public partial class Form1 : Form
    {
        // glavniot objekt preku koj ke gi izvrsuvame site metodi
        private GameScene Game;
        private Random randomFruitPicker;
        private Random LocationPicker;
        private int TimerCall;
        private bool Pause;
        private Point CurrentPoint;
        private Point PreviousPoint;
        private Pen Pen;
        private Graphics graphics;

        public Form1()
        {
            Game = new GameScene(this.Width, this.Height);
            InitializeComponent();
            this.DoubleBuffered = true;
            randomFruitPicker = new Random(); // Ke ja koristime ovaa slucajna promenliva za izbiranje na slucajno ovosje;
            LocationPicker = new Random(); // Promenliva koja ke odlucuva od koja lokacija da pocne da se frla ovosjeto;
            TimerCall = 0;
            timer1.Start();
            Pause = false;
            graphics = this.CreateGraphics();
            Pen = new Pen(Color.Gray, 5);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Game.DrawAllFruits(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Pause)
            {
                if (TimerCall % 30 == 0)
                { // na sekoi 3 sekundi dodavaj po 3 ovosja
                    Game.DirectionOfFruit = Game.DirectionOfFruit == 1 ? 0 : 1;
                    if (Game.DirectionOfFruit == 0)
                    {
                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                            new Point(LocationPicker.Next(-80, -50), LocationPicker.Next(140, 160)));

                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                            new Point(LocationPicker.Next(-80, -50), LocationPicker.Next(180, 200)));

                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                             new Point(LocationPicker.Next(-80, -50), LocationPicker.Next(220, 240)));
                    }
                    else
                    {
                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                            new Point(LocationPicker.Next(Width - 30, Width), LocationPicker.Next(140, 160)));

                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                            new Point(LocationPicker.Next(Width - 30, Width), LocationPicker.Next(180, 200)));

                        Game.AddFruit(GameScene.FruitNames[randomFruitPicker.Next(6)],
                            new Point(LocationPicker.Next(Width - 30, Width), LocationPicker.Next(220, 240)));
                    }
                }
                Game.Width = Width;
                Game.Height = Height;
                Game.MoveFruits();
                TimerCall++;
                updatePointsAndMisses();
                Invalidate();
            }
        }
        public void updatePointsAndMisses()
        {
            toolStripLabelPoints.Text = string.Format("Points: {0}", Game.TotalPoints);
            toolStripLabelMisses.Text = string.Format("Misses: {0}", Game.Misses);

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //Ako se napravi resize togas ke treba soodvetno da se zgolemat i radiusite, da ne bidat mn malecki
            Game.Width = Width;
            Game.Height = Height;
            /*Game.UpdateRadius();
            Invalidate();*/
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Pause)
            {
                Pause = true;
                pauseToolStripMenuItem.Text = "Continue";
            }
            else
            {
                Pause = false;
                pauseToolStripMenuItem.Text = "Pause";
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                CurrentPoint = e.Location;
                graphics.DrawLine(Pen, PreviousPoint, CurrentPoint);
                PreviousPoint = CurrentPoint;
            }
            
        }

    }
}
