using System;
using WebFacade.Core.Exceptions;

namespace WebFacade.Core.Models
{
    public class Resource
    {
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public long Timestamp { get; set; }
        public string Uuid { get; set; }
        public byte[] Value { get; set; }

        public string GetStringValue() => Value == null ? null : Convert.ToBase64String(Value);
        public void SetStringValue(string value) => Value = value == null ? null : Convert.FromBase64String(value);
        public DateTime GetTimestampUtc()
        {
            if (Timestamp < 0)
                throw new NegativeUnixException($"{nameof(Timestamp)} should be a positive integer!");

            return UnixEpoch.AddSeconds(Timestamp);
        }
        public void SetTimestampUtc(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                throw new DateTimeKindException($"The \"{nameof(dateTime)}\" parameter should be a UTC date!");

            var timestamp = (long)(dateTime - UnixEpoch).TotalSeconds;
            if (timestamp < 0)
                throw new NegativeUnixException($"The \"{nameof(dateTime)}\" parameter should be greater than Unix Epoch!");

            Timestamp = timestamp;
        }
    }
}
