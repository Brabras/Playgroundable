namespace Infrastructure.Seedwork.DataTypes;

public class Gender : EnumObject
{
    private const string MaleKey = "MAL";
    private const string FemaleKey = "FEM";

    public static readonly Gender Male = new(MaleKey, "Мужчина");
    public static readonly Gender Female = new(FemaleKey, "Женщина");

    public Gender(string key, string name) : base(key, name)
    {
    }

    public static Gender Create(string key)
    {
        return key switch
        {
            MaleKey => Male,
            FemaleKey => Female,
            _ => throw new InvalidOperationException($"Unsupported key '{key}'")
        };
    }

    public static implicit operator Gender(string key)
    {
        return Create(key);
    }
}