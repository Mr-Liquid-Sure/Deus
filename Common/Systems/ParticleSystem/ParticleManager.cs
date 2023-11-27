using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Deus.Common.Systems.ParticleSystem;

public class ParticleManager : ModSystem
{
    private static List<Particle> particles;

    public override void Load()
    {
        particles = new List<Particle>();
        On_Main.DrawDust += DrawParticles;
    }

    private void DrawParticles(On_Main.orig_DrawDust orig, Main self)
    {
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
        foreach (Particle particle in particles)
        {
            particle.Draw(Main.spriteBatch);
        }
        Main.spriteBatch.End();
        orig(self);
    }

    public override void PostUpdateEverything()
    {
        for (int i = 0; i < particles.Count; i++)
        {
            if (particles[i].Active)
            {
                particles[i].Update();
            }
            else
            {
                particles.RemoveAt(i);
                i--;
            }
        }
    }
    
    public static void CreateParticle(Particle particle)
    {
        particles.Add(particle);
        particle.OnSpawn();
    }
}