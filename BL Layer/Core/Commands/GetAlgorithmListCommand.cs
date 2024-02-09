using Application.Abstractions.Repositories;
using Application.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.API.Commands;

public class GetAlgorithmListCommand : ICommand
{
    private readonly IAlgorithmRepository _algorithmDao;
    private readonly TelegramBotClient _client;

    public GetAlgorithmListCommand(IAlgorithmRepository algorithmDao, TelegramBotClient client)
    {
        _algorithmDao = algorithmDao;
        _client = client;
    }

    public string Name { get; } = @"list";

    public async Task Execute(Update update, string[] args)
    {
        var algList = await _algorithmDao.GetAccessibleAlgorithms();
        var text = algList.Aggregate("", (current, alg) => current + $"{alg} \n");
        
        await _client.SendTextMessageAsync(
            update.Message.Chat.Id,
            text,
            parseMode: ParseMode.Html
        );
    }
}