#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using FSCMInterfaces;
using FSCMStrikesBackLogic;

#endregion

namespace Engine
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TimeSpan elapsedTime = TimeSpan.Zero;

        float height;
        float width;

        // Adjust as needed to make analog sticks more sensitive or less sensitive.
        private const float ANALOG_DEADZONE = 0.1f;

        BGMObserver bgm = new BGMObserver();
        SFXObserver sfx = new SFXObserver();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            // You never actually see the Window Title, so no worries here.
            Window.Title = "The Flying Spaghetti Code Monster Strikes Back!";
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ContentLoader.onLoad(Content);
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MediaHandler.registerBGM(bgm);
            MediaHandler.registerSFX(sfx);
            StateHandler.initialize();

            IsMouseVisible = false;
            graphics.IsFullScreen = true;
            graphics.SynchronizeWithVerticalRetrace = true;

            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            // This is obsolete with the *Factory classes.
        }

        protected override void UnloadContent()
        {
            // The *Factory classes rendered this completely obsolete.
        }

        protected override void Update(GameTime gameTime)
        {
            if (StateHandler.Exit())
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.PageDown) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_START);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                StateHandler.Input(Globals.KEY_EXIT);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_DOWN);

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_UP);

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_RIGHT);

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_LEFT);

            if (Keyboard.GetState().IsKeyDown(Keys.Q) || GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_CAMERA_LEFT);

            if (Keyboard.GetState().IsKeyDown(Keys.W) || GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_CAMERA_RIGHT);

            if (Keyboard.GetState().IsKeyDown(Keys.F) || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_ACCEPT);

            if (Keyboard.GetState().IsKeyDown(Keys.D) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_CANCEL);

            if (Keyboard.GetState().IsKeyDown(Keys.R) || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_MENU);

            if (Keyboard.GetState().IsKeyDown(Keys.E) || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
                StateHandler.Input(Globals.KEY_MISC);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > ANALOG_DEADZONE || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -ANALOG_DEADZONE)
                StateHandler.interpret_analog(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X / 2, Globals.LEFT_CONTROL_X);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > ANALOG_DEADZONE || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -ANALOG_DEADZONE)
                StateHandler.interpret_analog(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y / 2, Globals.LEFT_CONTROL_Y);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > ANALOG_DEADZONE || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < -ANALOG_DEADZONE)
                StateHandler.interpret_analog(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X, Globals.RIGHT_CONTROL_X);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > ANALOG_DEADZONE || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -ANALOG_DEADZONE)
                StateHandler.interpret_analog(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y, Globals.RIGHT_CONTROL_Y);

            if (Keyboard.GetState().IsKeyDown(Keys.P))
                setInternalFPS(90);

            if (Keyboard.GetState().IsKeyDown(Keys.O))
                setInternalFPS(30);

            if (Keyboard.GetState().IsKeyDown(Keys.I))
                setInternalFPS(60);

            StateHandler.Update();

            base.Update(gameTime);
        }

        private void setInternalFPS(int fps)
        {
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / (float)fps);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (height != Window.ClientBounds.Height)
            {
                height = Window.ClientBounds.Height;
                Globals.hmod = height / 768f;
            }
            if (width != Window.ClientBounds.Width)
            {
                width = Window.ClientBounds.Width;
                Globals.wmod = width / 1024f;
            }

            GraphicsDevice.Clear(Color.Transparent);
            SpriteBatch sBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont font;
            font = Content.Load<SpriteFont>("Old London");

            sBatch.Begin();
            Texture2D background = Content.Load<Texture2D>(MediaHandler.getBackground());
            sBatch.Draw(background, Window.ClientBounds, Color.White);
            sBatch.End();

            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            if (StateHandler.GetSceneList() != null)
            {
                foreach (Actor actor in StateHandler.GetSceneList())
                    if (actor != null)
                        actor.draw(gameTime.ElapsedGameTime);
            }

            sBatch.Begin();
            MessageBoxInterface[] messageboxes = StateHandler.GetMessageBoxes();
            if (messageboxes != null)
            {
                foreach (MessageBoxInterface message in messageboxes)
                {
                    if (message == null)
                        continue;

                    Texture2D messageBoxBackground;
                    if (message.IsChildMessage())
                        messageBoxBackground = Content.Load<Texture2D>("messagebox2.jpg");
                    else
                        messageBoxBackground = Content.Load<Texture2D>("messagebox.png");

                    if (!message.Scaling())
                        sBatch.Draw(messageBoxBackground, new Rectangle((int)(message.X()*Globals.wmod), (int)(message.Y()*Globals.hmod), message.Width(), message.Height()), Color.Blue);
                    else
                        sBatch.Draw(messageBoxBackground, new Rectangle((int)(message.X() * Globals.wmod), (int)(message.Y() * Globals.hmod), (int)(message.Width()*Globals.wmod), (int)(message.Height()*Globals.hmod)), Color.Blue);
                    for (int i = 0; i < message.stringToDisplay().Length; i++)
                    {
                        sBatch.DrawString(font, message.stringToDisplay()[i], new Vector2((float)(message.X()*Globals.wmod) + 10, (float)(message.Y()*Globals.hmod) + 10 + (i*Globals.FONT_HEIGHT)), message.Color()[i]);
                    }
                }
            }

            if (StateHandler.Paused)
                sBatch.DrawString(font, "P A U S E D", new Vector2(Window.ClientBounds.Width / 2 - 65, Window.ClientBounds.Height / 2), Color.NavajoWhite);

          //  sBatch.DrawString(font, "X : " + StateHandler.X + " Y: " + StateHandler.Y + " Z: " + StateHandler.Z + " TX: " + StateHandler.TargetX + " TY: " + StateHandler.TargetY + " TZ: " + StateHandler.TargetZ, new Vector2(100, 100), Color.NavajoWhite);

            sBatch.End();

            base.Draw(gameTime);
        }
    }
}
