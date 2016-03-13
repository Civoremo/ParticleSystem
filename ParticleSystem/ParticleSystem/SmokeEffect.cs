using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSystem
{
    public class SmokeEffect
    {
        Random random = new Random();

        public Particle Smoke()
        {
            Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            float size = (float)random.NextDouble() * 2;
            int ttl = 20 + random.Next(40);


            return new Particle(velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Update()
        {
        }
    }
}
