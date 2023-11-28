namespace ITDeskServer.WebAPI.Models;

public sealed class TicketPersonnel
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public Guid? ClosedByUserId { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? EndDate { get; private set; }
    public byte? FailureDuration { get; set; }

    public void AddFailureDuration(byte duration)
    {
        FailureDuration = duration;
    }

    public void CloseTicket(Guid closedByUserId, byte duration)
    {
        AddFailureDuration(duration);
        EndDate = DateTime.Now;
        ClosedByUserId = closedByUserId;
    }
}
