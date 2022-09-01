namespace CattleRanch.Core.Domain.Helpers;
public static class Utils
{
    public static T ParseEnum<T>(string value) => (T)Enum.Parse(typeof(T), value, true);

    //public static int CalculateCategory(int ageDays, Sex sex)
    //{
    //    int categoryId = ageDays switch
    //    {
    //        int value when value is > 0 and <= 240 && sex == Sex.Hembra => 1,
    //        int value when value is > 0 and <= 240 && sex == Sex.Macho => 1,
    //        int value when value is > 240 and <= 365 && sex == Sex.Hembra => 2,
    //        int value when value is > 365 and <= 600 && sex == Sex.Hembra => 3,
    //        int value when value is > 600 and <= 1080 && sex == Sex.Hembra => 4,
    //        int value when value is > 240 and <= 365 && sex == Sex.Macho => 5,
    //        int value when value is > 365 and <= 600 && sex == Sex.Macho => 6,
    //        int value when value is > 600 and <= 1080 && sex == Sex.Macho => 7,
    //        int value when value is > 1080 && sex == Sex.Hembra => 8,
    //        int value when value is > 1080 && sex == Sex.Macho => 9,
    //        _ => 8,
    //    };
    //    return categoryId;
    //}
}
