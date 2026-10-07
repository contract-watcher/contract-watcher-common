using ContractWatcher.Common.Enums;

namespace ContractWatcher.Common.Contracts;

/// <summary>
/// Ошибка валидации правила проверки
/// </summary>
public sealed class ValidationViolation
{
    /// <summary>
    /// Навзание поля
    /// </summary>
    public required string FieldName { get; init; }

    /// <summary>
    /// Тип ошибки валидации
    /// </summary>
    public required ViolationType Type { get; init; }

    /// <summary>
    /// Ожидаемый тип данных поля
    /// </summary>
    public ContractFieldType? ExpectedType { get; init; }

    /// <summary>
    /// Полученный тип данных поля
    /// </summary>
    public ContractFieldType? ActualType { get; init; }
}