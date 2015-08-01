using SIS.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Framework.DbUtility;
using System.Data;
using System.Data.SqlTypes;

namespace SIS.Framework.Repository
{
   public interface ICourseRepository:IGenericRepository<Course>
    {
    }

   public class CourseRepository : ICourseRepository {

       private DbConnection _Connection;
       public CourseRepository()
       {
           _Connection=new DbConnection("ConnectionString");
       }
       public int insert(Course c)
       {
           string sql = "INSERT INTO Courses(Name, Description, Price, Duration, DurationType, AddedDate, Status)";
           sql += "VALUES(@Name, @Description, @Price, @Duration, @DurationType, @AddedDate, @Status)";
           _Connection.Open();
           _Connection.InitCommand(sql, CommandType.Text);

           _Connection.AddInputParameter("@Name", c.Name, SqlDbType.VarChar);
           _Connection.AddInputParameter("@Description", c.Description, SqlDbType.VarChar);
           _Connection.AddInputParameter("@Price", c.Description, SqlDbType.Decimal);
           _Connection.AddInputParameter("@Duration", c.Duration, SqlDbType.Int);
           _Connection.AddInputParameter("@DurationType", c.DurationType, SqlDbType.VarChar);
           _Connection.AddInputParameter("@AddedDate", new SqlDateTime(c.AddedDate), SqlDbType.DateTime);
           _Connection.AddInputParameter("@Status", c.Status, SqlDbType.Bit);

           int result = _Connection.ExecuteNonQuery();
           _Connection.Close();
               return result;
       }

       public List<Course> GetALL()
       {
           List<Course> _CourseList = new List<Course>();
           String sql = "SELECT * FROM Courses";
           _Connection.InitCommand(sql, CommandType.Text);
           IDataReader reader = _Connection.ExecuteReader();
           while(reader.Read())
           {
               Course c = new Course();
               c.Id = Convert.ToInt32(reader["Id"]);
               c.Name = reader["Name"].ToString();
               c.Description = reader["Description"].ToString();
               c.Price = Convert.ToDecimal(reader["Price"]);
               c.Duration = Convert.ToInt32(reader["Duration"]);
               c.DurationType = reader["DurationType"].ToString();
               c.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
               c.Status = Convert.ToBoolean(reader["Status"]);

               _CourseList.Add(c);

           }

           _Connection.Close();
           return _CourseList;
       }
   }
}
