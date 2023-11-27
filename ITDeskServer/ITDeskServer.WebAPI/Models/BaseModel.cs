namespace ITDeskServer.WebAPI.Models;

public class BaseModel
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; private set; }
    public Guid? UpdatedBy { get; private set; }
    public DateTime? DeletedDate { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public Guid? DeletedBy { get; private set; }

    public void Update(Guid updatedBy)
    {
        UpdatedDate = DateTime.Now;
        UpdatedBy = updatedBy;
    }

    public void Delete(Guid deletedBy)
    {
        DeletedDate = DateTime.Now;
        IsDeleted = true;
        DeletedBy = deletedBy;
    }
}
