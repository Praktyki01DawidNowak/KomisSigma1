﻿namespace KomisSigma1.Models
{
    public class Model
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Samochodzik> Samochodziks { get; } = new List<Samochodzik>();

    }
}