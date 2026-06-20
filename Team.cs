using System;
using System.Collections.Generic;

namespace kursach_footballtransfers_14a
{
    public class Team
    {
        private string name;
        private string country;
        private double budget;

        private List<Player> players = new List<Player>();
        private List<Coach> coaches = new List<Coach>();
        private List<Manager> managers = new List<Manager>();

        public Team()
        {
            Name = "Невідомий club";
            Country = "Невідомо";
            Budget = 0;
        }

        public Team(string name, string country, double budget)
        {
            Name = name;
            Country = country;
            Budget = budget;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Помилка: Назва клубу не може бути порожньою!");
                name = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Помилка: Країна не може бути порожньою!");
                country = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Помилка: Бюджет клубу не може бути негативним!");
                budget = value;
            }
        }

        public List<Player> Players { get { return players; } set { players = value; } }
        public List<Coach> Coaches { get { return coaches; } set { coaches = value; } }
        public List<Manager> Managers { get { return managers; } set { managers = value; } }

        public void AddCoach(Coach coach) { coaches.Add(coach); }
        public void AddManager(Manager manager) { managers.Add(manager); }
        public void AddPlayerDirectly(Player player) { players.Add(player); }

        public TransferList BuyPlayer(Player player, Team fromTeam)
        {
            if (Budget < player.TransferPrice)
            {
                throw new Exception($"Помилка: У клубу {Name} недостатньо грошей для купівлі {player.Pib}!");
            }

            Budget -= player.TransferPrice;
            Players.Add(player);

            if (fromTeam != null)
            {
                fromTeam.Budget += player.TransferPrice;
                fromTeam.Players.Remove(player);
            }

            return new TransferList(player.Pib, fromTeam?.Name ?? "Вільний агент", this.Name, player.TransferPrice);
        }

        public TransferList SellPlayer(Player player, Team toTeam)
        {
            if (!Players.Contains(player))
            {
                throw new Exception($"Помилка: Гравець {player.Pib} не грає за команду {Name}!");
            }

            Players.Remove(player);
            Budget += player.TransferPrice;

            if (toTeam != null)
            {
                toTeam.Budget -= player.TransferPrice;
                toTeam.Players.Add(player);
            }

            return new TransferList(player.Pib, this.Name, toTeam?.Name ?? "Вільний агент", player.TransferPrice);
        }

        public void PaySalaries()
        {
            double totalSalaries = 0;

            foreach (var p in Players) totalSalaries += p.Salary;
            foreach (var c in Coaches) totalSalaries += c.Salary;
            foreach (var m in Managers) totalSalaries += m.Salary;

            if (Budget < totalSalaries)
            {
                throw new Exception($"Помилка: У клубу {Name} немає грошей на виплату річної зарплати (${totalSalaries:N0})!");
            }

            Budget -= totalSalaries;
            Console.WriteLine($"[ЗАРПЛАТА] Клуб {Name} успішно виплатив річну зарплату всім працівникам на суму: ${totalSalaries:N0}");
        }

        public void PrintTeamInfo()
        {
            Console.WriteLine($"\n=== КОМАНДА: {Name} ({Country}) | Бюджет: ${Budget:N0} ===");

            Console.WriteLine("--- ТРЕНЕРИ ---");
            if (Coaches.Count == 0) Console.WriteLine("Немає тренерів");
            foreach (var c in Coaches) c.PrintInfo();

            Console.WriteLine("--- МЕНЕДЖЕРИ ---");
            if (Managers.Count == 0) Console.WriteLine("Немає менеджерів");
            foreach (var m in Managers) m.PrintInfo();

            Console.WriteLine("--- ГРАВЦІ ---");
            if (Players.Count == 0) Console.WriteLine("Немає гравців");

            for (int i = 0; i < Players.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                Players[i].PrintInfo();
            }

            Console.WriteLine("==================================================\n");
        }
    }
}