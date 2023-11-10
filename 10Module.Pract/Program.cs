using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Module.Pract
{
    public interface IPart
    {
        void Build();
    }

    // Интерфейс для рабочих
    public interface IWorker
    {
        void Work(House house);
    }

    // Классы частей дома
    public class Basement : IPart
    {
        public void Build()
        {
            Console.WriteLine("Basement is built");
        }
    }

    public class Walls : IPart
    {
        public void Build()
        {
            Console.WriteLine("Walls are built");
        }
    }

    public class Door : IPart
    {
        public void Build()
        {
            Console.WriteLine("Door is installed");
        }
    }

    public class Window : IPart
    {
        public void Build()
        {
            Console.WriteLine("Window is installed");
        }
    }

    public class Roof : IPart
    {
        public void Build()
        {
            Console.WriteLine("Roof is built");
        }
    }

    // Классы для строителей
    public class Worker : IWorker
    {
        public void Work(House house)
        {
            Console.WriteLine("Worker is working");
        }
    }

    public class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            Console.WriteLine("Team leader is supervising the work");
        }

        public void Report(House house)
        {
            Console.WriteLine("Team leader is providing a report on the progress");
        }
    }

    // Класс для бригады строителей
    public class Team
    {
        private List<IWorker> workers;

        public Team(List<IWorker> workers)
        {
            this.workers = workers;
        }

        public void BuildHouse(House house)
        {
            foreach (var worker in workers)
            {
                worker.Work(house);

                // Проверка, является ли текущий работник бригадиром
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(house);
                }
            }
        }
    }

    // Класс для дома
    public class House
    {
        private List<IPart> parts;

        public House()
        {
            parts = new List<IPart>();
        }

        public void AddPart(IPart part)
        {
            parts.Add(part);
        }

        public void ShowHouse()
        {
            Console.WriteLine("The house is complete. Here is the structure:");

            foreach (var part in parts)
            {
                part.Build();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            House house = new House();

            Team team = new Team(new List<IWorker>
        {
            new Worker(),
            new Worker(),
            new Worker(),
            new Worker(),
            new TeamLeader()
        });
            // Строим дом
            house.AddPart(new Basement());
            house.AddPart(new Walls());
            house.AddPart(new Walls());
            house.AddPart(new Walls());
            house.AddPart(new Walls());
            house.AddPart(new Door());
            house.AddPart(new Window());
            house.AddPart(new Window());
            house.AddPart(new Window());
            house.AddPart(new Window());
            house.AddPart(new Roof());

            // Бригада строителей строит дом
            team.BuildHouse(house);

            // Отображаем результат
            house.ShowHouse();

            Console.ReadLine();
        }
    }
}
