namespace KomisSigma1.Models
{
    public class RodzajNadwozia
    {
        public int ID { get; set; }
        public string Rodzaj { get; set; }
        public ICollection<Samochodzik> Samochodziks { get; } = new List<Samochodzik>();
    }
}