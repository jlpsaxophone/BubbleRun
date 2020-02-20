﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleRun
{
    public class Spike
    {
        public BoundingRectangle bounds;

        Sprite sprite;

        public Spike(BoundingRectangle bounds, Sprite sprite)
        {
            this.bounds.X = bounds.X;
            this.bounds.Y = bounds.Y;
            this.bounds.Height = bounds.Height;
            this.bounds.Width = bounds.Width;
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(bounds.X, bounds.Y), Color.White);            
        }
    }
}
