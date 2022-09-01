using CattleRanch.Core.Domain.Common;

namespace CattleRanch.Core.Domain.Entities;
public class Farm : AuditableEntity
{
    #region Constructors
    private Farm(Guid id, string code, string name, string address, string phone)
    {
        Id = id;
        Code = code;
        Name = name;
        Address = address;
        Phone = phone;
    }
    #endregion

    #region Fields
    private List<Animal> _animals = new();
    #endregion

    #region Properties
    public Guid Id { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    #endregion

    #region Collections
    public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();
    #endregion

    #region Methods
    public static Farm Create(Guid id, string code, string name, string address, string phone, DateTimeOffset createdOn, string createdBy = "System")
    {
        var farm = new Farm(id, code, name, address, phone) { CreatedBy = createdBy, CreatedOn = createdOn };

        return farm;
    }
    #endregion
}
