# Uebung-036  --  FizzBuzz

###### [Angabezettel (.pdf)](https://github.com/IxI-Enki/Uebung-036/blob/main/FizzBuzz.pdf)

## Lernziele:  
 - While - Anweisung
## Vertiefung:
 - If-Anweisung
   
 Fizz-Buzz ist ein Gruppenspiel für Kinder, um die Rechenart der Division zu üben.  
 Die Spieler müssen dabei zum Beispiel in einem Kreis sitzen und schrittweise durchzählen.  
 - Der erste Spieler beginnt mit der Zahl 1. (Er sagt somit: „Eins“.)  
 - Der nächste Spieler auf der rechten Seite sagt „Zwei“.  
 - Und so weiter.

 Dabei muss auf folgendes geachtet werden:  
 - Wenn die Zahl durch 3 teilbar ist, sagt man „Fizz“.  
   > *Also anstatt 3, 6, 9, … sagt man „Fizz“.*  
 - Wenn die Zahl durch 5 teilbar ist, sagt man „Buzz“.  
   > *Also anstatt 5, 10, … sagt man „Buzz“.*  
 - Wenn die Zahl durch 5 und durch 3 teilbar ist, sagt man „Fizz“ und „Buzz“.  
   > *Also anstatt: 15, 30, 45, … sagt man „Fizz Buzz“.*  
 - Ansonsten nennt man die Zahl selbst.
 - Dann ist der nächste Spieler an der Reihe. Das geht solange im Kreis, bis jemand einen Fehler macht.  
   > *Ein Fehler soll im Programm nicht vorkommen!*


###   Die gesprochene Wort-Reihe der Spieler wäre also ohne Fehler:  
```
    1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz, 16, 17, Fizz, 19, Buzz,  
    Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, Fizz Buzz, 31, 32, Fizz, 34, Buzz, Fizz, …   
```

## Aufgabenstellung:  

   ***Schreiben Sie ein C#-Programm „FizzBuzz“, welches mit Hilfe einer Schleife Ihrer Wahl von 1 bis 100 zählt  
   und die Ausgabe nach den „Fizz-Buzz“-Regeln (wie oben beschrieben) in einer Zeile ausgibt.  
   Vorbild soll dabei die Ausgabe nach folgender Abbildung sein!***  

## Beispielausgabe:  

  ![Beispiel](https://github.com/IxI-Enki/Uebung-036/assets/138018029/ab3776c5-2087-4c27-b090-14b7869b3278)

-------------------------------
## *ausgedachte Zusatzaufgaben:*  
  - der Benutzer soll das obere Limit selbst bestimmen  
  - einzelnen Zahlen & die Wörter "Fizz" & "Buzz" sollen, in der Ausgabe nicht getrennt werden
  - Nach dem Letzten Wort / der letzten Zahl soll kein Beistrich mehr folgen  
-------------------------------
# **SPOILER**  

***[C#]:***

```c#
/*_________________________________libraries_________________________________*/
using System;                   //  
using System.Text;              //  Unicode Symbols
using System.Threading;         //  Thread.Sleep(1000) = 1 sec

/*---------------------------------- START ----------------------------------*/
namespace FizzBuzz          //  
{ public class Program      //
  { static void Main()      //
    { /*------------------------- console_settings --------------------------*/
      const int cWidth = 100;                    //  console width
      const int cHeight = 30;                    //  & height
      Console.SetWindowSize(cWidth, cHeight);    //
      Console.OutputEncoding = Encoding.UTF8;    //  Unicode Symbols
      /*----------------------------- VARIABLES -----------------------------*/
      string userInput;       //  
      char userChoice;        //  
      bool validInput;        //  
      int counter,            //  
          counterLenght,      //  
          checkValue,         //  
          lineCounter = 0;    //  
      int endNumber;          //  
      /*-------------------------------- HEAD -------------------------------*/
      Console.Clear();
      Console.Write("\n┌───────────────────────────────────────────────────┐" +
      /* cWidth: */ "\n│ > Ausgabe für Fizz-Buzz von 1 bis 100 :           │" +
                    "\n│      - Fizz, wenn durch 3 teilbar.                │" +
                    "\n│      - Buzz, wenn durch 5 teilbar.                │" +
                    "\n└───────────────────────────────────────────────────┘");
      /*---[in:]-------------------- PROMPT_USER ----------------------------*/
      Console.Write("\n [S/s]      : start " +    //  ✏
                    "\n [Q/q]      : quit  " +
                    "\n [Ganzzahl] : wähle ein anderes Spielende als 100" +
                    "\n");
      /*------------------------------------------------------- INPUTLOOP ---------------------------------------------------------*/
      do                                                                                                                           //
      {                                                                                                                            //
        userInput = Console.ReadLine();                                                                                            //
        /*---------------------------------------------------- CHECK THE INPUT ----------------------------------------------------*/
        if (validInput = Int32.TryParse(userInput, out endNumber) ? true : false)    //  parse to int works: limit = input         //
        {                                                                            //                                            //
          userChoice = 's';                                                          //  -> choose start                           //
        }                                                                                                                          //
        else if (validInput = char.TryParse(userInput, out userChoice) ? true : false)    //  parse to char works: choice = input  //
        {                                                                                 //                                       //
          endNumber = 100;                                                                //  -> limit = 100                       //
        }                                                                                                                          //
        if (char.ToLower(userChoice) != 's' && char.ToLower(userChoice) != 'q' || (endNumber < 0))  // choice neither 's' nor 'q'  //
        {                                                                                           //           or a negativ_int  //
          Console.Write("\n ! ungültige Auswahl, bitte wiederholen sie die Eingabe \n");            //  prompt to repeat input     //
          validInput = false;                                                                       //  -> invalid Input           //
        }                                                                                                                          //
      } while (!validInput);                                                                                                       //
      /*---------------------------------------------------------------------------------------------------------------------------*/

      /*---------------------------------------------------- CALCULATE OUTPUT -----------------------------------------------------*/
      if (char.ToLower(userChoice) == 's')                    //                                                                   //
      {                                                                                                                            //
        Console.Write("\n");                                                                                                       //
        for (counter = 1; counter <= endNumber; counter++)    //                                                                   //
        {                                                                                                                          //
          if (counter < endNumber)
          {
            if (counter % 3 == 0)
            {
              Console.Write("Fizz, ");
              lineCounter += 6;
            }
            else if (counter % 5 == 0)
            {
              Console.Write("Buzz, ");
              lineCounter += 6;
            }
            else if (counter % 3 == 0 && counter % 5 == 0)
            {
              Console.Write("Fizz, Buzz, ");
              lineCounter += 12;
            }
            else
            {
              Console.Write($"{counter}, ");

              checkValue = counter;
              counterLenght = 1;
              while (checkValue / 10 > 0)
              {
                checkValue = checkValue / 10;
                counterLenght++;
              }
              lineCounter += counterLenght + 3;
            }
          }
          else if (counter == endNumber)
          {
            if (counter % 3 == 0)
            {
              Console.Write("Fizz");
            }
            else if (counter % 5 == 0)
            {
              Console.Write("Buzz");
            }
            else
            {
              Console.Write($"{counter}, ");

              checkValue = counter;
              counterLenght = 1;
              while (checkValue / 10 > 0)
              {
                checkValue = checkValue / 10;
                counterLenght++;
              }
              lineCounter += counterLenght + 3;
            }

          }
          if (cWidth <= lineCounter)
          {
            Console.Write("\n");
            lineCounter = 0;
          }
        }
        Console.Write("\n");
      }
      else if (char.ToLower(userChoice) == 'q')
        Console.Write("\n Abbrechen gewählt.");
      else
        Console.Write("\n -fehler- ");
      /*-------------------------------- END --------------------------------*/
        Console.Write("\n Zum beenden Eingabetaste drücken..");
      Console.ReadLine();    //  wait for [enter]
      Console.Clear();       //
    }
  }
}
```
