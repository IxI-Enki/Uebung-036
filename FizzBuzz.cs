/*-----------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF                          
 *-----------------------------------------------------------------------------
 *                      Jan Ritt                                               
 *-----------------------------------------------------------------------------
 *  Description:  The program counts from 1 to 100 (or whereever you want)
 *                if n % 3 = 0 --> fizz,
 *                   n % 5 = 0 --> buzz,
 *                else it outputs the number,
 *                It outputs into a new line, if the output would exeed 
 *                terminal width of 100.
 *-----------------------------------------------------------------------------
*/

/*___________________________________libraries_______________________________*/
using System;                   //  
using System.Text;              //  Unicode Symbols
using System.Threading;         //  Thread.Sleep(1000) = 1 sec

/*---------------------------------- START ----------------------------------*/
namespace FizzBuzz          //  
{                           //
  public class Program      //
  {                         //
    static void Main()      //
    {
      /*---------------------------- console_settings -----------------------*/
      const int cWidth = 100;                    //  console width
      const int cHeight = 30;                    //  & height
      Console.SetWindowSize(cWidth, cHeight);    //
      Console.OutputEncoding = Encoding.UTF8;    //  Unicode Symbols

      /*---------------------------- VARIABLES ------------------------------*/
      string userInput;    //  
      char userChoice;     //  
      bool validInput;     //  
      int counter,         //  
          counterLenght,   //  
          checkValue,      //  
          lineCounter;     //  
      int endNumber;       //  

      /*---------------------------- HEAD -----------------------------------*/
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

      /*---------------------------- INPUTLOOP ---------------------------------------------------------------------------*/
      do                                                                                                                  //
      {                                                                                                                   //
        userInput = Console.ReadLine();                                                                                   //
        /*-------------------------- CHECK THE INPUT ---------------------------------------------------------------------*/
        if (validInput = Int32.TryParse(userInput, out endNumber) ? true : false)  // parse to int: limit = input         //
        {                                                                          //                                     //
          userChoice = 's';                                                        // -> choose start                     //
        }                                                                                                                 //
        else if (validInput = char.TryParse(userInput, out userChoice) ? true : false)  // parse to char: choice = input  //
        {                                                                               //                                //
          endNumber = 100;                                                              // -> limit = 100                 //
        }                                                                                                                 //
        if (char.ToLower(userChoice) != 's' && char.ToLower(userChoice) != 'q'   /*    choice neither 's' nor 'q'     */  //
                                            || (endNumber < 0))                  /*      or a negativ_int             */  //
        {                                                                                                                 //
          Console.Write("\n!Ungültige Auswahl, bitte wiederholen sie die Eingabe\n");  /* prompt to repeat input      */  //
          validInput = false;                                                          /* -> invalid Input            */  //
        }                                                                                                                 //
      } while (!validInput);                                                                                              //
      /*------------------------------------------------------------------------------------------------------------------*/

      /*------------------------------ CALCULATE OUTPUT -------------------------*/
      if (char.ToLower(userChoice) == 's')    // input:'s' = run calculation     //
      {                                                                          //
        Console.Write("\n");    //  → new line                                   //
        lineCounter = 0;        //  --→ 0 symbols in line                        //
        for (counter = 1; counter <= endNumber; counter++)    // count:1 → end   //
        {                                                                        //
          if (counter < endNumber)  //  → calc. out:   (last out: is different)  //
          {
            if (counter % 3 == 0 && counter % 5 == 0)  /*--→ TEST BOTH: %3 & %5 -*/
            {                                                                    //
              if (lineCounter > (cWidth - 11))  /*  → test remaining space   */  //
              {                                 /*                           */  //
                Console.Write("\n");            /*  → new line               */  //
                lineCounter = 0;                /*  --→ 0 symbols in line    */  //
              }                                                                  //
              Console.Write("Fizz Buzz, ");  /* out: "Fizz Buzz, "            */ //
              lineCounter += 11;             /*      ⊣¹²³⁴⁵⁶⁷⁸⁹⁰₁⊢> 11 spaces */ //
            }
            else  /*--→ COUNTER NOT divideable by 3 AND 5 :  --------------------*/
            {                                                                    //
              if (lineCounter > (cWidth - 6))  /*  → test remaining space     */ //
              {                                /*                             */ //
                Console.Write("\n");           /*  → new line                 */ //
                lineCounter = 0;               /*  --→ 0 symbols in line      */ //
              }                                                                  //
              if (counter % 3 == 0)       /*------------ → TEST %3 -----------*/ //
              {                           /*                                  */ //
                Console.Write("Fizz, ");  /* out: "Fizz, "                    */ //
                lineCounter += 6;         /*      ⊣¹²³⁴⁵⁶⊢>  6 spaces         */ //
              }                                                                  //
              else if (counter % 5 == 0)  /*------------ → TEST %5 -----------*/ //
              {                           /*                                  */ //
                Console.Write("Buzz, ");  /* out: "Buzz, "                    */ //
                lineCounter += 6;         /*      ⊣¹²³⁴⁵⁶⊢>  6 spaces         */ //
              }
              else  /*--→ COUNTER NOT divideable by 3 OR 5 :  -------------------*/
              {                                                                  //
                checkValue = counter;           //  - save counter poition       //
                counterLenght = 1;              //  - start at lenght 1          //
                while (checkValue / 10 > 0)        /*  WHILE number is > 9    */ //
                {                                  /*                         */ //
                  checkValue = checkValue / 10;    /*  - devide it by 10      */ //
                  counterLenght++;                 /*  - increment lenght +1  */ //
                }                                    //    zB: "4, "             //
                lineCounter += counterLenght + 2;    //        ⊣...⊢             //
                Console.Write($"{counter}, ");       // out: number/counter      //
              }                                                                  //
            }  /*----------------------------------------------------------------*/
          }
          else  //  → calc. LAST OUTPUT:  --------------------------------*/
          {                                                               //
            if (counter % 3 == 0 && counter % 5 == 0)  // → TEST %3AND%5  //
            {                                                             //
              if (lineCounter > (cWidth - 9))  /*  calc space        */   //
              {                                /*                    */   //
                Console.Write("\n");           /*  → new line        */   //
              }                            //      ⊣¹²³⁴⁵⁶⁷⁸⁹⊢>  9 spaces //
              Console.Write("Fizz Buzz");  // out: "Fizz Buzz"            //                              
            }
            else    /*--→ COUNTER NOT divideable by 3 OR 5 :  --*/
            {                                                   //
              if (lineCounter > (cWidth - 4))  /* calc space */ //
              {                                /*            */ //
                Console.Write("\n");           /* → new line */ //
              }                                                 //
              if (counter % 3 == 0)       /*--- → TEST %3 ---*/ //
              {                           /*     ⊣¹²³⁴⊢>  4  */ //
                Console.Write("Fizz");    /* out:"Fizz"      */ //
              }                                                 //
              else if (counter % 5 == 0)  /*--- → TEST %5 ---*/ //
              {                           /*     ⊣¹²³⁴⊢>  4  */ //
                Console.Write("Buzz");    /* out:"Buzz"      */ //
              }
              else   /*--→ COUNTER NOT divideable by 3 OR 5 : --*/
              {                                                 //
                checkValue = counter;        /* calc. digits */ //
                counterLenght = 1;                              //
                while (checkValue / 10 > 0)      /* while >9 */ //
                {                                /*          */ //
                  checkValue = checkValue / 10;  /*  val/10  */ //
                  counterLenght++;               /* digits++ */ //
                }                                               //
                lineCounter += counterLenght;  // needed space  //
                if (lineCounter > cWidth)   /*               */ //
                {                           /*               */ //
                  Console.Write("\n");      /*  → new line   */ //
                }                                               //
                Console.Write($"{counter}, ");  // out: counter //
              }                                                 //
            }  /*-----------------------------------------------*/
          }
        }
        Console.Write("\n");  /*  →  empty line   ---------------------------*/
      }                                                                      //
      else if (char.ToLower(userChoice) == 'q')   //  → QUIT choice          //
        Console.Write("\n Abbrechen gewählt.");   //  --→ abort              //
      else                                   /*  sneaky invalid input     */ //
        Console.Write("\n -fehler- ");       /*  --→ error                */ //
      //------------------------------- END ---------------------------------//
      Console.Write("\n Zum beenden Eingabetaste drücken..");  //   prompt   //
      Console.ReadLine();                    //  wait for [enter]            //
      Console.Clear();                       //  clear console               //
    }                                                                        //
  }    /*--------------------------------------------------------------------*/
}