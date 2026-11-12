using Dz7lat.Classes;
using Dz7lat.enums;
class Program
{
    static int ReadChoice(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($"Ошибка ввода. Введите число от {min} до {max}.");
        }
    }
    static void Main(string[] args)
    {
        Employee timur = new Employee("Тимур", "Генеральный директор", Department.General);
        Employee rashid = new Employee("Рашид", "Финансовый директор", Department.General, timur);
        Employee ilham = new Employee("О Ильхам", "Директор по автоматизации", Department.General, timur);
        Employee lukas = new Employee("Лукас", "Главный бухгалтер", Department.Accounting, rashid);

        Employee orkadiy = new Employee("Оркадий", "Начальник инф. систем", Department.ITManagement, ilham);
        Employee volodya = new Employee("Володя", "Зам. начальника инф. систем", Department.ITManagement, ilham);

        Employee ilshat = new Employee("Ильшат", "Главный системщик", Department.SystemAdmins, orkadiy, volodya);
        Employee ivanych = new Employee("Иваныч", "Зам. главного системщика", Department.SystemAdmins, ilshat);
        Employee ilya = new Employee("Илья", "Системщик", Department.SystemAdmins, ivanych);
        Employee vitya = new Employee("Витя", "Системщик", Department.SystemAdmins, ivanych);
        Employee zhenya = new Employee("Женя", "Системщик", Department.SystemAdmins, ivanych);

        Employee sergey = new Employee("Сергей", "Главный разработчик", Department.Developers, orkadiy, volodya);
        Employee lyaysan = new Employee("Ляйсан", "Зам. главного разработчика", Department.Developers, sergey);
        Employee marat = new Employee("Марат", "Разработчик", Department.Developers, lyaysan);
        Employee dina = new Employee("Дина", "Разработчик", Department.Developers, lyaysan);
        Employee ildar = new Employee("Ильдар", "Разработчик", Department.Developers, lyaysan);
        Employee anton = new Employee("Антон", "Разработчик", Department.Developers, lyaysan);

        List<Employee> employees = new List<Employee>
            {
                timur, rashid, ilham, lukas,
                orkadiy, volodya,
                ilshat, ivanych, ilya, vitya, zhenya,
                sergey, lyaysan, marat, dina, ildar, anton
            };
        List<WorkTask> tasks = new List<WorkTask>
            {
                new WorkTask("Сделать кнопку «Сделать всё хорошо» для бухгалтерии", TaskTarget.Developers),
                new WorkTask("Настроить корпоративный VPN", TaskTarget.SystemAdmins),
                new WorkTask("Согласовать бюджет на закупку серверов", TaskTarget.Management)
            };
        while (true)
        {
            Console.WriteLine("СПИСОК СОТРУДНИКОВ:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {employees[i].Name} ({employees[i].Position})");
            }
            Console.WriteLine("0. Выход из программы");

            int senderIndex = ReadChoice("\nВыберите номер сотрудника, КОТОРЫЙ дает задачу: ", 0, employees.Count);
            if (senderIndex == 0) break;

            int receiverIndex = ReadChoice("Выберите номер сотрудника, КОМУ дается задача: ", 1, employees.Count);

            Console.WriteLine("\nДОСТУПНЫЕ ЗАДАЧИ");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title} [Для: {tasks[i].Target}]");
            }

            int taskIndex = ReadChoice("Выберите номер задачи: ", 1, tasks.Count);

            // Выполняем назначение и проверку
            Employee sender = employees[senderIndex - 1];
            Employee receiver = employees[receiverIndex - 1];
            WorkTask selectedTask = tasks[taskIndex - 1];

            sender.AssignTask(selectedTask, receiver);

            Console.WriteLine("Нажмите Enter, чтобы назначить следующую задачу...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}


