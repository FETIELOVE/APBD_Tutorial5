using Tuto_5.Controllers.DTOs;

namespace Tuto_5.Controllers.DAL;

public interface IAnimalRepository
{
    Task<IEnumerable<AnimalDto>> GetAnimals(string orderBy = "name");
    void AddAnimal (AnimalDto animalDto);
    void UpdateAnimal(int idAnimal, AnimalDto animalDto);
    void DeleteAnimal(int idAnimal);
}