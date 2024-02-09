using Application.Contracts;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.API.Handlers;

public class CommandHandlerProxy : IHandler
{
    private readonly IHandler _commandHandler;

    public CommandHandlerProxy(IHandler commandHandler)
    {
        this._commandHandler = commandHandler;
    }

    public async Task Handle(Update update)
    {
        if (await CheckMessageCorrection(update))
        {
            await _commandHandler.Handle(update);
        }
    }

    private static async Task<bool> CheckMessageCorrection(Update update)
    {
        return await Task.Run(
            () =>
                update.Message?.ForwardFrom == null
                && update.Message?.ForwardFromChat == null
                && (
                    update.Message?.Entities?.Any(x => x.Type == MessageEntityType.BotCommand)
                    ?? false
                )
        );
    }
}