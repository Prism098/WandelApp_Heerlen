using ExotischNederlandKaasus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederlandKaasus.Models
{
    internal class SPECIE
    {
        public int SpecieId { get; private set; }
        public string Name { get; set; }
        public string? InvasivenessLevel { get; set; }
        public List<OBSERVATION> Observations { get; set; }

        public SPECIE()
        {
            
        }
        // Method to set the SpecieId in the Specie Class
        public void SetSpecieId(int id)
        {
            SpecieId = id;
        }


        // SPECIE METHODS FOR DATABASE INTERACTIONS
        //private SPECIE AddSpecie(SPECIE specie)
        //{
        //    // Add specie to database
        //    string query = "INSERT INTO SPECIE (Name, InvasivenessLevel) " +
        //        "VALUES (@Name, @InvasivenessLevel)";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Name", specie.Name);
        //    command.Parameters.AddWithValue("@InvasivenessLevel", specie.InvasivenessLevel);

        //    try
        //    {
        //        connection.Open();
        //        command.ExecuteNonQuery();

        //        // Retrieve the auto-incremented ID
        //        command.CommandText = "SELECT CAST(scope_identity() AS INT)";
        //        int addId = (int)command.ExecuteScalar();
        //        specie.SpecieId = addId;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions 
        //        throw new Exception("An error occurred while adding the specie.", ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return specie;
        //}


        //public void DeleteSpecie(int specieId)
        //{
        //    try
        //    {

        //        string sql = "DELETE FROM Player WHERE Id=@Id";
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            command.Parameters.AddWithValue("@Id", specieId);
        //            command.ExecuteNonQuery();
        //        }

        //        connection.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}

    }
}
