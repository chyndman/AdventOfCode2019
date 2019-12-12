(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.PuzzlePool

    open Day1
    open Log

    let private puzzles =
        Day1.puzzles
        @ Day2.puzzles

    let private filterKat p =
        Log.debug "%s: Performing KAT" p.Name
        if p.KnownAnswerTest()
        then
            Log.debug "KAT passed"
            Some p
        else
            Log.error "KAT failed"
            None

    let private solve lines p' =
        let solOpt =
            match p' with
            | Some p ->
                Log.info "%s: Solving" p.Name
                p.Solver lines
            | None -> None
        (p', solOpt)

    let private reportSolution = function
        | (Some p, Some sol) ->
            Log.info "%s: Solution is %i" p.Name sol
        | (Some p, None) ->
            Log.warning "%s: No solution" p.Name
        | _ -> ()

    let run pname lines =
        puzzles
        |> Seq.find (fun p -> p.Name = pname)
        |> filterKat
        |> solve lines
        |> reportSolution
