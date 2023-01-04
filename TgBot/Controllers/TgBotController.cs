using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot.Controllers;

[ApiController]
[Route("api/bot")]
public class TelegramController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        var botClient = new TelegramBotClient("5818909579:AAHjXutJHotzfLBzLH3UqMN77t19y8zoATk");
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.ChannelPost)
        {
            var messageId = update.ChannelPost.MessageId;
            await botClient.DeleteMessageAsync(-1001521736518, messageId);
        }
        

        return Ok();
    }
}