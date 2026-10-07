using System.Text.Json.Serialization;

namespace ContractWatcher.Common.Enums;

/// <summary>
/// Статус валидации контракта
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ValidationStatus>))]
public enum ValidationStatus
{
    /// <summary>
    /// Проверка прошла успешно
    /// </summary>
    Passed,
    
    /// <summary>
    /// Проверка прошла с ошибкой
    /// </summary>
    Failed
}