namespace Northwind.Web.ViewModels.DataTables
{
	public abstract class DataTableRow
	{
		/// <summary>
		/// Set the ID property of the "tr" node to this value
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Add this class to the "tr" node
		/// </summary>
		public string CssClass { get; set; }

		/// <summary>
		/// Add the data contained in the object to the row using the jQuery data()
		/// method to set the data, which can also then be used for later retrieval
		/// (for example on a click event).
		/// </summary>
		public object Data { get; set; }

		/// <summary>
		/// Add the data contained in the object to the row tr node as attributes.
		/// The object keys are used as the attribute keys and the values as the
		/// corresponding attribute values.
		/// </summary>
		public object CustomAttributes { get; set; }
	}
}
