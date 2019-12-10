(* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. *)

module Log

    open System

    type Level =
        | Trace
        | Debug
        | Info
        | Warning
        | Error
        | Fatal

    let private colorRed = "\u001b[31m"
    let private colorBlue = "\u001b[34m"
    let private colorOff = "\u001b[0m"

    let private prefix = function
        | Trace ->   "[     " + colorBlue + "\\" + colorOff + "]"
        | Debug ->   "[    " + colorBlue + "\\\\" + colorOff + "]"
        | Info ->    "[   " + colorBlue + "\\\\\\" + colorOff + "]"
        | Warning -> "[  " + colorRed + "\\" + colorBlue + "\\\\\\" + colorOff + "]"
        | Error ->   "[ " + colorRed + "\\\\" + colorBlue + "\\\\\\" + colorOff + "]"
        | Fatal ->   "[" + colorRed + "\\\\\\\\\\\\" + colorOff + "]"

    let private write lv =
        printf "%s " (prefix lv)
        printfn

    let trace fmt   = write Trace fmt
    let debug fmt   = write Debug fmt
    let info fmt    = write Info fmt
    let warning fmt = write Warning fmt
    let error fmt   = write Error fmt
    let fatal fmt   = write Fatal fmt
