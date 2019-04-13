using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Api.Models
{
    public class Identifiable:Identifiable<int>
    { }

    public class Identifiable<T> : IIdentifiable<T>
    {
        public virtual T Id { get; set; }

        [NotMapped]
        public string StringId
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

                /// <summary>
        /// Convert the provided resource identifier to a string.
        /// </summary>
        protected virtual string GetStringId(object value)
        {
            if(value == null)
                return string.Empty;

            var type = typeof(T);
            var stringValue = value.ToString();

            if (type == typeof(Guid))
            {
                var guid = Guid.Parse(stringValue);
                return guid == Guid.Empty ? string.Empty : stringValue;
            }

            return stringValue == "0"
                ? string.Empty
                : stringValue;
        }
    }
}
