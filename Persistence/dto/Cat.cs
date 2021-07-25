
using System;

namespace Project1.Persistence.dto
{
    class Cat : Animal {
        private long catID { get; }
        private bool isActive { get; }

        public Cat(long catID, long animalID, DateTime birthday, int feedingCount, string name, bool isActive) : base(animalID, birthday, feedingCount, name)
        {
            this.catID = catID;
            this.isActive = isActive;
        }

        public override string ToString()
        {
            return base.ToString() + " catID: " + catID + ", isActive: " + isActive + " }";
        }
    }
}