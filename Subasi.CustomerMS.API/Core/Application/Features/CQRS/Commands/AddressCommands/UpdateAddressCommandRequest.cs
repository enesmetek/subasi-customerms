using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Subasi.CustomerMS.API.Core.Domain.Enums;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands
{
    public class UpdateAddressCommandRequest : IRequest
    {
        public int ID { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AddressType AddressType { get; set; }
        public string? AddressLine { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public int CustomerID { get; set; }
    }
}
