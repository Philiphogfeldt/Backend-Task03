namespace Backend_Task03.Models
{
    public class Beer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Percentage { get; set; }
        public string Brewery { get; set; }
        public string Country { get; set; }
        public string EAN13 { get; set; }
        public bool? GoesFish { get; set; }
        public bool? GoesMeat { get; set; }
        public bool? GoesVeg { get; set; }
        public bool? GoesBird { get; set; }
        public bool? GoesDessert { get; set; }

        public List<Review>? Reviews { get; set; }

        //Glöm ej uppdatera EAN-code till not null senare

        //account kan inte creata ny review om man redan har en review på den ölen
    }
}
