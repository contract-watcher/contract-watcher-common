using System.Text.Json.Serialization;

namespace ContractWatcher.Common.Enums;

/// <summary>
/// Тип поля контракта
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ContractFieldType>))]
public enum ContractFieldType
{
    /// <summary>
    /// Строка
    /// </summary>
    String,
    
    /// <summary>
    /// Число
    /// </summary>
    Number,
    
    /// <summary>
    /// Булево значение
    /// </summary>
    Boolean,
    
    /// <summary>
    /// Объект
    /// </summary>
    Object,
    
    /// <summary>
    /// Массив
    /// </summary>
    Array
}