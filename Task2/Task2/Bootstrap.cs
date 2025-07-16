// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;
using Task2.Data;

namespace Task2
{
    internal class Bootstrap
    {
        private const string NoneEntitiesInCollection = "None human in system yet. Nothing happened.";
        private const string EnterChoice = "Enter your choice:";

        private static List<Human> _humans = [];

        public static void Main(string[] args)
        {
            Console.Clear();
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            var menuHint = new StringBuilder()
                .AppendLine("1. Add information about new human.")
                .AppendLine("2. Edit information about existing human.")
                .AppendLine("3. Delete information about existing human.")
                .AppendLine("4. Print information about existing human.")
                .AppendLine("5. Print information about all existing humans.")
                .AppendLine("\n\r0 - Exit.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, 5);

            switch (choice)
            {
                case 1:
                    ShowAddMenu();
                    break;
                case 2:
                    ShowMenuIfAnyHumanAdded(ShowUpdateMenu);
                    break;
                case 3:
                    ShowMenuIfAnyHumanAdded(ShowDeleteMenu);
                    break;
                case 4:
                    ShowMenuIfAnyHumanAdded(ShowWriteMenu);
                    break;
                case 5:
                    ShowMenuIfAnyHumanAdded(ShowWriteAllMenu);
                    break;
            }
        }

        private static void ShowMenuIfAnyHumanAdded(Action action)
        {
            if (_humans.Count != 0) 
                action();
            else
                ShowMessageMenu(NoneEntitiesInCollection);
        }

        private static void ShowAddMenu()
        {
            var menuHint = new StringBuilder()
                .AppendLine("1. Add Student.")
                .AppendLine("2. Add Employee.")
                .AppendLine("3. Add Driver.")
                .AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, 3);

            switch (choice)
            {
                case 0:
                    ShowMainMenu();
                    break;
                case 1:
                    AddHuman(new Student());
                    break;
                case 2:
                    AddHuman(new Employee());
                    break;
                case 3:
                    AddHuman(new Driver());
                    break;
            }

            ShowMessageMenu("\n\r", false);
        }

        private static void ShowUpdateMenu()
        {
            var menuHint = new StringBuilder("Select which human to Edit:\n\r");

            for (var i = 0; i < _humans.Count; i++)
                menuHint.AppendLine($"{i + 1}. {_humans[i].Name}.");

            menuHint.AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, _humans.Count);

            if (choice != 0)
                _humans[choice - 1].RequestData();

            ShowMainMenu();
        }

        private static void ShowDeleteMenu()
        {
            var menuHint = new StringBuilder("Select which human to Delete:\n\r");

            for (var i = 0; i < _humans.Count; i++)
                menuHint.AppendLine($"{i + 1}. {_humans[i].Name}.");

            menuHint.AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, _humans.Count);

            if (choice != 0)
                _humans.RemoveAt(choice - 1);

            ShowMainMenu();
        }

        private static void ShowWriteMenu()
        {
            var menuHint = new StringBuilder("Select which human to Write:\n\r");

            for (var i = 0; i < _humans.Count; i++)
                menuHint.AppendLine($"{i + 1}. {_humans[i].Name}.");

            menuHint.AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, _humans.Count);

            if (choice != 0)
                ShowMessageMenu(_humans[choice - 1].ToString());

            ShowMainMenu();
        }

        private static void ShowWriteAllMenu()
        {
            var menuHint = new StringBuilder();

            for (var i = 0; i < _humans.Count; i++)
                menuHint.AppendLine($"{i + 1}. {_humans[i].ToString()}\n\r");

            menuHint.AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, 0);

            ShowMainMenu();
        }

        private static void ShowMessageMenu(string message, bool isClear = true)
        {
            if (isClear)
                Console.Clear();

            Console.WriteLine(message);
            Console.WriteLine("\n\r0 - Back.");

            DefaultInputs.GetCorrectNumberFromConsole(EnterChoice, 0, 0);

            ShowMainMenu();
        }

        private static void AddHuman(Human human)
        {
            human.RequestData();
            _humans.Add(human);
            Console.WriteLine($"Added to list");
            human.Log();
        }
    }
}