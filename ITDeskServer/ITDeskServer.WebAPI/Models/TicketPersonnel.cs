namespace ITDeskServer.WebAPI.Models;

public sealed class TicketPersonnel
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? EndDate { get; private set; }
    public byte? FailureDuration { get; set; }
    public Guid? ClosedByUserId { get; set; }

    public void UpdateFailureDuration(byte duration)
    {
        FailureDuration = duration;
    }

    public void CloseTicket(Guid closedByUserId)
    {
        EndDate = DateTime.Now;
        ClosedByUserId = closedByUserId;
    }
}
