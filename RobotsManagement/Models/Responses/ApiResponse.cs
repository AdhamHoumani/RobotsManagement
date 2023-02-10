namespace RobotsManagement.Models.Responses
{
    public class ApiResponse
    {
        public dynamic? Data { get; set; }
        public int Status { get; set; }
        public string? ApiMessage { get; set; }
    }
}
