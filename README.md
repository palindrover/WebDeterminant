# WebDeterminant

https://webdeterminant.ru

asp.net web plant determinant

Plant Controller
Выводит все растения из базы данных.

    Методы:
        Index()
            Выводит все растения из базы.

        GetHttpContext()
            Получает контекст для выбора растений из базы. В данном случае  контекста нет и выбираются все растения из базы.

        Details()
            Запускает js скрипт для выведения всплывающего окна с   подробностями о растении.


Test Controller
Выводит вопросы и в соответствии с ответами выводит подходящие растения.

    Методы:
        Index()
            Выводит на экран вопрос.

        Result()
            Получает ответ из формы, добавляет соответствующий запрос в строку запроса SQL, добавляет вопрос в стек вопросов, в зависимоти от ответа определяет следующий вопрос и перенаправляет на метод Index()

        End()
            Собирает строку запроса и выводит растения. Если подходящих растений нет, то выводит строку "Такого растения нет в базе".

        Back()
            Достаёт из стека последний вопрос и перенаправляет на метод Index()

        GetHttpContext()
            Получает контекст для выбора растений из базы.

        AddToSearchString()
            Добавляет в строку поиска данные для подбора растений.

        Details()
            Запускает js скрипт для выведения всплывающего окна с   подробностями о растении.


Plant List
Класс, позволяющий создать и заполнить список растений

    Методы:
        Init()
            Инициализирует список.

        Fill()
            Заполняет список.

        GetPlannts()
            Возвращает список растений.


Question List
Данный класс запрашивает вопросы из базы данных при запуске приложения и добавляет их в список.

    Методы:
        Init()
            Инициализация списка.

        Count()
            Считает количество вопросов в базе для создания статического списка.

        FillList()
            Читает таблицу с вопросами и заполняет список.


Question Stack
Класс, содержащий стек вопросов для использования кнопки "back".

    Методы:
        Init()
            Инициализация стека.

        AddTransitionNode()
            Добавляет последний вопрос в верхушку стека.

        GetLastNode()
            Читает и удаляет элемент из верхушки стека.

        ClearAllNodes()
            Очищает стек.


Safe Get Data Controller
Класс читает данные из базы и избегает ячеек с значением null.

    Методы:
        SafeGetStringData()
            Читает строки из базы данных.

        SafeGetNumericData()
            Читает числовые значения из базы данных.


Search String Builder
Построитель поисковой строки SQL.
    
    Методы:
        Init()
            Инициализация поисковой строки.

        SetLiveForm()
            Задаёт LiveForm id.

        SetLeafModification()
            Задаёт LeafModification id.

        SetLeafStructure()
            Задаёт LeafStructure id.

        SetLeafArangement()
            Задаёт LeafArangement id.

        BuildSearchString()
            Строит поисковую строку, основываясь на ответах на вопросы.

        ClearSearchIDs()
            Очищает id поисковой строки.

        CheckBeforeBuild()
            Проверяет, есть ли id.

        GetRecentSearchString()
            Возвращает поисковую строку.
