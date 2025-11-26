using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationProgramBuilder
{
    // Enum для рівня складності
    public enum DifficultyLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert
    }

    // Клас предмету
    public class Subject
    {
        public string Name { get; set; }
        public int Hours { get; set; }

        public Subject(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }

        public override string ToString()
        {
            return $"{Name} ({Hours} годин)";
        }
    }

    // Продукт - Освітня програма
    public class EducationProgram
    {
        public string ProgramName { get; set; }
        public List<Subject> Subjects { get; set; }
        public int DurationMonths { get; set; }
        public DifficultyLevel Level { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }
        public decimal Price { get; set; }

        public EducationProgram()
        {
            Subjects = new List<Subject>();
        }

        public void Display()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  ОСВІТНЯ ПРОГРАМА: {ProgramName,-37}║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║  Рівень складності: {Level,-38}║");
            Console.WriteLine($"║  Тривалість: {DurationMonths} місяців{new string(' ', 42 - DurationMonths.ToString().Length)}║");
            Console.WriteLine($"║  Викладач: {Instructor,-46}║");
            Console.WriteLine($"║  Вартість: {Price:C}{new string(' ', 46 - Price.ToString("C").Length)}║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  ПРЕДМЕТИ:                                                 ║");
            
            int totalHours = 0;
            foreach (var subject in Subjects)
            {
                totalHours += subject.Hours;
                string subjectLine = $"    • {subject.Name} - {subject.Hours} год.";
                Console.WriteLine($"║  {subjectLine,-57}║");
            }
            
            Console.WriteLine($"║  {$"Загальна кількість годин: {totalHours}",-57}║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║  Опис: {Description,-50}║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
        }
    }

    // Абстрактний будівельник
    public abstract class EducationProgramBuilder
    {
        protected EducationProgram program;

        public void CreateNewProgram()
        {
            program = new EducationProgram();
        }

        public EducationProgram GetProgram()
        {
            return program;
        }

        public abstract void SetProgramName();
        public abstract void AddSubjects();
        public abstract void SetDuration();
        public abstract void SetDifficultyLevel();
        public abstract void SetDescription();
        public abstract void SetInstructor();
        public abstract void SetPrice();
    }

    // Конкретний будівельник - Програма з веб-розробки
    public class WebDevelopmentProgramBuilder : EducationProgramBuilder
    {
        public override void SetProgramName()
        {
            program.ProgramName = "Full Stack Web Development";
        }

        public override void AddSubjects()
        {
            program.Subjects.Add(new Subject("HTML & CSS", 40));
            program.Subjects.Add(new Subject("JavaScript", 60));
            program.Subjects.Add(new Subject("React", 50));
            program.Subjects.Add(new Subject("Node.js", 45));
            program.Subjects.Add(new Subject("MongoDB", 30));
            program.Subjects.Add(new Subject("Git & GitHub", 20));
        }

        public override void SetDuration()
        {
            program.DurationMonths = 6;
        }

        public override void SetDifficultyLevel()
        {
            program.Level = DifficultyLevel.Intermediate;
        }

        public override void SetDescription()
        {
            program.Description = "Повний курс веб-розробки від основ до професіонала";
        }

        public override void SetInstructor()
        {
            program.Instructor = "Іван Петренко";
        }

        public override void SetPrice()
        {
            program.Price = 15000m;
        }
    }

    // Конкретний будівельник - Програма з Data Science
    public class DataScienceProgramBuilder : EducationProgramBuilder
    {
        public override void SetProgramName()
        {
            program.ProgramName = "Data Science & Machine Learning";
        }

        public override void AddSubjects()
        {
            program.Subjects.Add(new Subject("Python для Data Science", 50));
            program.Subjects.Add(new Subject("Статистика та аналіз даних", 45));
            program.Subjects.Add(new Subject("Machine Learning", 70));
            program.Subjects.Add(new Subject("Deep Learning", 60));
            program.Subjects.Add(new Subject("SQL і бази даних", 35));
        }

        public override void SetDuration()
        {
            program.DurationMonths = 9;
        }

        public override void SetDifficultyLevel()
        {
            program.Level = DifficultyLevel.Advanced;
        }

        public override void SetDescription()
        {
            program.Description = "Професійна підготовка Data Scientist";
        }

        public override void SetInstructor()
        {
            program.Instructor = "Марія Коваленко";
        }

        public override void SetPrice()
        {
            program.Price = 22000m;
        }
    }

    // Конкретний будівельник - Програма з мобільної розробки
    public class MobileDevelopmentProgramBuilder : EducationProgramBuilder
    {
        public override void SetProgramName()
        {
            program.ProgramName = "Mobile Development (iOS & Android)";
        }

        public override void AddSubjects()
        {
            program.Subjects.Add(new Subject("Kotlin для Android", 55));
            program.Subjects.Add(new Subject("Swift для iOS", 55));
            program.Subjects.Add(new Subject("Flutter", 50));
            program.Subjects.Add(new Subject("UI/UX для мобільних додатків", 30));
            program.Subjects.Add(new Subject("REST API", 25));
        }

        public override void SetDuration()
        {
            program.DurationMonths = 8;
        }

        public override void SetDifficultyLevel()
        {
            program.Level = DifficultyLevel.Intermediate;
        }

        public override void SetDescription()
        {
            program.Description = "Розробка мобільних додатків для iOS та Android";
        }

        public override void SetInstructor()
        {
            program.Instructor = "Олександр Шевченко";
        }

        public override void SetPrice()
        {
            program.Price = 18000m;
        }
    }

    // Директор - керує процесом побудови
    public class ProgramDirector
    {
        private EducationProgramBuilder builder;

        public void SetBuilder(EducationProgramBuilder newBuilder)
        {
            builder = newBuilder;
        }

        public EducationProgram ConstructProgram()
        {
            builder.CreateNewProgram();
            builder.SetProgramName();
            builder.AddSubjects();
            builder.SetDuration();
            builder.SetDifficultyLevel();
            builder.SetDescription();
            builder.SetInstructor();
            builder.SetPrice();

            return builder.GetProgram();
        }
    }

    // Fluent Builder - альтернативний підхід з ланцюжком викликів
    public class FluentEducationProgramBuilder
    {
        private EducationProgram program;

        public FluentEducationProgramBuilder()
        {
            program = new EducationProgram();
        }

        public FluentEducationProgramBuilder WithName(string name)
        {
            program.ProgramName = name;
            return this;
        }

        public FluentEducationProgramBuilder AddSubject(string name, int hours)
        {
            program.Subjects.Add(new Subject(name, hours));
            return this;
        }

        public FluentEducationProgramBuilder WithDuration(int months)
        {
            program.DurationMonths = months;
            return this;
        }

        public FluentEducationProgramBuilder WithLevel(DifficultyLevel level)
        {
            program.Level = level;
            return this;
        }

        public FluentEducationProgramBuilder WithDescription(string description)
        {
            program.Description = description;
            return this;
        }

        public FluentEducationProgramBuilder WithInstructor(string instructor)
        {
            program.Instructor = instructor;
            return this;
        }

        public FluentEducationProgramBuilder WithPrice(decimal price)
        {
            program.Price = price;
            return this;
        }

        public EducationProgram Build()
        {
            return program;
        }
    }

    // Головна програма
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("   СИСТЕМА СТВОРЕННЯ ОСВІТНІХ ПРОГРАМ (ПАТЕРН BUILDER)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Використання класичного патерну Builder з Директором
            Console.WriteLine("▶ КЛАСИЧНИЙ ПАТЕРН BUILDER:\n");

            ProgramDirector director = new ProgramDirector();

            // Створення програми з веб-розробки
            EducationProgramBuilder webBuilder = new WebDevelopmentProgramBuilder();
            director.SetBuilder(webBuilder);
            EducationProgram webProgram = director.ConstructProgram();
            webProgram.Display();

            // Створення програми з Data Science
            EducationProgramBuilder dataBuilder = new DataScienceProgramBuilder();
            director.SetBuilder(dataBuilder);
            EducationProgram dataProgram = director.ConstructProgram();
            dataProgram.Display();

            // Створення програми з мобільної розробки
            EducationProgramBuilder mobileBuilder = new MobileDevelopmentProgramBuilder();
            director.SetBuilder(mobileBuilder);
            EducationProgram mobileProgram = director.ConstructProgram();
            mobileProgram.Display();

            // Використання Fluent Builder
            Console.WriteLine("\n▶ FLUENT BUILDER (гнучке створення):\n");

            EducationProgram customProgram = new FluentEducationProgramBuilder()
                .WithName("Кібербезпека для початківців")
                .AddSubject("Основи кібербезпеки", 30)
                .AddSubject("Мережева безпека", 40)
                .AddSubject("Криптографія", 35)
                .AddSubject("Етичний хакінг", 45)
                .WithDuration(5)
                .WithLevel(DifficultyLevel.Beginner)
                .WithDescription("Вступ до світу кібербезпеки")
                .WithInstructor("Андрій Мельник")
                .WithPrice(12000m)
                .Build();

            customProgram.Display();

            Console.WriteLine("\n▶ ПОРІВНЯННЯ ПРОГРАМ:\n");
            Console.WriteLine($"Загальна кількість програм створено: 4");
            Console.WriteLine($"Середня тривалість: {(webProgram.DurationMonths + dataProgram.DurationMonths + mobileProgram.DurationMonths + customProgram.DurationMonths) / 4.0:F1} місяців");
            Console.WriteLine($"Середня вартість: {(webProgram.Price + dataProgram.Price + mobileProgram.Price + customProgram.Price) / 4:C}");

            Console.WriteLine("\n\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
