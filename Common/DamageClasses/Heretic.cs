using Terraria.ModLoader;

namespace Deus.Common.DamageClasses
{
    public class Heretic : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                knockbackInheritance: 0f);
        }
        public override bool UseStandardCritCalcs => true;

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Summon)
                return true;
            if (damageClass == DamageClass.Magic)
                return true;

            return false;
        }
    }
}