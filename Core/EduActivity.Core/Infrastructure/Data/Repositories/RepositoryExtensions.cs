
namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
	using System;
	using System.Data;
	using System.Linq;
	using System.Collections.Generic;
	using System.Reflection;
	using gudusoft.gsqlparser;

	public static class RepositoryExtensions
	{
		private static readonly string sqlFieldName = "sql";
		private static readonly string parametersFieldName = "parameters";
		private static readonly string prefix = "@";

		private static TCustomSqlStatement ParseSql(string sql)
		{
			var dbVendor = TDbVendor.DbVMssql;

			var sqlparser = new TGSqlParser(dbVendor);
			sqlparser.SqlText.Text = sql;
			int ret = sqlparser.Parse();
			if (ret != 0)
			{
				throw new Exception("SQL Parser Error:" + sqlparser.ErrorMessages + "\r\n" + sqlparser.SqlText.Text);
			}
			var sqlStatement = sqlparser.SqlStatements.First();
			return sqlStatement;
		}

		public static void FixWhereStatement<T>(this IRepository<T> repository)
		{
			var sql = repository.GetType()
				.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(repository).ToString();

			var parameters = (List<Telerik.OpenAccess.Data.Common.OAParameter>)repository.GetType()
				.GetField(parametersFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(repository);

			var sqlStatement = ParseSql(sql);

			if (sqlStatement.SqlStatementType != TSqlStatementType.sstSelect)
				return;

			if (sqlStatement.WhereClause == null)
				return;

			if (sqlStatement.Params.Count() == 0 && sqlStatement.SqlVars.Count() == 0)
				return;

			var properties = repository.GetType()
						.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (var property in properties)
			{
				if (property.GetValue(repository, null) != null)
					continue;

				TSourceToken start = sqlStatement.WhereClause.StartToken;
				TSourceToken end = sqlStatement.WhereClause.EndToken;
				TSourceTokenList stlist = start.Container;
				for (int k = start.posinlist; k <= end.posinlist; k++)
				{
					if (stlist[k].TokenType == TTokenType.ttBindVar || stlist[k].TokenType == TTokenType.ttSqlVar)
					{
						if (stlist[k].TokenStatus == TTokenStatus.tsDeleted)
							continue;

						if (stlist[k].SourceCode.Replace(prefix, "").Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
						{
							stlist[k].TokenType = TTokenType.ttSqlVar;
							stlist[k].TokenStatus = TTokenStatus.tsDeleted;
							parameters.Remove(parameters.Where(c => c.ParameterName == property.Name).FirstOrDefault());
						}
					}
				}

				// rebuild the sql text
				sqlStatement.ReBuildSql(TRebuildFlags.rfClearRemovedVars);
				sql = sqlStatement.SqlDesc;
				repository.GetType()
					.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
					.SetValue(repository, sql);
			}
		}


		public static void FixWhereStatement<T>(this IRepository<T> repository, params string[] removedVars)
		{
			var sql = repository.GetType()
				.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(repository).ToString();
			
			var parameters = (List<Telerik.OpenAccess.Data.Common.OAParameter>)repository.GetType()
				.GetField(parametersFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(repository);

			var sqlStatement = ParseSql(sql);

			if (sqlStatement.SqlStatementType != TSqlStatementType.sstSelect)
				return;

			if (sqlStatement.WhereClause == null)
				return;

			if (sqlStatement.Params.Count() == 0 && sqlStatement.SqlVars.Count() == 0)
				return;

			var properties = repository.GetType()
						.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (var property in properties)
			{
				if (!removedVars.Contains(property.Name))
					continue;

				TSourceToken start = sqlStatement.WhereClause.StartToken;
				TSourceToken end = sqlStatement.WhereClause.EndToken;
				TSourceTokenList stlist = start.Container;
				for (int k = start.posinlist; k <= end.posinlist; k++)
				{
					if (stlist[k].TokenType == TTokenType.ttBindVar || stlist[k].TokenType == TTokenType.ttSqlVar)
					{
						if (stlist[k].TokenStatus == TTokenStatus.tsDeleted)
							continue;

						if (stlist[k].SourceCode.Replace(prefix, "").Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
						{
							stlist[k].TokenType = TTokenType.ttSqlVar;
							stlist[k].TokenStatus = TTokenStatus.tsDeleted;
							parameters.Remove(parameters.Where(c => c.ParameterName == property.Name).FirstOrDefault());
						}
					}
				}

				// rebuild the sql text
				sqlStatement.ReBuildSql(TRebuildFlags.rfClearRemovedVars);
				sql = sqlStatement.SqlDesc;
				repository.GetType()
					.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
					.SetValue(repository, sql);
			}
		}

		public static void FixWhereStatement<T>(this IRepository<T> repository, string whereStatement, bool replaceWhereStatement)
		{
			var sql = repository.GetType()
				.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(repository).ToString();

			var sqlStatement = ParseSql(sql);

			if (sqlStatement.SqlStatementType != TSqlStatementType.sstSelect)
				return;

			sqlStatement.WhereClauseText = replaceWhereStatement ? whereStatement : sqlStatement.WhereClauseText + whereStatement;
			sql = sqlStatement.SqlDesc;
			repository.GetType()
				.GetField(sqlFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
				.SetValue(repository, sql);
		}
	}
}


