using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotImporter
{
    class BotImporter
    {
        private string m_BotSearchPath;

        public BotImporter(string m_Directory)
        {
            this.m_BotSearchPath = m_Directory;
        }

        /// <summary>
        /// Starts the bot search
        /// </summary>
        public void Start()
        {
            if (!Directory.Exists(m_BotSearchPath))
            {
                Log.WriteError("The directory: " + m_BotSearchPath);
                Log.WriteError("Does not exist");
                return;
            }

            string[] botData = Directory.GetFiles(m_BotSearchPath, "*", SearchOption.AllDirectories);

            foreach (string botFile in botData)
            {
                string fileName = Path.GetFileName(botFile);

                if (fileName != "config.ini")
                    continue;

                ParseBotConfiguration(botFile);
            }
        }

        /// <summary>
        /// Parse the bot configuration file
        /// </summary>
        /// <param name="fileName">the path to the configuration</param>
        private void ParseBotConfiguration(string fileName)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();

                foreach (string line in File.ReadAllLines(fileName))
                {
                    if (!line.Contains("="))
                        continue;

                    if (line.StartsWith("text"))
                        continue;

                    int index = line.IndexOf("=");
                    string key = line.Substring(0, index);
                    string value = line.Substring(index + 1);

                    values.Add(key, value);
                }

                Bot bot = new Bot(
                    values["name"],
                    values["mission"],
                    values["location"],
                    values["figure"],
                    values["look"],
                    values["walkspace"].Replace(" ", "|").Replace(",", " ").Replace("|", ","),
                    values["roomname"]
                );

                bot.printValues();
                bot.save();
            }
            catch (Exception ex)
            {
                Log.WriteError("Error occurred: " + ex);
            }
        }
    }
}