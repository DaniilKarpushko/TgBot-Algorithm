using System.Collections;
using Application.API.Commands;
using Application.Contracts;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.API.Handlers;

public class CommandHandler : IHandler
{
    private readonly IEnumerable<ICommand> _commands;

    public CommandHandler(IEnumerable<ICommand> commands)
    {
        _commands = commands;
    }


    public async Task Handle(Update update)
    {
        var commandEntity = update.Message.Entities
            .Where(x => x.Type == MessageEntityType.BotCommand)
            .ToList().First();
        var commandText = update.Message.Text.Substring(commandEntity.Offset + 1);
        var name = commandText.Split(' ', '@').First().ToLowerInvariant();
        var args = commandText.Split(' ').Skip(1).ToArray();

        var command = _commands.FirstOrDefault(c => c.Name == name);

        if (command is not null)
        {
            await command.Execute(update, args);
        }
        else
        {
            await _commands.FirstOrDefault(c => c.Name == "help")?.Execute(update, args)!;
        }
    }
}