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
        public int Misses { get; set; }// TODO: ako ima 3 ili 5 misses(po nas izbor) da se prekine igrata
        //brzina na dvizenje za site ovosja
        public static string[] FruitNames = new string[] { "Watermelon", "Apple", "Pineapple", "Bomb", "Orange", "Strawberry" }; // ovaa promenliva ke mi koristi koga ke dodavame novo ovosje vo ovaa klasa!
        public int DirectionOfFruit { get; set; } // 0 - od levo kon desno, 1 - od desno kon levo
        public int Width { get; set; }
        public int Height { get; set; }

        //konstruktor
        public GameScene(int WidthOfForm, int HeightOfForm)
        {
            TotalPoints = 0;
            Misses = 0;
            AllFruits = new List<Fruit>();
            DirectionOfFruit = 0;
            this.Width = WidthOfForm;
            this.Height = HeightOfForm;
        }
        // Go iskomentirah voa oti ne znam bash da najdum soodveten radius za daden Width i Height
        // Na primer za 900, 500 da bide 35 ako ti dojde nekoja ideja implementiri go, i vo AddFruit na mestoto na radius
        // stavi getRadius()

        /*public void UpdateRadius()
        {
            foreach (Fruit f in AllFruits)
            {
                f.Radius = getRadius();
            }
        }*/
        /*private int getRadius()
        {
            return ((Width * Height) / 10000) - 10;
        }*/
        //dodavanje na ovosje
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
                f.Draw(g);
            }
        }
        public void MoveFruits()
        {
            foreach (Fruit f in AllFruits) // vo ovoj metod ke treba da se proveruva i dali e preseceno ovosjeto!
            {
                if (f.Location.Y <= Height - 150 && f.UpOrDown) // dodeka ne ja dostigne Height neka se dvizi nagore
                {
                    f.MoveUp(f.Velocity);
                }
                else // vo sprotivno odi nadolu
                {
                    f.UpOrDown = false;
                    f.MoveDown(f.Velocity);
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
                    //Ako e bomba da ne se broi kako miss
                    if (!AllFruits[i].Name.Equals("Bomb"))
                        Misses++;
                    AllFruits.RemoveAt(i);
                }
            }
        }
    }
}
