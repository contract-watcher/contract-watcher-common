# История проверок

GET /internal/v1/integrations/{integrationId}/reports

| Файл | Описание |
|---|---|
| [response-page.json](response-page.json) | Страница истории, HTTP 200 |
| [response-filtered.json](response-filtered.json) | Только Failed за период из примера ниже |
| [response-empty.json](response-empty.json) | Пустой результат |
| [response-outside-page.json](response-outside-page.json) | Страница за пределами списка |
| [error-invalid-request.json](error-invalid-request.json) | 400: неверный limit |

## Параметры

| Параметр | Правила |
|---|---|
| from | Нижняя граница времени приема, включительно |
| to | Верхняя граница, исключительно |
| status | Passed или Failed, без параметра оба результата |
| offset | 0..2147483647, по умолчанию 0 |
| limit | 1..100, по умолчанию 20 |

Все параметры необязательны. Время: YYYY-MM-DDTHH:mm:ss[.ffffff]Z, год 0001-9999, дробь до шести знаков. Смещение вместо Z не принимается. При двух границах нужно from < to.
Известные параметры передаются один раз, непустыми. offset и limit являются целыми без знака и пробелов. Неизвестные параметры игнорируются.

```http
GET /internal/v1/integrations/22222222-2222-4222-8222-222222222222/reports?from=2026-10-09T12:00:00Z&to=2026-10-09T12:03:00Z&status=Failed&offset=0&limit=20
```

## Ответ

items содержит текущую страницу, total считает отчеты после фильтров, offset и limit отражают примененные значения.
Каждая строка содержит reportId, contractId, contractVersion, status, receivedAt и violationCount.
total и violationCount являются 64-битными целыми; версия, offset и limit являются 32-битными целыми.

Порядок: receivedAt по убыванию, при равном времени внутренний ID строки по убыванию.
Новые отчеты между запросами могут сдвинуть страницы.
Пустая или неизвестная интеграция дает items=[] и total=0. Страница за пределами списка сохраняет настоящий total.
