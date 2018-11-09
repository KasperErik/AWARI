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



//--------------distribute-------------------



//--------------turn-------------------------



//--------------play-------------------------
