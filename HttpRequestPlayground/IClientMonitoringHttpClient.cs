namespace ConsolePlaygrouns;

public class ClientMonitoringHttpClientConfiguration
{
    public string BaseUri { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public TimeSpan Timeout { get; set; }
}

public class FinMonitoringCheckRequestDTO
{
    public MonitoringOperationType MonitoringOperationType { get; set; } = null!;

    public long PaymentSystemClientId { get; set; }

    public long? CashStationId { get; set; }

    public string? PayerDepositAccount { get; set; }

    public decimal PayerDepositAmount { get; set; }
}