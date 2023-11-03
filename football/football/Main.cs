using System;
using System.Threading;

namespace Football
{
    class Program
    {
        public int DoubleToInt(double i)
        {
            
            int i2 = (int)i;
            return i2;
        }


        static void Main(string[] args) {

            Console.WriteLine("Mitu mängijat on ühes meeskonnas?");
            Console.ForegroundColor = ConsoleColor.Blue;
            string PlayerAmountstr = Console.ReadLine();
            Console.ResetColor();
            int PlayerAmount = int.Parse(PlayerAmountstr);
            Team team1 = new Team("Esimene");
            Team team2 = new Team("Teine");
            for (int i = 1; i <= PlayerAmount; i++)
            {
              
                Player p = new Player($"Mängija {i}",'$');
                team1.AddPlayer(p);
            }
            for (int i = 1; i <= PlayerAmount; i++)
            {

                Player p = new Player($"Mängija {i+PlayerAmount}", '#');
                team2.AddPlayer(p);
            }

            Console.WriteLine("Staadioni mõõdud");
            Console.WriteLine("Laius: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string widthstr = Console.ReadLine();
            Console.ResetColor();
            int width = int.Parse(widthstr);

            
            Console.WriteLine("Kõrgus: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string heightstr = Console.ReadLine();
            Console.ResetColor();
            int height = int.Parse(heightstr);

            Console.WriteLine("Mängu kestus sekundites: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string durationstr = Console.ReadLine();
            Console.ResetColor();
            int duration = int.Parse(durationstr);

            Console.WriteLine("Mängu kiirus 1-5: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string speedstr = Console.ReadLine();
            Console.ResetColor();
            int speedint = int.Parse(speedstr);

            int delay = 0;
            if (speedint == 1) {  delay = 1000; }
            else if (speedint == 2) {  delay = 800; }
            else if (speedint == 3) {  delay = 600; }
            else if (speedint == 4) {  delay = 400; }
            else if (speedint == 5) {  delay = 200; }


            Stadium stadium = new Stadium(width, height);
            //Team team1 = new Team("Esimene");

            //Player p1 = new Player("Mängija 1", '$');
            //team1.AddPlayer(p1);
            //Player p2 = new Player("Mängija 2", '$');
            //team1.AddPlayer(p2);
            //Player p3 = new Player("Mängija 3", '$');
            //team1.AddPlayer(p3);
            //Player p4 = new Player("Mängija 4", '$');
            //team1.AddPlayer(p4);

            //Team team2 = new Team("Teine");

            //Player p5 = new Player("Mängija 5",'#');
            //team2.AddPlayer(p5);
            //Player p6 = new Player("Mängija 6",'#');
            //team2.AddPlayer(p6);
            //Player p7 = new Player("Mängija 7",'#');
            //team2.AddPlayer(p7);
            //Player p8 = new Player("Mängija 8",'#');
            //team2.AddPlayer(p8);

            //Stadium stadium = new Stadium(60, 20);

            Game game = new Game(team1, team2, stadium);
            game.Start();

            int CalculateGameTime()
            {
                return duration * 1000 / delay;
            }

            for (int i=0;i< CalculateGameTime(); i++)
            {
         
                
                Console.Clear(); // Очистка экрана

                // Нарисовать стадион
          
                Draw draw = new Draw();
                Console.ForegroundColor = ConsoleColor.Yellow;
                draw.DrawStadium(stadium.Width,stadium.Height);
                Console.ResetColor();

                //движение игры
                game.Move();
                //задержка
                Thread.Sleep(delay);
            }

            Console.Clear();
            //окончание игры
            Console.WriteLine("Game over");

       

        }
    }
}
