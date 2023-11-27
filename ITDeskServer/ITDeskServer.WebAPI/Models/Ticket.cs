namespace ITDeskServer.WebAPI.Models;

public sealed class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public byte Status { get; set; } // 0 => İnceleniyor, 1 => Cevap Verildi, 2 => İtiraz Edildi gibisinden
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

    public void Delete(bool isDeleted, Guid deletedBy)
    {
        DeletedDate = DateTime.Now;
        IsDeleted = isDeleted;
        DeletedBy = deletedBy;
    }
}
