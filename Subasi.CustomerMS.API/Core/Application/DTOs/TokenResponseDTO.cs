namespace Subasi.CustomerMS.API.Core.Application.DTOs
{
    public class TokenResponseDTO
    {
        public TokenResponseDTO(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
