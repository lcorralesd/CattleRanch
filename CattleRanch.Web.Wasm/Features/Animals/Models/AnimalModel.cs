namespace CattleRanch.Web.Wasm.Features.Animals.Models;

public class AnimalModel
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? EarTag { get; set; }
    public string? Name { get; set; }
    public string? Colour { get; set; }
    public string? Brand { get; set; }
    public string Sex { get; set; } = string.Empty;
    public string HornStatus { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool Discard { get; set; }
    public string Breed { get; set; } = string.Empty;
    public string Farm { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string FullAge { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
    public string? Remark { get; set; }
}
