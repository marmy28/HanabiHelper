// Learn more about F# at http://fsharp.org
open HanabiHelper.Types
open System

let succ e = 
    let allValues = Enum.GetValues typeof<'a> |> Seq.cast<'a> |> Seq.toList
    let rec next' values =
        match values with
        | v :: nextValue :: _ when v = e -> nextValue
        | v :: tail when v <> e -> next' tail
        | _ -> failwith "Cannot find the next value"    
    next' allValues

let baseGameDeck =
    let rec deck' l = 
        match l with
        | head :: tail & {Color = Color.Yellow; Number = Number.Five} :: _ 
            -> head :: tail
        | {Color = color; Number = Number.Five} as head :: tail 
            -> deck' ({Color = (succ color); Number = Number.One } :: head :: tail)
        | {Color = color; Number = number} as head :: tail 
            -> deck' ({Color = color; Number = (succ number)} :: head :: tail)
        | [] 
            -> deck' [{Color = Color.Red; Number = Number.One}]
    let rec deck'' l =
        match l with
        | {Color = _; Number = Number.One} as head :: tail -> List.replicate 3 head |> List.append (deck'' tail)
        | {Color = _; Number = Number.Five} as head :: tail -> head :: (deck'' tail)
        | head :: tail -> List.replicate 2 head |> List.append (deck'' tail)
        | [] -> []
    [] |> deck' |> deck'' |> List.sortBy (fun {Color=color; Number=number} -> color, number)

[<EntryPoint>]
let main _ =
    printfn "Hello World from F#!"
    printfn "%A" baseGameDeck
    0 // return an integer exit code
