using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Deus.Common.Systems.TrailSystem;

/// <summary>
/// Represents a trail made using triangle strips.
/// </summary>
public class PrimitiveTrail
{
    protected readonly TrailPositionBuffer Positions;
    public readonly TrailEntity Entity;

    protected readonly Func<float, float> widthFunction;
    protected readonly Func<float, Color> colorFunction;

    public bool Active = true;
    public bool Fading;

    /// <summary>
    /// Initializes a new instance of the PrimitiveTrail class.
    /// </summary>
    /// <param name="entity">The entity to attach the trail to.</param>
    /// <param name="length">The length of the trail buffer.</param>
    /// <param name="widthFunction">A function that determines the trail width based on time.</param>
    /// <param name="colorFunction">A function that determines the trail color based on time.</param>
    public PrimitiveTrail(Object entity, int length, Func<float, float> widthFunction, Func<float, Color> colorFunction)
    {
        this.Entity = new TrailEntity(entity);
        this.widthFunction = widthFunction;
        this.colorFunction = colorFunction;
        Positions = new TrailPositionBuffer(length);
    }

    /// <summary>
    /// Marks the trail as inactive.
    /// </summary>
    public void Kill()
    {
        Active = false;
    }

    /// <summary>
    /// Updates the trail
    /// </summary>
    public virtual void Update()
    {
    }

    /// <summary>
    /// Fades the trail by removing the oldest position from the trail buffer.
    /// Deactivates the trail when there are no positions left.
    /// </summary>
    public virtual void Fade()
    {
        
    }

    /// <summary>
    /// Prepares vertices and draws the trail
    /// </summary>
    public virtual void Draw()
    {
        
    }
    
    /// <summary>
    /// Fills the trail buffer with positions that are stretched along the direction vector.
    /// </summary>
    public void Stretch(Vector2 direction)
    {
        // will fill the trail buffer with positions
        // that are stretched along the direction vector
        for (int i = Positions.Capacity; i > 0; i--)
        {
            Positions.PushBack(Entity.Position - direction * i);
        }
    }
}
public class SimpleTrail : PrimitiveTrail  {
    private readonly string pass = "Default";
    private readonly Texture2D texture;
    private readonly PrimitiveDrawer drawer;
    private TrailTip tip;
    private float movementProgress;
    private readonly float movement;
    public SimpleTrail(object entity, int length, Func<float, float> widthFunction, Func<float, Color> colorFunction, Texture2D texture, float movement = 0f) :
        base(entity, length, widthFunction, colorFunction)
    {
        this.movement = movement;
        drawer = new PrimitiveDrawer(4, PrimitiveType.TriangleList);
        if (texture != null)
        {
            this.texture = texture;
            pass = "Texture";
        }
        tip = new TrailTip.None();
    }

    protected void SetTip<T>() where T : TrailTip, new()
    {
        tip = new T();
    }

    

    public override void Update()
    {
        Positions.PushBack(Entity.Position);
    }

    public override void Fade()
    {
        if (Positions.Count > 0)
            Positions.PopFront();
        if (Positions.Count == 0)
        {
            Active = false;
        }
    }
    public override void Draw()
    {
        movementProgress += movement;
        if (Positions.Count < 2) return;
        drawer.Resize(Positions.Count * 2 + tip.ExtraVertices);
        for (int i = 0; i < Positions.Count; i++)
        {
            float progress = i / (float)Positions.Capacity;
            float width = widthFunction(progress);
            Color color = colorFunction(progress);
            Vector2 position = Positions[i];
            Vector2 normal = Vector2.Zero;
            if (i > 0)
            {
                normal += (position - Positions[i - 1]).SafeNormalize(Vector2.Zero);
            }
            Vector2 offset = new Vector2(normal.Y, -normal.X) * width;
            drawer.AddVertex(position - offset - Main.screenPosition, color, new Vector2((progress + movementProgress) % 1, 1));
            drawer.AddVertex(position + offset - Main.screenPosition, color, new Vector2((progress + movementProgress) % 1, 0));
        }
        drawer.PrepareIndices();
        Vector2 dir = (Positions[^1] - Positions[^2]).SafeNormalize(Vector2.Zero);
        tip.AddTip(drawer, Entity, Positions[^1], dir, widthFunction(Positions.Count / (float)Positions.Capacity), colorFunction(Positions.Count / (float)Positions.Capacity));
        Effect effect = TrailManager.TrailShader;
        effect.Parameters["WorldViewProjection"].SetValue(Utils.GetMatrix());
        effect.Parameters["tex"].SetValue(texture);
        effect.CurrentTechnique.Passes[pass].Apply();
        drawer.Draw();
    }
}