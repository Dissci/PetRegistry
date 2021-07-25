using System.Collections.Generic;
using Project1;
using Project1.Persistence.dto;

namespace Persistence
{
    interface IPersonRepository
    {
        List<Person> GetListofPetOwners();
        List<Overview> GetOverview(string[] IDs);
    }
}