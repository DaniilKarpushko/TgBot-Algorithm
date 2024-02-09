using Telegram.Bot.Types;

namespace Application.Contracts;

public interface IHandler
{
    Task Handle(Update update);
}