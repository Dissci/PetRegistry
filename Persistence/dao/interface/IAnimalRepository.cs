using Project1.Persistence.dto;
using System.Collections.Generic;

namespace Persistence
{
    interface IAnimalRepository {
        List<Animal> GetListofPets(long personID);
        bool Feeding(long animalID);
    }
}