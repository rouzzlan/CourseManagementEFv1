using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace CM_EF.DAL
{
  public class CMContext : DbContext
  {
    public CMContext() : base("myCM_EF")
    {
      Database.SetInitializer<CMContext>(new CMInitializer());
    }
    public DbSet<Models.Course> Courses { get; set; }
  }
}
