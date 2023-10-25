
    // Класс для представления подпункта меню
    public class MenuItem
    {
        public string Description { get; set; } // Описание подпункта
        public decimal Price { get; set; } // Цена подпункта

        public MenuItem(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
