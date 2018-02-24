module MonoGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Entity

type MonoGame () as game =
    inherit Game ()

    let mutable entities    = []
    let mutable texture     = Unchecked.defaultof<Texture2D>
    let mutable graphics    = Unchecked.defaultof<GraphicsDeviceManager>
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
    do 
        graphics <- new GraphicsDeviceManager (game)
        game.Content.RootDirectory <- "Content"

    override game.Initialize () =
        base.Initialize ()
        ()
     
    override game.LoadContent () =
        spriteBatch <- new SpriteBatch (graphics.GraphicsDevice)

        //texture <- new Texture2D (graphics.GraphicsDevice, 32, 32)
        //texture.SetData <| Array.create (32*32) Color.Chocolate

        let pixel = new Texture2D (graphics.GraphicsDevice, 1, 1)
        pixel.SetData<Color> [|Color.White|]
        let entity : Entity = { components = 
                                    [ Position(new Vector2(float32 64, float32 64));
                                      Appearance(pixel) ] 
                              }
        entities <- entity :: entities
        ()
     
    override game.Update (gameTime) =
        base.Update gameTime
        ()
     
    override game.Draw (gameTime) =
        game.GraphicsDevice.Clear Color.CornflowerBlue
        DrawEntities game.GraphicsDevice entities
        base.Draw gameTime
        ()
