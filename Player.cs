using System;

namespace kursach_footballtransfers_14a
{
    public class Player : Person
    {
        private string position;
        private double transferPrice;
        private double salary;

        public Player() : base()
        {
            Position = "Вільний агент";
            TransferPrice = 0;
            Salary = 0;
        }

        public Player(string pib, int age, int height, string position, double transferPrice, double salary)
            : base(pib, age, height)
        {
            Position = position;
            TransferPrice = transferPrice;
            Salary = salary;
        }

        public string Position
        {
            get { return position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Помилка: Позиція гравця не може бути порожньою!");
                position = value;
            }
        }

        public double TransferPrice
        {
            get { return transferPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Помилка: Трансферна ціна не може бути негативною!");
                transferPrice = value;
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Помилка: Зарплата не може бути негативною!");
                salary = value;
            }
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" | Позиція: {Position} | Ціна: ${TransferPrice:N0} | Зарплата/рік: ${Salary:N0}");
        }
    }
}