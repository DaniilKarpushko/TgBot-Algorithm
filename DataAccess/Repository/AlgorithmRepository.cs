using Application.Abstractions.Repositories;
using Application.Models;
using System.Text.Json;


namespace DataAccess.Repository;

public class AlgorithmRepository : IAlgorithmRepository
{
    private string _jsonLib;
    private string _jsonList;

    public AlgorithmRepository(AppConfiguration appConfiguration)
    {
        _jsonLib = appConfiguration.AlgorithmDataFile;
        _jsonList = appConfiguration.AlgorithmListFile;
    }

    public async Task<Algorithm?> GetAlgorithm(string name)
    {
        var txt = new StreamReader(_jsonLib);
        var res = await JsonSerializer.DeserializeAsync<List<Algorithm>>(txt.BaseStream);
        
        return res.Find(arg => arg.Name == name);
    }

    public async Task<List<string>?> GetAccessibleAlgorithms()
    {
        var txt =  new StreamReader(_jsonList);
        var list = await JsonSerializer.DeserializeAsync<List<string>>(txt.BaseStream);
        return list;
    }
}