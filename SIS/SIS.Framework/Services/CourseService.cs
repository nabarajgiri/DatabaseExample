using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Framework.Models;
using SIS.Framework.Repository;

namespace SIS.Framework.Services
{
    public class CourseService
    {
        ICourseRepository _CourseRepository = new CourseRepository();
        public int insert(Course c)
        {
            return _CourseRepository.insert(c);
        }

        public List<Course> GetALL()
        {
            return _CourseRepository.GetALL();
        }
    }
}
