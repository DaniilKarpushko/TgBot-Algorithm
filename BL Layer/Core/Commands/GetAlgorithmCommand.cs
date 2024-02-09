using Application.Abstractions.Repositories;
using Application.Contracts;
using Application.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.API.Commands;

public class GetAlgorithmCommand : ICommand
{
    private readonly IAlgorithmRepository _algorithmDao;
    private readonly TelegramBotClient _client;

    public GetAlgorithmCommand(IAlgorithmRepository algorithmDao, TelegramBotClient client)
    {
        _algorithmDao = algorithmDao;
        _client = client;
    }

    public string Name { get; } = @"find";

    public async Task Execute(Update update, string[] args)
    {
        var algorithm = await _algorithmDao.GetAlgorithm(string.Join(" ",args.ToArray()));
        string text = "Sorry algorithm was not found";

        if (algorithm is not null)
        {
            text = await CreateText(algorithm);
        }

        await _client.SendTextMessageAsync(
            update.Message.Chat.Id,
            text,
            parseMode: ParseMode.Html
        );
    }

    private async Task<string> CreateText(Algorithm algorithm)
    {
        string res = $"""
                     <b>Algorithm :</b> {algorithm.Name}
                     <b>Time complexity:</b> {algorithm.TimeComplexity}
                     <b>Memory complexity:</b> {algorithm.MemoryComplexity}
                     <b>Code:</b>
                     {algorithm.Code}
                     <b>Links:</b>
                     """;
        return algorithm.Links.Aggregate(res, (current, link) => current + $"\n{link}");
    }
}