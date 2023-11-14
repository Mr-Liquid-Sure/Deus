using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Deus.Common.Systems.TrailSystem;

public abstract class TrailTip
{
    public abstract int ExtraVertices { get; }
    public abstract void AddTip(PrimitiveDrawer drawer, TrailEntity entity, Vector2 pos, Vector2 direction, float width, Color color);
    public class None : TrailTip
    {
        public override int ExtraVertices => 0;
        public override void AddTip(PrimitiveDrawer drawer, TrailEntity entity, Vector2 pos, Vector2 direction, float width, Color color)
        {
        }
    }
    
    public class Triangle : TrailTip
    {
        public override int ExtraVertices => 4;
        public override void AddTip(PrimitiveDrawer drawer, TrailEntity entity, Vector2 pos, Vector2 direction, float width, Color color)
        {
            Vector2 normal = new Vector2(direction.Y, -direction.X);
            Vector2 offset = normal * width ;
            int indexOffset = drawer.VertexCount;
            
            drawer.AddVertex(pos - Main.screenPosition, color, new Vector2(0.5f, 0.5f));
            drawer.AddVertex(pos - offset - Main.screenPosition, color, new Vector2(0, 1));
            drawer.AddVertex(pos + offset - Main.screenPosition, color, new Vector2(0, 0));
            drawer.AddVertex(pos + direction * width - Main.screenPosition, Color.Transparent, new Vector2(0.5f, 0.5f));
            
            // triangle is actually 2 triangles (0, 1, 3) and (0, 2, 3)
            drawer.AddIndexes(new short[]
            {
                (short)(indexOffset),
                (short)(indexOffset + 1),
                (short)(indexOffset + 3),
                (short)(indexOffset),
                (short)(indexOffset + 2),
                (short)(indexOffset + 3),
            });
        }
    }
    
    public class Square : TrailTip
    {
        public override int ExtraVertices => 4;
        public override void AddTip(PrimitiveDrawer drawer, TrailEntity entity, Vector2 pos, Vector2 direction, float width, Color color)
        {
            Vector2 normal = new Vector2(direction.Y, -direction.X);
            Vector2 offset = normal * width;
            int indexOffset = drawer.VertexCount;
            drawer.AddVertex(pos - offset - Main.screenPosition, color, new Vector2(0, 1));
            drawer.AddVertex(pos + offset - Main.screenPosition, color, new Vector2(1, 0));
            drawer.AddVertex(pos + direction * width + offset - Main.screenPosition, color, new Vector2(0, 0));
            drawer.AddVertex(pos + direction * width - offset - Main.screenPosition, color, new Vector2(0, 1));
            
            drawer.AddIndexes(new short[]
            {
                (short)(indexOffset),
                (short)(indexOffset + 1),
                (short)(indexOffset + 2),
                (short)(indexOffset),
                (short)(indexOffset + 2),
                (short)(indexOffset + 3),
            });
        }
    }
    public class Circle : TrailTip
    {
        public override int ExtraVertices => 14;
        public override void AddTip(PrimitiveDrawer drawer, TrailEntity entity, Vector2 pos, Vector2 direction, float width, Color color)
        {
            int indexOffset = drawer.VertexCount;
            drawer.AddVertex(pos - Main.screenPosition, color, new Vector2(0.5f, 0.5f));
            for (int i = 0; i < 13; i++)
            {
                float angle = MathHelper.Pi * i / 12f + direction.ToRotation() - MathHelper.PiOver2;
                Vector2 circleOffset = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * width;
                drawer.AddVertex(pos + circleOffset - Main.screenPosition, Color.Transparent, new Vector2((float)Math.Cos(MathHelper.Pi * (i / 12f)) , i > 6 ? 0 : 1));
            }
            
            short[] indices = new short[39];
            for (int i = 0; i < 13; i++)
            {
                indices[i * 3] = (short)(indexOffset);
                indices[i * 3 + 1] = (short)(indexOffset + i + 1);
                indices[i * 3 + 2] = (short)(indexOffset + (i + 1) % 13 + 1);
            }
            drawer.AddIndexes(indices);
        }
    }
    
    

}
