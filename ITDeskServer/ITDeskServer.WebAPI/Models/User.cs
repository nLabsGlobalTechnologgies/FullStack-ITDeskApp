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
    public DateTime? UpdatedDate { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public DateTime? DeletedDate { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public Guid? DeletedBy { get; private set; }

    public ICollection<Ticket> Tickets { get; set; }

    public void RoleUpdate(bool isAdmin, Guid updatedBy)
    {
        UpdatedDate = DateTime.Now;
        IsAdmin = isAdmin;
        UpdatedBy = updatedBy;
    }

    public void Update(Guid updatedBy)
    {
        UpdatedDate = DateTime.Now;
        UpdatedBy = updatedBy;
    }

    public void Delete(bool isDeleted, Guid deletedBy)
    {
        DeletedDate = DateTime.Now;
        IsDeleted = isDeleted;
        DeletedBy = deletedBy;

    }

}
