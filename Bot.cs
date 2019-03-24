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
    }
}
