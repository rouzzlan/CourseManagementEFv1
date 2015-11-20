using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CM_EF.Models
{
  public class Course
  {
    [Key]
    public int CourseId { get; set; }
    [StringLength(20)]
    [Required]
    public string Name { get; set; }
    [StringLength(25)]
    public string Teacher { get; set; }
    public CourseType CourseType { get; set; }
    public DateTime? StartDate { get; set; }
    public bool LaptopRequired { get; set; }
    public int MaximumParticipants { get; set; }
    public double? Price { get; set; }

    public override string ToString()
    {
      return String.Format("*) Course {0} ({1}) is an {2} course, "
      + "will be given by {3}, "
      + "starts on {4}, costs {5:0.0} and "
      + "will have maximum {6} participants"
      , Name, CourseId, CourseType, Teacher
      , StartDate.HasValue
      ? StartDate.Value.ToString("dd/MM/yyyy")
      : "?"
      , Price ?? 0
      , MaximumParticipants);
    }
  }
}
