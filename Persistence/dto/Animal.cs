using System;
using Evidence.utils;

namespace Project1.Persistence.dto
{
    public class Animal
    {
        public long animalID { get; }
        public DateTime birthday {get;}
        public int feedingCount { get; }
        public string name { get; }

        public Animal(long animalID, DateTime birthday, int feedingCount, string name) {
            this.animalID = animalID;
            this.birthday = birthday;
            this.feedingCount = feedingCount;
            this.name = name;
        }

        public override string ToString()
        {
            return "{ animalID: " + animalID + ", name: " + name + ", age: " + DateTimeUtils.ToAgeString(birthday) + ", feedingCount: " + feedingCount;
        }
    }
}