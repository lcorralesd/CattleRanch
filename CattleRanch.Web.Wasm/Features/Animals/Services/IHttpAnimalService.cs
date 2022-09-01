using CattleRanch.Web.Wasm.Features.Animals.Models;

namespace CattleRanch.Web.Wasm.Features.Animals.Services;

public interface IHttpAnimalService
{
    Task<IReadOnlyList<AnimalModel>> GetAnimals();
}
