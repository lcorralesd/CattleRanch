namespace CattleRanch.Kernel.Exceptions.CustomExceptions;
public class NotFoundException : Exception
{
    public IReadOnlyList<string> Entries { get; } = default!;

    public NotFoundException() { }

    public NotFoundException(string message) : base(message) { }
}

