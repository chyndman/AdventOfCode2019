(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module AdventOfCode.Kat

    open Log

    let init () =
        Log.trace "KAT init"
        (0, 0)

    let expect e a (passed, ran) =
        let inc =
            if e = a
            then
                Log.debug "Got %A" a
                1
            else
                Log.error "Got %A, expected %A" a e
                0
        (passed + inc, ran + 1)

    let finish (passed, ran) =
        let logfn = if passed = ran then Log.debug else Log.error
        logfn "KAT %d of %d tests passed" passed ran
        passed = ran
