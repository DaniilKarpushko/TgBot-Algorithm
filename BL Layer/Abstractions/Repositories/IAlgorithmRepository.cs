using Application.Models;

namespace Application.Abstractions.Repositories;

public interface IAlgorithmRepository
{
    Task<Algorithm?> GetAlgorithm(string name);

    Task<List<string>?> GetAccessibleAlgorithms();
}