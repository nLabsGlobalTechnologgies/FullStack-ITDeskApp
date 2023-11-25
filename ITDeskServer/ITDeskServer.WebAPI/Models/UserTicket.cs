namespace ITDeskServer.WebAPI.Models;

public sealed class UserTicket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
}
