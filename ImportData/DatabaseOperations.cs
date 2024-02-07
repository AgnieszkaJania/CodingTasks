using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProcessData
{
    public static class DatabaseOperations
    {
        private const string _connectionString = "Data Source=.;Initial Catalog=CodingTasks;Integrated Security=True";
        public static async Task CreateRatesTableAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = @"IF (OBJECT_ID('dbo.Rates', 'U') IS NULL)
                        BEGIN
                            CREATE TABLE Rates (
                                 ID INT IDENTITY(1,1)
                                , Currency NVARCHAR(255) NOT NULL
                                , Code CHAR(3) NOT NULL
                                , Mid MONEY NOT NULL
                                , CONSTRAINT PK_Rates_ID PRIMARY KEY(ID)
                              )
                        END";
                    _printSqlCommand(command.CommandText);
                    try
                    {
                        conn.Open();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static async Task SaveDataToDatabaseAsync(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    bulkCopy.DestinationTableName = dt.TableName;
                    try
                    {
                        await bulkCopy.WriteToServerAsync(dt);
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                
            }
        }
        public static async Task TruncateTableAsync(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"IF (OBJECT_ID('dbo.Rates', 'U') IS NOT NULL) BEGIN TRUNCATE TABLE [{tableName}] END";
                    _printSqlCommand(command.CommandText);
                    try
                    {
                        conn.Open();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static DataTable QueryTable(string query)
        {   
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = query;
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            conn.Open();
                            da.Fill(dt);
                        }
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return dt;
        }
        private static void _printSqlCommand(string sqlCommand)
        {
            Console.WriteLine(sqlCommand);
        }
    }
}
