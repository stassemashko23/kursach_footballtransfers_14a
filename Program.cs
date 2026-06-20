using kursach_footballtransfers_14a;
using System;
using System.Collections.Generic;

namespace FootballManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Team barcelona = new Team("ФК Барселона", "Іспанія", 150000000);
            Team manCity = new Team("ФК Манчестер Сіті", "Англія", 250000000);

            Coach flick = new Coach("Ганс-Дітер Флік", 61, 180, 7, 7000000);
            Manager deco = new Manager("Деку", 48, 177, 3500000);
            barcelona.AddCoach(flick);
            barcelona.AddManager(deco);
            barcelona.AddPlayerDirectly(new Player("Ламін Ямал", 18, 178, "Нападник", 120000000, 5000000));
            barcelona.AddPlayerDirectly(new Player("Гаві", 21, 173, "Півзахисник", 90000000, 6000000));
            barcelona.AddPlayerDirectly(new Player("Педрі", 22, 174, "Півзахисник", 80000000, 5500000));
            barcelona.AddPlayerDirectly(new Player("Роберт Левандовський", 36, 185, "Нападник", 15000000, 10000000));
            barcelona.AddPlayerDirectly(new Player("Марк-Андре тер Штеген", 32, 187, "Воротар", 30000000, 7000000));

            Coach guardiola = new Coach("Пеп Гвардіола", 55, 180, 37, 20000000);
            Manager begiristain = new Manager("Чікі Бегірістайн", 61, 172, 5000000);
            manCity.AddCoach(guardiola);
            manCity.AddManager(begiristain);
            manCity.AddPlayerDirectly(new Player("Ерлінг Голанд", 25, 194, "Нападник", 180000000, 20000000));
            manCity.AddPlayerDirectly(new Player("Кевін Де Брейне", 34, 181, "Півзахисник", 70000000, 15000000));
            manCity.AddPlayerDirectly(new Player("Філ Фоден", 24, 171, "Півзахисник", 130000000, 12000000));
            manCity.AddPlayerDirectly(new Player("Родрі", 28, 191, "Півзахисник", 110000000, 14000000));
            manCity.AddPlayerDirectly(new Player("Едерсон", 31, 188, "Воротар", 40000000, 9000000));

            List<TransferList> history = new List<TransferList>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("                  ГОЛОВНЕ МЕНЮ           ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Вивести інформацію про клуби та їхні склади");
                Console.WriteLine("2. Купити гравця з ФК \"Манчестер Сіті\" у ФК \"Барселона\"");
                Console.WriteLine("3. Купити гравця з ФК \"Барселона\" у ФК \"Манчестер Сіті\"");
                Console.WriteLine("4. Симулювати виплату річної зарплати (Барселона)");
                Console.WriteLine("5. Симулювати виплату річної зарплати (Манчестер Сіті)");
                Console.WriteLine("6. Подивитися історію трансферів");
                Console.WriteLine("0. Вихід із програми");
                Console.WriteLine("==================================================");
                Console.Write("Оберіть дію (0-6): ");

                string choice = Console.ReadLine() ?? string.Empty;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            barcelona.PrintTeamInfo();
                            Console.WriteLine(new string('-', 50));
                            manCity.PrintTeamInfo();
                            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до меню...");
                            Console.ReadKey();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Оберіть гравця з ФК \"Манчестер Сіті\" для переходу в ФК \"Барселона\":");
                            manCity.PrintTeamInfo();
                            Console.Write("Введіть номер гравця: ");
                            if (int.TryParse(Console.ReadLine(), out int indexCity))
                            {
                                Player p = manCity.Players[indexCity - 1];
                                TransferList receipt = barcelona.BuyPlayer(p, manCity);
                                history.Add(receipt);
                                Console.Clear();
                                receipt.PrintTransfer();
                                Console.WriteLine("\nТранзакція успішно завершена! Натисніть клавішу...");
                                Console.ReadKey();
                            }
                            else
                            {
                                throw new Exception("Спроба викликати неіснуючу команду меню.");
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Оберіть гравця з ФК \"Барселона\" для переходу в ФК \"Манчестер Сіті\":");
                            barcelona.PrintTeamInfo();
                            Console.Write("Введіть номер гравця: ");
                            if (int.TryParse(Console.ReadLine(), out int indexBarca))
                            {
                                Player p = barcelona.Players[indexBarca - 1];
                                TransferList receipt = manCity.BuyPlayer(p, barcelona);
                                history.Add(receipt);
                                Console.Clear();
                                receipt.PrintTransfer();
                                Console.WriteLine("\nТранзакція успішно завершена! Натисніть клавішу...");
                                Console.ReadKey();
                            }
                            else
                            {
                                throw new Exception("Спроба викликати неіснуючу команду меню.");
                            }
                            break;

                        case "4":
                            Console.Clear();
                            barcelona.PaySalaries();
                            Console.ReadKey();
                            break;

                        case "5":
                            Console.Clear();
                            manCity.PaySalaries();
                            Console.ReadKey();
                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("==================================================");
                            Console.WriteLine("           ЖУРНАЛ ІСТОРІЇ ФУТБОЛЬНИХ ТРАНСФЕРІВ");
                            Console.WriteLine("==================================================");
                            if (history.Count == 0)
                            {
                                Console.WriteLine("Журнал порожній. Операцій не зафіксовано.");
                            }
                            else
                            {
                                foreach (var t in history)
                                {
                                    t.PrintTransfer();
                                }
                            }
                            Console.WriteLine("==================================================");
                            Console.ReadKey();
                            break;

                        case "0":
                            return;

                        default:
                            throw new Exception("Спроба викликати неіснуючу команду меню.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ПОМИЛКА] Трансфер скасовано! \n{ex.Message}");
                    Console.WriteLine("Натисніть будь-яку клавішу для повернення до головного меню...");
                    Console.ReadKey();
                }
            }
        }
    }
}