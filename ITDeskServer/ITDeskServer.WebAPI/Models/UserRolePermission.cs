namespace ITDeskServer.WebAPI.Models;

public sealed class UserRolePermission : BaseModel
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public Tables TableName { get; set; }
    public bool CanAdd { get; set; } = false;
    public bool CanUpdate { get; set; } = false;
    public bool CanDelete { get; set; } = false;
    public bool CanShow { get; set; } = false;

    public ICollection<User>? Users { get; set; }
    public ICollection<Role>? Roles { get; set; }

    public enum Tables
    {
        Roles,
        Users,
        Tickets,
        SupportTickets,
        TicketPersonnels
    }
}
