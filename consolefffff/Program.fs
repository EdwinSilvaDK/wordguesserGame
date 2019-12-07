// Learn more about F# at http://fsharp.org

open System
open Console.Configuration
open Console.GuesserLogic

[<EntryPoint>]
let main argv =
    Console.WriteLine("Welcome to WordGuesser")
    let secretWord = getrandomitem()
    Console.WriteLine("The length of the word is " + sprintf "%i" secretWord.Length)
    let mutable listSoFar = compare2 secretWord charList
    let mutable bool = true
    while (bool) do
         Console.WriteLine("Make a guess!")
         let key = Console.ReadKey(true)
         
         if HELP = true && key.KeyChar = '1' then compare3 (secretWord, listSoFar) |> addToMutable
            
         else if CASE_SENSITIVE = false then addToMutable (Char.ToLower (key.KeyChar))
         else Console.WriteLine("Your guess was: " + sprintf "%c" key.KeyChar)
              addToMutable key.KeyChar
         
         
         let guessList = charList
         listSoFar <- compare2 secretWord guessList
         Console.WriteLine("Word so far: " + sprintf "%A" listSoFar)
         Console.WriteLine("Used " + sprintf "%A" guessList )
         let checkList = checkForGuessed listSoFar guessList
         Console.WriteLine("" + sprintf "%b" checkList)
         bool <- checkList

    Console.WriteLine("Congratulation you guessed it on " + sprintf "%i" charList.Length + " Guesses!")
    0