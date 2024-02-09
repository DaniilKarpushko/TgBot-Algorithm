namespace Application.Models;

public class Algorithm
{
    public Algorithm(string name, string timeComplexity, string memoryComplexity, string code, List<string> links)
    {
        Name = name;
        TimeComplexity = timeComplexity;
        MemoryComplexity = memoryComplexity;
        Code = code;
        Links = links;
    }

    public string Name { get; set; }
    public string TimeComplexity { get; set; }
    public string MemoryComplexity { get; set; }
    public string Code { get; set; }
    public List<string> Links { get; set; }
}