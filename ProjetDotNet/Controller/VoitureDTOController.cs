using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controller;


    [Route("api/[controller]")]
    [ApiController]
    public class VoitureDTOController : ControllerBase
    {
        // Création de voiture pour pouvoir tester directement 
        private static readonly List<Voiture> voitures = new List<Voiture>
        {
            new Voiture { Id = 1, Marque = "Peugeot", Modele = "208", Immatriculation = "AB-123-CD", AdressePropriétaire = "Paris" },
            new Voiture { Id = 2, Marque = "Renault", Modele = "Clio", Immatriculation = "EF-456-GH", AdressePropriétaire = "Toulouse" },
            new Voiture { Id = 3, Marque = "Tesla", Modele = "Model 3", Immatriculation = "IJ-789-KL", AdressePropriétaire = "Marseille" }
        };
        
        // GET: GetAll 
        [HttpGet]
        public ActionResult<IEnumerable<Voiture.VoitureDto>> GetAll()
        {
            var voituresDto = voitures.Select(v => new Voiture.VoitureDto
            {
                Id = v.Id,
                Marque = v.Marque,
                Modele = v.Modele
            }).ToList();

            return Ok(voituresDto);
        }
        
        // GET: GetById
        [HttpGet("voitureById/{id}")]
        public ActionResult<IEnumerable<Voiture.VoitureDto>> GetById(int id)
        {
            var voiture = voitures.Find(v => v.Id == id);

            if (voiture == null)
            {
                return NotFound();
            }

            var dto = new Voiture.VoitureDto
            {
                Id = voiture.Id,
                Marque = voiture.Marque,
                Modele = voiture.Modele
            };

            return Ok(dto);
        }
        
        //Get: Get Recherche
        [HttpGet("recherche")]
        public ActionResult<IEnumerable<Voiture.VoitureDto>> GetBySearch([FromQuery] string recherche)
        {
            if (string.IsNullOrWhiteSpace(recherche))
                return BadRequest("Veuillez entrer un terme de recherche.");

            var resultats = voitures
                .Where(v =>
                    v.Marque.Contains(recherche, StringComparison.OrdinalIgnoreCase) ||
                    v.Modele.Contains(recherche, StringComparison.OrdinalIgnoreCase) ||
                    v.Immatriculation.Contains(recherche, StringComparison.OrdinalIgnoreCase));

            return Ok(resultats);
        }
        
    }
