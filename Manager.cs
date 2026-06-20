using System;

namespace kursach_footballtransfers_14a
{
    public class Manager : Person
    {
        private double salary;

        public Manager() : base()
        {
            Salary = 0;
        }

        public Manager(string pib, int age, int height, double salary)
            : base(pib, age, height)
        {
            Salary = salary;
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
            Console.WriteLine($" | Менеджер | Зарплата/рік: ${Salary:N0}");
        }
    }
}