module Awari

type pit = int
type board = pit list
type player = Player1 | Player2

let printBoard (b : board) : unit =
  System.Console.Clear()
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
                ▄▄▄▄▄▄▄▄   ▄▄      ▄▄   ▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄
               ▐█      █▌  ▐█      █▌  ▐█      █▌  ▐█      █▄      ██
               ▐█▄▄▄▄▄▄█▌  ▐█  ▄▄  █▌  ▐█▄▄▄▄▄▄█▌  ▐█▄▄▄▄▄▄█▀      ██
               ▐█      █▌  ▐█ █  █ █▌  ▐█      █▌  ▐█  ▀█▄         ██
               ▐█      █▌  ▐█▀    ▀█▌  ▐█      █▌  ▐█    ▀█▄       ██
               ▀▀      ▀▀  ▀▀      ▀▀  ▀▀      ▀▀  ▀▀      ▀▀  ▀▀▀▀▀▀▀▀▀▀
    ╔═════════╤═════════╤═════════╤═════════╤═════════╤═════════╤═════════╤═════════╗
    ║ Player2 │    6    │    5    │    4    │    3    │    2    │    1    │ Player1 ║
    ╟─────────┼────<────┼────<────┼────<────┼────<────┼────<────┼────<────┼─────────╢
    ║         │         │         │         │         │         │         │         ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║  %5s  │         │         │         │         │         │         │  %5s  ║
    ║  %5s  ╞═════════╪═════════╪═════════╪═════════╪═════════╪═════════╡  %5s  ║
    ║  %5s  │         │         │         │         │         │         │  %5s  ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║         │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │  %5s  │         ║
    ║         │         │         │         │         │         │         │         ║
    ╟─────────┼────>────┼────>────┼────>────┼────>────┼────>────┼────>────┼─────────╢
    ║   Home  │    1    │    2    │    3    │    4    │    5    │    6    │   Home  ║
    ╚═════════╧═════════╧═════════╧═════════╧═════════╧═════════╧═════════╧═════════╝
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

let printGameOver b (p1: string) (p2: string) (i1: int) (i2: int) =
    printBoard b
    System.Threading.Thread.Sleep (1000)
    System.Console.Clear()
    printfn "
                ▄▄▄▄▄▄▄▄   ▄▄      ▄▄   ▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄
               ▐█      █▌  ▐█      █▌  ▐█      █▌  ▐█      █▄      ██
               ▐█▄▄▄▄▄▄█▌  ▐█  ▄▄  █▌  ▐█▄▄▄▄▄▄█▌  ▐█▄▄▄▄▄▄█▀      ██
               ▐█      █▌  ▐█ █  █ █▌  ▐█      █▌  ▐█  ▀█▄         ██
               ▐█      █▌  ▐█▀    ▀█▌  ▐█      █▌  ▐█    ▀█▄       ██
               ▀▀      ▀▀  ▀▀      ▀▀  ▀▀      ▀▀  ▀▀      ▀▀  ▀▀▀▀▀▀▀▀▀▀
    ╔═════════╤═══════════════════════════════════════════════════════════╤═════════╗
    ║ Player2 │                                                           │ Player1 ║
    ╟─────────┤       ▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄   ▄▄      ▄▄  ▄▄▄▄▄▄▄▄▄▄        ├─────────╢
    ║         │      ▐█      █▌ ▐█      █▌  ▐█▄    ▄█▌  ▐█       ▀        │         ║
    ║         │      ▐█         ▐█▄▄▄▄▄▄█▌  ▐█ █  █ █▌  ▐█                │         ║
    ║         │      ▐█   █▀▀█▌ ▐█      █▌  ▐█  ▀▀  █▌  ▐█▀▀▀▀▀           │         ║
    ║         │      ▐█      █▌ ▐█      █▌  ▐█      █▌  ▐█       ▄        │         ║
    ║         │       ▀▀▀▀▀▀▀▀  ▀▀      ▀▀  ▀▀      ▀▀  ▀▀▀▀▀▀▀▀▀▀        │         ║
    ║    %2i   │                                                           │    %2i   ║
    ║         │       ▄▄▄▄▄▄▄▄  ▄▄      ▄▄  ▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄         │         ║
    ║         │      ▐█      █▌  █      █   ▐█       ▀  ▐█      █▄        │         ║
    ║         │      ▐█      █▌   █    █    ▐█          ▐█▄▄▄▄▄▄█▀        │         ║
    ║         │      ▐█      █▌   ▀▄  ▄▀    ▐█▀▀▀▀▀     ▐█  ▀█▄           │         ║
    ║         │      ▐█      █▌    █  █     ▐█       ▄  ▐█    ▀█▄         │         ║
    ╟─────────┤       ▀▀▀▀▀▀▀▀      ▀▀      ▀▀▀▀▀▀▀▀▀▀  ▀▀      ▀▀        ├─────────╢
    ║ %7s │                                                           │ %7s ║
    ╚═════════╧═══════════════════════════════════════════════════════════╧═════════╝
    "
        i2 i1 p2 p1

let isHome (p : player) (i : int) =
    if p = Player1 && i = 6 || p = Player2 && i = 13 then true else false
    erjh ejk

let isGameOver  (b : board) =
    match b with
    | _ when List.sum b.[0..5] = 0 || List.sum b.[7..12] = 0 ->
        if b.[6] > b.[13] then
            printGameOver b "WINNER" "LOSER " b.[6] b.[13]
        elif b.[6] < b.[13] then
            printGameOver b "LOSER " "WINNER" b.[6] b.[13]
        else
            printGameOver b "TIE  " "TIE  " b.[6] b.[13]
        true
    | _                                                      ->
        false

let rec getMove (b : board) p q =
    printf "%s" q
    let i = System.Console.ReadLine()
    match p with
    | Player1 ->
        match System.Int32.TryParse(i) with
        | (true,x) when x < 7 && x > 0 ->
              match x with
              |_ when b.[x-1] = 0 ->
                    let s = sprintf "    %A you can not pick an empty pit: " p
                    (getMove b p s)
              |_ -> x - 1
        |_      ->  let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p s)
    | Player2 ->
        match System.Int32.TryParse(i) with
        | (true,x) when x < 7 && x > 0 ->
              match x with
              |_ when b.[x+6] = 0 ->
                    let s = sprintf "    %A you can not pick an empty pit: " p
                    (getMove b p s)
              |_ -> x + 6
        |_      ->  let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p s)

let distribute (b:board) (p:player) (i:int) =
    let a = List.toArray b
    let mutable h = a.[i]
    a.[i] <- 0
    for j = 1 to h do
        a.[(i+j)%14] <- a.[(i+j)%14] + 1
        printBoard (Array.toList a)
        System.Threading.Thread.Sleep (500)
    h <- (i + h)%14
    if h <> 6 && h <> 13 && a.[h] = 1 && a.[12-h] <> 0 then
        match p with
        | Player1 ->  a.[6] <- a.[6] + a.[12-h] + 1
        | Player2 ->  a.[13] <- a.[13] + a.[12-h] + 1
        a.[12-h] <- 0
        a.[h] <- 0
    else a.[h] <- a.[h]
    let B = Array.toList a
    (B, h)

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "    %A's turn: " p
      else
        sprintf "    %A's turn again: " p
    let i = getMove b p str
    let (newB, finalPit)= distribute b p i
    if not (isHome p finalPit) || (isGameOver newB) then
      newB //exit conditions
    else
      repeat newB p (n + 1) //repeat new turn
  repeat b p 0 //start turn

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
