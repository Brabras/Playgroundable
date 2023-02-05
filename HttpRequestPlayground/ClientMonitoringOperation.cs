namespace ConsolePlaygrouns;

public class ClientMonitoringOperation
{
    public MonitoringOperationType MonitoringOperationType { get; private init; }

    public long PaymentSystemClientId { get; private init; }

    public long? CashStationId { get; private set; }

    public string? PayerDepositAccount { get; private init; }

    public decimal? PayerDepositAmount { get; private init; }


    private ClientMonitoringOperation()
    {
    }

    public static ClientMonitoringOperation ClientConfirmVerification(long paymentSystemClientId,
                                                                      long cashStationId)
    {
        return new ClientMonitoringOperation
        {
            PaymentSystemClientId   = paymentSystemClientId,
            CashStationId           = cashStationId
        };
    }
    
    public static ClientMonitoringOperation CreatePayerOperation(long paymentSystemClientId,
                                                                 long cashStationId,
                                                                 string? payerDepositAccount,
                                                                 decimal payerDepositAmount)
    {
        return new ClientMonitoringOperation
        {
            MonitoringOperationType = MonitoringOperationType.CreatePayer,
            PaymentSystemClientId   = paymentSystemClientId,
            CashStationId           = cashStationId,
            PayerDepositAccount     = payerDepositAccount,
            PayerDepositAmount      = payerDepositAmount
        };
    }
    //
    // public static ClientMonitoringOperation UpdatePaymentSystemClientIdentityDocument(long paymentSystemClientId)
    // {
    //     return new ClientMonitoringOperation
    //     {
    //         MonitoringOperationType = MonitoringOperationType.UpdatePaymentSystemClientIdentityDocument,
    //         PaymentSystemClientId   = paymentSystemClientId
    //     };
    // }
    //
    // public static ClientMonitoringOperation UpdateFinMonitoringClientFromWatcherOperation(long paymentSystemClientId)
    // {
    //     return new ClientMonitoringOperation
    //     {
    //         MonitoringOperationType = MonitoringOperationType.UpdateFinMonitoringClientFromWatcher,
    //         PaymentSystemClientId   = paymentSystemClientId
    //     };
    // }
}