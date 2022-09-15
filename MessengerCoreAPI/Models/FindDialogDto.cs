namespace MessengerCoreAPI.Models;

public class FindDialogDto
{
    public List<Guid> ClientsIds { get; set; } = new();
}