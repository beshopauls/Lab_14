using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab12;
using Lab_10;
using Lab_13;
namespace Lab_14
{
    /*
     1. Names of all male (female) persons.
     2. Names of students of the same course.
    19. Number of men (women).
    20. Number of students in the same course.
    37. Average score per session for a given student.
     Maximum - Minimum - Sumition score.
     */
   
    public class Program
    {
        public static void Work(University university)
        {
            Console.WriteLine(" Enter number of faculties");
            int number =3;
            //bool success = false;
            //do
            //{
            //    success = int.TryParse(Console.ReadLine(), out number);
            //    if(!success)
            //        Console.WriteLine(" Please Try againe");
            //}while (!success);
            Random rand = new Random();
            for (int i = 0; i < number; i++)
            {
                    Faculties faculty = new Faculties("Faculty "+ (i+1));
                    Student student1 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho"+rand.Next(1,4), true, "SW", rand.Next(1, 10));
                    Student student2 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), true, "Cs", rand.Next(1, 10));
                    Student student3 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), false, "SW", rand.Next(1, 10));
                    Student student4 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), true, "SW", rand.Next(1, 10));
                Student student5 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), true, "SW", rand.Next(1, 10));
                Student student6 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), true, "Cs", rand.Next(1, 10));
                Student student7 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), false, "SW", rand.Next(1, 10));
                Student student8 = new Student(rand.Next(100, 1000), 0, rand.Next(18, 30), "Bisho" + rand.Next(1, 4), true, "SW", rand.Next(1, 10));
                     Person person1 = new Person(student1.Id, student1.Age, student1.Name, student1.GenderMale);
                    Person person2 = new Person(student2.Id, student2.Age, student2.Name, student2.GenderMale);
                    Person person3 = new Person(student3.Id, student3.Age, student3.Name, student3.GenderMale);
                    Person person4 = new Person(student4.Id, student4.Age, student4.Name, student4.GenderMale);
                Person person5 = new Person(student5.Id, student5.Age, student5.Name, student5.GenderMale);
                Person person6 = new Person(student6.Id, student6.Age, student6.Name, student6.GenderMale);
                Person person7 = new Person(student7.Id, student7.Age, student7.Name, student7.GenderMale);
                Person person8 = new Person(student8.Id, student8.Age, student8.Name, student8.GenderMale);
                    faculty.FacultiesDictionary.Add(person1, student1);
                    faculty.FacultiesDictionary.Add(person2, student2);
                    faculty.FacultiesDictionary.Add(person3, student3);
                    faculty.FacultiesDictionary.Add(person4, student4);
                faculty.FacultiesDictionary.Add(person5, student5);
                faculty.FacultiesDictionary.Add(person6, student6);
                faculty.FacultiesDictionary.Add(person7, student7);
                faculty.FacultiesDictionary.Add(person8, student8);
                university.Faculties.Add(faculty);
            }
        }
        public static void NameMaleAndFemaleByLINQ(University university)
        {
            string namefaculty = "Faculty 1";
            Console.WriteLine(" Enter Name Faculty ");
           // namefaculty = Console.ReadLine();   

            //Query Syntax for Male
            IEnumerable<string> ListQueryMale = from list
                                         in (from dictionary
                                             in university.Faculties
                                             where dictionary.Name == namefaculty
                                             select dictionary).First().FacultiesDictionary 
                                          where list.Value.GenderMale == true 
                                          select list.Value.Name;
            Console.WriteLine(" Name Male by LINQ");
            foreach (var item in ListQueryMale)
                Console.WriteLine(" "+item.ToString());
            //Query Syntax for Female
            IEnumerable<string> ListQueryFemale = from list
                                         in (from dictionary
                                             in university.Faculties
                                             where dictionary.Name == namefaculty
                                             select dictionary).First().FacultiesDictionary
                                                where list.Value.GenderMale != true
                                                select list.Value.Name;
            Console.WriteLine(" Name Female by LINQ");
            Console.WriteLine(" Female : ");
            foreach (var item in ListQueryFemale)
                Console.WriteLine(" " + item.ToString());
        }
        public static void NameMaleAndFemaleByMethodExtension(University university)
        {
            string namefaculty = "Faculty 1";
            Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();

            Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
           //Method Syntax for male
            var ListQueryMale = university.Faculties
                                .Where(fact => fact.Name==namefaculty)
                                .First().FacultiesDictionary
                                .Where(std=> std.Value.GenderMale==true)
                                .Select(per => per.Value.Name);

            Console.WriteLine(" Name Male by Method Extension");
            foreach (var item in ListQueryMale)
                Console.WriteLine(" " + item.ToString());
            //Method Syntax for Female
            var ListQueryFemale = university.Faculties
                                   .Where(fact => fact.Name == namefaculty)
                                   .First().FacultiesDictionary
                                   .Where(std => std.Value.GenderMale == false)
                                   .Select(per => per.Value.Name);
            Console.WriteLine(" Name Male by Method Extension");
            foreach (var item in ListQueryFemale)
                Console.WriteLine(" " + item.ToString());
        }
        public static void NameStudentsInTheSameCourseByLINQ(University university)
        {
            string namefaculty = "Faculty 1", course = "SW";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();
            Console.WriteLine(" Enter Name course ");
            // course = Console.ReadLine();

            var ListQuerycourse = from list
                                         in (from dictionary
                                             in university.Faculties
                                             where dictionary.Name == namefaculty
                                             select dictionary).First().FacultiesDictionary
                                  where list.Value.Section == course
                                  select list.Value.Name;
            Console.WriteLine(" Name students that studing in the same course by LINQ");
            foreach (var item in ListQuerycourse)
                Console.WriteLine(" " + item.ToString());
        }
        public static void NameStudentsInTheSameCourseByMethodExtension(University university)
        {
            string namefaculty = "Faculty 1", course = "SW";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();
            Console.WriteLine(" Enter Name course ");
            // course = Console.ReadLine();

        

            Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
            //Method Syntax for male
            var ListQueryCourse = university.Faculties
                                .Where(fact => fact.Name == namefaculty)
                                .First().FacultiesDictionary
                                .Where(std => std.Value.Section == course)
                                .Select(per => per.Value.Name);



            Console.WriteLine(" Name students that studing in the same course by Method Extension");
            foreach (var item in ListQueryCourse)
                Console.WriteLine(" " + item.ToString());
        }
        public static void NumberOfMaleAndFemaleByLINQ(University university)
        {
            string namefaculty = "Faculty 1";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();

           
            var ListQueryMale = (from list
                                        in (from dictionary
                                            in university.Faculties
                                            where dictionary.Name == namefaculty
                                            select dictionary).First().FacultiesDictionary
                                  where list.Value.GenderMale == true 
                                  select list.Value).Count();
            Console.WriteLine(" Number of Male by LINQ = " + ListQueryMale);


            var ListQueryFemale = (from list
                                       in (from dictionary
                                           in university.Faculties
                                           where dictionary.Name == namefaculty
                                           select dictionary).First().FacultiesDictionary
                                 where list.Value.GenderMale == false
                                 select list.Value).Count();
            Console.WriteLine(" Number of Female by LINQ = " + ListQueryFemale);
        }

        public static void NumberOfMaleAndFemaleByMethodExtension(University university)
        {
            string namefaculty = "Faculty 1";
            Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();

            Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
            //Method Syntax for male
            var ListQueryMale = university.Faculties
                                .Where(fact => fact.Name == namefaculty)
                                .First().FacultiesDictionary
                                .Where(std => std.Value.GenderMale == true)
                                .Select(per => per.Value).Count();

            Console.WriteLine(" Number of Male by Method Extension = " + ListQueryMale);

            //Method Syntax for Female
            var ListQueryFemale = university.Faculties
                                   .Where(fact => fact.Name == namefaculty)
                                   .First().FacultiesDictionary
                                   .Where(std => std.Value.GenderMale == false)
                                   .Select(per => per.Value).Count();
            Console.WriteLine(" Number of Female by Method Extension = " + ListQueryFemale);
        }

        public static void NumberOfStudentsINTheSameCourseByLINQ(University university)
        {
            string namefaculty = "Faculty 1", course = "SW";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();
            Console.WriteLine(" Enter Name course ");
            // course = Console.ReadLine();



            var ListQuerycourse = (from list
                                        in (from dictionary
                                            in university.Faculties
                                            where dictionary.Name == namefaculty
                                            select dictionary).First().FacultiesDictionary
                                 where list.Value.Section == course
                                 select list.Value).Count();

            Console.WriteLine(" Number of students that studing in tha same course by LINQ = " + ListQuerycourse);


        }
        public static void NumberOfStudentsInTheSameCourseByMethodsExtension(University university)
        {
            string namefaculty = "Faculty 1", course = "SW";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();
            Console.WriteLine(" Enter Name course ");
            // course = Console.ReadLine();


            Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
            //Method Syntax for male
            var ListQuerycourse = university.Faculties
                                .Where(fact => fact.Name == namefaculty)
                                .First().FacultiesDictionary
                                .Where(std => std.Value.Section == course)
                                .Select(per => per.Value).Count();

            Console.WriteLine(" Number of students that studing in tha same course by Method Extension  = " + ListQuerycourse);



        }
        public static void AverageScoreForAllStudentByLINQ(University university)
        {
            string namefaculty = "Faculty 1";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();
            Console.WriteLine(" Enter Name course ");
            // course = Console.ReadLine();



            var ListQueryScore = (from list
                                        in (from dictionary
                                            in university.Faculties
                                            where dictionary.Name == namefaculty
                                            select dictionary).First().FacultiesDictionary
                                  select list.Value.Score).Average();

            Console.WriteLine(" Average score for students by LINQ " + ListQueryScore);
        }

        public static void AverageScoreForAllStudentByMethodExtension(University university)
        {
            string namefaculty = "Faculty 1";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();


            Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
            //Method Syntax for male
            var ListQueryScore = university.Faculties
                                .Where(fact => fact.Name == namefaculty)
                                .First().FacultiesDictionary
                                .Select(per => per.Value.Score).Average();

            Console.WriteLine(" Average score for students by Method Extension " + ListQueryScore);
        }
        public static void MaxMinAndSumByLINQ(University university)
        {
            string namefaculty = "Faculty 1";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();



            var ListQueryMaxScore = (from list
                                        in (from dictionary
                                            in university.Faculties
                                            where dictionary.Name == namefaculty
                                            select dictionary).First().FacultiesDictionary
                                  select list.Value.Score).Max();

            Console.WriteLine(" Maxmum score for student by LINQ " + ListQueryMaxScore);

            var ListQueryMinScore = (from list
                                       in (from dictionary
                                           in university.Faculties
                                           where dictionary.Name == namefaculty
                                           select dictionary).First().FacultiesDictionary
                                  select list.Value.Score).Min();

            Console.WriteLine(" Minimum score for student by LINQ " + ListQueryMinScore);

            var ListQuerySumScore = (from list
                                      in (from dictionary
                                          in university.Faculties
                                          where dictionary.Name == namefaculty
                                          select dictionary).First().FacultiesDictionary
                                     select list.Value.Score).Sum();

            Console.WriteLine(" Sumition score for students by LINQ " + ListQuerySumScore);
        }
      
        public static void MaxMinAndSumByMethodExtension(University university)
        {
            string namefaculty = "Faculty 1";
            // Console.WriteLine(" Enter Name Faculty ");
            // namefaculty = Console.ReadLine();


           // Func<KeyValuePair<Person, Student>, KeyValuePair<Person, Student>> func = delegate (KeyValuePair<Person, Student> students) { return students; };
            //Method Syntax for male
            var ListQueryMaxScore = university.Faculties
                                .Where(fact => fact.Name == namefaculty)
                                .First().FacultiesDictionary
                                .Select(per => per.Value.Score).Max();

            Console.WriteLine(" Maximum score for students by Method Extension " + ListQueryMaxScore);

            var ListQueryMinScore = university.Faculties
                               .Where(fact => fact.Name == namefaculty)
                               .First().FacultiesDictionary
                               .Select(per => per.Value.Score).Min();

            Console.WriteLine(" Minimum score for students by Method Extension " + ListQueryMinScore);

            var ListQuerySumScore = university.Faculties
                              .Where(fact => fact.Name == namefaculty)
                              .First().FacultiesDictionary
                              .Select(per => per.Value.Score).Sum();

            Console.WriteLine(" Sumition score for students by Method Extension " + ListQuerySumScore);
        }

        public static void UnionBetweenTwoFacultiesByLINQ(University university)
        {
            string namefaculty1 = "Faculty 1", namefaculty2 = "Faculty 2";
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty1 = Console.ReadLine();
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty2 = Console.ReadLine();
     
            var ListQueryUnion = (from list1 in 
                                      (from dic1 in university.Faculties
                                       where dic1.Name == namefaculty1
                                       select dic1.FacultiesDictionary).First()
                                  select list1.Value.Name)
                                  .Union(from list2 in
                                                 (from dic2 in university.Faculties
                                                  where dic2.Name == namefaculty2
                                                       select dic2.FacultiesDictionary).Last()
                                             select list2.Value.Name);



            Console.WriteLine(" Union by LINQ");
            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);

        }
        public static void UnionBetweenTwoFacultiesByMethodExtention(University university)
        {





            Func<KeyValuePair<Person, Student>,string> func = delegate (KeyValuePair<Person, Student> students) { return students.Value.Name; };

            var ListQueryUnion = university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).First().Select(func);
            ListQueryUnion = ListQueryUnion.Union(university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).Last().Select(func));
                                       



            Console.WriteLine(" Union by Method Extention");
            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);
        }
        public static void IntersectionBetweenTwoFacultiesByLINQ(University university)
        {
            string namefaculty1 = "Faculty 1", namefaculty2 = "Faculty 2";
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty1 = Console.ReadLine();
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty1 = Console.ReadLine();
            var ListQueryUnion = (from list1 in
                                      (from dic1 in university.Faculties
                                       where dic1.Name == namefaculty1
                                       select dic1.FacultiesDictionary).First()
                                  select list1.Value.Name)
                                  .Intersect(from list2 in
                                                 (from dic2 in university.Faculties
                                                  where dic2.Name == namefaculty2
                                                  select dic2.FacultiesDictionary).Last()
                                         select list2.Value.Name);



            Console.WriteLine(" Intersection by LINQ");

            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);

        }
        public static void IntersectionBetweenTwoFacultiesByMethodExtention(University university)
        {
            Func<KeyValuePair<Person, Student>, string> func = delegate (KeyValuePair<Person, Student> students) { return students.Value.Name; };

            var ListQueryUnion = university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).First().Select(func);
            ListQueryUnion = ListQueryUnion.Intersect(university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).Last().Select(func));




            Console.WriteLine(" Intersection by Method Extention");
            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);
        }
        public static void ConcatNamesByLINQ(University university)
        {
            string namefaculty1 = "Faculty 1", namefaculty2 = "Faculty 2";
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty1 = Console.ReadLine();
            // Console.WriteLine(" Enter Name Faculty 1 ");
            // namefaculty2 = Console.ReadLine();

            var ListQueryUnion = (from list1 in
                                      (from dic1 in university.Faculties
                                       where dic1.Name == namefaculty1
                                       select dic1.FacultiesDictionary).First()
                                  select list1.Value.Name)
                                  .Concat(from list2 in
                                                 (from dic2 in university.Faculties
                                                  where dic2.Name == namefaculty2
                                                  select dic2.FacultiesDictionary).Last()
                                         select list2.Value.Name);



            Console.WriteLine(" Concat by LINQ");
            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);
        }

        public static void ConcatNamesByMethodExtention(University university)
        {
            Func<KeyValuePair<Person, Student>, string> func = delegate (KeyValuePair<Person, Student> students) { return students.Value.Name; };

            var ListQueryUnion = university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).First().Select(func);
            ListQueryUnion = ListQueryUnion.Concat(university.Faculties.Select((Faculties facul) => facul.FacultiesDictionary).Last().Select(func));




            Console.WriteLine(" Concat by Method Extention");
            foreach (var item in ListQueryUnion)
                Console.WriteLine(item);
        }

        public static void GroupByLINQ(University university)
        {

            var ListQueryGroupByScore = from list in
                                            (from dictionary in university.Faculties
                                             select dictionary.FacultiesDictionary)
                                        select (from student in list group student.Value by student.Value.Name);


            int i = 1;
            Console.WriteLine(" Group by name by LINQ");
            foreach (var items in ListQueryGroupByScore)
            {
                Console.WriteLine( "Facutly " +  i);
                foreach (var item in items)
                {

                    Console.WriteLine("    Group : " + " " +item.Key);
                   
                    foreach (var it in item)
                        Console.WriteLine(it.Name);

                }
                i++;
            }
        }

        public static void GroupByMethodExtention(University university)
        {

            var ListQueryGroupByScore = university.Faculties
                                        .Select(list => list.FacultiesDictionary)
                                        .Select(dictionay => dictionay.GroupBy(student => student.Value.Name));

            int i = 1;
            Console.WriteLine(" Group by name by Method Extention");
            foreach (var items in ListQueryGroupByScore)
            {
                Console.WriteLine("Facutly " + i);
                foreach (var item in items)
                {

                    Console.WriteLine("    Group : " + " " + item.Key);

                    foreach (var it in item)
                        Console.WriteLine(it.Value.Name);

                }
                i++;
            }
        }
        public static void Print(University university)
        {
            foreach(var item in university.Faculties)
            {
                Console.WriteLine(" FacultyName : " + item.Name);
                foreach (KeyValuePair<Person,Student> dictionary in item.FacultiesDictionary)
                                Console.WriteLine(" Key : "+ dictionary.Key.Id.ToString() + "  "+ " Value  : "+dictionary.Value.Name.ToString() + "  "+ "Score : " + dictionary.Value.Score);
            }
        }

        
        static void Main(string[] args)
        {
            University university = new University();
            Work(university);
          
            Print(university);

            //NameMaleAndFemaleByLINQ(university);
            //NameMaleAndFemaleByMethodExtension(university);



            //NameStudentsInTheSameCourseByLINQ(university);
            //NameStudentsInTheSameCourseByMethodExtension(university);

            //NumberOfMaleAndFemaleByLINQ(university);
            //NumberOfMaleAndFemaleByMethodExtension(university);

            //NumberOfStudentsINTheSameCourseByLINQ(university);
            //NumberOfStudentsInTheSameCourseByMethodsExtension(university);

            //AverageScoreForAllStudentByLINQ(university);
            //AverageScoreForAllStudentByMethodExtension(university);


            //MaxMinAndSumByLINQ(university);
            //MaxMinAndSumByMethodExtension(university);

            //UnionBetweenTwoFacultiesByLINQ(university);
            //UnionBetweenTwoFacultiesByMethodExtention(university);


            //IntersectionBetweenTwoFacultiesByLINQ(university);
            //IntersectionBetweenTwoFacultiesByMethodExtention(university);

            //ConcatNamesByLINQ(university);
            //ConcatNamesByMethodExtention(university);


            GroupByLINQ(university);

            GroupByMethodExtention(university);

            Console.ReadKey();
        }
    }
}
