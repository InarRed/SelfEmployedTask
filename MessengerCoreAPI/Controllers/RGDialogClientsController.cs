using MessengerCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessengerCoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RGDialogClientsController : ControllerBase
{
    [HttpPost]
    public ActionResult<Guid> FindDialog(FindDialogDto findDialogDto)
    {
        var dialogsClients = new RGDialogsClients().Init();

        var dialog = dialogsClients
            .GroupBy(dc => dc.IDRGDialog)
            .FirstOrDefault(dialog => findDialogDto.ClientsIds
                .All(c => dialog.Any(d => d.IDClient == c)))
            ?.First().IDRGDialog;

        return dialog ?? Guid.Empty;
    }
}