namespace ContractWatcher.Common.Contracts;

/// <summary>
/// Опубликованный контракт
/// </summary>
public sealed class PublishedContract
{
    /// <summary>
    /// Уникальное имя контракта в рамках текущей интеграции
    /// </summary>
    public required string Slug { get; init; }
    
    /// <summary>
    /// Версия контракта
    /// </summary>
    public required int ContractVersion { get; init; }

    /// <summary>
    /// Правила проверки полей контракта
    /// </summary>
    public required IReadOnlyCollection<ContractRule> Rules { get; init; }
}