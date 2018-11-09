
type pit = int// intentionally left empty
type board = pit list// intentionally left empty
type player = Player1 | Player2

// intentionally many missing implementations and additions

let startBoard = [3;3;3;3;3;3;0;3;3;3;3;3;3;0]

let printBoard (b : board) : unit =
  //printfn "printBoard"
  System.Console.Clear()
  //printfn "%A" b
  let num x =
    match x with
    | 0  -> ["     ";"     ";"     "]
    | 1  -> ["     ";"  o  ";"     "]
    | 2  -> ["     ";"o   o";"     "]
    | 3  -> ["  o  ";"     ";"o   o"]
    | 4  -> ["o   o";"     ";"o   o"]
    | 5  -> ["o   o";"  o  ";"o   o"]
    | 6  -> ["o   o";"o   o";"o   o"]
    | 7  -> ["o   o";"o o o";"o   o"]
    | 8  -> ["o o o";"o   o";"o o o"]
    | 9  -> ["o o o";"o o o";"o o o"]
    | _  -> [" ";(sprintf "  %i " x);" "]
  printfn "




  ╔═══════╤═══════╤═══════╤═══════╤═══════╤═══════╤═══════╤═══════╗
  ║Player2│   6   │   5   │   4   │   3   │   2   │   1   │Player1║
  ╟───────┼───<───┼───<───┼───<───┼───<───┼───<───┼───<───┼───────╢
  ║       │       │       │       │       │       │       │       ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║ %5s │       │       │       │       │       │       │ %5s ║
  ║ %5s ╞═══════╪═══════╪═══════╪═══════╪═══════╪═══════╡ %5s ║
  ║ %5s │       │       │       │       │       │       │ %5s ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║       │ %5s │ %5s │ %5s │ %5s │ %5s │ %5s │       ║
  ║       │       │       │       │       │       │       │       ║
  ╟───────┼───>───┼───>───┼───>───┼───>───┼───>───┼───>───┼───────╢
  ║  Home │   1   │   2   │   3   │   4   │   5   │   6   │  Home ║
  ╚═══════╧═══════╧═══════╧═══════╧═══════╧═══════╧═══════╧═══════╝
    "
    (num b.[12]).[0] (num b.[11]).[0] (num b.[10]).[0] (num b.[9]).[0] (num b.[8]).[0] (num b.[7]).[0]
    (num b.[12]).[1] (num b.[11]).[1] (num b.[10]).[1] (num b.[9]).[1] (num b.[8]).[1] (num b.[7]).[1]
    (num b.[12]).[2] (num b.[11]).[2] (num b.[10]).[2] (num b.[9]).[2] (num b.[8]).[2] (num b.[7]).[2]
    (num b.[13]).[0] (num b.[6]).[0]
    (num b.[13]).[1] (num b.[6]).[1]
    (num b.[13]).[2] (num b.[6]).[2]
    (num b.[0]).[0] (num b.[1]).[0] (num b.[2]).[0] (num b.[3]).[0] (num b.[4]).[0] (num b.[5]).[0]
    (num b.[0]).[1] (num b.[1]).[1] (num b.[2]).[1] (num b.[3]).[1] (num b.[4]).[1] (num b.[5]).[1]
    (num b.[0]).[2] (num b.[1]).[2] (num b.[2]).[2] (num b.[3]).[2] (num b.[4]).[2] (num b.[5]).[2]

let isHome (b : board) (p : player) (i : int) =
    //printfn "isHome"
    match p with
    | _ when p = Player1 && i = 6   -> true
    | _ when p = Player2 && i = 13  -> true
    | _                             -> false

let isGameOver  (b : board) =
    //printfn "isGameOver"
    match b with
    | _ when List.sum b.[0..5] = 0 || List.sum b.[7..12] = 0 -> //printfn "Ja \n %A" b
                                                                if b.[6] > b.[13] then
                                                                     printfn "    Player1 WINS!"
                                                                else printfn "    Player2 WINS!"
                                                                true
    | _                                                      -> //printfn "Nej \n %A" b
                                                                false

let rec getMove (b : board) p q =
    //printfn "getMove"
    printf "%s" q
    let i = System.Console.ReadLine()
    match p with
    | Player1 ->
        match System.Int32.TryParse(i) with
        | (true,x) when x < 7 && x > 0 ->
                                          match x with
                                          |_ when b.[x-1] = 0 ->  let s = sprintf "    %A you can not pick an empty pit: " p
                                                                  (getMove b p s)
                                          |_ -> x - 1

        |_      ->  let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p s)
    | Player2 ->
        match System.Int32.TryParse(i) with
        | (true,x) when x < 7 && x > 0 ->
                                          match x with
                                          |_ when b.[x+6] = 0 ->  let s = sprintf "    %A you can not pick an empty pit: " p
                                                                  (getMove b p s)
                                          |_ -> x + 6
        |_      ->  let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p s)

let distribute (b:board) (p:player) (i:int) =
    //printfn "distribute"
    let a = List.toArray b
    let mutable h = a.[i]
    a.[i] <- 0
    for j = 1 to h do
        match i with
        |_ when i+j > 13  -> a.[i+j-14] <- a.[i+j-14] + 1
                             //printBoard (Array.toList a)
                             //System.Threading.Thread.Sleep (500)
        |_                -> a.[i+j] <- a.[i+j] + 1
                             //printBoard (Array.toList a)
                             //System.Threading.Thread.Sleep (500)

    h <- (i + h)%14
    if h <> 6 && h <> 13 && a.[h] = 1 && a.[12-h] <> 0 then
        match p with
        | Player1 ->  a.[6] <- a.[6] + a.[12-h] + 1
        | Player2 ->  a.[13] <- a.[13] + a.[12-h] + 1
        a.[12-h] <- 0
        a.[h] <- 0
    else a.[h] <- a.[h]
    let B = Array.toList a
    (B,p,h)

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "    %A's turn: " p
      else
        sprintf "    %A's turn again: " p
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if (isGameOver b) || not (isHome b finalPitsPlayer finalPit) then
      //printfn "if newB"
      newB //exit conditions
    else
      //printfn "else repeat newB"
      repeat newB p (n + 1) //repeat
  //printfn "sidste linje i turn"
  repeat b p 0

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP

play startBoard Player1
