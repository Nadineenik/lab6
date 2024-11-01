using System;

namespace NumberGuessingGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
    
    public class Game
    {
        private int _targetNumber;
        private int _attempts;

        public void Start()
        {
            Console.WriteLine("Выберите уровень сложности: 1 - Легкий, 2 - Средний, 3 - Сложный");
            int level = int.Parse(Console.ReadLine());
            SetDifficulty(level);
            
            Console.WriteLine("Угадайте число:");
            bool isCorrect = false;
            while (!isCorrect)
            {
                int guess = int.Parse(Console.ReadLine());
                _attempts++;
                isCorrect = CheckGuess(guess);
            }
            Console.WriteLine($"Поздравляем! Вы угадали число за {_attempts} попыток.");
        }

        private void SetDifficulty(int level)
        {
            Random rand = new Random();
            switch (level)
            {
                case 1:
                    _targetNumber = rand.Next(1, 10); // Легкий уровень
                    break;
                case 2:
                    _targetNumber = rand.Next(1, 50); // Средний уровень
                    break;
                case 3:
                    _targetNumber = rand.Next(1, 100); // Сложный уровень
                    break;
                default:
                    Console.WriteLine("Некорректный выбор уровня.");
                    SetDifficulty(1);
                    break;
            }
        }

        private bool CheckGuess(int guess)
        {
            if (guess == _targetNumber) return true;
            Console.WriteLine(guess < _targetNumber ? "Больше" : "Меньше");
            return false;
        }
    }
}
