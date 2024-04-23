using Microsoft.AspNetCore.Mvc;
using Tuto_5.Controllers.DTOs;
using Tuto_5.Controllers.DAL;



namespace Tuto_5.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AnimalsControllers : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalsControllers(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string orderBy = "name")
    {
        var animals = await _animalRepository.GetAnimals(orderBy);
        return Ok(animals);

    }

    [HttpPost]
    public IActionResult Post(AnimalDto animal)
    {
        _animalRepository.AddAnimal(animal);
        return Ok();
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult Delete(int idAnimal)
    {
        _animalRepository.DeleteAnimal(idAnimal);
        return Ok();
    }

    [HttpPut("{idAnimal}")]
    public IActionResult Put(int idAnimal, AnimalDto animal)
    {
        _animalRepository.UpdateAnimal(idAnimal, animal);
        return Ok();
    }
}