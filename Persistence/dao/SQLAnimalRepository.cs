using Project1.Persistence.dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistence
{
    class SQLAnimalRepository : IAnimalRepository
    {
        private static String UPDATE_FEEDING = "UPDATE Animal SET FeedingCount = FeedingCount + 1 WHERE AnimalID = @animalID";

        private static String SELECT_PETS = @"SELECT
                                            pa.AnimalID,
                                            an.dogID,
	                                        an.catID,
                                            an.Birthday,
                                            an.FeedingCount,
                                            an.Name,
                                            d.SkillLevel,
                                            d.BodySize,
                                            c.isActive
                                        FROM
                                            Person pe
                                        JOIN
                                            P_A pa ON (pe.PersonID=pa.PersonID)
                                        JOIN
                                            Animal an ON (an.AnimalID=pa.AnimalID)
                                        LEFT JOIN
                                            Dog d ON (d.DogID=an.DogID)
                                        LEFT JOIN
                                            Cat c ON (c.CatID=an.CatID)
                                        WHERE (1=1)
                                            AND pe.PersonID = @personID";

        private string connection;
        public SQLAnimalRepository(string connection)
        {
            this.connection = connection;
        }
        public bool Feeding(long animalID)
        {
            int result = 0;
            using (var sqlConnection = new SqlConnection(connection))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = UPDATE_FEEDING;
                        command.Parameters.AddWithValue("@animalID", animalID);
                        result = command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurs on feeding " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return result > 0;
        }
        

        public List<Animal> GetListofPets(long personID)
        {
            var list = new List<Animal>();
            using (var sqlConnection = new SqlConnection(connection))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = SELECT_PETS;
                        command.Parameters.AddWithValue("@personID", personID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long animalID = reader.GetInt64(0);
                                long dogID = reader.IsDBNull(1) ? default(long) : reader.GetInt64(1);
                                long catID = reader.IsDBNull(2) ? default(long) : reader.GetInt64(2);
                                DateTime birthday = reader.GetDateTime(3);
                                int feedingCount = reader.GetInt32(4);
                                string name = reader.GetString(5);
                                Animal animal = null;
                                if (dogID != 0L)
                                {
                                    short skillLevel = reader.GetInt16(6);
                                    int bodySize = reader.GetInt32(7);
                                    animal = new Dog(dogID, skillLevel, bodySize, animalID, birthday, feedingCount, name);
                                }
                                else if (catID != 0L)
                                {
                                    bool isActive = reader.GetBoolean(8);
                                    animal = new Cat(catID, animalID, birthday, feedingCount, name, isActive);
                                }
                                else
                                {
                                    animal = new Animal(animalID, birthday, feedingCount, name);
                                }
                                list.Add(animal);
                            }
                            reader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurs on getListofPets " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return list;
        }
    }
}