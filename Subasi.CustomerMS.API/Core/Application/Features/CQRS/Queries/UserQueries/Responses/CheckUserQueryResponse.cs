namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Responses
{
    public class CheckUserQueryResponse
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
