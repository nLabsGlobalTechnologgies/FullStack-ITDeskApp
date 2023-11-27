namespace ITDeskServer.WebAPI.Models;

public sealed class Role : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
