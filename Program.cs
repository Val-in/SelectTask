namespace SelectTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();
            {
                // добавляем контакты
                phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
                phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
                phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
                phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
                phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
                phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            };
            var sortedPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName).ToList();
            while (true)
            { 
                Console.WriteLine("Выберите страницу: 1, 2 или 3");
                char input = Console.ReadKey().KeyChar;

                if (char.IsDigit(input) && int.TryParse(input.ToString(), out int pageNumber) && pageNumber >= 1 && pageNumber <= 3)
                {
                    var page = sortedPhoneBook.Skip((pageNumber - 1) * 2).Take(2);

                    Console.WriteLine();

                    foreach (var contact in page)
                    {
                        Console.WriteLine($"{contact.Name} {contact.LastName} - {contact.PhoneNumber} - {contact.Email}");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Страница не существует. Введите номер страницы: 1, 2 или 3");
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
