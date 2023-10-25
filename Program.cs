using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;


// Класс для представления заказа
public class Order
{
    // Меню с пунктами
    public static readonly List<MenuItem> CakeForms = new List<MenuItem>
    {
        new MenuItem("Круглая", 1000),
        new MenuItem("Прямоугольная", 1500),
        new MenuItem("Сердце", 1200)
    };

    public static MenuItem GetSelectedCakeForm(int choice)
{
    // Проверяем значение выбора и возвращаем соответствующий вариант
    switch (choice)
    {
        case 1:
            return CakeForms[0]; // Возвращаем "Круглая", 1000
        case 2:
            return CakeForms[1]; // Возвращаем "Прямоугольная", 1500
        case 3:
            return CakeForms[2]; // Возвращаем "Сердце", 1200
        default:
            throw new ArgumentException("Некорректный выбор. Допустимые значения: 1, 2, 3.");
    }
}

    public static readonly List<MenuItem> CakeSizes = new List<MenuItem>
    {
        new MenuItem("Маленький", 500),
        new MenuItem("Средний", 800),
        new MenuItem("Большой", 1200)
    };

    public static readonly List<MenuItem> CakeFlavors = new List<MenuItem>
    {
        new MenuItem("Шоколадный", 600),
        new MenuItem("Ванильный", 500),
        new MenuItem("Карамельный", 700)
    };

    public static readonly List<MenuItem> CakeQuantities = new List<MenuItem>
    {
        new MenuItem("Один", 1),
        new MenuItem("Два", 2),
        new MenuItem("Три", 3)
    };

    public static readonly List<MenuItem> CakeIcings = new List<MenuItem>
    {
        new MenuItem("Шоколадная", 203),
        new MenuItem("Ванильная", 150),
        new MenuItem("Карамельная", 250)
    };

    public static readonly List<MenuItem> CakeDecorations = new List<MenuItem>
    {
        new MenuItem("Цветочные узоры", 300),
        new MenuItem("Фигурки", 400),
        new MenuItem("Надписи", 200)
    };

    private string filePath; // Путь к файлу для сохранения заказов
    private List<MenuItem> chosenItems; // Выбранные пункты заказа

    public Order(string filePath)
    {
        this.filePath = filePath;
        chosenItems = new List<MenuItem>();
    }
    //ЗАХОТЕЛОСЬ ПОЕСТЬ...
    // Функция для отображения меню и выбора пунктов заказа
    public void ShowMenu()
    {

        ConsoleKeyInfo keyInfo;
        bool isOrderCompleted = false;

        // Пока заказ не завершен
        while (!isOrderCompleted)
        {
            Console.Clear();
        Console.WriteLine("Выберите пункты заказа:");

        // Вывод основного меню
        Console.WriteLine("1. Форма");
        Console.WriteLine("2. Размер");
        Console.WriteLine("3. Вкус");
        Console.WriteLine("4. Количество");
        Console.WriteLine("5. Глазурь");
        Console.WriteLine("6. Декор");
        Console.WriteLine("7. Завершить заказ и сохранить");
            keyInfo = Console.ReadKey();

            // При нажатии Enter переходим к дополнительному меню
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                Console.WriteLine($"Выберите пункт меню для {chosenItems.Count + 1} пункта заказа:");

                // В зависимости от выбранного пункта основного меню выводим дополнительные подпункты
                switch (chosenItems.Count + 1)
                {
                    case 1:
                        ShowSubMenu(CakeForms);
                        break;
                    case 2:
                        ShowSubMenu(CakeSizes);
                        break;
                    case 3:
                        ShowSubMenu(CakeFlavors);
                        break;
                    case 4:
                        ShowSubMenu(CakeQuantities);
                        break;
                    case 5:
                        ShowSubMenu(CakeIcings);
                        break;
                    case 6:
                        ShowSubMenu(CakeDecorations);
                        break;
                }
            }
            // При нажатии Escape выходим из программы
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            // При нажатии цифровой клавиши добавляем выбранный пункт в заказ
            else if (Char.IsDigit(keyInfo.KeyChar))
            {
                int choice = Int32.Parse(keyInfo.KeyChar.ToString());

                Console.Clear();

                Console.WriteLine($"Выберите пункт меню для {chosenItems.Count + 1} пункта заказа:");

                // В зависимости от выбранного пункта основного меню выводим дополнительные подпункты
                switch (choice)
                {
                    case 1:
                        ShowSubMenu(CakeForms);
                        break;
                    case 2:
                        ShowSubMenu(CakeSizes);
                        break;
                    case 3:
                        ShowSubMenu(CakeFlavors);
                        break;
                    case 4:
                        ShowSubMenu(CakeQuantities);
                        break;
                    case 5:
                        ShowSubMenu(CakeIcings);
                        break;
                    case 6:
                        ShowSubMenu(CakeDecorations);
                        break;
                        case 7:
                        SaveOrder();

                        break;
                }
                /*
                                // Проверка, что выбранный пункт есть в подменю
                                if (choice >= 1 && choice <= chosenItems.Count)
                                {
                                    Console.WriteLine("Данный пункт уже выбран, выберите другой.");
                                    continue;
                                }

                                if (choice >= 1 && choice <= GetSubMenuCount())
                                {
                                    chosenItems.Add(GetSelectedItem(choice));
                                    Console.WriteLine($"Выбран пункт {chosenItems[choice - 1].Description}");
                                    Console.WriteLine();
                                }
                                else if (choice == GetSubMenuCount() + 1)
                                {
                                    SaveOrder(); // Завершаем заказ и сохраняем его
                                    isOrderCompleted = true;
                                }
                                else
                                {
                                    Console.WriteLine("Неверный пункт меню, выберите другой.");
                                }*/
            }
            else
            {
                Console.WriteLine("Неверный символ, выберите другой.");
            }
        }
    }

    // Отображение дополнительного меню
    private void ShowSubMenu(List<MenuItem> menuItems)
    {
        int index = 1;

        foreach (var menuItem in menuItems)
        {
            Console.WriteLine($"{index}. {menuItem.Description} ({menuItem.Price} руб.)");
            index++;
        }

        Console.WriteLine($"{index}. Завершить заказ и сохранить");

        // Здесь также реализуется возможность нажать Esc для выхода из программы
        ConsoleKeyInfo keyInfo;

        while (true)
        {
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else if (Char.IsDigit(keyInfo.KeyChar))
            {
                int choice = Int32.Parse(keyInfo.KeyChar.ToString());

                if (choice >= 1 && choice <= menuItems.Count)
                {
                    chosenItems.Add(menuItems[choice - 1]);
                    Console.WriteLine($"Выбран пункт {menuItems[choice - 1].Description}");
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                }
                else if (choice == menuItems.Count + 1)
                {
                    SaveOrder();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Неверный пункт меню, выберите другой.");
                }
            }
            else
            {
                Console.WriteLine("Неверный символ, выберите другой.");
            }
        }
    }

    // Получение количества пунктов в дополнительном меню
    private int GetSubMenuCount()
    {
        int count = 0;

        foreach (var menuItem in chosenItems)
        {
            if (menuItem == chosenItems[chosenItems.Count - 1])
            {
                count += 1;
            }
            else
            {
                count += 2;
            }
        }

        return count;
    }

    // Получение выбранного пункта в дополнительном меню
    private MenuItem GetSelectedItem(int choice)
    {
        int index = 1;

        foreach (var menuItem in chosenItems)
        {
            if (choice == index)  // Сравниваем выбранный пункт меню с текущим индексом
            {
                return menuItem;
            }
            else if (choice == index + 1 && menuItem != chosenItems[chosenItems.Count - 1]) // Проверяем, что выбранный пункт меню является вторым пунктом и не является последним пунктом
            {
                return menuItem;
            }

            index += 2;
        }

        return null; // Возвращаем null в случае, если выбранного пункта меню не существует
    }

    // Сохранение заказа в файл
    // Здесь мы имеем метод SaveOrder() для сохранения заказа.
    // Внутри метода используется объект StreamWriter для записи текстовых данных в файл, указанный в переменной filePath.

    private void SaveOrder()
    {
        string Path = "Файлик.txt";


        // Создаем объект StreamWriter, используя конструктор, который принимает два параметра:
        // filePath - путь к файлу, в который будут записываться данные.
        // true - указывает, что при записи новые данные будут добавляться в конец файла, а не заменять его содержимое.
        using (var writer = new StreamWriter(Path, true))
        {
            string message = "";
            // Проходим по каждому элементу в коллекции chosenItems
            writer.WriteLine("\n\nЗаказ");
            foreach (var menuItem in chosenItems)
            {
                // Записываем в файл описание и цену каждого элемента.
                writer.WriteLine($"{menuItem.Description} - {menuItem.Price} руб.");
            }

            // Инициализируем переменную totalPrice в значение 0.
            decimal totalPrice = 0;

            // Снова проходим по каждому элементу в коллекции chosenItems
            foreach (var menuItem in chosenItems)
            {
                // Добавляем цену каждого элемента к общей сумме.
                totalPrice += menuItem.Price;
            }

            // Записываем в файл общую стоимость заказа.
            writer.WriteLine($"Цена заказа: {totalPrice} руб.");
        }
    }
}

// Класс для работы с стрелочным меню
public static class ArrowMenu
{

    // Функция для выбора пункта меню с помощью стрелок вверх и вниз
    public static int ChooseOption(string[] options)
    {
        int selectedOption = 0;
        int optionsCount = options.Length;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < optionsCount; i++)
            {
                Console.WriteLine($"{(i == selectedOption ? ">>> " : "    ")}{options[i]}");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 + optionsCount) % optionsCount;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % optionsCount;
                    break;
                case ConsoleKey.Enter:
                    return selectedOption;
            }
        }
    }//Очень извиняюсь я попыталась сделать стрелочное меню,но у меня вывело 45 ошибок
}
//Я ХОЧУ СПААТЬ
public class Program
{
    public static void Main(string[] args)
    {
        string[] mainMenu = new string[]
        {
            "1. Выбрать торт",
            "2. Выйти из программы"
        };

        int selectedOption = ArrowMenu.ChooseOption(mainMenu);

        if (selectedOption == 0)
        {
            Order order = new Order("История заказов.txt");
            order.ShowMenu();
        }
        else if (selectedOption == 1)
        {
            Environment.Exit(0);
        }
    }
}
