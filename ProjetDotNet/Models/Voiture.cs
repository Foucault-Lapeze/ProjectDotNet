namespace ProjetDotNet.Models;

public class Voiture
{
    public int Id { get; set; }
    public string Marque { get; set; }
    public string Modele { get; set; }
    public string Immatriculation { get; set; }
    public string AdressePropriétaire { get; set; }
    
    public class VoitureDto
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
    }
}