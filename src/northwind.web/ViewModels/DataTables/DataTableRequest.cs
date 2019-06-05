namespace Northwind.Web.ViewModels.DataTables
{
    public class DataTableRequest
	{
		public DataTableRequest() { }

		public bool LegacyMode { get; set; }

		/// <summary>
		/// Draw counter. This is used by DataTables to ensure that the Ajax returns
		/// from server-side processing requests are drawn in sequence by DataTable
		/// </summary>
		public int Draw { get; set; }

		/// <summary>
		/// Paging first record indicator. This is the start point in the current data
		/// set (0 index based - i.e. 0 is the first record).
		/// </summary>
		public int Start { get; set; }

		/// <summary>
		/// Number of records that the table can display in the current draw. It is
		/// expected that the number of records returned will be equal to this number,
		/// unless the server has fewer records to return. Note that this can be -1 to
		/// indicate that all records should be returned.
		/// </summary>
		public int Length { get; set; } = 100;

		public SearchCriterion GlobalSearch { get; set; }

		public DataTableColumn[] Columns { get; set; }

		public OrderingCriterion[] Ordering { get; set; }
	}
}
