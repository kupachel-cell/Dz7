using Dz7lat.enums;
using System;
using System.Collections.Generic;

namespace Dz7lat.Classes
{
    public class Employee
    {
        public string Name { get; }
        public string Position { get; }
        public Department Dept { get; }
        public List<Employee> Managers { get; }

        public Employee(string name, string position, Department dept, params Employee[] managers)
        {
            Name = name;
            Position = position;
            Dept = dept;
            Managers = new List<Employee>(managers);
        }

        public void AssignTask(WorkTask task, Employee receiver)
        {
            Console.WriteLine($"\nОт {this.Name} даётся задача «{task.Title}» сотруднику {receiver.Name}.");

            bool isDirectManager = receiver.Managers.Contains(this);
            bool isCorrectDepartment = false;

            if (task.Target == TaskTarget.Management)
            {
                isCorrectDepartment = receiver.Dept == Department.ITManagement;
            }
            else if (task.Target == TaskTarget.SystemAdmins)
            {
                isCorrectDepartment = receiver.Dept == Department.SystemAdmins;
            }
            else if (task.Target == TaskTarget.Developers)
            {
                isCorrectDepartment = receiver.Dept == Department.Developers;
            }

            if (isDirectManager && isCorrectDepartment)
            {
                Console.WriteLine($"{receiver.Name} БЕРЕТ задачу.\n");
            }
            else if (!isDirectManager)
            {
                Console.WriteLine($"{receiver.Name} НЕ БЕРЕТ задачу (не прямое руководство).\n");
            }
            else
            {
                Console.WriteLine($"{receiver.Name} НЕ БЕРЕТ задачу (задача не для его сектора).\n");
            }
        }
    }
}
