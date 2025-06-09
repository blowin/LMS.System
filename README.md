# Система управления обучением (Learning Management System / LMS)
**Backend на C# (ASP.NET Core)**  

---

## **Цель**  
Разработать платформу онлайн-обучения, где преподаватели могут создавать курсы, а студенты — изучать материалы, выполнять задания и отслеживать прогресс.

---

## **Технологии**  
### Основные:  
- Blazor
- Entity Framework Core (с Service'ами)  
- SQL Server / PostgreSQL  
- JWT Bearer Authentication (для авторизации внутри Blazor, через AuthenticationStateProvider)
- FluentValidation  
- Docker (опционально)  

### Дополнительные:  
- Serilog (логирование)
- xUnit + NSubstitute (тестирование)
- QuestPDF (экспорт в PDF)
- CsvHelper или ClosedXML (экспорт в CSV/Excel)

---

## **Функционал бэкенда**  
### 1. Аутентификация и роли  
- Регистрация и вход с использованием JWT (в рамках Blazor Server)
- Использование `AuthenticationStateProvider` для определения текущего пользователя и его ролей
- Поддержка ролей:
  - **Студент** — доступ к курсам, выполнение заданий, просмотр прогресса
  - **Преподаватель** — создание и управление курсами, проверка заданий
  - **Администратор** — управление пользователями и всеми курсами

### 2. Управление курсами  
- Создание, редактирование, публикация и архивирование курсов
- Возможность указать категорию курса
- Уроки внутри курса (в порядке) с поддержкой:
  - Текста
  - Ссылок
  - Файлов (PDF, видео) *(опционально)*

### 3. Задания и оценивание  
- Преподаватели могут создавать задания:
  - Текстовые ответы
  - Тесты с вариантами
  - Загрузку файлов
- Проверка заданий:
  - Автоматическая проверка тестов
  - Ручная проверка с выставлением оценки
  - Возможность добавить комментарий (обратную связь)

### 4. Прогресс студентов  
- Отслеживание завершенных уроков
- Просмотр результатов по заданиям и тестам
- Панель прогресса студента (для отображения в UI)

### 5. Дополнительные функции  
- Уведомления о дедлайнах (реализуется через Email)
- Экспорт оценок в CSV или Excel
- Поиск курсов (на основе LINQ-запросов, Elasticsearch — опционально) 

---

## Примеры сервисов и методов

### 1. `ICourseService`
Сервис для управления курсами.

```csharp
Task<IPagedList<CoursePageResponse>> GetCoursePageAsync(CoursePageRequest request, CancellationToken cancellationToken);
Task<CourseByIdResponse?> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken);
Task<Guid> CreateCourseAsync(CourseCreateRequest request, CancellationToken cancellationToken);
Task UpdateCourseAsync(CourseUpdateRequest request, CancellationToken cancellationToken);
Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken);
Task PublishCourseAsync(Guid id, CancellationToken cancellationToken);
Task ArchiveCourseAsync(Guid id, CancellationToken cancellationToken);
```

### 2. `IUserService`
Сервис для управления пользователями и прогрессом.

```csharp
Task<Guid> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken);
Task<string> LoginAsync(UserLoginRequest request, CancellationToken cancellationToken);
Task<UserProgressResponse> GetUserProgressAsync(Guid userId, CancellationToken cancellationToken);
Task<IPagedList<UserPageResponse>> GetUserPageAsync(UserPageRequest request, CancellationToken cancellationToken);
```

### 3. `IAssignmentService`
Сервис для управления заданиями и отправками.

```csharp
Task<Guid> CreateAssignmentAsync(CreateAssignmentRequest request, CancellationToken cancellationToken);
Task SubmitAssignmentAsync(SubmitAssignmentRequest request, CancellationToken cancellationToken);
Task<AssignmentResultResponse> GetAssignmentResultAsync(AssignmentResultRequest request, CancellationToken cancellationToken);
Task<IPagedList<AssignmentPageResponse>> GetAssignmentsByCoursePageAsync(AssignmentPageRequest request, CancellationToken cancellationToken);
```

### 4. `IProgressTrackingService`
Сервис для отслеживания прогресса студента.

```csharp
Task MarkLessonCompletedAsync(MarkLessonCompletedRequest request, CancellationToken cancellationToken);
Task<StudentDashboardResponse> GetStudentDashboardAsync(StudentDashboardRequest request, CancellationToken cancellationToken);
```

### 5. `INotificationService`
Сервис для уведомлений.

```csharp
Task SendDeadlineReminderAsync(SendDeadlineReminderRequest request, CancellationToken cancellationToken);
Task NotifyCoursePublishedAsync(NotifyCoursePublishedRequest request, CancellationToken cancellationToken);
```

---

## Архитектура и структура проекта

- **Сервисы (Domain Layer)**: логика обработки данных, взаимодействие с EF Core
- **Инфраструктура (Infrastructure Layer)**: Специфичные реализации (например, работа с CSV, отпрвка почты)
- **Компоненты Blazor (UI Layer)**: использование DI для взаимодействия с сервисами
- **Авторизация**: через `AuthorizeView`, `AuthenticationStateProvider` и `[Authorize(Roles = "...")]`

---

## **База данных (ER-диаграмма)**  
```plaintext
User:
- Id, Email, PasswordHash, Role, FirstName, LastName

Course:
- Id, Title, Description, CategoryId, InstructorId, IsPublished, CreatedAt

Category:
- Id, Name

Lesson:
- Id, Title, Content, CourseId, Order, Type (Text, Video, PDF)

Assignment:
- Id, Title, Description, Deadline, CourseId, AssignmentType (Test, FileUpload, Text)

Submission:
- Id, AssignmentId, StudentId, AnswerText, FilePath, Grade, Feedback, SubmittedAt

Enrollment:
- Id, StudentId, CourseId, EnrollmentDate, Completed (флаг завершения)

TestQuestion:
- Id, AssignmentId, QuestionText, QuestionType (SingleChoice, MultiChoice)

TestAnswerOption:
- Id, TestQuestionId, OptionText, IsCorrect

TestSubmission:
- Id, TestQuestionId, SubmissionId, SelectedOptionId

Все модели должны содержать CreateAt & UpdatedAt (кроме ситуаций M-M). Реализовать можно через подписку на событие `SavingChanges` DbContext'а.
```

### Сущности и связи:

- **User**: содержит информацию о пользователях (студенты, преподаватели, админы).
- **Course**: представляет собой учебный курс.
- **Lesson**: урок внутри курса.
- **Assignment**: задание, связанное с уроком или курсом.
- **Submission**: решения студентов по заданиям.
- **TestCategory**, **TestQuestion**, **TestAnswerOption** — для тестовых заданий.
- **Category**: категории курсов (например, "Программирование", "Маркетинг").
- **Enrollment**: информация о том, какие студенты записаны на курс.

> Для всех операций используется Entity Framework Core. Предполагается использование миграций
---

## **Оформление кода**

Для автоматического форматирования кода запускаем команду `dotnet format`. Данная команда может исправить не все ошибки (например документирование она не исправит), остальное нужно поправить руками при необходимости.

---

## **Коммиты**

Шаблон сообщения коммитов следующий: `PROJECT, AREA: ACTION`

Т.е, например, был добавлен сервис UserService в проект Domain, тогда сообщение будет такое `Domain, UserService: Added service`. Если в сервис был добавлен метод `CreateUserAsync`, тогда сообщение будет такое `Domain, UserService: Added 'CreateUserAsync' method`. Если добавляются тесты для сервиса `Test, UserService: Added tests for service` и т.д. Если что-то глобальное по проекту было сделано `Project`, но в идеале таких коммитов не должно быть, если за 1 коммит нельзя однозначно описать что было сделано, скорее всего делается что-то не так и в рамках одного коммита было сделано слишком много изменений.

---

## **Тестирование**

При добавление *ЛЮБОГО* функционала (кроме `UI`, его тестировать не будем, хотя там тоже часто возникают ошибки), должны быть написаны тесты, которые проверяют работоспособность кода. При тестировании сервисов, необходимо использовать EF Core + Sqlite в InMemory режиме, использование просто InMemory провайдер не проверит корректность Linq Expression.

Нигде напрямую не должны использоаться свойства DateTime.Now и/или DateTime.UtcNow, используется только ISystemClock для дальнейшего тестирования.

---

## **Именование веток**

Каждая ветка должна начинатся с префикса `feature` или `bug`, а далее идёт номер задачи. 

Пример, есть задача `https://github.com/blowin/LMS.System/issues/2`, у неё номер `2`, если мы делаем ветку для этой задачи, то название ветки будет такое: `feature/#2`, если это `bug`, то: `bug/#2`.

В названии PR обязательно должен фигурировать номер задачи, а так же она должна быть слинкована с PR (см поле `Development` в PR).

---

## **Миграции**

Обязательно делается отдельным проектом.
