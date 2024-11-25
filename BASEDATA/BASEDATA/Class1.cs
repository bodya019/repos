using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System.Collections;

namespace BASEDATA
{
    internal class DB
    {
        private const string HOST = "localHost";
        private const string PORT = "3306";
        private const string BASEDATA = "bogdan";
        private const string USER = "root";
        private const string PASS = "root";
        private readonly string connect;

        public DB()
        {
            connect = $"Server={HOST};User={USER};Password={PASS};Database={BASEDATA};Port={PORT}";
        }

        public async Task CreateTable()
        {
            string sql = "";
            await ExecutEQuery(sql);
        }
              
       

        private async Task ExecutEQuery(string sql, Dictionary<string,string?>? paremetrs = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                await conn.OpenAsync();

                MySqlCommand command = new MySqlCommand(sql, conn);
                if (paremetrs != null)
                {
                    foreach (var item in paremetrs)
                    {
                        MySqlParameter param = new MySqlParameter($"@{item.Key}", item.Value);

                        command.Parameters.Add(param);
                    }
                }

                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task Getdate()
        {
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                await conn.OpenAsync();

                MySqlCommand command = new MySqlCommand("SELECT * FROM jyman", conn);
                MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        object id = reader["id"];
                        object text = reader["text"];
                        object title = reader["title"];
                        object avtor = reader["avtor"];
                        Console.WriteLine($"{id}. {title} - {avtor}");
                    }
                }
                await reader.CloseAsync();
            }
        }
        public async Task UpdateData(string? title, string? text, string? date, string? avtor)
        {
            Dictionary<string, string?> parametrs = new Dictionary<string, string?>();
            parametrs.Add("title", title);
            parametrs.Add("text", text);
            parametrs.Add("date", date);
            parametrs.Add("avtor", avtor);

            string sql = "UPDATE jyman SET title = @title, text = @text, date = @date, avtor = @avtor WHERE id = 2";
            await ExecutEQuery(sql, parametrs);

        }
    }
}
