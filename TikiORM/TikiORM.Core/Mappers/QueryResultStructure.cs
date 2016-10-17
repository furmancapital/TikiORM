using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    /// <summary>
    /// This is a helper class to associate field name to index to improve ado.net field access
    /// but not forcing it to perform a look up every time and allow to query by name
    /// while having this class perform the translations to the numeric field index
    /// </summary>
    public class QueryResultStructure
    {
        private Dictionary<string, int> FieldNameToIndex
        {
            get;
            set;
        }

        public QueryResultStructure()
        {
            this.FieldNameToIndex = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Helper method to create and populate the result from the datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static QueryResultStructure FromDataReader (IDataReader dataReader)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException(nameof(dataReader));
            }

            var result = new QueryResultStructure();

            for (var fieldIndex = 0; fieldIndex < dataReader.FieldCount; fieldIndex++)
            {
                result.AddColumn(dataReader.GetName(fieldIndex), fieldIndex);
            }

            return result;
        }

        public void AddColumn (string columnName, int fieldIndex)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            try
            {
                this.FieldNameToIndex.Add(columnName, fieldIndex);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"{columnName} has already been added. It appears you have a duplicate column name! This is unsupported.");
            }
        }

        public int GetColumnIndex (string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            try
            {
                return this.FieldNameToIndex[columnName];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"No column named {columnName} was found in the result.");
            }
        }

        public IEnumerable<string> GetColumns()
        {
            return this.FieldNameToIndex.Keys;
        }
    }
}
