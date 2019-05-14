namespace Northwind.Web.ViewModels.DataTables
{
    public class OrderingCriterion
	{
		/// <summary>
		/// Column to which ordering should be applied. This is an index
		/// reference to the columns array of information that is also
		/// submitted to the server.
		/// </summary>
		public DataTableColumn Column { get; set; }

		/// <summary>
		/// Ordering direction for this column
		/// </summary>
		public SortDirection Direction { get; set; }
	}
}
