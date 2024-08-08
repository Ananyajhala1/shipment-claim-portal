namespace ClaimsAPI.Models
{

    public interface ITokenInfo
    {


    }
    public class RequestTokenInfo : ITokenInfo
    {
    
        public string? userId { get; set; }

        public string? clientId { get; set; }

        public string? userName{ get; set; }

        public string? clientName { get; set; }

    }
}
