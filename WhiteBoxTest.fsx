type pit = int
type board = pit list
type player = Player1 | Player2

printfn "WhiteBox Test"

//--------------isHome-----------------------

let isHome (p : player) (i : int) =
    if p = Player1 && i = 6 || p = Player2 && i = 13 then true else false

printfn "isHome Test
%b
%b
%b
%b  "
  (isHome Player1 6 = true)
  (isHome Player1 8 = false)
  (isHome Player2 13 = true)
  (isHome Player2 6 = false)

//--------------isGameOver-------------------

let isGameOver  (b : board) =
    match b with
    | _ when List.sum b.[0..5] = 0 || List.sum b.[7..12] = 0 ->
        if b.[6] > b.[13] then
            printf "" //printGameOver b "WINNER" "LOSER " b.[6] b.[13]
        elif b.[6] < b.[13] then
            printf "" //printGameOver b "LOSER " "WINNER" b.[6] b.[13]
        else
            printf "" //printGameOver b "TIE  " "TIE  " b.[6] b.[13]
        true
    | _                                                      ->
        false

printfn "isGameOver Test
%b
%b
%b
%b  "
  (isGameOver [0;0;0;0;0;0;0;3;3;3;3;3;3;0] = true)
  (isGameOver [3;3;3;3;3;3;0;0;0;0;0;0;0;0] = true)
  (isGameOver [3;3;3;3;3;3;0;3;3;3;3;3;3;0] = false)
  (isGameOver [0;0;0;0;0;0;0;0;0;0;0;0;0;0] = true)

//--------------getMove----------------------

let rec getMove (b : board) p (i : string list) =
    printf "" //printf "%s" q
    //let i = System.Console.ReadLine(), string list givet som alternativt input
    match p with
    | Player1 ->
        match System.Int32.TryParse(i.Head) with
        | (true,x) when x < 7 && x > 0 ->
              match x with
              |_ when b.[x-1] = 0 ->
                    //let s = sprintf "    %A you can not pick an empty pit: " p
                    (getMove b p i.Tail)
              |_ -> x - 1
        |_      ->  //let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p i.Tail)
    | Player2 ->
        match System.Int32.TryParse(i.Head) with
        | (true,x) when x < 7 && x > 0 ->
              match x with
              |_ when b.[x+6] = 0 ->
                    //let s = sprintf "    %A you can not pick an empty pit: " p
                    (getMove b p i.Tail)
              |_ -> x + 6
        |_      ->  //let s = sprintf "    %A you dum dum, it has to be 1-6: " p
                    (getMove b p i.Tail)

printfn "getMove
%b
%b"
  (getMove [0;3;0;3;0;3; 0 ;3;0;3;0;3;0; 3] Player1 ["H";"7";"3";"4"] = 3)
  (getMove [0;3;0;3;0;3; 0 ;3;0;3;0;3;0; 3] Player2 ["J";"0";"4";"3"] = 9)

//--------------distribute-------------------

let distribute (b:board) (p:player) (i:int) =
    let a = List.toArray b
    let mutable h = a.[i]
    a.[i] <- 0
    for j = 1 to h do
        a.[(i+j)%14] <- a.[(i+j)%14] + 1
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
    (B, h)

printfn "distribute
%b
%b
%b
%b
%b
%b"
  (distribute [3;3;3;3;3;3;0;3;3;3;3;3;3;0] Player1 3 = ([3;3;3;0;4;4;1;3;3;3;3;3;3;0], 6))
  (distribute [3;3;3;3;3;3;0;3;0;3;3;3;3;0] Player1 5 = ([3;3;3;3;0;0;5;4;0;3;3;3;3;0], 8))
  (distribute [3;3;3;3;3;3;0;3;3;3;3;3;3;0] Player1 0 = ([0;4;4;4;3;3;0;3;3;3;3;3;3;0], 3))
  (distribute [3;3;3;3;3;3;0;3;3;3;3;3;3;0] Player2 10 = ([3;3;3;3;3;3;0;3;3;3;0;4;4;1], 13))
  (distribute [3;0;3;3;3;3;0;3;3;3;3;3;3;0] Player2 12 = ([4;0;3;3;3;3;0;3;3;3;3;0;0;5], 1))
  (distribute [3;3;3;3;3;3;0;3;3;3;3;3;3;0] Player2 7 = ([3;3;3;3;3;3;0;0;4;4;4;3;3;0], 10))

//--------------turn-------------------------

//Jeg ved ikke om vi skal teste dem her

//--------------play-------------------------

//Jeg ved ikke om vi skal teste dem her
