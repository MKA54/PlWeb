using Microsoft.Data.Sqlite;
using plumsailbackend.Models;

namespace plumsailbackend.Repository
{
    public static class FormTable
    {
        public static void CreateFormTable()
        {
            using var connection = new SqliteConnection("Data Source=./Repository/Data/forms.db;Mode=ReadWriteCreate;");
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());        
            connection.Open();

            var command = new SqliteCommand        
            {
                 Connection = connection,
                 CommandText = "CREATE TABLE IF NOT EXISTS Forms " +
                               "(" +
                                "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                "first_name TEXT NOT NULL, " +
                                "last_name TEXT NOT NULL," +
                                "car_model TEXT NOT NULL," +
                                "engine_type TEXT NOT NULL," +
                                "checked_options TEXT" +
                               ")"
            };

            command.ExecuteNonQuery();
        }

        public static void AddForm(Form form)
        {
            using var connection = new SqliteConnection("Data Source=./Repository/Data/forms.db");
            connection.Open();

            var insertText = "INSERT INTO Forms (" +
                             "first_name, " +
                             "last_name, " +
                             "car_model, " +
                             "engine_type, " +
                             "checked_options) " +
                             "VALUES (" +
                             "'" + form.FirstName + "', " +
                             "'" + form.LastName + "', " +
                             "'" + form.CarModel + "', " +
                             "'" + form.EngineType + "'";

            var checkedOptions = string.Join(", ", form.CheckedOptions.ToArray());

            if (!string.IsNullOrEmpty(checkedOptions))
            {
                insertText += ", " +
                              "'" + checkedOptions + "')";
            }
            else
            {
                insertText += ", 'NULL')";
            }

            var command = new SqliteCommand
            {
                Connection = connection,
                CommandText = insertText
            };

            command.ExecuteNonQuery();
        }

        public static List<Form> GetAllForms()
        {
            return ReadingDatabase("SELECT * FROM forms");
        }

        public static List<Form> GetRequiredForms(string param)
        {
            var sqlExpression = "SELECT * FROM forms " +
                                       "WHERE first_name = '" + param + "'";

            var result = ReadingDatabase(sqlExpression);
            if (result.Count > 0)
            {
                return result;
            }

            sqlExpression = "SELECT * FROM forms " +
                                "WHERE last_name = '" + param + "'";

            result = ReadingDatabase(sqlExpression);
            if (result.Count > 0)
            {
                return result;
            }

            sqlExpression = "SELECT * FROM forms " +
                                "WHERE car_model = '" + param + "'";

            result = ReadingDatabase(sqlExpression);
            if (result.Count > 0)
            {
                return result;
            }

            sqlExpression = "SELECT * FROM forms " +
                            "WHERE engine_type = '" + param + "'";

            result = ReadingDatabase(sqlExpression);
            if (result.Count > 0)
            {
                return result;
            }

            sqlExpression = "SELECT * FROM forms " +
                            "WHERE checked_options LIKE '%" + param + "%'";

            result = ReadingDatabase(sqlExpression);
            if (result.Count > 0)
            {
                return result;
            }

            return new List<Form>();
        }

        private static List<Form> ReadingDatabase(string sqlExpression)
        {
            var forms = new List<Form>();

            using (var connection = new SqliteConnection("Data Source=./Repository/Data/forms.db"))
            {
                connection.Open();

                var command = new SqliteCommand(sqlExpression, connection);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = (long)reader.GetValue(0);
                        var firstName = (string)reader.GetValue(1);
                        var lastName = (string)reader.GetValue(2);
                        var carModel = (string)reader.GetValue(3);
                        var engineType = (string)reader.GetValue(4);
                        var checkedOptions = (string?)reader.GetValue(5);

                        forms.Add(new Form(id, firstName, lastName, carModel, engineType, checkedOptions));
                    }
                }
            }

            return forms;
        }

    }
}
