using System;
using System.Threading;

namespace Football
{
    class Program
    {


        static void Main(string[] args) {

            Console.WriteLine("Mitu mängijat on ühes meeskonnas?");//сколько бужет игроков в 1 команде
            Console.ForegroundColor = ConsoleColor.Blue;
            string PlayerAmountstr = Console.ReadLine();
            Console.ResetColor();
            int PlayerAmount = int.Parse(PlayerAmountstr);
            Team team1 = new Team("Esimene",0);
            Team team2 = new Team("Teine",0);
            for (int i = 1; i <= PlayerAmount; i++) //заполнение 1 команды
            {
              
                Player p = new Player($"Mängija {i}",'$');
                team1.AddPlayer(p);
            }
            for (int i = 1; i <= PlayerAmount; i++)
            {

                Player p = new Player($"Mängija {i+PlayerAmount}", '#');//заполнение 2 команды
                team2.AddPlayer(p);
            }

            Console.WriteLine("Staadioni mõõdud"); //размер стадиона
            Console.WriteLine("Laius: "); //длинна
            Console.ForegroundColor = ConsoleColor.Blue;
            string widthstr = Console.ReadLine();
            Console.ResetColor();
            int width = int.Parse(widthstr);

            
            Console.WriteLine("Kõrgus: "); //ширина
            Console.ForegroundColor = ConsoleColor.Blue;
            string heightstr = Console.ReadLine();
            Console.ResetColor();
            int height = int.Parse(heightstr);

            Console.WriteLine("Mängu kestus sekundites: "); //время игры
            Console.ForegroundColor = ConsoleColor.Blue;
            string durationstr = Console.ReadLine();
            Console.ResetColor();
            int duration = int.Parse(durationstr);

            Console.WriteLine("Mängu kiirus 1-3: "); //скоростт
            Console.ForegroundColor = ConsoleColor.Blue;
            string speedstr = Console.ReadLine();
            Console.ResetColor();
            int speedint = int.Parse(speedstr);

            int delay = 0; //задержка в милисекундах
            if (speedint == 1) {  delay = 1000; }
            else if (speedint == 2) {  delay = 800; }//чем больше скорость тем меньше задержка
            else if (speedint == 3) {  delay = 600; }
            else{
                Console.WriteLine("Vali kiirus, seatud keskmisele-2");
                delay = 800;
            }

            Console.WriteLine("Alustamiseks klõpsake ENTER");
            Console.ReadLine();


            Stadium stadium = new Stadium(width, height); //создаем стадион
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

            Game game = new Game(team1, team2, stadium); //создаем игру
            game.Start();

            int CalculateGameTime() //расчитиать время игры поделив длительность игры в милисекундах на задержку, это будет количество циклов
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
                //счет игры
                draw.DrawTekst(width + 20, 0, "Skoor(Palli tabamiste arv)");
                Console.ForegroundColor = ConsoleColor.Green;
                draw.DrawTekst(width+20, 1, "Team 1: " + team1.Score);
                Console.ForegroundColor = ConsoleColor.Blue;
                draw.DrawTekst(width + 20, 2, "Team 2: " + team2.Score);
                Console.ResetColor();
                //задержка
                Thread.Sleep(delay);
            }

            Console.Clear();
            //окончание игры
            Console.WriteLine("Game over");

            Console.ReadLine();

       

        }
    }
}
