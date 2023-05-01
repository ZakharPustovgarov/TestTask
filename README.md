# TestTask

Репозитроий для тестового задания

## Описание задания

Создать компонент в Unity, который имеет кнопку. При нажатии на кнопку открывается окно со всеми MonoBehaviour классами на GameObject'е.
При двойном нажатии на класс в списке он открывается в сопряжённой с Unity IDE.

## Используемые классы

- `Assets\Scripts\ComponentCollector.cs` - компонент для сбора всех MonoBehaviour на GameObject'e, к которому он прикреплён
- `Assets\Scripts\CustomEditor\ComponentCollectorEditor.cs` - класс Editor'а, который добавляет кнопку в инспекторе для класса ComponentCollector и обрабатывает её нажатие
- `Assets\Scripts\TestClasses\Class1.cs, Class2.cs, Class3.cs, Class4.cs, Class5.cs` - компоненты для тестирования работы ComponentCollector
- `Assets\Scripts\ScriptableObjects\ClassListLayout.cs` - абстрактный ScriptableObject, который предоставляет методы для заполнения списка компонентов для показа и вызов открытия окна
- `Assets\Scripts\ScriptableObjects\ListClassListLayout.cs` - дочерний класс ClassListLayout, который вызывает открытия окна с компонентами через ListEditorWindow
- `Assets\Scripts\CustomEditor\ListEditorWindow.cs` - класс, который формирует окно и заполняет его переданными компонентами, а также обрабатывает двойное нажатия на элемент списка
- `Assets\Scripts\Utility\TypeUtility.cs` - утилитарный класс, используется для получения пути к файлу, содержащему MonoBehaviour

