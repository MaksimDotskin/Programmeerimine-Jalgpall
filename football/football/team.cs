using System;
using System.Collections.Generic;

namespace Football
{

    public class Team
    {
        public List<Player> Players { get; } = new List<Player>(); //список обьектов класса player
        public string Name { get; private set; }
        public Game Game { get; set; }
        public int Score {  get; set; }

        public Team(string name,int score)//конструктор обекта team
        {
            Name = name;
            Score = score;
        }

        public void StartGame(int width, int height) //метод начала игры
        {
            Random rnd = new Random();// рандомное значение 
            foreach (var player in Players)// перебирается каждый обект из списка 
            {
                player.SetPosition(            //задать позицию
                    rnd.NextDouble() * width,       //по горизонатли
                    rnd.NextDouble() * height     //по вертикали
                    );
            }
        }

        public void AddPlayer(Player player) //метод добавить игрока
        {
            if (player.Team != null) return;   //если у игрока нет команды, то возврощаем ничего
            Players.Add(player); //добавить игрока
            player.Team = this;
        }

        public (double, double) GetBallPosition() //получить позицию мяча
        {
            return Game.GetBallPositionForTeam(this); //вернуть позицию мяча
        }

        public void SetBallSpeed(double vx, double vy) //задать скорость мяча
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        public Player GetClosestPlayerToBall() //получить ближвйшего игрока к мячу
        {
            Player closestPlayer = Players[0]; //массив 
            double bestDistance = Double.MaxValue;
            foreach (var player in Players) //каждый игрок из массива
            {
                var distance = player.GetDistanceToBall(); //получить дистанцию
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        public void Move() //джигаться 
        {
            GetClosestPlayerToBall().MoveTowardsBall();
            Players.ForEach(player => player.Move());
        }
    }
}