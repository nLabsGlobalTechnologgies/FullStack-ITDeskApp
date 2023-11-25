namespace ITDeskServer.WebAPI.Models;

public sealed class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public byte Status { get; set; } // 0 => İnceleniyor, 1 => Cevap Verildi, 2 => İtiraz Edildi gibisinden
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletdDate { get; set; }
}
