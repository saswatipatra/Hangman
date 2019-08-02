using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Game
  {
    private string [] _wordStore= {"one","two","three"};
    private int _lives = 6;
    private string _randomWord;
    private char[] _wordDisplay;
    private static List<Game> _allGames = new List<Game>{};
    private List<char> _lettersInput = new List<char>{};
    private string _errorMessage = "";

    
    private string RandomNumber ()
    {
      Random random = new Random();
      int index= random.Next(0,_wordStore.Length);
      return _wordStore[index];
    }

    public Game()
    {
      _randomWord= RandomNumber();
      _wordDisplay= new char [_randomWord.Length];
      for (int i=0; i<_wordDisplay.Length ; i++)
      {
        _wordDisplay[i]= '_';
      }

      _allGames.Add(this);
    }
    public static Game GetCurrentGame()
    {
      return _allGames[0];
    }

    public static void ClearAll()
    {
      _allGames.Clear();
    }

    public string GetDisplay()
    {
      return string.Join(" ", _wordDisplay);
    }

    public string CheckDisplay()
    {
      return string.Join("", _wordDisplay);
    }

    public string GetListLetterInput()
    {
      return string.Join(" ",_lettersInput );
    }


    public int GetLives()
    {
      return _lives;
    }

    public string GetWordToFind()
    {
      return _randomWord;
    }

    public string GetErrorMessage()
    {
      return _errorMessage;
    }
    public bool CheckForError(char guessLetter)
    {
      if (guessLetter == '\0')
        {
          _errorMessage = "Please, enter a letter.";
          return true;
        }
      else if(_lettersInput.Contains(guessLetter))
      {
        _errorMessage = "You already guessed that letter!";
        return true;
      }
      else
      {
        return false;
      }
    }

    public void CheckGuess(char guessLetter)
    {
      if (CheckForError(guessLetter))
      {
        return;
      }
      if (_randomWord.Contains(guessLetter))
      {
          _lettersInput.Add(guessLetter);
        for(int i = 0; i<_randomWord.Length; i++)
        {
          if(_randomWord[i] == guessLetter)
          {
            _wordDisplay[i] = guessLetter;
          }
        }
      }
      else
      {
        _lives -= 1;
        _lettersInput.Add(guessLetter);
      }
      _errorMessage = "";
    }
  }
}
