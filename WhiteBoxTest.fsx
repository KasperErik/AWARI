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
  (isHome Player2 8 = false)

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

printfn "getMove"

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

printfn "distribute"

//--------------turn-------------------------

//Jeg ved ikke om vi skal teste dem her

//--------------play-------------------------

//Jeg ved ikke om vi skal teste dem her 
