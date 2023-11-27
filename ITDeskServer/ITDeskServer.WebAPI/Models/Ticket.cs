namespace ITDeskServer.WebAPI.Models;

public sealed class Ticket : BaseModel
{
    
    public string? Tags { get; set; } = string.Empty;// Etiketlerle ilişkilendirilmiş metin bilgisi.    
    public string Subject { get; set; } = string.Empty;// Destek talebi başlığı.    
    public string Description { get; set; } = string.Empty;// Destek talebi açıklaması.    
    public Priorities Priority { get; set; } = Priorities.Low;// Destek talebinin önceliği (Düşük, Orta, Yüksek).    
    public Statusses Status { get; set; } = Statusses.UnderReview;// Destek talebinin durumu (İnceleniyor, Cevap Verildi, İtiraz Edildi, vb.).    
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
}

public enum Priorities
{
    Low = 0,
    Medium = 1,
    High = 2
}

public enum Statusses
{
    UnderReview = 0,
    Answered = 1,
    Disputed = 2
    // Diğer durumlar eklenebilir.
}
