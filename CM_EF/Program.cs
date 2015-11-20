using CM_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CM_EF
{
  class Program
  {
    static CM_EF.DAL.CMContext context;
    static void Main(string[] args)
    {
      context = new DAL.CMContext();
      SearchCourseByNumber(1);
      Console.WriteLine("Done!");
      Console.ReadLine();
    }
    private static void DeleteCourse()
    {
      IEnumerable<Course> allCourses = context.Courses.ToList<Course>();
      foreach (var item in allCourses)
      {
        if (item.Name.Contains("Web Design"))
          context.Courses.Remove(item);
      }
      context.SaveChanges();
    }

    private static void ShowCourses()
    {
      IEnumerable<Course> allCourses = context.Courses.AsEnumerable<Course>();
      //IEnumerable<Course> allCourses = context.Courses.ToList<Course>();
      foreach (var course in allCourses)
        Console.WriteLine(course);
    }
    private static void UpdateCourses()
    {
      IEnumerable<Course> allCourses = context.Courses.AsEnumerable<Course>();
      foreach (var item in allCourses)
        item.Price = item.Price * 1.1;
      context.SaveChanges();
    }
    private static void ShowCoursesWithAPrice()
    {
      IEnumerable<Course> coursesWithAPrice
      = context.Courses.Where<Course>(HasThisCourseAPrice).AsEnumerable<Course>();
      Console.Write("{0} courses has a price\n", coursesWithAPrice.Count<Course>());
    }
    private static bool HasThisCourseAPrice(Course course)
    {
      return course.Price.HasValue;
    }
    private static void ShowCoursesWithAPrice2()
    {
      IEnumerable<Course> coursesWithAPrice
      = context.Courses.Where<Course>(delegate (Course course)
      {
        return course.Price.HasValue;
      })
      .AsEnumerable<Course>();
      Console.Write("{0} courses has a price\n", coursesWithAPrice.Count<Course>());
    }
    private static void ShowCoursesWithAPrice3()
    {
      IEnumerable<Course> coursesWithAPrice
      = context.Courses.Where<Course>(course => course.Price.HasValue)
      .AsEnumerable<Course>();
      Console.Write("{0} courses has a price\n", coursesWithAPrice.Count<Course>());
    }
    private static void ShowCoursesWithAPrice4()
    {
      var coursesWithAPrice
      = context.Courses.Where<Course>(course => course.Price.HasValue);
      Console.Write("{0} courses has a price\n", coursesWithAPrice.Count<Course>());
    }
    private static void SearchCourseByText(string searchText)
    {
      var requestedCourses = context.Courses
      .Where<Course>(c => c.Name.Contains(searchText))
      .AsEnumerable<Course>();
      foreach (var item in requestedCourses)
        Console.WriteLine(item);
    }
    private static void SearchCourseByNumber(int nbr)
    {
      var course = context.Courses.Single<Course>(c => c.CourseId == nbr);
      Console.WriteLine(course);
    }
  }
}
