using System;
using Deus.Common.Systems.ParticleSystem;
using Deus.Common.Systems.TrailSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Content.Trails;

namespace Deus.Content.Particles;

public class Wind : Particle
{
    float rotPerFrame;
    public override void OnSpawn()
    {
        var trail = TrailManager.CreateTrail<WindTrail>(this, 8, f => (float)Math.Sin(f * Math.PI) * 8f * Scale * f,
            f => new Color(96, 128, 96, 0) * 0.3f);
        Player player = Main.player[(int)ExtraData[0]];
        float distance = Vector2.Distance(player.Center, Position);
        rotPerFrame = MathHelper.TwoPi / (MathHelper.TwoPi * distance / Velocity.Length());
        trail.Stretch(Velocity / 4);
    }
    
    public override void Update()
    {
        Velocity = Velocity.RotatedBy(rotPerFrame) * 0.97f;
        Position += new Vector2(ExtraData[1], ExtraData[2]) * 0.7f;
        Scale -= 0.05f - Velocity.Length() * 0.001f;
        Position += Velocity;
        if (Scale < 0.1f)
            Kill();
    }
}