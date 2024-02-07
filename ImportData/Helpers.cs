using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProcessData
{
    public static class Helpers
    {
        public static string BuildSelectQuery(string tableName, string[] columns = null, int? topRows = null,
           string orderColumn = null, bool sortAscending = true)
        {
            StringBuilder query = new StringBuilder("SELECT ");
            if (topRows is not null)
            {
                query.Append($"TOP {topRows} ");
            }
            if (columns is not null)
            {
                query.Append("[");
                query.Append(string.Join("], [", columns));
                query.Append("]");
            }
            else
            {
                query.Append("*");
            }
            query.Append($" FROM [{tableName}] ");
            if (orderColumn is not null)
            { 
                query.Append($"ORDER BY [{orderColumn}] {(sortAscending ? "ASC" : "DESC")} ");
            }
            return query.ToString();
        }
        public static DataTable ConvertRatesToDataTable(IList<Rate> rates)
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.Rates";
            foreach (PropertyInfo prop in typeof(Rate).GetProperties())
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (Rate rate in rates)
            {
                dt.Rows.Add(new string[] { rate.Currency, rate.Code, rate.Mid.ToString() });
            }
            return dt;
        }
    }
}
