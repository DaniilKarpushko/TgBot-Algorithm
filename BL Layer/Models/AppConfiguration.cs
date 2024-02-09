using Microsoft.Extensions.Configuration;

namespace Application.Models;

public class AppConfiguration
{
    public AppConfiguration(IConfiguration configuration)
    {
        AlgorithmDataFile = configuration["AlgorithmDataFile"] ?? throw new InvalidOperationException();
        AlgorithmListFile = configuration["AlgorithmListFile"] ?? throw new InvalidOperationException();
        TelegramBotToken = configuration["TelegramBotToken"] ?? throw new InvalidOperationException();
    }

    public string AlgorithmDataFile { get; }
    public string AlgorithmListFile { get; }
    public string TelegramBotToken { get; }
    
    
}