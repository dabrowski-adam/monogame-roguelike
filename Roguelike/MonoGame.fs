module MonoGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type MonoGame () as game =
    inherit Game ()

    let mutable texture = Unchecked.defaultof<Texture2D>
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

        texture <- new Texture2D (graphics.GraphicsDevice, 32, 32)
        texture.SetData <| Array.create (32*32) Color.Chocolate

        ()
     
    override game.Update (gameTime) =
        base.Update gameTime
        ()
     
    override game.Draw (gameTime) =
        game.GraphicsDevice.Clear Color.CornflowerBlue

        spriteBatch.Begin ()
        spriteBatch.Draw (texture, new Vector2 (float32 10, float32 20), Color.White)
        spriteBatch.End ()

        base.Draw gameTime
        ()
