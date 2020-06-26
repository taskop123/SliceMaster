using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public class GameScene
    {
        public List<Fruit> AllFruits { get; set; }
        public int TotalPoints { get; set; }
        //brzina na dvizenje za site ovosja
        public static string [] FruitNames = new string[] { "Watermelon", "Apple", "Pineapple", "Bomb", "Orange", "Strawberry" }; // ovaa promenliva ke mi koristi koga ke dodavame novo ovosje vo ovaa klasa!
        public int DirectionOfFruit { get; set; } // 0 - od levo kon desno, 1 - od desno kon levo
        public int Width { get; set; }
        //konstruktor
        public GameScene(int WidthOfForm)
        {
            TotalPoints = 0;
            AllFruits = new List<Fruit>();
            DirectionOfFruit = 0;
            this.Width = WidthOfForm;

        }
        //dodavanje na ovosje
        public void AddFruit(String Name, Point Location)
        {
            Fruit NewFruit;
            if (Name.Equals("Watermelon"))
                NewFruit = new Watermelon(Name, Location);
            else if (Name.Equals("Pineapple"))
                NewFruit = new Pineapple(Name, Location);
            else if (Name.Equals("Apple"))
                NewFruit = new Apple(Name, Location);
            else if (Name.Equals("Orange"))
                NewFruit = new Orange(Name, Location);
            else if (Name.Equals("Strawberry"))
                NewFruit = new Strawberry(Name, Location);
            else
                NewFruit = new Bomb(Name, Location);
            AllFruits.Add(NewFruit);
        }
        public void DrawAllFruits(Graphics g)
        {
            foreach(Fruit f in AllFruits)
            {
                f.Draw(g);
            }
        }
        public void MoveFruits()
        {
            foreach (Fruit f in AllFruits) // vo ovoj metod ke treba da se proveruva i dali e preseceno ovosjeto!
            {
                if (f.Location.Y <= f.MaxHeight) // dodeka ne ja dostigne maxHeight neka se dvizi nagore
                {
                    f.MoveUp(f.Velocity, this.DirectionOfFruit);
                }
                else // vo sprotivno odi nadolu
                {
                    f.MoveDown(f.Velocity, this.DirectionOfFruit);
                    if (f.Location.X > this.Width + 110 || f.Location.X < -110) // Ovoj uslov mi proveruva dali ovosjeto veke si ja zavrsilo traektorijata i ne bilo preseceno
                    {// proveruva dali po x oskata e pogolema od goleminata na formata + 50 toa mi e na nekoj nacin offset (go stavam ovoj offset bidejki moze da se sluci uste ne izlezen na ekranot ovosjeto da bide unisteno)
                     // Dodeka drugiot del mi proveruva ako ovosjeto se dvizi od desno kon levo dali po X oskata vrednosta e pomala od -50px vo levo   
                        f.State = 0; // do ovoj if se stignuva dokolku
                        //ZA JOVAN: tuka moze da brojme kolko pti nekoe ovosje ne bilo seceno!
                    }
                }
            }
            for (int i = 0; i < AllFruits.Count; i++)
            {
                if (AllFruits[i].State == 0)
                {
                    AllFruits.RemoveAt(i);
                }
            }
        }
    }
}
