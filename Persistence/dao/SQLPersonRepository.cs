using Project1.Persistence.dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Persistence
{
    class SQLPersonRepository : IPersonRepository
    {
        private static String SELECT_PERSON = @"SELECT
                                                PersonID,
                                                Name,
                                                Surname
                                            FROM 
                                                Person";

        private static String SELECT_OVERVIEW = @"SELECT 
	                                                count(xx.PersonID) selectedPeople,
	                                                SUM(xx.AnimalIDs) selectedPets,
	                                                SUM(xx.AnimalIDs)/count(xx.PersonID) avgPetsCount,
	                                                CAST(CAST(AVG(xx.value) AS DATETIME) AS DATE) avgDateTime
                                                FROM
	                                                (SELECT
		                                                pe.PersonID,
		                                                count(an.AnimalID) AnimalIDs,
		                                                avgAge.value
	                                                FROM
		                                                Person pe
	                                                LEFT JOIN
		                                                P_A pa 
	                                                ON 
		                                                (pe.PersonID=pa.PersonID)
	                                                LEFT JOIN
		                                                Animal an 
	                                                ON 
		                                                (an.AnimalID=pa.AnimalID)
	                                                LEFT JOIN (	SELECT 
					                                                pa.PersonID
					                                                ,AVG(CAST(CAST(an.Birthday AS DATETIME) AS INT)) AS value
				                                                FROM 
					                                                Animal an
				                                                LEFT JOIN 
					                                                P_A pa 
				                                                ON 
					                                                (an.AnimalID=pa.AnimalID)
				                                                GROUP BY
					                                                pa.PersonID
				                                                ) AS avgAge 
	                                                ON 
		                                                (avgAge.PersonID=pe.PersonID)
	                                                WHERE (1=1)
		                                                AND pe.PersonID IN ({0})
	                                                GROUP BY
		                                                pe.PersonID,
		                                                avgAge.value,
		                                                pe.name,
		                                                pe.surname
		                                                ) xx";
        private string connection;

        public SQLPersonRepository(string connection) {
            this.connection = connection;
        }                                                
        public List<Person> GetListofPetOwners()
        {
            var list = new List<Person>();
            using (var sqlConnection = new SqlConnection(connection))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = SELECT_PERSON;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Person(reader.GetInt64(0),
                                                    reader.GetString(1),
                                                    reader.GetString(2)
                                                    ));
                            }
                            reader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurs on GetListofPetOwners " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return list;
        }

        public List<Overview> GetOverview(string[] IDs)
        {
            var list = new List<Overview>();
            using (var sqlConnection = new SqlConnection(connection))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        var index = 0;
                        var idParameterList = new List<string>();
                        foreach (var id in IDs)
                        {
                            var paramName = "@idParam" + index;
                            command.Parameters.AddWithValue(paramName, id);
                            idParameterList.Add(paramName);
                            index++;
                        }
                        command.CommandText = String.Format(SELECT_OVERVIEW, string.Join(",", idParameterList));
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Overview(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2),
                                                    reader.GetDateTime(3)
                                                    ));
                            }
                            reader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurs on GetOverviewInformation " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return list;
        }
    }
}    