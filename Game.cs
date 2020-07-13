using System;

namespace Hacked
{
    class Game
    {
        public void Greet()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Hacked: The Game");
            Console.WriteLine("=================");
            Console.WriteLine("How to play: Guess the letters in the word before getting hacked.\n");
        }

        public string CodeWord
        { get; private set; }
        public string CurrentWord
        { get; private set; }
        public int MaxGuesses
        { get; private set; }
        public int WrongGuesses
        { get; private set; }
        private string[] codeWords = { "detected", "stealth", "mexico", "ultimate", "talon" };

        private Ufo skull = new Ufo();

        public Game()
        {
            Random rnd = new Random();
            CodeWord = codeWords[rnd.Next(codeWords.Length)];
            MaxGuesses = 5;
            WrongGuesses = 0;
            for (int i = 0; i < CodeWord.Length; i++)
            {
                CurrentWord += "_";
            }
        }

        public void Display()
        {
            Console.WriteLine(skull.Stringify());
            Console.WriteLine($"Current word: {CurrentWord}\n");
            Console.WriteLine($"Wrong guesses: {WrongGuesses}\n");
        }

        public void Ask()
        {
            Console.Write("Guess a letter: ");
            string userGuess = Console.ReadLine();
            Console.WriteLine();
            if (userGuess.Trim().Length != 1)
            {
                Console.WriteLine("One letter at a time!");
                return;
            }
            char guess = userGuess.Trim().ToCharArray()[0];
            if (CodeWord.Contains(guess))
            {
                Console.WriteLine($"The letter {guess} is in the word!\n");
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guess == CodeWord[i])
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"The letter {guess} isn't in the word. You're getting closer to being hacked!");
                WrongGuesses++;
                skull.AddPart();
            }
        }

        public bool DidWin()
        {
            if (CodeWord.Equals(CurrentWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLose()
        {
            if (WrongGuesses >= MaxGuesses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}