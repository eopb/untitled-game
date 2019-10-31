namespace MGNamespace

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type WindowSize(window: GameWindow) =
    member this.Width = window.ClientBounds.Width
    member this.Height = window.ClientBounds.Height
    member this.Update() = WindowSize(window)
    member this.AsString = sprintf "%s %s" (this.Width.ToString()) (this.Height.ToString())

type Game1() as this =
    inherit Game()

    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<_>
    let mutable windowSize = WindowSize(this.Window)

    do
        this.Content.RootDirectory <- "Content"
        this.IsMouseVisible <- true
        graphics.IsFullScreen <- false
        graphics.PreferredBackBufferWidth <- 800
        graphics.PreferredBackBufferHeight <- 600
        this.Window.AllowUserResizing <- true
        // graphics.ApplyChanges()
        this.Window.ClientSizeChanged.Add(fun arg ->
            do windowSize <- windowSize.Update()
               printfn "%s" (windowSize.AsString))

    override this.Initialize() =
        // TODO: Add your initialization logic here
        base.Initialize()

    override this.LoadContent() = spriteBatch <- new SpriteBatch(this.GraphicsDevice)

    // TODO: use this.Content to load your game content here

    override this.Update(gameTime) =
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)) then this.Exit()

        // TODO: Add your update logic here

        base.Update(gameTime)

    override this.Draw(gameTime) =
        this.GraphicsDevice.Clear Color.CornflowerBlue

        // TODO: Add your drawing code here

        base.Draw(gameTime)
