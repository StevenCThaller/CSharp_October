using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQ
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public User(string fName, string lName, string email, int age)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            Age = age;
        }
    }

    class Program
    {   
        static void Main(string[] args)
        {
            List<User> Data = new List<User>()
            {
                new User("Bill", "Gates", "bgates@microsoft.com", 52),
                new User("Elon", "Musk", "emusk@tesla.com", 43),
                new User("Steve", "Wozniak", "thewoz@apple.com", 57),
                new User("Steve", "Jobs", "sjobs@apple.com", 65),
                new User("Albert", "Einstein", "thisis@relative.com", 138),
                new User("Nikola", "Tesla", "ih8edison@fu.com", 200),
                new User("Thomas", "Edison", "ikillelephants@dc.com", 200)
            }; 

            // Syntax
            // Collection followed by the Method (optional) conversion


            // .Where() -> return a collection of all entries that match a query
                // I want to retrieve all users younger than 75 years old
            List<User> LessThanOld = Data.Where(u => u.Age < 75).OrderByDescending(u => u.Age).ToList();
            
            // function(parameter) --> parameter is each individual object

            // .Any() -> return a boolean based on whether or not there are ANY entries that match a given query
            bool IsJoe = Data.Any(u => u.FirstName == "Joe");
            bool AtMicrosoft = Data.Any(u => u.Email.Contains("@microsoft.com"));
            // .All() -> return a boolean based on whether or not ALL of the entries match the given query
            bool AllOverThirty = Data.All(u => u.Age > 30);
            // .FirstOrDefault() => return the FIRST entry that matches, or if none exists, returns null
            User Elon = Data.FirstOrDefault(u => u.FirstName == "Elon");
            User Steven = Data.FirstOrDefault(u => u.FirstName == "Steven");
            // .Select() => return everything, but the .Select() is going to actually choose a single attribute
            List<string> Emails = Data.Select(u => u.Email).ToList();

            List<string> LivingMemberEmails = Data.Where(u => u.Age < 100).Select(u => u.Email).ToList();
            // .Min()/.Max() => returns the minimum or maximum of a collection
            List<int> Numbers = new List<int>(){ 23,567,23,57,89,34,32,54,11,3};
            int Min = Numbers.Min();
            int Max = Numbers.Max();

            int OldestAge = Data.Where(u => u.FirstName == "Steve").Max(u => u.Age);
            User OldestUser = Data.FirstOrDefault(u => u.Age == OldestAge);


        }
    }
}
