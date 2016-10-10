using FurmanCapitalTechGroup.TikiORM.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core
{

    public class RetrievalQueryExecutor<TItem>
    {
        public IResultMapper<TItem> ResultMapper
        {
            get;
            private set;
        }

        public IDictionary<string, object> Parameters
        {
            get;
            private set;
        }

        public string Query
        {
            get;
            private set;
        }

        public RetrievalQueryExecutor(string sqlQuery, 
            IDictionary<string, object> parameters,
            IResultMapper<TItem> resultMapper)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }


            if (resultMapper == null)
            {
                throw new ArgumentNullException(nameof(resultMapper));
            }


            this.Query = sqlQuery;
            this.ResultMapper = resultMapper;
            this.Parameters = parameters;
        }


        public List<TItem> PerformOnConnection(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            var results = new List<TItem>();

            using (var command = connection.CreateCommand())
            {
                GenerateComandParametersIfNecessary(command);

                command.CommandText = this.Query;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(this.ResultMapper.MapResult(reader));
                    }
                }
            }

            return results;
        }

        private void GenerateComandParametersIfNecessary(IDbCommand command)
        {
            foreach (var keyValuePair in this.Parameters)
            {
                var parameter = command.CreateParameter();

                parameter.ParameterName = keyValuePair.Key;
                parameter.Value = keyValuePair.Value;

                command.Parameters.Add(parameter);
            }
        }
    }
}
