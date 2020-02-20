using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BubbleRun
{
    enum PlayerAnimState
    {
        Idle,
        JumpingLeft,
        JumpingRight,
        WalkingLeft,
        WalkingRight,
        FallingLeft,
        FallingRight
    }

    enum VerticalMovementState
    {
        OnGround,
        Jumping,
        Falling
    }
    public class BubblePlayer
    {
        // The speed of the walking animation
        const int FRAME_RATE = 300;

        // The duration of a player's jump, in milliseconds
        const int JUMP_TIME = 500;

        // The player sprite frames
        Sprite[] frames;

        // The currently rendered frame
        int currentFrame = 0;

        // The player's animation state
        PlayerAnimState animationState = PlayerAnimState.Idle;

        // The player's speed
        int speed = 3;

        // The player's vertical movement state
        VerticalMovementState verticalState = VerticalMovementState.OnGround;

        // A timer for jumping
        TimeSpan jumpTimer;

        // A timer for animations
        TimeSpan animationTimer;

        // The currently applied SpriteEffects
        SpriteEffects spriteEffects = SpriteEffects.None;

        // The color of the sprite
        Color color = Color.White;

        // The origin of the sprite (centered on its feet)
        Vector2 origin = new Vector2(10, 21);

        /// <summary>
        /// Gets and sets the position of the player on-screen
        /// </summary>
        public Vector2 Position = new Vector2(200, 200);

        public BoundingRectangle Bounds => new BoundingRectangle(Position - 2 * origin, 38, 41);

        public int heldGems = 0;

        int type;
        public bool player1Wins = false;
        public bool player2Wins = false;

        BubbleRun game;

        /// <summary>
        /// Constructs a new player
        /// </summary>
        /// <param name="frames">The sprite frames associated with the player</param>
        public BubblePlayer(IEnumerable<Sprite> frames, BubbleRun game, int type)
        {
            this.frames = frames.ToArray();
            this.type = type;
            this.game = game;
            animationState = PlayerAnimState.WalkingLeft;
            if(type == 1)
            {
                Position.X = 20;
                Position.Y = 430;
            }
            else
            {
                Position.X = 620;
                Position.Y = 430;
            }
        }

        /// <summary>
        /// Updates the player, applying movement and physics
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if(Position.X < 12)
            {
                Position.X = 12;
            }
            if(Position.X > 634)
            {
                Position.X = 634;
            }

            if (Bounds.CollidesWith(game.gems.gem1.bounds))
            {
                game.gems.gem1.bounds.X = 0;
                game.gems.gem1.bounds.Y = 0;
                game.gems.gem1.bounds.Width = 0;
                game.gems.gem1.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem2.bounds))
            {
                game.gems.gem2.bounds.X = 0;
                game.gems.gem2.bounds.Y = 0;
                game.gems.gem2.bounds.Width = 0;
                game.gems.gem2.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem3.bounds))
            {
                game.gems.gem3.bounds.X = 0;
                game.gems.gem3.bounds.Y = 0;
                game.gems.gem3.bounds.Width = 0;
                game.gems.gem3.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem4.bounds))
            {
                game.gems.gem4.bounds.X = 0;
                game.gems.gem4.bounds.Y = 0;
                game.gems.gem4.bounds.Width = 0;
                game.gems.gem4.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem5.bounds))
            {
                game.gems.gem5.bounds.X = 0;
                game.gems.gem5.bounds.Y = 0;
                game.gems.gem5.bounds.Width = 0;
                game.gems.gem5.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem6.bounds))
            {
                game.gems.gem6.bounds.X = 0;
                game.gems.gem6.bounds.Y = 0;
                game.gems.gem6.bounds.Width = 0;
                game.gems.gem6.bounds.Height = 0;
                heldGems++;
            }
            if (Bounds.CollidesWith(game.gems.gem7.bounds))
            {
                game.gems.gem7.bounds.X = 0;
                game.gems.gem7.bounds.Y = 0;
                game.gems.gem7.bounds.Width = 0;
                game.gems.gem7.bounds.Height = 0;
                heldGems++;
            }



            if (type == 1)
            {
                if(heldGems == 4)
                {
                    player1Wins = true;
                }
                if (Bounds.CollidesWith(game.spike1.bounds)
               || Bounds.CollidesWith(game.spike2.bounds)
               || Bounds.CollidesWith(game.spike3.bounds)
               || Bounds.CollidesWith(game.spike4.bounds)
               || Bounds.CollidesWith(game.spike5.bounds)
               || Bounds.CollidesWith(game.spike6.bounds)
               || Bounds.CollidesWith(game.spike7.bounds)
               || Bounds.CollidesWith(game.spike8.bounds)
               || Bounds.Y > 450)
                {
                    Position.X = 20;
                    Position.Y = 430;
                }

                // Vertical movement
                    switch (verticalState)
                {
                    case VerticalMovementState.OnGround:
                        if (keyboard.IsKeyDown(Keys.W))
                        {
                            verticalState = VerticalMovementState.Jumping;
                            jumpTimer = new TimeSpan(0);
                        }
                        break;
                    case VerticalMovementState.Jumping:
                        jumpTimer += gameTime.ElapsedGameTime;
                        // Simple jumping with platformer physics
                        Position.Y -= (450 / (float)jumpTimer.TotalMilliseconds);
                        if (jumpTimer.TotalMilliseconds >= JUMP_TIME) verticalState = VerticalMovementState.Falling;
                        break;
                    case VerticalMovementState.Falling:
                        Position.Y += speed;
                        break;
                }


                // Horizontal movement
                if (keyboard.IsKeyDown(Keys.A))
                {
                    if (verticalState == VerticalMovementState.Jumping || verticalState == VerticalMovementState.Falling)
                        animationState = PlayerAnimState.JumpingLeft;
                    else animationState = PlayerAnimState.WalkingLeft;
                    Position.X -= speed;
                }
                else if (keyboard.IsKeyDown(Keys.D))
                {
                    if (verticalState == VerticalMovementState.Jumping || verticalState == VerticalMovementState.Falling)
                        animationState = PlayerAnimState.JumpingRight;
                    else animationState = PlayerAnimState.WalkingRight;
                    Position.X += speed;
                }
                else
                {
                    animationState = PlayerAnimState.Idle;
                }

                // Apply animations
                switch (animationState)
                {
                    case PlayerAnimState.Idle:
                        currentFrame = 0;
                        animationTimer = new TimeSpan(0);
                        break;

                    case PlayerAnimState.JumpingLeft:
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        currentFrame = 7;
                        break;

                    case PlayerAnimState.JumpingRight:
                        spriteEffects = SpriteEffects.None;
                        currentFrame = 7;
                        break;

                    case PlayerAnimState.WalkingLeft:
                        animationTimer += gameTime.ElapsedGameTime;
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        // Walking frames are 9 & 10
                        if (animationTimer.TotalMilliseconds > FRAME_RATE * 2)
                        {
                            animationTimer = new TimeSpan(0);
                        }
                        currentFrame = (int)Math.Floor(animationTimer.TotalMilliseconds / FRAME_RATE) + 9;
                        break;

                    case PlayerAnimState.WalkingRight:
                        animationTimer += gameTime.ElapsedGameTime;
                        spriteEffects = SpriteEffects.None;
                        // Walking frames are 9 & 10
                        if (animationTimer.TotalMilliseconds > FRAME_RATE * 2)
                        {
                            animationTimer = new TimeSpan(0);
                        }
                        currentFrame = (int)Math.Floor(animationTimer.TotalMilliseconds / FRAME_RATE) + 9;
                        break;

                }
            }        

            else
            {
                if(heldGems == 4)
                {
                    player2Wins = true;
                }
                if (Bounds.CollidesWith(game.spike1.bounds)
              || Bounds.CollidesWith(game.spike2.bounds)
              || Bounds.CollidesWith(game.spike3.bounds)
              || Bounds.CollidesWith(game.spike4.bounds)
              || Bounds.CollidesWith(game.spike5.bounds)
              || Bounds.CollidesWith(game.spike6.bounds)
              || Bounds.CollidesWith(game.spike7.bounds)
              || Bounds.CollidesWith(game.spike8.bounds)
              || Bounds.Y > 450)
                {
                    Position.X = 620;
                    Position.Y = 430;
                }
                // Vertical movement
                switch (verticalState)
                {
                    case VerticalMovementState.OnGround:
                        if (keyboard.IsKeyDown(Keys.Up))
                        {
                            verticalState = VerticalMovementState.Jumping;
                            jumpTimer = new TimeSpan(0);
                        }
                        break;
                    case VerticalMovementState.Jumping:
                        jumpTimer += gameTime.ElapsedGameTime;
                        // Simple jumping with platformer physics
                        Position.Y -= (450 / (float)jumpTimer.TotalMilliseconds);
                        if (jumpTimer.TotalMilliseconds >= JUMP_TIME) verticalState = VerticalMovementState.Falling;
                        break;
                    case VerticalMovementState.Falling:
                        Position.Y += speed;
                        break;
                }


                // Horizontal movement
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    if (verticalState == VerticalMovementState.Jumping || verticalState == VerticalMovementState.Falling)
                        animationState = PlayerAnimState.JumpingLeft;
                    else animationState = PlayerAnimState.WalkingLeft;
                    Position.X -= speed;
                }
                else if (keyboard.IsKeyDown(Keys.Right))
                {
                    if (verticalState == VerticalMovementState.Jumping || verticalState == VerticalMovementState.Falling)
                        animationState = PlayerAnimState.JumpingRight;
                    else animationState = PlayerAnimState.WalkingRight;
                    Position.X += speed;
                }
                else
                {
                    animationState = PlayerAnimState.Idle;
                }

                // Apply animations
                switch (animationState)
                {
                    case PlayerAnimState.Idle:
                        currentFrame = 0;
                        animationTimer = new TimeSpan(0);
                        break;

                    case PlayerAnimState.JumpingLeft:
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        currentFrame = 7;
                        break;

                    case PlayerAnimState.JumpingRight:
                        spriteEffects = SpriteEffects.None;
                        currentFrame = 7;
                        break;

                    case PlayerAnimState.WalkingLeft:
                        animationTimer += gameTime.ElapsedGameTime;
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        // Walking frames are 9 & 10
                        if (animationTimer.TotalMilliseconds > FRAME_RATE * 2)
                        {
                            animationTimer = new TimeSpan(0);
                        }
                        currentFrame = (int)Math.Floor(animationTimer.TotalMilliseconds / FRAME_RATE) + 9;
                        break;

                    case PlayerAnimState.WalkingRight:
                        animationTimer += gameTime.ElapsedGameTime;
                        spriteEffects = SpriteEffects.None;
                        // Walking frames are 9 & 10
                        if (animationTimer.TotalMilliseconds > FRAME_RATE * 2)
                        {
                            animationTimer = new TimeSpan(0);
                        }
                        currentFrame = (int)Math.Floor(animationTimer.TotalMilliseconds / FRAME_RATE) + 9;
                        break;

                }
            }           
        }

        public void CheckForPlatformCollision(IEnumerable<IBoundable> platforms)
        {
            if (verticalState != VerticalMovementState.Jumping)
            {
                verticalState = VerticalMovementState.Falling;
                foreach (Platform platform in platforms)
                {
                    if (Bounds.CollidesWith(platform.Bounds))
                    {
                        Position.Y = platform.Bounds.Y - 1;
                        verticalState = VerticalMovementState.OnGround;
                    }
                }
            }
        }

        /// <summary>
        /// Render the player sprite.  Should be invoked between 
        /// SpriteBatch.Begin() and SpriteBatch.End()
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
#if VISUAL_DEBUG 
            VisualDebugging.DrawRectangle(spriteBatch, Bounds, Color.Red);
#endif
            frames[currentFrame].Draw(spriteBatch, Position, color, 0, origin, 2, spriteEffects, 1);
        }
    }
}
