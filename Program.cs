using OOAPLAB7;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Calculator calculator = new Calculator();
        Invoker invoker = new Invoker();

        Console.WriteLine("Простий калькулятор (патерн Command)");
        Console.WriteLine("Доступні операції: +, -, *, /");
        Console.WriteLine("u - скасувати (undo)");
        Console.WriteLine("r - повторити (redo)");
        Console.WriteLine("q - вихід\n");

        while (true)
        {
            Console.WriteLine($"Поточне значення: {calculator.CurrentValue}");
            Console.Write("Введіть операцію та число (наприклад, + 5) або команду: ");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "q")
                break;
            else if (input.ToLower() == "u")
                invoker.Undo();
            else if (input.ToLower() == "r")
                invoker.Redo();
            else
            {
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Невірний формат. Спробуйте ще раз.");
                    continue;
                }

                string op = parts[0];
                if (!double.TryParse(parts[1], out double value))
                {
                    Console.WriteLine("Невірне число. Спробуйте ще раз.");
                    continue;
                }

                try
                {
                    ICommand command = null;
                    switch (op)
                    {
                        case "+":
                            command = new AddCommand(calculator, value);
                            break;
                        case "-":
                            command = new SubtractCommand(calculator, value);
                            break;
                        case "*":
                            command = new MultiplyCommand(calculator, value);
                            break;
                        case "/":
                            command = new DivideCommand(calculator, value);
                            break;
                        default:
                            Console.WriteLine("Невідома операція. Використовуйте +, -, *, /");
                            continue;
                    }

                    invoker.ExecuteCommand(command);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }

        Console.WriteLine("Роботу завершено.");
    }
}