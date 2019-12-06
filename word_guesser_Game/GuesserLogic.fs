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
        let guessWord = Seq.toList "adcsqefthuj7"
        let rec compare2 secretWord guessWord =
            match secretWord with
             | head :: tail -> 
              let rest = compare2 tail guessWord
              if mem guessWord head then head::rest
              else Configuration.HINDDEN::rest
             | [] -> []