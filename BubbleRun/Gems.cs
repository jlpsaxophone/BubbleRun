using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleRun
{
    public class Gems
    {       
        Vector2[] locations = new Vector2[] {new Vector2(297, 244), new Vector2(303,339), new Vector2(0,159), new Vector2(630,159)};
        
        Sprite sprite;

        BubbleRun game;

        Random random = new Random();

        Vector2 previousLocation;

        public Gem gem1 = new Gem();
        public Gem gem2 = new Gem();
        public Gem gem3 = new Gem();
        public Gem gem4 = new Gem();
        public Gem gem5 = new Gem();
        public Gem gem6 = new Gem();
        public Gem gem7 = new Gem();

        bool gem1Lock = true;
        bool gem2Lock = true;
        bool gem3Lock = true;
        bool gem4Lock = true;
        bool gem5Lock = true;
        bool gem6Lock = true;
        bool gem7Lock = true;

        public Gems(Sprite sprite, BubbleRun game)
        {
            this.sprite = sprite;
            this.game = game;
        }

        public void UpdateGems()
        {
            
            if(game.player1.heldGems + game.player2.heldGems == 0 && gem1Lock)
            {              
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem1.bounds.X = location.X;
                gem1.bounds.Y = location.Y;
                gem1.bounds.Width = 21;
                gem1.bounds.Height = 21;
                gem1Lock = !gem1Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 1 && gem2Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while(previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem2.bounds.X = location.X;
                gem2.bounds.Y = location.Y;
                gem2.bounds.Width = 21;
                gem2.bounds.Height = 21;
                gem2Lock = !gem2Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 2 && gem3Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem3.bounds.X = location.X;
                gem3.bounds.Y = location.Y;
                gem3.bounds.Width = 21;
                gem3.bounds.Height = 21;
                gem3Lock = !gem3Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 3 && gem4Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem4.bounds.X = location.X;
                gem4.bounds.Y = location.Y;
                gem4.bounds.Width = 21;
                gem4.bounds.Height = 21;
                gem4Lock = !gem4Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 4 && gem5Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem5.bounds.X = location.X;
                gem5.bounds.Y = location.Y;
                gem5.bounds.Width = 21;
                gem5.bounds.Height = 21;
                gem5Lock = !gem5Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 5 && gem6Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem6.bounds.X = location.X;
                gem6.bounds.Y = location.Y;
                gem6.bounds.Width = 21;
                gem6.bounds.Height = 21;
                gem6Lock = !gem6Lock;
            }
            if (game.player1.heldGems + game.player2.heldGems == 6 && gem7Lock)
            {
                Vector2 location = locations[random.Next(0, 4)];
                while (previousLocation == location)
                {
                    location = locations[random.Next(0, 4)];
                }
                previousLocation = location;
                gem7.bounds.X = location.X;
                gem7.bounds.Y = location.Y;
                gem7.bounds.Width = 21;
                gem7.bounds.Height = 21;
                gem7Lock = !gem7Lock;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(game.player1.heldGems + game.player2.heldGems == 0)
            {
                sprite.Draw(spriteBatch, gem1.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 1)
            {
                sprite.Draw(spriteBatch, gem2.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 2)
            {
                sprite.Draw(spriteBatch, gem3.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 3)
            {
                sprite.Draw(spriteBatch, gem4.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 4)
            {
                sprite.Draw(spriteBatch, gem5.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 5)
            {
                sprite.Draw(spriteBatch, gem6.bounds, Color.White);
            }
            if (game.player1.heldGems + game.player2.heldGems == 6)
            {
                sprite.Draw(spriteBatch, gem7.bounds, Color.White);
            }
        }
    }
}
