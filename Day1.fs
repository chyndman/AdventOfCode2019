(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.Day1

    let private solveSumOf f =
        (Seq.fold (fun acc l -> acc + (f (int l))) 0) >> (fun i -> Some i)

    let private fuel mass = (mass / 3) - 2

    let private katPart1 () =
        Kat.init()
        |> Kat.expect 654 (fuel 1969)
        |> Kat.expect 33583 (fuel 100756)
        |> Kat.finish

    let private solvePart1 = solveSumOf fuel

    let rec private fuelCompound mass =
        let f = fuel mass
        if f > 0 then f + (fuelCompound f) else 0

    let private katPart2 () =
        Kat.init()
        |> Kat.expect 2 (fuelCompound 14)
        |> Kat.expect 966 (fuelCompound 1969)
        |> Kat.expect 50346 (fuelCompound 100756)
        |> Kat.finish

    let private solvePart2 = solveSumOf fuelCompound

    let puzzles = [
        { Puzzle.Name = "day1p1"; KnownAnswerTest = katPart1; Solver = solvePart1 }
        { Puzzle.Name = "day1p2"; KnownAnswerTest = katPart2; Solver = solvePart2 }
        ]
