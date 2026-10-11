using System;
using System.Globalization;

class Worker
{
    private string name;
    private int age;
    private double salary;
    private DateTime hireDate;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Некоректне прізвище");
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0 || value > 120)
                throw new ArgumentException("Некоректний вік");
            age = value;
        }
    }

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Некоректна зарплата");
            salary = value;
        }
    }

    public DateTime HireDate
    {
        get { return hireDate; }
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Некоректна дата прийняття");
            hireDate = value;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Worker[] workers = new Worker[5];

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();

                Console.Write("Прізвище та ініціали: ");
                workers[i].Name = Console.ReadLine();

                Console.Write("Вік: ");
                workers[i].Age = int.Parse(Console.ReadLine());

                Console.Write("Зарплата: ");
                workers[i].Salary = double.Parse(
                    Console.ReadLine(),
                    CultureInfo.InvariantCulture);

                Console.Write("Дата прийняття (дд.мм.рррр): ");
                workers[i].HireDate = DateTime.ParseExact(
                    Console.ReadLine(),
                    "dd.MM.yyyy",
                    CultureInfo.InvariantCulture);
            }

            Array.Sort(workers, (a, b) =>
                string.Compare(a.Name, b.Name,
                    StringComparison.CurrentCultureIgnoreCase));

            Console.Write("Введіть стаж роботи в роках: ");
            int years = int.Parse(Console.ReadLine());

            Console.WriteLine("Працівники зі стажем більше " + years + " років:");

            foreach (Worker worker in workers)
            {
                int experience = (int)((DateTime.Now - worker.HireDate).TotalDays / 365.2425);

                if (experience > years)
                    Console.WriteLine(worker.Name);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка формату введених даних!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Введене число виходить за допустимі межі!");
        }
    }
}




using System;

class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Sub(double a, double b)
    {
        return a - b;
    }

    public double Mul(double a, double b)
    {
        return a * b;
    }

    public double Div(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе!");

        return a / b;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Calculator calculator = new Calculator();

            Console.Write("Введіть перше число: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введіть друге число: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Виберіть операцію: +, -, *, /");
            string operation = Console.ReadLine();

            double result;

            switch (operation)
            {
                case "+":
                    result = calculator.Add(a, b);
                    break;
                case "-":
                    result = calculator.Sub(a, b);
                    break;
                case "*":
                    result = calculator.Mul(a, b);
                    break;
                case "/":
                    result = calculator.Div(a, b);
                    break;
                default:
                    throw new ArgumentException("Невідома операція!");
            }

            Console.WriteLine("Результат: " + result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка формату числа!");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Число виходить за допустимі межі!");
        }
    }
}
