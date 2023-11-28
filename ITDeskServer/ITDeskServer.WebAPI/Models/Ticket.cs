namespace ITDeskServer.WebAPI.Models;

public sealed class Ticket : BaseModel
{
    
    public string? Tags { get; set; } = string.Empty;// Etiketlerle ilişkilendirilmiş metin bilgisi.    
    public string Subject { get; set; } = string.Empty;// Destek talebi başlığı.    
    public string Description { get; set; } = string.Empty;// Destek talebi açıklaması.    
    public byte Priority { get; set; } = 0;// Destek talebinin önceliği (Düşük, Orta, Yüksek).    
    public byte Status { get; set; } = 0;// Destek talebinin durumu (İnceleniyor, Cevap Verildi, İtiraz Edildi, vb.).    
    public byte Rating { get; private set; } = 0; // Kullanıcı tarafından belirlenen bir derecelendirme (Min 1, Max 5).    
    public Guid? AssignedTo { get; private set; }// Destek talebine atanmış olan kişinin kimliği.

    public ICollection<TicketResponse> TicketResponses { get; set; }


    public void AddToAssigned(Guid assignedPersonnel, Guid updatedBy)
    {
        AssignedTo = assignedPersonnel;
        Update(updatedBy);
    }

    public void UpdateToAssigned(Guid assignedPersonnel, Guid updatedBy)
    {
        AssignedTo = assignedPersonnel;
        Update(updatedBy);
    }

    public void UpdateToRating(Guid updatedBy, byte rating)
    {
        Rating = rating;
        Update(updatedBy);
    }

    public void UpdateStatus(Guid updatedBy, byte status)
    {
        Status = status;
        Update(updatedBy);
    }

    public void UpdatePriority(Guid updatedBy, byte priority)
    {
        Priority = priority;
        Update(updatedBy);
    }
}
