# Monitoring

| Метод и путь | Описание и примеры |
|---|---|
| POST /internal/v1/reports | [Отправка отчета](reports/README.md) |
| GET /internal/v1/integrations/{integrationId}/reports | [История проверок](history/README.md) |
| GET /internal/v1/integrations/{integrationId}/reports/{reportId} | [Подробности отчета](details/README.md) |

[Ошибки](errors/README.md). [Запросы Postman](monitoring.postman_collection.json).

## Общие правила

- Успешный ответ: application/json. Ошибка: application/problem+json.
- UUID передаются строками. Даты в ответах имеют UTC и окончание Z.
- Nullable-поля ответа передаются явно как null, пустые списки как [].
- receivedAt означает серверное время приема отчета.
- Имена полей и порядок нарушений сохраняются, одинаковые нарушения не объединяются.

| Поле | Значения |
|---|---|
| status | Passed, Failed |
| type нарушения | RequiredFieldMissing, NullNotAllowed, TypeMismatch |
| expectedType, actualType | String, Number, Boolean, Object, Array |

Для чтения expectedType и actualType могут быть null. Правила входного отчета указаны отдельно.
Ответы истории и подробностей содержат данные для Core и фронта; фронт получает их через Core.
