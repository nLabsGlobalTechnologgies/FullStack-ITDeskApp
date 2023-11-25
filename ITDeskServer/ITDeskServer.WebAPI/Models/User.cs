namespace ITDeskServer.WebAPI.Models;

public sealed class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public bool IsAdmin { get; private set; } = false;
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; } = new byte[64];
    public byte[] PasswordHash { get; set; } = new byte[128];
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; private set; } = false;

    public ICollection<Ticket> Tickets { get; set; }

    public void RoleUpdate(Guid id, bool isAdmin)
    {
        Id = id;
        IsAdmin = isAdmin;
    }

    public void DeleteTicket(Guid id, bool isDeleted)
    {
        Id = id;
        IsDeleted = isDeleted;
    }

}
