(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

open System
open AdventOfCode.PuzzlePool

let readLines path = IO.File.ReadLines(path)

[<EntryPoint>]
let main argv =
    Log.trace "%A" argv
    let puzzleName = argv.[0]
    let inputFilePath = argv.[1]
    let inputLines = readLines inputFilePath
    AdventOfCode.PuzzlePool.run puzzleName inputLines
    0 // return an integer exit code
