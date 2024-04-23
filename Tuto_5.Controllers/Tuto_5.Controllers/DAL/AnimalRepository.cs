using Microsoft.Data.SqlClient;
using Tuto_5.Controllers.DTOs;



namespace Tuto_5.Controllers.DAL;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;

    }


    public void AddAnimal(AnimalDto animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        using SqlCommand command = new SqlCommand();
        command.CommandText = "INSERT INTO ANIMAL VALUES (@Id, @Name,  @Description, @Category, @Area)";
        command.Parameters.AddWithValue("@Id", animal.Id);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        command.Connection = connection;
        connection.Open();
        _ = command.ExecuteNonQuery();
    }


    public void DeleteAnimal(int idAnim)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        using SqlCommand command = new SqlCommand("DELETE FROM ANIMAL WHERE IDANIMAL = @idAnimal", connection);
        command.Parameters.AddWithValue("@idAnimal", idAnim);
        connection.Open();
        int rowsDeleted = command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine(rowsDeleted);
    }

    public async Task<IEnumerable<AnimalDto>> GetAnimals(string orderBy = "Name")
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        using SqlCommand command = new SqlCommand();
        command.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {orderBy}";
        command.Connection = connection;
        await connection.OpenAsync();
        using SqlDataReader reader = await command.ExecuteReaderAsync();

        var list = new List<AnimalDto>();
        while (reader.Read())
        {
            var animal = new AnimalDto()
            {
                Id = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Area = reader["Area"].ToString()
            };
            list.Add(animal);
        }
        return list;
    }

    public void UpdateAnimal(int animalId, AnimalDto animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        using SqlCommand command = new SqlCommand($"UPDATE ANIMAL SET Name=@Name, description=@description, category=@category, area=@area WHERE IDANIMAL=@animalId", connection);
        command.Connection=connection;
        connection.Open();
        command.Parameters.AddWithValue("@animalId", animalId);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        int rowsUpdated = command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine(rowsUpdated);
    }

    }


     
    
