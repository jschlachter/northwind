namespace Northwind.Web.ViewModels.DataTables
{
    public class SearchCriterion
	{
		/// <summary>
		/// Global search value. To be applied to all columns which have
		/// "searchable" as true.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// "true" if the global filter should be treated as a regular
		/// expression for advanced searching, "false" otherwise.
		/// </summary>
		public bool Regex { get; set; }
	}
}
