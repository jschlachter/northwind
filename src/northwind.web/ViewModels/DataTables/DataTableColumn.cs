namespace Northwind.Web.ViewModels.DataTables
{
    	public class DataTableColumn
	{
		/// <summary>
		/// Column's data source
		/// </summary>
		public object Data { get; set; }

		/// <summary>
		/// Column's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Flag to indicate if this column is searchable
		/// </summary>
		public bool Searchable { get; set; }

		/// <summary>
		/// Flag to indicate if this column is orderable
		/// </summary>
		public bool Orderable { get; set; }

		/// <summary>
		/// Search value to apply to this specific column
		/// </summary>
		public SearchCriterion Search { get; set; }

		public int ColumnIndex { get; set; }
	}
}
