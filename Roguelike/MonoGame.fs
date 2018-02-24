module MonoGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type MonoGame () as game =
    inherit Game ()

    let mutable graphics = Unchecked.defaultof<GraphicsDeviceManager>
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
    do 
        graphics <- new GraphicsDeviceManager (game)
        game.Content.RootDirectory <- "Content"

    override game.Initialize () =
        base.Initialize ()
        ()
     
    override game.LoadContent () =
        spriteBatch <- new SpriteBatch (graphics.GraphicsDevice)
        ()
     
    override game.Update (gameTime) =
        base.Update gameTime
        ()
     
    override game.Draw (gameTime) =
        game.GraphicsDevice.Clear Color.CornflowerBlue
        base.Draw gameTime
        ()
