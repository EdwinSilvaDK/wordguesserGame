// Learn more about F# at http://fsharp.org

open System
open Console.Configuration
open Console.GuesserLogic

[<EntryPoint>]
let main argv =
    Console.WriteLine("Welcome to WordGuesser")
    let secretWord = getrandomitem()
    Console.WriteLine("The length of the word is " + sprintf "%i" secretWord.Length)
    
    let mutable bool = true
    while (bool) do
         Console.WriteLine("Make a guess!")
         let key = Console.ReadKey(true)
         Console.WriteLine("Your guess was: " + sprintf "%c" key.KeyChar)
         addToMutable key.KeyChar
         let guessList = charList
         let listSoFar = compare2 secretWord guessList
         Console.WriteLine("Word so far: " + sprintf "%A" listSoFar)
         Console.WriteLine("Used" + sprintf "%A" guessList )
         let checkList = checkForGuessed listSoFar guessList
         
         bool <- checkList

    Console.WriteLine("Congratulation you guessed it on " + sprintf "%i" charList.Length + " Guesses!")
    0
    