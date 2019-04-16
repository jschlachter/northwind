using System;
using System.ComponentModel.DataAnnotations.Schema;
using Northwind.Core.Interfaces;

namespace Northwind.Core.Entities
{
    public class Identifiable:Identifiable<int>
    { }

    public class Identifiable<T> : IIdentifiable<T>
    {
        public virtual T Id { get; set; }

        [NotMapped]
        public string StringId
        {
            get => GetStringId(Id);
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
