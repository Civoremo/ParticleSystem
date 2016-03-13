using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ParticleSystem
{
 
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;                

        ParticleEngine particleEngine;
        ParticleEngine particleEngine2;

        List<Texture2D> textures = new List<Texture2D>();
        List<Texture2D> textures2 = new List<Texture2D>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

 
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //textures2.Add(Content.Load<Texture2D>("ballBlue"));
            textures2.Add(Content.Load<Texture2D>("smoke"));
            //textures.Add(Content.Load<Texture2D>("tree3"));
            //textures2.Add(Content.Load<Texture2D>("snailShell"));
            textures.Add(Content.Load<Texture2D>("muzzle1"));
            textures.Add(Content.Load<Texture2D>("muzzle2"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240), 1);
            particleEngine2 = new ParticleEngine(textures2, new Vector2(400, 240), 2);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                particleEngine2.Active = true;
                particleEngine2.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            }

            ButtonPressed();

            particleEngine.Update(1);
            particleEngine2.Update(5);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            particleEngine.Draw(spriteBatch);
            particleEngine2.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        public void ButtonPressed()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                particleEngine.Active = true;
            }
        }
    }
}
