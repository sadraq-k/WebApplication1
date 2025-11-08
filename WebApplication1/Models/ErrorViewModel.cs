namespace WebApplication1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
//this folder (models) connect to the database it s very near to entity framework they handle databace and web
//to create a model we can use code first approach or database first approach
