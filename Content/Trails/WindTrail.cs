using System;
using Deus.Common.Systems.TrailSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace TestMod.Content.Trails;

public class WindTrail : SimpleTrail
{
    public WindTrail(object entity, int length, Func<float, float> widthFunction, Func<float, Color> colorFunction) : base(entity, length, widthFunction, colorFunction,
        ModContent.Request<Texture2D>("Deus/Assets/WindTrail", AssetRequestMode.ImmediateLoad).Value)
    {
    }

    public override void Fade()
    {
        Active = false;
    }
}