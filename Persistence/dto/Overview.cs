using Evidence.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Persistence.dto
{
    public class Overview
    {
        public int selectedPeople { get; }
        public int selectedPets { get; }
        public int avgPetPerPerson { get; }
        public string avgAge { get; }

        public Overview(int selectedPeople, int selectedPets, int avgPetPerPerson, DateTime avgAge)
        {
            this.selectedPeople = selectedPeople;
            this.selectedPets = selectedPets;
            this.avgPetPerPerson = avgPetPerPerson;
            this.avgAge = DateTimeUtils.ToAgeString(avgAge);
        }

        public override string ToString()
        {
            return "[selectedPeople: " + selectedPeople + " selectedPets: " + selectedPets + "avgPetPerPerson: " + avgPetPerPerson + " avgAge: " + avgAge + "]";
        }
    }
}
