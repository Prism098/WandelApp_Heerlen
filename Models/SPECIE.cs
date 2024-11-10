using ExotischNederlandKaasus.DAL;

namespace ExotischNederlandKaasus.Models
{
    internal class SPECIE
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public int SpecieId { get; private set; }
        public string Name { get; set; }
        public string? InvasivenessLevel { get; set; }
        public List<OBSERVATION> Observations { get; set; } = new List<OBSERVATION>(); // Not being used by program but was here to visualize the relationship between the two classes. Used to adding these for EF.

        //Constructors that are being used to make database calls
        public SPECIE(string name, string? invasivenessLevel)
        {
            Name = name;
            InvasivenessLevel = invasivenessLevel;
        }
        public SPECIE(int specieId, string name, string? invasivenessLevel)
        {
            SpecieId = specieId;
            Name = name;
            InvasivenessLevel = invasivenessLevel;
        }

        public void SetSpecieId(int id)
        {
            SpecieId = id;
        }         // Method for auto incrementing the ID ( Must be auto inc due to database restrictions )

        // Interaction with the database methods.
        public void AddSpecie()
        {
            sqlDAL.AddSpecie(this);
        }
        public void UpdateSpecie(SPECIE specie)
        {
            sqlDAL.UpdateSpecie(specie);
        }
        public List<SPECIE> GetSpecies()
        {
            return sqlDAL.GetSpecies();
        }
        public void DeleteSpecie()
        {
            sqlDAL.DeleteSpecie(this.SpecieId);
        }
    }
}
