using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SliceMaster
{
    public class GameScene
    {
        public List<Fruit> AllFruits { get; set; }
        public int TotalPoints { get; set; }
        public int Misses { get; set; }
        public static string[] FruitNames = new string[] {
            "Watermelon",
            "Apple",
            "Pineapple",
            "Orange",
            "Strawberry"
        }; 
        public int DirectionOfFruit { get; set; } 
        public int Width { get; set; }
        public int Height { get; set; }
        public bool GameOver { get; set; }
        //WindowsMediaPlayer FruitSlicedSound;
        WindowsMediaPlayer BombSliced;


        public GameScene(int WidthOfForm, int HeightOfForm)
        {
            GameOver = false;
            TotalPoints = 0;
            Misses = 0;
            AllFruits = new List<Fruit>();
            DirectionOfFruit = 0;
            this.Width = WidthOfForm;
            this.Height = HeightOfForm;
            //FruitSlicedSound = new WindowsMediaPlayer();
            BombSliced = new WindowsMediaPlayer();
            //FruitSlicedSound.URL = "fruit_cut.mp3";
        }

        public void AddFruit(String Name, Point Location)
        {
            Fruit NewFruit;
            if (Name.Equals("Watermelon"))
                NewFruit = new Watermelon(Name, Location, DirectionOfFruit, 35);
            else if (Name.Equals("Pineapple"))
                NewFruit = new Pineapple(Name, Location, DirectionOfFruit, 35);
            else if (Name.Equals("Apple"))
                NewFruit = new Apple(Name, Location, DirectionOfFruit, 35);
            else if (Name.Equals("Orange"))
                NewFruit = new Orange(Name, Location, DirectionOfFruit, 35);
            else if (Name.Equals("Strawberry"))
                NewFruit = new Strawberry(Name, Location, DirectionOfFruit, 35);
            else
                NewFruit = new Bomb(Name, Location, DirectionOfFruit, 35);
            AllFruits.Add(NewFruit);
        }
        public void DrawAllFruits(Graphics g)
        {
            foreach (Fruit f in AllFruits)
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.Xsign);
                bitmap.MakeTransparent();
                f.Draw(g);
                if (this.Misses >= 1)
                    g.DrawImage(bitmap,
                        new Rectangle(832, 393, 42, 36));
                if (this.Misses >= 2)
                    g.DrawImage(bitmap,
                        new Rectangle(784, 393, 42, 36));
                if (this.Misses == 3)
                    g.DrawImage(bitmap,
                        new Rectangle(736, 393, 42, 36));
                bitmap.Dispose();
            }
        }
        public void MoveFruits()
        {
            foreach (Fruit f in AllFruits) 
            {
                if (f.Location.Y <= Height - 150 && f.UpOrDown) 
                {
                    f.MoveUp(f.Velocity);
                }
                else 
                {
                    f.UpOrDown = false;
                    f.MoveDown(f.Velocity);
                }
                if (f.Location.X > this.Width + 110 || f.Location.X < -110 || f.IsHit) 
                {   
                    f.State = 0;
                }
            }
            deleteFruits();
        }
        public void CheckFruitCollision(Point point)
        {
            foreach (Fruit f in AllFruits)
            {
                f.IsHitByUser(point);
                if (f.IsHit)
                {
                    //FruitSlicedSound.controls.play();
                }
            }
        }
        private void deleteFruits()
        {
            for (int i = 0; i < AllFruits.Count; i++)
            {
                if (AllFruits[i].State == 0)
                {
                    if (AllFruits[i].Name.Equals("Bomb") && AllFruits[i].IsHit)
                    {
                        GameOver = true;
                    }
                    if (AllFruits[i].IsHit)
                    {
                        TotalPoints += AllFruits[i].Points;
                    }
                    if (!AllFruits[i].Name.Equals("Bomb") && !AllFruits[i].IsHit)
                        Misses++;
                    AllFruits.RemoveAt(i);
                    if (Misses == 3)
                        GameOver = true;
                }
            }
        }
        public void RemoveAll()
        {
            AllFruits.Clear();
        }
    }
}
