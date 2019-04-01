namespace Northwind.Api.Models
{
    public interface IIdentifiable
    {
        string StringId { get; set; }
    }

    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}
