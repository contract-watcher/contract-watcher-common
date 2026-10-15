# Отправка отчета

POST /internal/v1/reports, Content-Type: application/json.

| Файл | Описание |
|---|---|
| [report-passed.json](report-passed.json) | Проверка без нарушений |
| [report-failed.json](report-failed.json) | Проверка с нарушениями |
| [report-failed-repeated.json](report-failed-repeated.json) | Отчет с одинаковыми нарушениями |
| [response-accepted.json](response-accepted.json) | 201: новый отчет сохранен |
| [response-duplicate.json](response-duplicate.json) | 200: отчет уже был сохранен |
| [error-validation-report.json](error-validation-report.json) | 400: нарушены правила заполнения |

## Запрос

Конверт содержит integrationId и contractId в формате UUID и объект report:

| Поле report | Тип |
|---|---|
| reportId | UUID-строка |
| contractVersion | Положительное целое число |
| status | Passed или Failed |
| violations | Массив нарушений |

Нарушение содержит fieldName, type, expectedType и actualType.
fieldName должен быть непустой строкой, type и expectedType обязательны.
Для RequiredFieldMissing и NullNotAllowed actualType отсутствует или равен null.
Для TypeMismatch actualType обязателен и отличается от expectedType.
Для Passed violations пуст, для Failed содержит хотя бы один элемент. Null вместо элемента запрещен.
Допустимые строки типов перечислены в [общих правилах](../README.md#общие-правила).

integrationId, contractId и версия должны соответствовать контракту проверки. Исходный документ и значения его полей в отчет не входят.

## Ответ

integrationId и reportId возвращаются строками UUID, receivedAt содержит время первого сохранения, duplicate является boolean.
При повторе пары integrationId + reportId возвращается 200 с duplicate=true и прежним receivedAt. Первый сохраненный отчет не меняется.
Если ответ потерялся, повторная отправка использует прежний reportId.
