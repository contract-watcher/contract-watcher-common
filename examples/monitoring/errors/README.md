# Ошибки

Content-Type: application/problem+json.

| Файл | HTTP / code |
|---|---|
| [error-invalid-request.json](error-invalid-request.json) | 400 INVALID_REQUEST: неверный JSON |
| [error-unsupported-media-type.json](error-unsupported-media-type.json) | 415 UNSUPPORTED_MEDIA_TYPE: неподходящий Content-Type |
| [error-storage-unavailable.json](error-storage-unavailable.json) | 503 STORAGE_UNAVAILABLE: хранилище недоступно |
| [error-internal.json](error-internal.json) | 500 INTERNAL_ERROR: ошибка чтения отчета |
| [Ошибка полей отчета](../reports/error-validation-report.json) | 400 VALIDATION_REPORT_INVALID |
| [Ошибка параметров истории](../history/error-invalid-request.json) | 400 INVALID_REQUEST |
| [Ошибка ID](../details/error-invalid-ids.json) | 400 INVALID_REQUEST |
| [Отчет не найден](../details/error-not-found.json) | 404 REPORT_NOT_FOUND |

## Поля ответа

- type: about:blank.
- title: название HTTP-статуса.
- status: HTTP-статус числом.
- detail: пояснение ошибки.
- instance: фактический путь запроса без query.
- code: код для обработки ошибки.
- errors: объект «поле -> массив сообщений», либо {} для общей ошибки.

Путь instance зависит от запроса. Для 500 текст detail зависит от операции: «Не удалось обработать отчет.», «Не удалось прочитать историю.» или «Не удалось прочитать отчет.».
