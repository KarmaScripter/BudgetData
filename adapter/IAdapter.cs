namespace BudgetExecution
{
    using System.Data.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface IAdapter
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        DbConnection GetConnection();

        /// <summary>
        /// Gets the select command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetSelectCommand();

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetInsertCommand();

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetUpdateCommand();

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetDeleteCommand();
    }
}