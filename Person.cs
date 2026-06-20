namespace kursach_footballtransfers_14a
{
    public class Person
    {
        private string pib;
        private int age;
        private int height;

        public Person()
        {
            Pib = "Невідомо";
            Age = 18;
            Height = 175;
        }

        public Person(string pib, int age, int height)
        {
            Pib = pib;
            Age = age;
            Height = height;
        }

        public string Pib
        {
            get { return pib; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Помилка: ПІБ не може бути порожнім!");
                pib = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 14 || value > 80)
                    throw new ArgumentOutOfRangeException("Помилка: Вік має бути від 14 до 80 років!");
                age = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 130 || value > 230)
                    throw new ArgumentOutOfRangeException("Помилка: Ріст має бути від 130 до 230 см!");
                height = value;
            }
        }

        public virtual void PrintInfo()
        {
            Console.Write($"ПІБ: {Pib} | Вік: {Age} | Ріст: {Height} см");
        }
    }
}