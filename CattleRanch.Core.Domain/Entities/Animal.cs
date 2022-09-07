using CattleRanch.Core.Domain.Common;
using CattleRanch.Core.Domain.Enums;

namespace CattleRanch.Core.Domain.Entities;
public class Animal : AuditableEntity
{
    #region Contructors
    private Animal(Guid id,
               string code,
               string? earTag,
               string? name,
               string? colour,
               string? brand,
               Sex sex,
               Origin origin,
               Guid breedId,
               Guid farmId,
               DateTime dOB,
               decimal birthWeight,
               DateTime arrivalDate,
               decimal incomeWeight,
               string? imagePath,
               string? remark)
    {
        Id = id;
        Code = code;
        EarTag = earTag;
        Name = name;
        Colour = colour;
        Brand = brand;
        Sex = sex;
        Origin = origin;
        BreedId = breedId;
        FarmId = farmId;
        DOB = dOB;
        BirthWeight = birthWeight;
        ArrivalDate = arrivalDate;
        IncomeWeight = incomeWeight;
        ImagePath = imagePath;
        Remark = remark;
    }
    #endregion

    #region Fields
    private string _fullAge = string.Empty;
    private int _ageInDays;
    private int _ageInMonths;
    private List<Animal> _damPups = new();
    private List<Animal> _sirePups = new();
    #endregion

    #region Properties
    public Guid Id { get; private set; }
    public string Code { get; private set; }
    public string? EarTag { get; private set; }
    public string? Name { get; private set; }
    public string? Colour { get; private set; }
    public string? Brand { get; private set; }
    public Sex Sex { get; private set; }
    public Origin Origin { get; private set; }
    public Status Status { get; private set; } = Status.Activo;
    public DateTime UpdateStatusDate { get; private set; }
    public string? UpdateStatusReason { get; private set; }
    public Guid BreedId { get; private set; }
    public Breed Breed { get; set; } = default!;
    public Guid FarmId { get; private set; }
    public Farm Farm { get; set; } = default!;
    public string? Category { get; private set; }
    public bool Discard { get; private set; } = false;
    public DateTime DOB { get; private set; }
    public decimal BirthWeight { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public decimal IncomeWeight { get; private set; }
    public Guid? DamId { get; private set; }
    public Animal? Dam { get; private set; }
    public Guid? SireId { get; private set; }
    public Animal? Sire { get; private set; }
    public string? ImagePath { get; private set; }
    public string? Remark { get; private set; }

    public int AgeInDays
    {
        get
        {
            int year = DOB.Year;
            int leapYear = 0;

            for (int i = year; i < DateTime.Now.Year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    ++leapYear;
                }
            }
            TimeSpan timeSpan = DateTime.Now.Subtract(DOB.Date);
            _ageInDays = timeSpan.Days - leapYear;
            return _ageInDays;
        }
    }
    public int AgeInMonths
    {
        get
        {
            int days = AgeInDays;
            _ageInMonths = (int)Math.Round(days / 30m, 0);
            return _ageInMonths;
        }
    }
    public string FullAge
    {
        get
        {
            int year = DOB.Year;
            int leapYear = 0;

            for (int i = year; i < DateTime.Now.Year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    ++leapYear;
                }
            }
            TimeSpan timeSpan = DateTime.Now.Subtract(DOB);
            var day = timeSpan.Days - leapYear;

            year = Math.DivRem(day, 365, out int remainder);

            var month = Math.DivRem(remainder, 30, out _);
            _fullAge = $"{year} años, {month} meses.";
            return _fullAge;
        }
    }
    #endregion

    #region Collections
    public IReadOnlyList<Animal> DamPups => _damPups.AsReadOnly();
    public IReadOnlyList<Animal> SirePups => _sirePups.AsReadOnly();
    #endregion

    #region Methods
    public static Animal Create(
        Guid id,
        string code,
        string? earTag,
        string? name,
        string? colour,
        string? brand,
        Sex sex,
        Origin origin,
        Guid breedId,
        Guid farmId,
        DateTime dOB,
        decimal birthWeight,
        DateTime arrivalDate,
        decimal incomeWeight,
        string? imagePath,
        string? remark, DateTimeOffset? createdOn, string createdBy = "System")
    {
        var animal = new Animal(
        id,
        code,
        earTag,
        name,
        colour,
        brand,
        sex,
        origin,
        breedId,
        farmId,
        dOB,
        birthWeight,
        arrivalDate,
        incomeWeight,
        imagePath,
        remark)
        { CreatedBy = createdBy, CreatedOn = createdOn };

        animal.SetCategory(animal.AgeInDays, animal.Sex);

        return animal;
    }

    public void SetCategory(int ageInDays, Sex sex) => Category = ageInDays switch
    {
        int value when value is > 0 and <= 240 && sex == Sex.Hembra => "Becerra",
        int value when value is > 0 and <= 240 && sex == Sex.Macho => "Becerro",
        int value when value is > 240 and <= 365 && sex == Sex.Hembra => "Novillas Destete",
        int value when value is > 365 and <= 600 && sex == Sex.Hembra => "Novillas de Levante",
        int value when value is > 600 and <= 1080 && sex == Sex.Hembra => "Novillas de Vientre",
        int value when value is > 240 and <= 365 && sex == Sex.Macho => "Mautes Destete",
        int value when value is > 365 and <= 600 && sex == Sex.Macho => "Mautes de Levante",
        int value when value is > 600 and <= 1080 && sex == Sex.Macho => "Mautes de Ceba",
        int value when value is > 1080 && sex == Sex.Hembra => "Vacas",
        int value when value is > 1080 && sex == Sex.Macho => "Toros",
        _ => "No Catalogado"
    };

    public void Inactive() => this.Status = Enums.Status.Inactivo;

    public void SetDiscard() => this.Discard = true;

    public void UpdateStatus(Status status, DateTime updateStatusDate, string? updateStatusReason)
    {
        Status = status;
        UpdateStatusDate = updateStatusDate;
        UpdateStatusReason = updateStatusReason;
    }

    public void UpdateInfo(
        string code,
        string? earTag,
        string? name,
        string? colour,
        string? brand,
        Sex sex,
        Origin origin,
        DateTime dOB,
        decimal birthWeight,
        DateTime arrivalDate,
        decimal incomeWeight,
        Guid? damId,
        Guid? sireId,
        string? imagePath,
        string? remark)
    {
        Code = code;
        EarTag = earTag;
        Name = name;
        Colour = colour;
        Brand = brand;
        Sex = sex;
        Origin = origin;
        DOB = dOB;
        BirthWeight = birthWeight;
        ArrivalDate = arrivalDate;
        IncomeWeight = incomeWeight;
        DamId = damId;
        SireId = sireId;
        ImagePath = imagePath;
        Remark = remark;
    }

    public void AddDamPups(Animal calf) => _damPups!.Add(calf);
    public void AddSirePups(Animal calf) => _sirePups!.Add(calf);
    #endregion

}
