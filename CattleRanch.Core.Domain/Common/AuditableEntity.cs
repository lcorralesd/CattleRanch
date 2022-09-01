namespace CattleRanch.Core.Domain.Common;
public abstract class AuditableEntity
{
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
}
