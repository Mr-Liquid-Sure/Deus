using System;
using Deus.Common.Systems.ParticleSystem;
using Microsoft.Xna.Framework;
using Terraria;

namespace Deus.Common.Systems.TrailSystem;

public enum TrailType
{
    NPC,
    Projectile,
    Particle,
    Other
}
public class TrailEntity
{
    public readonly Object Entity;
    public TrailType Type;
    public TrailEntity(Object obj)
    {
        Entity = obj;
        if (obj is Projectile)
        {
            Type = TrailType.Projectile;
        }
        else if (obj is NPC)
        {
            Type = TrailType.NPC;
        }
        else
        {
            Type = TrailType.Other;
        }
    }

    public Vector2 Position
    {
        get
        {
            return Entity switch
            {
                Projectile proj => proj.Center,
                NPC npc => npc.Center,
                Particle particle => particle.Position,
                _ => default
            };
        }
    }
    
    public Vector2 Direction
    {
        get
        {
            return Entity switch
            {
                Projectile proj => proj.velocity,
                NPC npc => npc.velocity,
                Particle particle => particle.Velocity,
                _ => default
            };
        }
    }

    public bool Active
    {
        get
        {
            return Entity switch
            {
                Projectile proj => proj.active,
                NPC npc => npc.active,
                Particle particle => particle.Active,
                _ => false
            };
        }
    }
}