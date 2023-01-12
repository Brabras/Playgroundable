using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/bot")]
public class TelegramController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        var context = HttpContext.Request.Body;
        var botClient = new TelegramBotClient("5818909579:AAHjXutJHotzfLBzLH3UqMN77t19y8zoATk");
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            
            var messageId = update.ChannelPost.MessageId;
            await botClient.DeleteMessageAsync(-1001521736518, messageId);
        }
        

        return Ok();
    }
}