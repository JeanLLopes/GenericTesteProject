using GenericTestProject.Model;
using GenericTextProject.Generic;
using System;
using System.Collections.Generic;

namespace GenericTestProject
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Person> people = new List<Person>();
            List<Log> logs = new List<Log>();

            var peopleFile = @"C:\Users\JEAN-NOTE\AppData\Local\Temp\people.txt";
            var logFile = @"C:\Users\JEAN-NOTE\AppData\Local\Temp\log.txt";

            /* New way of doing things - generics */
            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<Log>(logs, logFile);


            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            }


            var newLogs = GenericTextFileProcessor.LoadFromTextFile<Log>(logFile);

            foreach (var log in newLogs)
            {
                Console.WriteLine($"{ log.ErrorCode }: { log.Message } at { log.TimeOfEvent.ToShortTimeString() }");
            }


        }

        private static void PopulateLists(List<Person> people, List<Log> logs)
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new Log { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new Log { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new Log { Message = "I was tired", ErrorCode = 2222 });
        }
    }


}
