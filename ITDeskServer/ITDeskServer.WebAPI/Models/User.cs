namespace ITDeskServer.WebAPI.Models;

public sealed class User : BaseModel
{
    public Guid RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } = new byte[128];
    public byte[] PasswordHash { get; set; } = new byte[64];

    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<TicketResponse> TicketResponses { get; set; }
    public ICollection<TicketPersonnel> TicketPersonnels { get; set; }
    public void RoleUpdate(Guid roleId, Guid updatedBy)
    {
        RoleId = roleId;
        Update(updatedBy);
    }
}
