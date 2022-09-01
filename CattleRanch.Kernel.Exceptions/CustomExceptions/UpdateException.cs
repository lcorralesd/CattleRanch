namespace CattleRanch.Kernel.Exceptions.CustomExceptions;
public class UpdateException : Exception
{
    public IReadOnlyList<string> Entries { get; } = default!;

    public UpdateException() { }

    public UpdateException(string message) : base(message) { }

    public UpdateException(string message, Exception innerException) : base(message, innerException) { }

    public UpdateException(string message, IReadOnlyList<string> entries) : base(message) =>
        Entries = entries;
}
