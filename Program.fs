(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

open System
open Log
open AdventOfCode.PuzzlePool

[<EntryPoint>]
let main argv =
    Log.trace "%A" argv
    AdventOfCode.PuzzlePool.run argv.[0]
    0 // return an integer exit code
