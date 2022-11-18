namespace KooliProjekt.Data
{
    public class Reservationcs
    {
        public int ID { get; set; }
        public int AutoID { get; set; }

        public string bron_len_min { get; set; }

        public int KM { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }
    }
}

