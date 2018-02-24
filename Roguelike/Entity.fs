module Entity

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Component = 
    | Position   of point : Vector2
    | Appearance of texture : Texture2D
    | Collision  of blocking : bool

type Entity = { components : Component list }

// TODO: Figure out how to make these into one generic function
// TODO: Assign them a return type
let GetPosition (e : Entity) =
    e.components |> List.find (function | Position(_) -> true | _ -> false)

let GetAppearance (e : Entity) =
    e.components |> List.find (function | Appearance(_) -> true | _ -> false)

let DrawEntity (sb : SpriteBatch) (e : Entity) =
    try
        let (Appearance texture) = GetAppearance e
        let (Position point)     = GetPosition e
        sb.Draw (texture, new Rectangle (int point.X, int point.Y, 32, 32), Color.White)
        //sb.Draw (texture, point, Color.White)
        ()
    with
        | :? System.Collections.Generic.KeyNotFoundException -> ()

let DrawEntities (gd : Graphics.GraphicsDevice) (es : Entity list) =
    let sb = new SpriteBatch (gd)
    let DrawEntity' = DrawEntity sb
    let isAppearance c = match c with | Appearance(_) -> true | _ -> false
    let isPosition   c = match c with | Position(_)   -> true | _ -> false

    let isDrawable (e : Entity) = 
        e.components |> List.exists isPosition && e.components |> List.exists isAppearance

    sb.Begin ()
    es |> List.filter isDrawable |> List.iter DrawEntity'
    sb.End ()
    ()