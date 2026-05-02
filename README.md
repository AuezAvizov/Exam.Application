# 🎓 Online Examination System (ASP.NET)

![Language](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Framework](https://img.shields.io/badge/Framework-ASP.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/Status-In_Development-blue?style=flat-square)

Комплексная система онлайн-тестирования, разрабатываемая на базе **ASP.NET (C#)**. 

Проект создается в рамках дипломной работы и направлен на автоматизацию проверки знаний студентов. Особое внимание уделено разделению логики: проект использует многослойную архитектуру, включая отдельные модули для доступа к данным (`DataAccess`) и представления (`ViewModels`).

---

## ✨ Текущий и планируемый функционал

* 📝 **Модуль тестирования (В процессе):** Гибкий конструктор тестов для преподавателей с поддержкой различных форматов вопросов (Multiple choice, True/False, текстовые ответы).
* 👨‍🏫 **Панель преподавателя:** Удобный дашборд для управления тестами, мониторинга активности студентов и ручной/автоматической проверки результатов.
* 🛡️ **Аутентификация (В планах):** Безопасная система входа с разделением ролей (Студент / Преподаватель / Администратор).
* 📊 **Аналитика (В планах):** Сбор статистики успеваемости и генерация отчетов по результатам экзаменов.

---

## 🛠 Технологический стек и Архитектура

* **Язык разработки:** C#
* **Платформа:** ASP.NET 
* **Архитектурный паттерн:** N-Tier Architecture (выделенные слои `OnlineExamination.DataAccess` и `OnlineExamination.ViewModels`)

---

## 🚀 Запуск проекта (Development)

1. Склонируйте репозиторий:
   ```bash
   git clone [https://github.com/AuezAvizov/online-examination-aspnet.git](https://github.com/AuezAvizov/online-examination-aspnet.git)
