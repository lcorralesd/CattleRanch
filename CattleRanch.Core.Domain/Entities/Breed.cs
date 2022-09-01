using CattleRanch.Core.Domain.Common;

namespace CattleRanch.Core.Domain.Entities;
public class Breed : AuditableEntity
{
    #region Constructors
    private Breed(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    #endregion

    #region Fields
    private List<Animal> _animals = new();
    #endregion

    #region Properties
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    #endregion

    #region Collections
    public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();
    #endregion

    #region Methods
    public static Breed Create(Guid id, string name, DateTimeOffset createdOn, string createdBy = "System")
    {
        var breed = new Breed(id, name) { CreatedBy = createdBy, CreatedOn = createdOn };

        return breed;
    }
    #endregion


}
