using FurmanCapitalTechGroup.TikiORM.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core
{
    public class RetrievalQueryExecutorBuilder
    {
        private RetrievalQueryExecutorBuilder()
        {

        }

        /// <summary>
        /// To reduce the need to check for nulls, we initialize
        /// a single instance of empty parameters that is readonly so that we can pass it 
        /// for all queries that do not specify parameters
        /// </summary>
        public static readonly IDictionary<string, object> EmptyParameters = new ReadOnlyDictionary<string, object>(new Dictionary<string, object>());

    }

    /// <summary>
    /// This builder class is used to build up RetrievalQueryExecutor instances
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class RetrievalQueryExecutorBuilder<TItem>
        where TItem : new()
    {
        private IResultMapper<TItem> ResultMapper
        {
            get;
            set;
        }

        /// <summary>
        /// Initialize to ensure that we never get a null dictionary of parameters
        /// </summary>
        private IDictionary<string, object> Parameters
        {
            get;
            set;
        } = RetrievalQueryExecutorBuilder.EmptyParameters;


        private string Query
        {
            get;
            set;
        }


        private RetrievalQueryExecutorBuilder(string sqlQuery)
        {
            this.Query = sqlQuery;
        }

        public static RetrievalQueryExecutorBuilder<TItem> ForQuery(string sqlQuery)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            return new RetrievalQueryExecutorBuilder<TItem>(sqlQuery);
        }

        /// <summary>
        /// Adds the specified parameters to the query in one shot.
        /// Note: this clears out any previous parameters that may have existed.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public RetrievalQueryExecutorBuilder<TItem> WithParameters(IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            this.Parameters = parameters;
            return this;
        }

        /// <summary>
        /// Helper method if a user wishes to add parameters one at a time
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public RetrievalQueryExecutorBuilder<TItem> WithParameter(string key, object parameterValue)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (this.Parameters == RetrievalQueryExecutorBuilder.EmptyParameters)
            {
                this.Parameters = new Dictionary<string, object>();
            }

            this.Parameters.Add(key, parameterValue);

            return this;
        }

        /// <summary>
        /// Allows the specification of a custom mapper
        /// </summary>
        /// <param name="resultMapper"></param>
        /// <returns></returns>
        public RetrievalQueryExecutorBuilder<TItem> WithCustomResultMapper(IResultMapper<TItem> resultMapper)
        {

            if (resultMapper == null)
            {
                throw new ArgumentNullException(nameof(resultMapper));
            }


            this.ResultMapper = resultMapper;

            return this;
        }

        /// <summary>
        /// Allows the specification of a custom mapper via a function
        /// </summary>
        /// <param name="resultMapper"></param>
        /// <returns></returns>
        public RetrievalQueryExecutorBuilder<TItem> WithCustomFuncMapper(Func<IDataReader, TItem> resultMapper)
        {
            if (resultMapper == null)
            {
                throw new ArgumentNullException(nameof(resultMapper));
            }

            this.ResultMapper = new FuncBasedResultMapper<TItem>(resultMapper);

            return this;
        }

        public RetrievalQueryExecutor<TItem> Build()
        {
            var mapper = this.ResultMapper ?? new ColumnNameToObjectResultMapper<TItem>();

            return new RetrievalQueryExecutor<TItem>(this.Query, this.Parameters, mapper);
        }
    }
}
