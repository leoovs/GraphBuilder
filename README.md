# Построитель графиков
Приложение позволяет строить и масштабировать несколько графиков на одном холсте.
Содержит встроенный парсер математических выражений, что позволяет вводить
произвольные формулы, а не использовать заготовленные шаблоны. Парсер выполнен
в виде отдельной библиотеки классов, что позволяет переиспользовать его в других
проектах.

### Необходимые компоненты для запуска приложения:
- .NET Core Runtime версии 7.0 и выше

### Необходимые компоненты для сборки приложения:
- .NET Core SDK версии 7.0 и выше

### Как собрать приложение
#### 1. Склонировать репозиторий
Выполнить команду
`git clone https://github.com/leoovs/GraphBuilder.git GraphBuilder`
#### 2. Собрать .NET решение
Выполнить команду
`dotnet build`
#### 3. Запустить приложение через .NET
Выполнить команду
`dotnet run --project GraphBuilder.App`

### Синтаксис формул
Формулы имеют следющий синтаксис:
`<Название функции> = f(x,a,b,...)`
где `x` - переменная.

`a,b,...` - параметры, значения которых можно задать в выпадающем, списке.

`f(x,a,b,...)` - математическое выражение 

Пример:
`F = ln(x) * a * sin(x)`

