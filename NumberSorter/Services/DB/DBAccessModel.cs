using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NumberSorter.Services.DB
{
    public class DBAccessModel
    {
        public string GetConnectionString(string connectionName = "RecordedSorts")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    
        public Boolean AddSortedToDB(string sortedNumberString, string sortDirection, double sortTimeMillisec)
        {
            bool success = false;
            var cnn = new SqlConnection(GetConnectionString());

            try
            {
                cnn.Open();
                var command = new SqlCommand(null, cnn);

                //preparing preparedstatement
                command.CommandText = "INSERT INTO Sorts (sortedNumbers, sortDirection, sortTimeMillisec)" +
                    "values(@numbers, @direction, @time)";

                //setting pram
                var numbersParam = new SqlParameter("@numbers", SqlDbType.VarChar, sortedNumberString.Length);
                numbersParam.Value = sortedNumberString;
                command.Parameters.Add(numbersParam);


                var directionParam = new SqlParameter("@direction", SqlDbType.VarChar, sortDirection.Length);
                directionParam.Value = sortDirection;
                command.Parameters.Add(directionParam);


                var timeParam = new SqlParameter("@time", SqlDbType.Decimal);
                timeParam.Precision = 8;
                timeParam.Scale = 4;
                timeParam.Value = sortTimeMillisec;
                command.Parameters.Add(timeParam);

                //trying the query and checking
                command.Prepare();
                command.ExecuteNonQuery();

                //checking if entry is entered
                command.CommandText = "select * from Sorts where sortedNumbers=@numbers " +
                        "and sortTimeMillisec = @time " +
                        "and sortDirection=@direction;";

                command.Prepare();
                
                success = command.ExecuteReader().HasRows;
            } 
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                cnn.Close();
            }
            return success;
        }
        
        public List<Object> GetAllAsJson()
        {
            var resultJson = new List<Object>();
            var cnn = new SqlConnection(GetConnectionString());

            try
            {
                cnn.Open();
                var command = new SqlCommand(null, cnn);

                command.CommandText = "select * from Sorts";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var temp = new List<object>();
                    temp.Add(reader["sortedNumbers"].ToString());
                    temp.Add(reader["sortTimeMillisec"]);
                    temp.Add(reader["sortDirection"]);

                    resultJson.Add(temp);
                }
                
                cnn.Close();

            }
            catch (SqlException)
            {
                resultJson.Add("SQL Exception");
            }
                catch (Exception)
            {
                resultJson.Add("Unknown Error");
            }
            finally
            {
            cnn.Close();
            }

            return resultJson;
        }

        //used to clean test data
        public bool removeFromDB(string sortedNumberString, string sortDirection, double sortTimeMillisec)
        {
            int affected = 0;
            bool successful;

            var cnn = new SqlConnection(GetConnectionString());
            
            try
            {
                cnn.Open();
                var command = new SqlCommand(null, cnn);

                command.CommandText = "delete from Sorts where sortedNumbers=@numbers " +
                        "and sortTimeMillisec = @time " +
                        "and sortDirection=@direction;" ;

                var numbersParam = new SqlParameter("@numbers", SqlDbType.VarChar, sortedNumberString.Length);
                numbersParam.Value = sortedNumberString;
                command.Parameters.Add(numbersParam);


                var directionParam = new SqlParameter("@direction", SqlDbType.VarChar, sortDirection.Length);
                directionParam.Value = sortDirection;
                command.Parameters.Add(directionParam);


                var timeParam = new SqlParameter("@time", SqlDbType.Decimal);
                timeParam.Precision = 8;
                timeParam.Scale = 4;
                timeParam.Value = sortTimeMillisec;
                command.Parameters.Add(timeParam);

                //trying the query and checking
                
                    command.Prepare();
                    affected = command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                successful =  false;
            }
            finally
            {
                cnn.Close();
            }
            

            if (affected == 1)
                successful = true;
            else
                successful = false;

            return successful;
        }
    
    }

}