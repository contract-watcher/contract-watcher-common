# Подробности отчета

GET /internal/v1/integrations/{integrationId}/reports/{reportId}

| Файл | Описание |
|---|---|
| [response-passed.json](response-passed.json) | Успешная проверка, HTTP 200 |
| [response-failed.json](response-failed.json) | Проверка с нарушениями, HTTP 200 |
| [response-failed-repeated.json](response-failed-repeated.json) | Одинаковые нарушения в исходном порядке |
| [error-invalid-ids.json](error-invalid-ids.json) | 400: оба ID некорректны |
| [error-not-found.json](error-not-found.json) | 404: пара ID не найдена |

## Ответ

Ответ содержит integrationId, reportId, contractId, contractVersion, status, receivedAt, violationCount и violations. Вложенного объекта report нет.
Заголовок совпадает с соответствующей строкой истории. violationCount является 64-битным целым и равен числу элементов violations, включая повторы.

| Поле нарушения | Тип |
|---|---|
| groupId | UUID-строка или null |
| fieldName | Точное сохраненное имя поля |
| type | RequiredFieldMissing, NullNotAllowed или TypeMismatch |
| expectedType | Тип из общих правил или null |
| actualType | Тип из общих правил или null |

Нарушения возвращаются в сохраненном порядке. Одинаковые элементы остаются отдельными строками; groupId не является уникальным ключом элемента списка.
Для Passed возвращаются violations=[] и violationCount=0. Значения сохраненного отчета не пересчитываются при чтении.

Поиск выполняется по паре integrationId + reportId. Неизвестный отчет и отчет другой интеграции дают одинаковый 404 REPORT_NOT_FOUND.
Неверный UUID дает 400 INVALID_REQUEST с ключом integrationId и/или reportId в errors.
