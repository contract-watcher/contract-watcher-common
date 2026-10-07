using ContractWatcher.Common.Enums;

namespace ContractWatcher.Common.Contracts;

/// <summary>
/// Правило проверки поля контракта
/// </summary>
public sealed class ContractRule
{
    /// <summary>
    /// Название поля
    /// </summary>
    public required string FieldName { get; init; }

    /// <summary>
    /// Тип данных поля
    /// </summary>
    public required ContractFieldType Type { get; init; }

    /// <summary>
    /// Является ли поле обязательным
    /// </summary>
    public required bool Required { get; init; }

    /// <summary>
    /// Допутимо ли null значение для поля
    /// </summary>
    public required bool Nullable { get; init; }
}