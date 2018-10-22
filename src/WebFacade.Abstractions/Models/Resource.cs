using System.Text;

namespace WebFacade.Abstractions.Models
{
    public class Resource
    {
        public string Category { get; set; }
        public string Uuid { get; set; }
        public byte[] Value { get; set; }

        public string GetStringValue() => Value == null ? null : Encoding.UTF8.GetString(Value);
        public void SetStringValue(string value) => Value = value == null ? null : Encoding.UTF8.GetBytes(value);
    }
}
