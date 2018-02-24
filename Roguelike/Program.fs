// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open MonoGame

[<EntryPoint>]
let main argv = 
    use g = new MonoGame ()
    g.Run ()
    0 // return an integer exit code
