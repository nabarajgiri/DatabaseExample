using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SIS.Framework.DbUtility
{
   public class DbConnection
    {
        SqlConnection _Connection = null;
        SqlCommand _Command = null;

        public DbConnection( string name) 
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }


        public string ConnectionString { get; set; }


        public void Open()
        {
            _Connection = new SqlConnection(ConnectionString);
            _Connection.Open();
           

        }

        public void  InitCommand(String sql, CommandType pCommandType) {
            _Command = new SqlCommand();
            _Command.CommandText=sql;
            _Command.CommandType=pCommandType;
            _Command.Connection=_Connection;
          
        
        }

        public void AddInputParameter(string param, Object value, SqlDbType dbType)
        {
           
            SqlParameter _paramater = new SqlParameter();
            _paramater.ParameterName = param;
            _paramater.Value = value;
            _paramater.SqlDbType = dbType;
            _paramater.Direction = ParameterDirection.Input;
            _Command.Parameters.Add(_paramater);
        }
      

        public int ExecuteNonQuery()
        {
            
           return _Command.ExecuteNonQuery();
        }
 

        public IDataReader ExecuteReader()
        {
            return _Command.ExecuteReader();
        }

        public void Close()
        {
            if (_Connection.State != ConnectionState.Closed && _Connection != null)
            {
                _Connection.Close();
                _Connection = null;
               
            }
           

        }
    }
}
