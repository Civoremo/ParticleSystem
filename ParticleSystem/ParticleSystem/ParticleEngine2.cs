using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleSystem
{
    public class ParticleEngine
    {

        private Random random;        
        private List<Particle> particles;
        private List<Texture2D> textures;

        public Vector2 EmitterLocation { get; set; }
        public bool Active { get; set; }

        int EffectNum { get; set; }

        public ParticleEngine(List<Texture2D> textures, Vector2 location, int effectNumber)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
            EffectNum = effectNumber;
        }

        
        /*private Particle GenerateNewParticle()
        {
            
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            
            Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            float size = (float)random.NextDouble() * 2 ;
            int timetolive = 20 + random.Next(40);
              
            
            Vector2 Velocity = velocity;
            float Angle = angle;
            float AngularVelocity = angularVelocity;
            Color Color = color;
            float Size = size;
            int TimeToLive = timetolive;

            return new Particle(texture, position, Velocity, Angle, AngularVelocity, Color, Size, TimeToLive);
        }*/
    


        public void Update(int total)                   // include the number of particles to be generated
        {
                int Total = total;

            if (Active == true)                         // while the particle system is Active; generate new particle
            {
                for (int i = 0; i < Total; i++)
                {
                    particles.Add();
                }
            }

                for (int particle = 0; particle < particles.Count; particle++)      
                {
                    particles[particle].Update();
                    if (particles[particle].TimeToLive <= 0)
                    {
                        particles.RemoveAt(particle);
                        particle--;
                    }
                }            
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public void EffectSelection()
        {
            Particle smoke = new Particle();

            KeyboardState currentSelection = Keyboard.GetState();

            if (currentSelection.IsKeyDown(Keys.D1))
            {
                
            }

            if (currentSelection.IsKeyDown(Keys.D2))
            { }
        }
    }
}
