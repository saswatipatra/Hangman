using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Game
  {
    private string [] _wordStore= {"one","two","three"};
    private int lives = 6;
    private string randomWord;
    
    public static string RandomNumber ()
    {
      Random random = new Random();
      int index= random.Next(0,_wordStore.Length-1);
      return _wordStore[index];
    }

  }
}

