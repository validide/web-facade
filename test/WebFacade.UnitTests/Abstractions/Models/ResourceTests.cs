using System;
using Xunit;
using MDL = WebFacade.Core.Models;
using EXC = WebFacade.Core.Exceptions;

namespace WebFacade.UnitTests.Abstractions.Models
{
    public class ResourceTests
    {
        [Fact]
        public void UnixEpoch_Basic()
        {
            Assert.Equal(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), MDL.Resource.UnixEpoch);
        }

        [Fact]
        public void SetStringValue_Basic()
        {
            var text = "c29tZSByYW5kb20gc3RyaW5nYWE=";
            var res = new MDL.Resource { Uuid = "" };
            res.SetStringValue(text);
            Assert.Equal(Convert.FromBase64String(text), res.Value);
        }

        [Fact]
        public void SetStringValue_Null()
        {
            var res = new MDL.Resource();
            res.SetStringValue(null);
            Assert.Null(res.Value);
        }

        [Fact]
        public void GetStringValue_Basic()
        {
            var text = "c29tZSByYW5kb20gc3RyaW5nYWE=";
            var res = new MDL.Resource
            {
                Value = Convert.FromBase64String(text)
            };
            Assert.Equal(text, res.GetStringValue());
        }

        [Fact]
        public void GetStringValue_Null()
        {
            var res = new MDL.Resource
            {
                Value = null
            };
            Assert.Null(res.GetStringValue());
        }

        [Fact]
        public void GetTimestampUtc_UnixEpoch()
        {
            var res = new MDL.Resource
            {
                Timestamp = 0
            };
            Assert.Equal(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), res.GetTimestampUtc());
        }

        [Fact]
        public void GetTimestampUtc_Basic()
        {
            var timestampDate = new DateTime(2018, 12, 11, 10, 9, 8, DateTimeKind.Utc);
            var res = new MDL.Resource
            {
                Timestamp = (long)(timestampDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds
            };
            Assert.Equal(timestampDate, res.GetTimestampUtc());
        }

        [Fact]
        public void GetTimestampUtc_NegativeUnixException()
        {
            var res = new MDL.Resource
            {
                Timestamp = -1
            };
            Assert.Throws<EXC.NegativeUnixException>(() => res.GetTimestampUtc());
        }

        [Fact]
        public void SetTimestampUtc_UnixEpoch()
        {
            var res = new MDL.Resource();
            res.SetTimestampUtc(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            Assert.Equal(0, res.Timestamp);
        }

        [Fact]
        public void SetTimestampUtc_Basic()
        {
            var res = new MDL.Resource();
            res.SetTimestampUtc(new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc));
            Assert.Equal(1, res.Timestamp);
        }

        [Fact]
        public void SetTimestampUtc_DateTimeKindException_Unspecified()
        {
            var res = new MDL.Resource();
            Assert.Throws<EXC.DateTimeKindException>(() => res.SetTimestampUtc(new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Unspecified)));
        }

        [Fact]
        public void SetTimestampUtc_DateTimeKindException_Local()
        {
            var res = new MDL.Resource();
            Assert.Throws<EXC.DateTimeKindException>(() => res.SetTimestampUtc(new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Local)));
        }

        [Fact]
        public void SetTimestampUtc_NegativeUnixException()
        {
            var res = new MDL.Resource();
            Assert.Throws<EXC.NegativeUnixException>(() => res.SetTimestampUtc(new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc)));
        }
    }
}
