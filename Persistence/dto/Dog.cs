
using System;

namespace Project1.Persistence.dto
{
    class Dog : Animal 
    {

        private long dogID {get;}
        private short skillLevel { get; }
        private int bodySize { get; }
        public Dog(long dogID, short skillLevel, int bodySize, long animalID, DateTime birthday, int feedingCount, string name) : base(animalID, birthday, feedingCount, name)
        {
            this.dogID = dogID;
            this.skillLevel = skillLevel;
            this.bodySize = bodySize;
        }

        public override string ToString()
        {
            return base.ToString() + " dogID: " + dogID + ", skillLevel: " + skillLevel + ", bodySize: " + bodySize + " }";
        }
    }
}