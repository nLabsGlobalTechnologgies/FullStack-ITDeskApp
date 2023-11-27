namespace ITDeskServer.WebAPI.Models
{
    public sealed class TicketResponse : BaseModel
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public Guid AnsweredUserId { get; set; }
        public Guid AnsweredResponseId {get; set; } 
        public string Response { get; set; } = string.Empty;
        public ICollection<TicketResponse> ChildResponses { get; set; }
    }
}
