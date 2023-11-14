using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Deus.Common.Systems.ParticleSystem;

public abstract class Particle
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Color Color;
    public float Alpha;
    public float Scale;
    public float Rotation;
    public int TimeLeft;
    public bool Active = true;
    public float[] ExtraData = new float[4];

    public virtual void OnSpawn() { }

    public void Kill()
    {
        Active = false;
    }
    
    public virtual void Update()
    {
        Position += Velocity;
        TimeLeft--;
        if (TimeLeft <= 0)
        {
            Active = false;
        }
    }
    
    public virtual void Draw(SpriteBatch spriteBatch) { }
    
    public static void NewParticle<T>(Vector2 position, Vector2 velocity, Color color = default, float alpha = 1, float scale = 0, float rotation = 0, float data1 = 0, float data2 = 0, float data3 = 0, float data4 = 0) where T : Particle, new()
    {
        T particle = new T
        {
            Position = position,
            Velocity = velocity,
            Color = color,
            Alpha = alpha,
            Scale = scale,
            Rotation = rotation,
            ExtraData = new float[4]
        };
        particle.ExtraData[0] = data1;
        particle.ExtraData[1] = data2;
        particle.ExtraData[2] = data3;
        particle.ExtraData[3] = data4;
        ParticleManager.CreateParticle(particle);
    }
}