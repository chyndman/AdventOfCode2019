(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.Day2

    let private parse =
        let csv (l: string) = l.Split [| ',' |]
        csv >> Array.map (fun s -> int s)

    type ArithOpCode =
        | Add
        | Multiply

    type OpCode =
        | Arith of ArithOpCode
        | Halt

    let private decodeOpCode = function
        | 1 -> Arith Add
        | 2 -> Arith Multiply
        | _ -> Halt

    let private opCodeAt (arr: int array) i =
        if i >= arr.Length then Halt else (decodeOpCode arr.[i])

    let private compute =
        let rec compute' pc (arr: int array) =
            match (opCodeAt arr pc) with
            | Halt -> arr
            | Arith aop ->
                let infix =
                    match aop with
                    | Add -> (+)
                    | Multiply -> (*)
                arr.[arr.[pc + 3]] <- infix arr.[arr.[pc + 1]] arr.[arr.[pc + 2]]
                compute' (pc + 4) arr
        compute' 0

    let private katPart1 () =
        Kat.init()
        |> Kat.expect [| 2; 0; 0; 0; 99 |] (compute [| 1; 0; 0; 0; 99 |])
        |> Kat.expect [| 2; 3; 0; 6; 99 |] (compute [| 2; 3; 0; 3; 99 |])
        |> Kat.expect [| 2; 4; 4; 5; 99; 9801 |] (compute [| 2; 4; 4; 5; 99; 0 |])
        |> Kat.expect [| 30; 1; 1; 4; 2; 5; 6; 0; 99 |] (compute [| 1; 1; 1; 4; 99; 5; 6; 0; 99 |])
        |> Kat.finish

    let private solvePart1 lines =
        let arr = parse (Seq.head lines)
        arr.[1] <- 12
        arr.[2] <- 2
        Some (compute arr).[0]

    let puzzles = [
        { Puzzle.Name = "day2p1"; KnownAnswerTest = katPart1; Solver = solvePart1 }
        ]
