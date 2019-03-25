using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotImporter
{
    class Bot
    {
        public string Name { get; set; }
        public string Mission { get; set; }
        public string Location { get; set; }
        public string Figure { get; set; }
        public string Look { get; set; }
        public string Walkspace { get; set; }
        public string RoomName { get; set; }

        public Bot(string m_Name, string m_Mission, string m_Location, string m_Figure, string m_Look, string m_Walkspace, string m_RoomName)
        {
            this.Name = m_Name;
            this.Mission = m_Mission;
            this.Location = m_Location;
            this.Figure = m_Figure;
            this.Look = m_Look;
            this.Walkspace = m_Walkspace;
            this.RoomName = m_RoomName;
        }

        /// <summary>
        /// Print all the values of the bots
        /// </summary>
        internal void printValues()
        {
            string json = JsonConvert.SerializeObject(this);
            Console.WriteLine("[JSON] " + json);
        }

        internal void save()
        {
            var databaseString = new MySqlConnectionStringBuilder();
            databaseString.Server = "localhost";
            databaseString.Port = 3306;
            databaseString.UserID = "root";
            databaseString.Password = "123";
            databaseString.Database = "dev";
            databaseString.MinimumPoolSize = 5;
            databaseString.MaximumPoolSize = 10;
            databaseString.SslMode = MySqlSslMode.None;

            string[] coords = Location.Split(' ');

            using (MySqlConnection conn = new MySqlConnection(databaseString.ToString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO rooms_bots (name, mission, x, y, start_look, figure, walkspace, roomname) VALUES (@name, @mission, @x, @y, @start_look, @figure, @walkspace, @roomname)", conn);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@mission", Mission);
                cmd.Parameters.AddWithValue("@x", int.Parse(coords[0]));
                cmd.Parameters.AddWithValue("@y", int.Parse(coords[1]));
                cmd.Parameters.AddWithValue("@start_look", Look);
                cmd.Parameters.AddWithValue("@figure", Figure);
                cmd.Parameters.AddWithValue("@walkspace", Walkspace);
                cmd.Parameters.AddWithValue("@roomname", RoomName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
