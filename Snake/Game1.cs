using Eron;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Controllers;
using Snake.Graphics;
using Snake.Sneak;
using Snake.SoundEffects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Snake
{
    public enum GameState
    {
        Start, InGame, GameOver
    }


    public class Game1 : Game
    {
       
        private readonly DirectoryInfo snakeSounds = new(@"Content\Sounds\SnakeSound");
        private List<SoundEffect> generalEffects;
        private GameState gameState = GameState.Start;
        private ColisionManager colisionManager;
        private GraphicsDeviceManager _graphics;
        private List<IUpdateable> updateables;
        private List<ICollidable> collidables;
        private List<Animator> animatores;
        private SpriteBatch _spriteBatch;
        private List<Entity> entities;
        private Controller controller;
        private SpriteFont mainFont;
        private List<Wall> walls;
        private Counter counter;
        private Serpent snake;
        private Food apple;
        public Game1()
        {
           
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferHeight = Constants.HEIGHT;
            _graphics.PreferredBackBufferWidth = Constants.WIDTH;
            generalEffects = new List<SoundEffect>();
            collidables = new List<ICollidable>();
            updateables = new List<IUpdateable>();
            animatores = new List<Animator>();
            entities = new List<Entity>();

            _graphics.SynchronizeWithVerticalRetrace = true;
            this.IsFixedTimeStep = false;

            _graphics.ApplyChanges(); 
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            walls = new List<Wall>();
            apple = new Food(new Vector2(0, 0), new Sprite(new Vector2(200, 300), Content.Load<Texture2D>("FoodSprites\\1_food")));

            snake = new Serpent(
                new Head(new Vector2(100, 100), new Sprite(new Vector2(100, 100), Content.Load<Texture2D>("SnakeSprites\\1_Head"))),
                Content.Load<Texture2D>("SnakeSprites\\1_block"),  ResourcePacker<SoundEffect>.Pack(Content, snakeSounds, @"Sounds\SnakeSound", "*.wma")
                );

            Texture2D wl = Content.Load<Texture2D>("1_Wall");

            for (int i = 0; i * wl.Width < Constants.WIDTH + 30; i++)
            {

                walls.Add(new Wall(new Vector2(i * wl.Width, wl.Height / 2), new Sprite(new Vector2(i * wl.Width, wl.Height / 2), wl)));
                walls.Add(new Wall(new Vector2(i * wl.Width, Constants.HEIGHT - wl.Height / 2), new Sprite(new Vector2(i * wl.Width, Constants.HEIGHT - wl.Height / 2), wl)));


                for (int j = 0; j * wl.Height < Constants.HEIGHT + 30; j++)
                {
                    walls.Add(new Wall(new Vector2(wl.Width / 2, j * wl.Height), new Sprite(new Vector2(wl.Width / 2, j * wl.Height), wl)));
                    walls.Add(new Wall(new Vector2(Constants.WIDTH - wl.Width / 2, j * wl.Height), new Sprite(new Vector2(Constants.WIDTH - wl.Width / 2, j * wl.Height), wl)));
                }



            }

            controller = new Controller(snake);
            entities.Add(apple);
            entities.Add(snake.Head);


            for (int i = 0; i < snake.body.Count; i++) entities.Add(snake.body[i]);

            for (int i = 0; i < walls.Count; i++) entities.Add(walls[i]);




            for (int i = 0; i < entities.Count; i++) collidables.Add(entities[i]);

            collidables.Remove(snake.body.First());

            colisionManager = new ColisionManager(snake);

            foreach (var entity in entities) animatores.Add(new Animator(entity.Sprite));


            mainFont = Content.Load<SpriteFont>("a");
            updateables.Add(snake);
            updateables.Add(apple);
            counter = new Counter(mainFont);
            gameState = GameState.Start;

        }



        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.R) && gameState == GameState.GameOver)
            {
                SoundPlayer.StopSound();
                entities.Clear();
                animatores.Clear();
                collidables.Clear();
                updateables.Clear();
                LoadContent();
                gameState = GameState.InGame;
                DirectionControl.list = new List<PointDirection>();
            }

            switch (gameState)
            {
                case GameState.Start:

                    if (gameState != GameState.InGame && gameState != GameState.GameOver && Keyboard.GetState().IsKeyDown(Keys.Space)) gameState = GameState.InGame;

                    break;

                case GameState.InGame:

                    DirectionControl.Control(snake.body);
                    foreach (var updateable in updateables) { updateable.Update(gameTime); }
                    controller.HandleKeyboard();
                    colisionManager.Colision(ref collidables);

                    if (snake.AddSegment)
                    {
                        entities.Add(snake.body[snake.body.Count - 1]);
                        animatores.Add(new Animator(snake.body[snake.body.Count - 1].Sprite));
                        snake.AddSegment = false;

                    }

                    base.Update(gameTime);

                    if (snake.Head.Collided) { gameState = GameState.GameOver; SoundPlayer.PlaySound(Content.Load<SoundEffect>(@"Sounds\GeneralSounds\gameover sound"), 0.1f); }
                    
                    break;

            }
            counter.count = snake.Lenght;

            for (int i = 0; i < animatores.Count; i++) animatores[i]?.Update(gameTime, entities[i].Sprite, entities[i].Sprite.Rotation);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Start:
                
                    _spriteBatch.DrawString(mainFont, "Press space to start", new Vector2(Constants.WIDTH / 3, Constants.HEIGHT / 2), Color.White);
                    break;
                case GameState.InGame:
                    for (int i = 0; i < animatores.Count; i++) { animatores[i]?.Draw(_spriteBatch, animatores[i].Sprite.Origin); }
                    counter.DrawCount(_spriteBatch);
                    break;
                case GameState.GameOver:
                    _spriteBatch.DrawString(mainFont, "Press R to restart", new Vector2((Constants.WIDTH / 2) - 185 , (Constants.HEIGHT/2) + 100), Color.White);
                    _spriteBatch.DrawString(mainFont, "GAME OVER", new Vector2((Constants.WIDTH / 2) - 100, (Constants.HEIGHT / 2)), Color.Red);
                    break;
            }

            

            


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}