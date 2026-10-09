# Core → Monitoring

Предлагаемый формат POST /internal/v1/reports.
Требует подтверждения разработчиками Core и Monitoring.

report-failed.json и report-passed.json — тела запросов Core.
response-accepted.json — подтверждение сохранения, HTTP 201.
response-duplicate.json — подтверждение повторного отчета, HTTP 200.

Core определяет integrationId и contractId, проверяет принадлежность
контракта интеграции и существование использованной версии.

Поля внутри report соответствуют текущим DTO Common.
Passed передается с пустым violations, Failed — с непустым.
actualType может быть null для RequiredFieldMissing и NullNotAllowed.

Monitoring подтверждает прием после сохранения.
receivedAt — время первого сохранения в Monitoring, в UTC.
Повторная отправка сохраняет reportId и не увеличивает счетчики.

Исходный webhook, значения полей и секреты не передаются.
Все идентификаторы и даты в примерах вымышленные.