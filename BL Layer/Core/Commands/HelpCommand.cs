using Application.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.API.Commands;

public class HelpCommand : ICommand
{
    public string Name { get; } = @"help";
    private readonly TelegramBotClient _client;

    private const string HelpMessage = """
                                        <b>/find {algorithm} - searches for algorithm;</b>
                                        <b>/list - shows available algorithms;</b>
                                        """;

    public HelpCommand(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task Execute(Update update, string[] args)
    {
        await _client.SendTextMessageAsync(
            update.Message.Chat.Id,
            HelpMessage,
            parseMode: ParseMode.Html
        );
    }
}