using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NumberSorter.Models.DB
{
    public static class DBAccessModel{

        public static string getConnectionString(string connectionName = "RecordedSorts"){

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    
        public static Boolean addSortedToDB(string sortedNumberString, string sortDirection, double sortTimeMillisec){

            bool success = false;
            using (SqlConnection cnn = new SqlConnection(getConnectionString())){

                cnn.Open();
                SqlCommand command = new SqlCommand(null, cnn);

                //preparing preparedstatement
                command.CommandText = "INSERT INTO Sorts (sortedNumbers, sortDirection, sortTimeMillisec)" +
                    "values(@numbers, @direction, @time)";

                //setting pram
                SqlParameter numbersParam = new SqlParameter("@numbers", SqlDbType.VarChar, sortedNumberString.Length);
                numbersParam.Value = sortedNumberString;
                command.Parameters.Add(numbersParam);


                SqlParameter directionParam = new SqlParameter("@direction", SqlDbType.VarChar, sortDirection.Length);
                directionParam.Value = sortDirection;
                command.Parameters.Add(directionParam);


                SqlParameter timeParam = new SqlParameter("@time", SqlDbType.Decimal);
                timeParam.Precision = 8;
                timeParam.Scale = 4;
                timeParam.Value = sortTimeMillisec;
                command.Parameters.Add(timeParam);

                //trying the query and checking
                try{

                    command.Prepare();
                    command.ExecuteNonQuery();

                    //checking if entry is entered
                    command.CommandText = "select * from Sorts where sortedNumbers=@numbers " +
                        "and sortTimeMillisec = @time " +
                        "and sortDirection=@direction;";

                    command.Prepare();
                    success = command.ExecuteReader().HasRows;

                }catch (SqlException){

                    cnn.Close();
                    return false;

                }catch (Exception){

                    cnn.Close();
                    return false;
                }
                cnn.Close();
            }

            return success;
        }
        
        public static List<Object> getAllAsJson(){

            List<Object> resultJson = new List<Object>();
            using (SqlConnection cnn = new SqlConnection(getConnectionString())){

                try{

                    cnn.Open();
                    SqlCommand command = new SqlCommand(null, cnn);

                    command.CommandText = "select * from Sorts";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()){
                        List<Object> temp = new List<object>();
                        temp.Add(reader["sortedNumbers"].ToString());
                        temp.Add(reader["sortTimeMillisec"]);
                        temp.Add(reader["sortDirection"]);

                        resultJson.Add(temp);
                    }


                    cnn.Close();

                }catch (SqlException){

                    cnn.Close();
                    resultJson.Add("SQL Exception");
                    return resultJson;

                }catch (Exception){

                    cnn.Close();
                    resultJson.Add("Unknown Error");
                    return resultJson;
                }
            }
                return resultJson;
        }

        //used to clean test data
        public static Boolean removeFromDB(string sortedNumberString, string sortDirection, double sortTimeMillisec){
            int affected = 0;

            using (SqlConnection cnn = new SqlConnection(getConnectionString())){

                cnn.Open();
                SqlCommand command = new SqlCommand(null, cnn);

                command.CommandText = "delete from Sorts where sortedNumbers=@numbers " +
                        "and sortTimeMillisec = @time " +
                        "and sortDirection=@direction;" ;

                SqlParameter numbersParam = new SqlParameter("@numbers", SqlDbType.VarChar, sortedNumberString.Length);
                numbersParam.Value = sortedNumberString;
                command.Parameters.Add(numbersParam);


                SqlParameter directionParam = new SqlParameter("@direction", SqlDbType.VarChar, sortDirection.Length);
                directionParam.Value = sortDirection;
                command.Parameters.Add(directionParam);


                SqlParameter timeParam = new SqlParameter("@time", SqlDbType.Decimal);
                timeParam.Precision = 8;
                timeParam.Scale = 4;
                timeParam.Value = sortTimeMillisec;
                command.Parameters.Add(timeParam);

                //trying the query and checking
                try
                {
                    command.Prepare();
                    affected = command.ExecuteNonQuery();

                }
                catch (SqlException)
                {

                    cnn.Close();
                    return false;

                }
                catch (Exception)
                {

                    cnn.Close();
                    return false;
                }
                cnn.Close();
            }

            if (affected == 1)
                return true;
            else
                return false;
        }
    
    }

}