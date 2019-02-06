using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private static List<Person> familyList = new List<Person>();

        public static  void AddMember(Person person)
        {
            familyList.Add(person);
        }

        public static Person GetOldestMember()
        {
            Person person = familyList.OrderByDescending(x=>x.Age).FirstOrDefault();

            return person;
        }
    }
}