namespace Northwind.Web.ViewModels.DataTables
{
    public class DataTableResponse<T>
	{
		/// <summary>
		/// The draw counter that this object is a response to - from the draw parameter sent as
		/// part of the data request.
		/// </summary>
		public int Draw { get; set; }

		/// <summary>
		/// Total records, before filtering (i.e. the total number of records in the database)
		/// </summary>
		public int RecordsTotal{ get;set; }

		/// <summary>
		/// Total records, after filtering (i.e. the total number of records after filtering
		/// has been applied - not just the number of records being returned for this page of data).
		/// </summary>
		public int RecordsFiltered { get; set; }

		/// <summary>
		/// The data to be displayed in the table
		/// </summary>
		public T[] Data { get; set; }

		/// <summary>
		/// If an error occurs during the running of the server-side processing script,
		/// you can inform the user of this error by passing back the error message to be displayed
		/// using this parameter. Do not include if there is no error.
		/// </summary>
		public string Error { get; set; }
	}
}
