# Система управления обучением (Learning Management System / LMS)
**Backend на C# (ASP.NET Core)**  

---

## **Цель**  
Разработать платформу онлайн-обучения, где преподаватели могут создавать курсы, а студенты — изучать материалы, выполнять задания и отслеживать прогресс.

---

## **Технологии**  
### Основные:  
- Blazor
- Entity Framework Core (с Repository + Service паттерном)  
- SQL Server / PostgreSQL  
- JWT Bearer Authentication  
- FluentValidation  
- Docker (опционально)  

### Дополнительные:  
- Swagger/OpenAPI  
- xUnit / NSubstitude
- Serilog  
- QuestPDF  

---

## **Функционал бэкенда**  
### 1. Аутентификация и роли  
- Регистрация/вход через JWT.  
- Роли:  
  - **Студент**: просмотр курсов, выполнение заданий, отслеживание прогресса.  
  - **Преподаватель**: создание курсов, управление уроками, проверка заданий.  
  - **Админ**: управление пользователями и курсами.  

### 2. Управление курсами  
- Создание/редактирование курсов (название, описание, категория).  
- Добавление уроков:  
  - Текстовый контент.  
  - Ссылки на внешние ресурсы.  
  - Файлы (PDF, видео). (ОПЦИОНАЛЬНО)
- Публикация/архивация курсов.  

### 3. Задания и оценивание  
- Преподаватели могут создавать:  
  - Текстовые задания.  
  - Тесты с вариантами ответов.  
  - Задания с загрузкой файлов.  
- Система проверки:  
  - Автоматическая проверка тестов.  
  - Ручная оценка преподавателем.  
  - Обратная связь через комментарии.  

### 4. Прогресс студентов  
- Отслеживание пройденных уроков.  
- Статистика по оценкам и дедлайнам.  
- Dashboard с общей успеваемостью (для фронтенда).  

### 5. Дополнительные функции  
- Уведомления о дедлайнах (Email/SignalR).  
- Экспорт оценок в CSV/Excel.  
- Поиск курсов (LINQ/Elasticsearch).  

---

## **Пример структуры API**  
### 1. Курсы  
- `GET /api/courses?page=1&pageSize=10` — получить список курсов с пагинацией  
- `GET /api/courses/{id}` — получить детали курса  
- `POST /api/courses` — создать курс *(только преподаватель/админ)*  
- `PUT /api/courses/{id}` — обновить курс  
- `DELETE /api/courses/{id}` — удалить курс  

### 2. Пользователи  
- `POST /api/auth/register` — регистрация.  
- `POST /api/auth/login` — вход.  
- `GET /api/users/{id}/progress` — прогресс студента.  

### 3. Задания  
- `POST /api/assignments` — создание задания (преподаватель).  
- `POST /api/assignments/{id}/submit` — отправка решения (студент).  
- `GET /api/assignments/{id}/results` — результаты выполнения.  

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
