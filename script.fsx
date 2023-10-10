#r "nuget: Argu, 6.1.1"
#load "stupid-math.fsx"
open StupidMath
open Argu

type Arguments =
    | [<MainCommand; ExactlyOnce; Last>] Whole_Number of number:int

    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Whole_Number _ -> "whole number on which to operate"

let parser =
    ArgumentParser.Create<Arguments> "stupid-math"
let print = printfn "%s"

// [<EntryPoint>]
let main argv =
    try
        let results =
            parser.Parse (inputs=argv)
        let number =
            results.GetResult Whole_Number
        add41 number |> printfn "%i"

    with e ->
        print e.Message
    0

fsi.CommandLineArgs
|> Array.tail
|> main
