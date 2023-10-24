
//######## Laborator 2 EGC, Exercitiul 2, Cocriș Iulian, grupa 3132A #############//

using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ControlObiectRandareOpenTK
{
    class Game : GameWindow
    {
        private int objectX = 50;
        private int objectY = 50;
        private int lastMouseX;
        private int lastMouseY;
        private Vector2 objectPosition = Vector2.Zero;


        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Control Obiect cu Input mouse") 
        {
            VSync = VSyncMode.On;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.BlueViolet);
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //  Controlarea obiectului folosind mouse-ul
            MouseState mouse = Mouse.GetState();
            objectPosition.X = (mouse.X - Width / 2) / (float)(Width / 2);
            objectPosition.Y = (Height / 2 - mouse.Y) / (float)(Height / 2);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            var keyboardState = Keyboard.GetState();
            float speed = 1.0f;
            // Controlul obiectului cu tastatura
            if (keyboardState.IsKeyDown(Key.W))
            {
                objectPosition.Y += speed;
            }
            if (keyboardState.IsKeyDown(Key.S))
            {
                objectPosition.Y -= speed;
            }
            if (keyboardState.IsKeyDown(Key.A))
            {
                objectPosition.X -= speed;
            }
            if (keyboardState.IsKeyDown(Key.D))
            {
                objectPosition.X += speed;
            }
            GL.Begin(PrimitiveType.Quads);
            GL.Color3((System.Drawing.Color)Color4.Blue);
            GL.Vertex2(objectPosition.X, objectPosition.Y);
            GL.Vertex2(objectPosition.X + 50, objectPosition.Y);
            GL.Vertex2(objectPosition.X + 50, objectPosition.Y + 50);
            GL.Vertex2(objectPosition.X, objectPosition.Y + 50);
            GL.End();

            SwapBuffers();

        }


        [STAThread]
        static void Main()
        {
            using (var game = new Game(800, 600))
            {
                game.Run(60.0);
            }
        }
    }
}
