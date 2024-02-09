using Telegram.Bot.Types;

namespace Application.Contracts;

public interface ICommand
{
    string Name { get; }
    Task Execute(Update update, string[] args);
}