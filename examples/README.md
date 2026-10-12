# Как Core отправляет отчет в Monitoring

Monitoring сохраняет отчеты о проверках. Core получает отчет от SDK,
проверяет интеграцию, контракт и его версию, затем отправляет отчет в Monitoring.

## Что нужно сделать в Core

1. Взять отчет, полученный от SDK.
2. Добавить integrationId и contractId: ID интеграции и ID контракта,
   по которому SDK выполнял проверку. Сам отчет находится внутри report.
3. Отправить JSON в POST /internal/v1/reports на адрес Monitoring
   с заголовком Content-Type: application/json.
4. Дождаться ответа. HTTP 201 означает, что отчет и все нарушения сохранены.

## Примеры запросов и ответов

- [report-passed.json](report-passed.json): проверка прошла без нарушений.
- [report-failed.json](report-failed.json): SDK обнаружил нарушения.
- [response-accepted.json](response-accepted.json): отчет сохранен, HTTP 201.
- [error-validation-report.json](error-validation-report.json): ошибка в полях отчета, HTTP 400.
- [error-report-id-conflict.json](error-report-id-conflict.json): отчет уже сохранен, HTTP 409.
- [error-storage-unavailable.json](error-storage-unavailable.json): хранилище недоступно, HTTP 503.
- [response-duplicate.json](response-duplicate.json): будущий успешный ответ на повтор.
  Сейчас этот ответ еще не реализован.

Все ID и даты в примерах вымышленные.
receivedAt — время сохранения в Monitoring, в UTC.
duplicate=false означает, что сохранен новый отчет.

## Правила заполнения

- integrationId, contractId и reportId обязательны и должны быть UUID.
- contractVersion — целое число больше нуля, без кавычек.
- Статус и типы передаются строками с точным написанием, как в примерах:
  Passed, Failed, RequiredFieldMissing, NullNotAllowed, TypeMismatch,
  String, Number, Boolean, Object, Array.
- Для Passed список violations должен быть пустым.
- Для Failed список violations должен содержать хотя бы одно нарушение.
- В списке violations не должно быть null вместо нарушения.
- Каждому нарушению нужны непустой fieldName, type и expectedType.
  expectedType — тип, который ожидался по правилу контракта.
- Для RequiredFieldMissing и NullNotAllowed поле actualType нужно
  не передавать или передавать как null.
- Для TypeMismatch поле actualType обязательно и должно отличаться
  от expectedType.

Принадлежность контракта интеграции и существование версии проверяет Core.
Исходный webhook, значения его полей и секретные ключи в запрос не включаются.

## Как читать ошибки

Ошибки возвращаются с Content-Type: application/problem+json.

detail содержит описание ошибки.
code содержит название ошибки для обработки в программе.
errors показывает поля, которые нужно исправить.

Например, report.violations[0].actualType означает actualType
в первом нарушении. Если ошибка не относится к полю, errors будет {}.

| HTTP | code | Что произошло |
|---|---|---|
| 400 | INVALID_REQUEST | Пустое тело, неверный JSON или неверный тип значения |
| 400 | VALIDATION_REPORT_INVALID | Нарушены правила заполнения отчета |
| 415 | UNSUPPORTED_MEDIA_TYPE | Запрос передан не как application/json |
| 409 | REPORT_ID_CONFLICT | Такой reportId уже сохранен в этой интеграции |
| 503 | STORAGE_UNAVAILABLE | Хранилище Monitoring недоступно |
| 500 | INTERNAL_ERROR | Другая ошибка обработки или сохранения |

## Повторная отправка

Сейчас уже сохраненный reportId в той же интеграции получает HTTP 409.
Позже будет реализован успешный ответ HTTP 200 с duplicate=true,
показанный в response-duplicate.json.

Если Core не дождался ответа, отчет мог успеть сохраниться.
При повторной отправке того же отчета нужно сохранять прежний reportId.

Прием реализован и проверен в Monitoring.
Настоящую отправку из Core еще нужно проверить вместе с Monitoring.