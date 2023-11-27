using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace Deus.Common.Systems.TrailSystem;

public class TrailManager : ModSystem
{
    private static List<PrimitiveTrail> trails;
    public static Effect TrailShader { get; private set; }
    
    public static T CreateTrail<T>(Object entity, int length, Func<float, float> widthFunction, Func<float, Color> colorFunction) where T : PrimitiveTrail
    {
        T trail = (T)Activator.CreateInstance(typeof(T), entity, length, widthFunction, colorFunction);
        trails.Add(trail);
        return trail;
    }

    public override void Load()
    {
        trails = new List<PrimitiveTrail>();
        TrailShader = Mod.Assets.Request<Effect>("Effects/TrailShader", AssetRequestMode.ImmediateLoad).Value;
        On_Main.DrawProjectiles += DrawProjectileTrails;
    }
    
    public static void DrawTrails(TrailType type)
    {
        if (trails.Count == 0) return;
        foreach (PrimitiveTrail trail in trails)
        {
            if (trail.Entity.Type != type) continue;
            trail.Draw();
        }
    }

    private void DrawProjectileTrails(On_Main.orig_DrawProjectiles orig, Main self)
    {
        if (Main.spriteBatch.HasBegun()) Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullNone);
        DrawTrails(TrailType.Projectile);
        // temp
        DrawTrails(TrailType.Other);
        Main.spriteBatch.End();
        orig(self);
    }

    public override void PostUpdateEverything()
    {
        for (int i = 0; i < trails.Count; i++)
        {
            PrimitiveTrail trail = trails[i];

            if (!trail.Entity.Active && !trail.Fading)
            {
                trail.Fading = true;
            }

            if (!trail.Active)
            {
                trails.RemoveAt(i);
                i--;
                continue;
            }
            if (trail.Fading)
            {
                trail.Fade();
                continue;
            }

            trail.Update();
        }
    }
}