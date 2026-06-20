using System;

namespace kursach_footballtransfers_14a
{
    public class TransferList
    {
        private string playerName;
        private string fromTeam;
        private string toTeam;
        private double price;

        public TransferList()
        {
            playerName = "Невідомо";
            fromTeam = "Невідомо";
            toTeam = "Невідомо";
            price = 0;
        }

        public TransferList(string playerName, string fromTeam, string toTeam, double price)
        {
            PlayerName = playerName;
            FromTeam = fromTeam;
            ToTeam = toTeam;
            Price = price;
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public string FromTeam
        {
            get { return fromTeam; }
            set { fromTeam = value; }
        }

        public string ToTeam
        {
            get { return toTeam; }
            set { toTeam = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentException("Ціна не може бути менше нуля.");
                price = value;
            }
        }

        public void PrintTransfer()
        {
            Console.WriteLine($"[ТРАНСФЕР] Гравець: {PlayerName} | З клубу: {FromTeam} -> В клуб: {ToTeam} | Сума: ${Price:N0}");
        }
    }
}