namespace Console
open System


    module GuesserLogic =
        
        let getrandomitem()  = 
            let rand = new System.Random()
            let randWord = Configuration.WORDS.[rand.Next(Configuration.WORDS.Length)]
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
              else Configuration.HINDDEN::rest
             | [] -> []

        let checkForGuessed secretWord charList = compare2 secretWord charList |> List.contains '*'
