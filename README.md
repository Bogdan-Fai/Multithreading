# Лабораторная работа: Многопоточность в C#

Этот проект демонстрирует основные концепции многопоточности в C#. В проекте реализованы два задания:

1. **Задание 1: Гонка данных**
2. **Задание 2: Producer-Consumer**

## Описание

### Задание 1: Гонка данных
Этот модуль демонстрирует проблему гонки данных и различные способы её решения:
- Небезопасное инкрементирование
- Использование блокировки
- Использование `Interlocked.Increment`

### Задание 2: Producer-Consumer
Этот модуль демонстрирует паттерн Producer-Consumer с использованием `BlockingCollection` и отмены задач.

## Требования

- .NET Core SDK 3.1 или выше

## Установка

1. Убедитесь, что у вас установлен .NET Core SDK 3.1 или выше. Вы можете скачать его с [официального сайта .NET](https://dotnet.microsoft.com/download).
2. Клонируйте репозиторий или скопируйте проект в вашу рабочую директорию.

## Запуск

1. Откройте терминал и перейдите в директорию проекта.
2. Запустите программу с помощью команды:

```bash
dotnet build
```

```bash
dotnet run
```

3. Программа предложит выбрать задание:
   - Введите `1` для запуска задания "Гонка данных".
   - Введите `2` для запуска задания "Producer-Consumer".
   - Введите `0` для выхода из программы.

## Структура проекта

- **Program.cs**: Точка входа в программу, предоставляет меню для выбора задания.
- **RaceCondition.cs**: Реализация задания "Гонка данных".
- **ProducerConsumer.cs**: Реализация задания "Producer-Consumer".
- **MultithreadingDemo.csproj**: Проектный файл.

## Пример вывода

### Задание 1: Гонка данных

```
--- Задание 1: Гонка данных ---

UnsafeIncrement:
Время: 100 ms, Итоговое значение counter = 400000
LockIncrement:
Время: 150 ms, Итоговое значение counter = 400000
InterlockedIncrement:
Время: 120 ms, Итоговое значение counter = 400000
```

### Задание 2: Producer-Consumer

```
--- Задание 2: Producer–Consumer ---

Produced: 1
Produced: 2
Produced: 3
Consumer 1 processed: 1 -> 2
Consumer 2 processed: 2 -> 4
Produced: 4
Consumer 3 processed: 3 -> 6
Produced: 5
Produced: 6
Consumer 1 processed: 4 -> 8
Consumer 2 processed: 5 -> 10
Produced: 7
Produced: 8
Consumer 3 processed: 6 -> 12
Produced: 9
Produced: 10
Consumer 1 processed: 7 -> 14
Consumer 2 processed: 8 -> 16
Produced: 11
Produced: 12
Consumer 3 processed: 9 -> 18
Produced: 13
Produced: 14
Consumer 1 processed: 10 -> 20
Consumer 2 processed: 11 -> 22
Produced: 15
Produced: 16
Consumer 3 processed: 12 -> 24
Produced: 17
Produced: 18
Consumer 1 processed: 13 -> 26
Consumer 2 processed: 14 -> 28
Produced: 19
Produced: 20
Consumer 3 processed: 15 -> 30
Produced: 21
Produced: 22
Consumer 1 processed: 16 -> 32
Consumer 2 processed: 17 -> 34
Produced: 23
Produced: 24
Consumer 3 processed: 18 -> 36
Produced: 25
Produced: 26
Consumer 1 processed: 19 -> 38
Consumer 2 processed: 20 -> 40
Produced: 27
Produced: 28
Consumer 3 processed: 21 -> 42
Produced: 29
Produced: 30
Consumer 1 processed: 22 -> 44
Consumer 2 processed: 23 -> 46
Produced: 31
Produced: 32
Consumer 3 processed: 24 -> 48
Produced: 33
Produced: 34
Consumer 1 processed: 25 -> 50
Consumer 2 processed: 26 -> 52
Produced: 35
Produced: 36
Consumer 3 processed: 27 -> 54
Produced: 37
Produced: 38
Consumer 1 processed: 28 -> 56
Consumer 2 processed: 29 -> 58
Produced: 39
Produced: 40
Consumer 3 processed: 30 -> 60
Produced: 41
Produced: 42
Consumer 1 processed: 31 -> 62
Consumer 2 processed: 32 -> 64
Produced: 43
Produced: 44
Consumer 3 processed: 33 -> 66
Produced: 45
Produced: 46
Consumer 1 processed: 34 -> 68
Consumer 2 processed: 35 -> 70
Produced: 47
Produced: 48
Consumer 3 processed: 36 -> 72
Produced: 49
Produced: 50
Consumer 1 processed: 37 -> 74
Consumer 2 processed: 38 -> 76
Consumer 3 processed: 39 -> 78
Consumer 1 processed: 40 -> 80
Consumer 2 processed: 41 -> 82
Consumer 3 processed: 42 -> 84
Consumer 1 processed: 43 -> 86
Consumer 2 processed: 44 -> 88
Consumer 3 processed: 45 -> 90
Consumer 1 processed: 46 -> 92
Consumer 2 processed: 47 -> 94
Consumer 3 processed: 48 -> 96
Consumer 1 processed: 49 -> 98
Consumer 2 processed: 50 -> 100
Все задачи завершены.
```

## Лицензия

Этот проект лицензирован под лицензией MIT.
