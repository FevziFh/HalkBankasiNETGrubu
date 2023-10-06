using _32_EF_StudentCourseTeacher.Contexts;
using _32_EF_StudentCourseTeacher.Models;

namespace _32_EF_StudentCourseTeacher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContex())
            {
                var course = new Course()
                {
                    CreateDate= DateTime.Now,
                    DeleteDate= DateTime.Now,
                    UpdateDate= DateTime.Now,
                    Status=Enums.Status.Active,
                    Title="Matematik",
                    Teacher = new Teacher()
                    {
                        CreateDate = DateTime.Now,
                        DeleteDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Status=Enums.Status.Active,
                        Name ="Fatih"
                    },
                    Students = new List<Student>() 
                    { 
                        new Student() 
                        {
                            CreateDate= DateTime.Now,
                            DeleteDate= DateTime.Now,
                            UpdateDate= DateTime.Now,
                            Status=Enums.Status.Active,
                            Name="Furkan"
                        },
                        new Student()
                        {
                            CreateDate= DateTime.Now,
                            DeleteDate= DateTime.Now,
                            UpdateDate= DateTime.Now,
                            Status=Enums.Status.Active,
                            Name="Furkan Kartal"
                        },
                        new Student()
                        {
                            CreateDate= DateTime.Now,
                            DeleteDate= DateTime.Now,
                            UpdateDate= DateTime.Now,
                            Status=Enums.Status.Active,
                            Name="Ahmet Balcı"
                        }
                    }
                };

                context.Add(course);
                context.SaveChanges();
            }

            Console.WriteLine("Başarılı");
        }
    }
}