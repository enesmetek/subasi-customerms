using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Responses;
using Subasi.CustomerMS.API.Core.Domain.Enums;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests
{
    public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AddressType AddressType { get; set; }
        public string? AddressLine { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public int CustomerID { get; set; }
    }
}
