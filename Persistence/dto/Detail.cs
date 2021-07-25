using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Persistence.dto
{
    public class Detail
    {
        public long personID { get; }
        public List<Animal> pets { get; }
        public string avgAge { get; }

        public Detail(long personID, List<Animal> pets, string avgAge)
        {
            this.personID = personID;
            this.pets = pets;
            this.avgAge = avgAge;
        }
    }
}
