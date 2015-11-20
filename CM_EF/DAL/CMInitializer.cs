using CM_EF.Models;
using System;
using System.Data.Entity;
namespace CM_EF.DAL
{
  public class CMInitializer : DropCreateDatabaseAlways<CMContext>
  {
    protected override void Seed(CMContext context)
    {
      Course c1 = new Course() {
        CourseType = CourseType.Online,
        LaptopRequired = true,
        MaximumParticipants = 150,
        Name = "Programming in Java",
        Price = 564.14,
        StartDate = new DateTime(2015, 12, 9),
        Teacher = "Johan Ven"
      }; //Cut-and-paste deze code uit program.cs
      Course c2 = new Course() {
        CourseType = CourseType.OnCampus,
        LaptopRequired = true,
        MaximumParticipants = 40,
        Name = " Programming in .NET",
        Price = 225.50,
        StartDate = new DateTime(2016, 1, 10),
        Teacher = "Kenneth De Keulenaer"
      }; //Cut-and-paste deze code uit program.cs
      Course c3 = new Course() {
        CourseType = CourseType.OnCampus,
        LaptopRequired = false,
        MaximumParticipants = 25,
        Name = "Web Design 1",
        Price = 120.48,
        StartDate = new DateTime(2014, 11, 10),
        Teacher = null
      }; //Cut-and-paste deze code uit program.cs
      context.Courses.Add(c1);
      context.Courses.Add(c2);
      context.Courses.Add(c3);
      /*alles staat nog in het geheughen enpas op het moment van uitvoeren van save changes wordt alles uit het 
      geheugen opgeslagen in de databank*/
      context.SaveChanges();
    }
  }
}