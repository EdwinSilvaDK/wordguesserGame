namespace Console
open System


    module GuesserLogic =
        

        let rec getrandomitem()  = 
            let rand = new System.Random()
            let mutable listOfWords = Configuration.WORDS
            
            let randWord = listOfWords.[rand.Next(listOfWords.Length)]
            if Configuration.ALLOW_BLANKS = false && randWord.Contains(" ") then getrandomitem()
            else
            if Configuration.CASE_SENSITIVE = false then 
                let wordList = Seq.toList(randWord.ToLower())
                wordList

            else 
                let wordList = Seq.toList(randWord)
                wordList

        let rec mem list x = 
          match list with
          | [] -> false
          | head :: tail -> 
           if x = head then true else mem tail x 

        let secretWord = getrandomitem()
        let mutable charList:list<char> = []
        let appendToList (oldList) (newItem) = oldList @ [newItem]
        let addToMutable char = charList <- appendToList charList char
        
        let rec compare2 secretWord addToGuessWord =
            match secretWord with
             | head :: tail -> 
              let rest = compare2 tail addToGuessWord
              if mem addToGuessWord head then head::rest
              elif head = ' ' then ' '::rest
              else Configuration.HIDDEN::rest
             | [] -> []

        let checkForGuessed secretWord charList = compare2 secretWord charList |> List.contains '*'
        
        let rec compare3 (secretWord:list<char>, guessWord:list<char>) =
            match (secretWord, guessWord) with
            |x::xs , y::ys -> 
            if x = y then compare3 (xs, ys)
            else x
            |_ -> '_'
