using System;

namespace kursach_footballtransfers_14a
{
    public class Coach : Person
    {
        private int experience;
        private double salary;

        public Coach() : base()
        {
            Experience = 0;
            Salary = 0;
        }

        public Coach(string pib, int age, int height, int experience, double salary)
            : base(pib, age, height)
        {
            Experience = experience;
            Salary = salary;
        }

        public int Experience
        {
            get { return experience; }
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentException("Помилка: Досвід тренера має бути від 0 до 60 років!");
                experience = value;
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
            Console.WriteLine($" | Тренер | Досвід: {Experience} років | Зарплата/рік: ${Salary:N0}");
        }
    }
}