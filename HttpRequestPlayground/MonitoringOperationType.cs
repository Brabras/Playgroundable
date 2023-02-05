namespace ConsolePlaygrouns;

public class MonitoringOperationType : EnumObject
{
    private const string ClientConfirmVerificationKey = "ClientConfirmVerification";
    private const string CreatePayerKey = "CreatePayer";
    private const string UpdatePaymentSystemClientIdentityDocumentKey = "UpdatePaymentSystemClientIdentityDocument";
    private const string UpdateFinMonitoringClientFromWatcherKey = "UpdateFinMonitoringClientFromWatcher";

    public static readonly MonitoringOperationType ClientConfirmVerification = new(ClientConfirmVerificationKey,
                                                                                   "Подтверждение верификации");
    
    public static readonly MonitoringOperationType CreatePayer = new(CreatePayerKey, 
                                                                     "Создание плательщика");
    
    public static readonly MonitoringOperationType UpdatePaymentSystemClientIdentityDocument = new(UpdatePaymentSystemClientIdentityDocumentKey,
                                                                                                   "Обновление анкеты");
    
    public static readonly MonitoringOperationType UpdateFinMonitoringClientFromWatcher = new(UpdateFinMonitoringClientFromWatcherKey,
                                                                                              "Проверка пользователей по черным спискам комплаенса");
    
    
    private MonitoringOperationType(string key, string name) : base(key, name)
    {
    }

    public static MonitoringOperationType Create(string key)
    {
        return key switch
        {
            ClientConfirmVerificationKey => ClientConfirmVerification,
            CreatePayerKey => CreatePayer,
            UpdatePaymentSystemClientIdentityDocumentKey => UpdatePaymentSystemClientIdentityDocument,
            UpdateFinMonitoringClientFromWatcherKey => UpdateFinMonitoringClientFromWatcher,
            _ => throw new InvalidOperationException($"Unsupported key '{key}'")
        };
    }

    public static implicit operator MonitoringOperationType(string key)
    {
        return Create(key);
    }
}
