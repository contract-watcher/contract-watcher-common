using System.Text.Json.Serialization;

namespace ContractWatcher.Common.Enums;

/// <summary>
/// Типы ошибок валидации контракта
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ViolationType>))]
public enum ViolationType
{
    /// <summary>
    /// Отсутствует обяхательное поле
    /// </summary>
    RequiredFieldMissing,
    
    /// <summary>
    /// Несовпадение типов
    /// </summary>
    TypeMismatch,
    
    /// <summary>
    /// Не допустимо использование null
    /// </summary>
    NullNotAllowed
}