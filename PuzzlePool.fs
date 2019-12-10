(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.PuzzlePool

    open Day1
    open Log

    let private puzzles = Day1.puzzles

    let run (pname: string) =
        puzzles
        |> Seq.find (fun p -> p.Name = pname)
        |> (fun p ->
            Log.info "Running puzzle \"%s\"" p.Name
            Log.debug "Performing KAT"
            if p.KnownAnswerTest()
                then
                    Log.debug "Solving"
                else
                    Log.error "KAT failed")
