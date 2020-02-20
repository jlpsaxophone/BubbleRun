using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace BubbleRun
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BubbleRun : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont text;
        SpriteSheet sheet;
        AxisList world;
        public BubblePlayer player1;
        public BubblePlayer player2;
        public Gems gems;
        public Spike spike1;
        public Spike spike2;
        public Spike spike3;
        public Spike spike4;
        public Spike spike5;
        public Spike spike6;
        public Spike spike7;
        public Spike spike8;

        public List<Platform> platforms;      

        public BubbleRun()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            platforms = new List<Platform>();           
        }

        protected override void Initialize()
        {
            base.Initialize();
            graphics.PreferredBackBufferWidth = 651;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var t = Content.Load<Texture2D>("spritesheet");
            text = Content.Load<SpriteFont>("score");
            sheet = new SpriteSheet(t, 21, 21, 3, 2);

            // Create the player with the corresponding frames from the spritesheet
            var playerFrames1 = from index in Enumerable.Range(19, 30) select sheet[index];
            var playerFrames2 = from index in Enumerable.Range(49, 60) select sheet[index];
            player1 = new BubblePlayer(playerFrames1, this, 1);
            player2 = new BubblePlayer(playerFrames2, this, 2);
            gems = new Gems(sheet[144], this);
            spike1 = new Spike(new BoundingRectangle(0, 339, 10, 10), sheet[70]);
            spike2 = new Spike(new BoundingRectangle(630, 339, 10, 10), sheet[70]);
            spike3 = new Spike(new BoundingRectangle(255, 244, 10, 10), sheet[70]);
            spike4 = new Spike(new BoundingRectangle(360, 244, 10, 10), sheet[70]);
            spike5 = new Spike(new BoundingRectangle(234, 244, 10, 10), sheet[70]);
            spike6 = new Spike(new BoundingRectangle(339, 244, 10, 10), sheet[70]);
            spike7 = new Spike(new BoundingRectangle(42, 160, 10, 10), sheet[70]);
            spike8 = new Spike(new BoundingRectangle(588, 160, 10, 10), sheet[70]);

            // Create the platforms
            platforms.Add(new Platform(new BoundingRectangle(0, 459, 232, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(390, 459, 273, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(0, 360, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(567, 360, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(240, 360, 147, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(150, 265, 315, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(0, 180, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(567, 180, 84, 21), sheet[122]));

            platforms.Add(new Platform(new BoundingRectangle(0, 459, 232, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(390, 459, 273, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(0, 360, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(567, 360, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(240, 360, 147, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(150, 265, 315, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(0, 180, 84, 21), sheet[122]));
            platforms.Add(new Platform(new BoundingRectangle(567, 180, 84, 21), sheet[122]));

            world = new AxisList();
            foreach (Platform platform in platforms)
            {
                world.AddGameObject(platform);
            }
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            //Update Method Pattern
            gems.UpdateGems();
            player1.Update(gameTime);
            player2.Update(gameTime);
            var platformQuery1 = world.QueryRange(player1.Bounds.X, player1.Bounds.X + player1.Bounds.Width);
            player1.CheckForPlatformCollision(platformQuery1);
            var platformQuery2 = world.QueryRange(player2.Bounds.X, player2.Bounds.X + player2.Bounds.Width);
            player2.CheckForPlatformCollision(platformQuery2);          

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            gems.Draw(spriteBatch);
            platforms.ForEach(platform =>
            {
                platform.Draw(spriteBatch);
            });
            spike1.Draw(spriteBatch);
            spike2.Draw(spriteBatch);
            spike3.Draw(spriteBatch);
            spike4.Draw(spriteBatch);
            spike5.Draw(spriteBatch);
            spike6.Draw(spriteBatch);
            spike7.Draw(spriteBatch);
            spike8.Draw(spriteBatch);

            if(!player1.player1Wins && !player2.player2Wins)
            {
                spriteBatch.DrawString(
                text,
                "Player 1: " + player1.heldGems.ToString(),
                new Vector2(1, 0),
                Color.Black
                );
                spriteBatch.DrawString(
                    text,
                    "Player 2: " + player2.heldGems.ToString(),
                    new Vector2(572, 0),
                    Color.Black
                    );
                spriteBatch.DrawString(
                text,
                "Collect 4 gems before your oponent!",
                new Vector2(197, 0),
                Color.Black
                );
            }                     
            if(player1.player1Wins)
            {
                spriteBatch.DrawString(
                text,
                "Player 1 wins!",
                new Vector2(260, 50),
                Color.Black
                );
                player1.heldGems = 1000;
                player2.Position.X = -1000;
                player2.Position.Y = -1000;
            }
            if (player2.player2Wins)
            {
                spriteBatch.DrawString(
                text,
                "Player 2 wins!",
                new Vector2(260, 50),
                Color.Black
                );
                player2.heldGems = 1000;
                player1.Position.X = -1000;
                player1.Position.Y = -1000;
            }
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
