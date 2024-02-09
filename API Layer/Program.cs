using API_Layer.Controllers;
using Application.API.Extensions;
using Application.API.Handlers;
using Application.Models;
using DataAccess.Extensions;
using Telegram.Bot;
using Telegram.Bot.Polling;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<AppConfiguration>(x => new AppConfiguration(context.Configuration));
        services.AddSingleton<TelegramBotClient>(x =>
            new TelegramBotClient(context.Configuration["TelegramBotToken"]));
        services.AddScoped<BotController>();
        services.AddInfrastructureDataAccess();
        services.AddApplication();
    })
    .Build();
var tgBotClient = host.Services.GetRequiredService<TelegramBotClient>();
var botController = host.Services.GetRequiredService<BotController>();
using var cts = new CancellationTokenSource();

tgBotClient.StartReceiving(
    updateHandler: botController.HandleUpdateAsync,
    pollingErrorHandler: botController.HandlePollingErrorAsync,
    receiverOptions: new ReceiverOptions(),
    cancellationToken: cts.Token
);

var me = await host.Services.GetRequiredService<TelegramBotClient>().GetMeAsync();

Console.WriteLine($"Bot start @{me.Username}");
Console.ReadLine();

cts.Cancel();