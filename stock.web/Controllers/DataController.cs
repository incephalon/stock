using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using stock.web.Models;

namespace stock.web.Controllers
{
    public class DataController : Controller
    {
        private const string connectionString = "Server=localhost;Database=world;Uid=manager;Pwd=123letmein";

        public ActionResult Index()
        {
            List<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    return View();
                }

                MySqlCommand command = new MySqlCommand("SELECT * FROM City LIMIT 0, 50", connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                    while (reader.Read())
                    {
                        City city = new City
                                        {
                                            ID = Convert.ToInt32(reader["ID"]),
                                            Name = reader["Name"] as string,
                                            CountryCode = reader["CountryCode"] as string,
                                            District = reader["District"] as string,
                                            Population = Convert.ToUInt32(reader["population"])
                                        };

                        cities.Add(city);
                    }

                connection.Close();
            }

            return View(cities);
        }

    }
}
