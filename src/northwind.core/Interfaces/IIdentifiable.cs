namespace Northwind.Core.Interfaces
{
    public interface IIdentifiable
    {
        string StringId { get; set; }
    }

    public interface IIdentifiable<T> : IIdentifiable
    {
        T Id { get; set; }
    }
}
