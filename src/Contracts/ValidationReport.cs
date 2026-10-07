using ContractWatcher.Common.Enums;

namespace ContractWatcher.Common.Contracts;

/// <summary>
/// Отчет проверки контракта
/// </summary>
public sealed class ValidationReport
{
    /// <summary>
    /// ID отчета проверки
    /// </summary>
    public required Guid ReportId { get; init; }

    /// <summary>
    /// Версия контракта
    /// </summary>
    public required int ContractVersion { get; init; }

    /// <summary>
    /// Статус проверки контракта
    /// </summary>
    public required ValidationStatus Status { get; init; }

    /// <summary>
    /// Ошибки валидации контракта
    /// </summary>
    public required IReadOnlyCollection<ValidationViolation> Violations { get; init; }
}