namespace Infrastructure.Seedwork.DataTypes;

public class WithdrawalAgentLimitTarget : EnumObject
{
    private const string CommonKey = "COM";
    private const string RequisitesKey = "REQ";

    public static readonly WithdrawalAgentLimitTarget Common = new(CommonKey, "Общие");
    public static readonly WithdrawalAgentLimitTarget Requisites = new(RequisitesKey, "Реквизит");

    private WithdrawalAgentLimitTarget(string key, string name)
        : base(key, name)
    {
    }

    public static WithdrawalAgentLimitTarget Create(string key)
    {
        return key switch
        {
            CommonKey => Common,
            RequisitesKey => Requisites,
            _ => throw new InvalidOperationException($"Unsupported type '{key}'")
        };
    }
}