using System;
using System.Collections.Generic;
using Evidence.utils;

namespace Project1.Persistence.dto
{
    public class Person {

        public long personID {get;}
        public string name {get; set;}
        public string surname {get; set;}

        public Person(long personID, string name, string surname) {
            this.personID = personID;
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return "{ ID: " + personID + ", name:" + name + ", surname: " + surname + " }"; 
        }
    }
}