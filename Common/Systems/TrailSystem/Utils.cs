using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Deus.Common.Systems.TrailSystem;

public static partial class Utils
{
    // primitive stuff
    public static bool HasBegun(this SpriteBatch spriteBatch)
    {
        return (bool)spriteBatch.GetType().GetField("beginCalled", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
    }
    public static void Reload(this SpriteBatch spriteBatch, BlendState state, SpriteSortMode mode = default)
    {
        if (spriteBatch.HasBegun())
            spriteBatch.End();
        if (mode == default) mode = (SpriteSortMode)spriteBatch.GetType().GetField("sortMode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var samplerState = (SamplerState)spriteBatch.GetType().GetField("samplerState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var depthStencilState = (DepthStencilState)spriteBatch.GetType().GetField("depthStencilState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var rasterizerState = (RasterizerState)spriteBatch.GetType().GetField("rasterizerState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var effect = (Effect)spriteBatch.GetType().GetField("customEffect", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var transformMatrix = (Matrix)spriteBatch.GetType().GetField("transformMatrix", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        spriteBatch.Begin(mode, state, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
    }
    private static int width;
    private static int height;
    private static Vector2 zoom;
    private static bool CheckGraphicsChanged()
    {
        var device = Main.graphics.GraphicsDevice;
        bool changed = device.Viewport.Width != width
                       || device.Viewport.Height != height
                       || Main.GameViewMatrix.Zoom != zoom;

        if (!changed) return false;

        width = device.Viewport.Width;
        height = device.Viewport.Height;
        zoom = Main.GameViewMatrix.Zoom;

        return true;
    }

    private static Matrix view;
    private static Matrix projection;
    public static Matrix GetMatrix()
    {
        if (CheckGraphicsChanged())
        {
            var device = Main.graphics.GraphicsDevice;
            int width = device.Viewport.Width;
            int height = device.Viewport.Height;
            Vector2 zoom = Main.GameViewMatrix.Zoom;
            view =
                Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.Up)
                * Matrix.CreateTranslation(width / 2, height / -2, 0)
                * Matrix.CreateRotationZ(MathHelper.Pi)
                * Matrix.CreateScale(zoom.X, zoom.Y, 1f);
            projection = Matrix.CreateOrthographic(width, height, 0, 1000);
        }

        return view * projection;
    }
    
}