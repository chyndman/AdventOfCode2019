(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.Day1

    let private fuel mass = (mass / 3) - 2

    let kat () =
        Kat.init()
        |> Kat.expect 654 (fuel 1969)
        |> Kat.expect 33583 (fuel 100756)
        |> Kat.finish

    let solve =
        (Seq.fold (fun acc l -> acc + (fuel (int l))) 0) >> (fun i -> Some i)
    let puzzles =
        [
            { Puzzle.Name = "day1"; KnownAnswerTest = kat; Solver = solve }
        ]
