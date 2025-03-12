using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace AlienCuisine
{
    public class IngestionOutcomeDoer_GiveTrait : IngestionOutcomeDoer
    {
        public TraitDef traitDef;
        public int degree;
        public float chance = 1f;

        // 必须：显式空构造函数
        public IngestionOutcomeDoer_GiveTrait() { }

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            if (pawn?.story?.traits == null || traitDef == null) return;

            if (Rand.Value < chance && !pawn.story.traits.HasTrait(traitDef))
            {
                //添加特质
                pawn.story.traits.GainTrait(new Trait(traitDef, degree));

                // 显示提示消息
                Messages.Message(
                    "AC_Message_TraitGained".Translate(
                        pawn.LabelShortCap
                    ),
                    pawn,
                    MessageTypeDefOf.PositiveEvent
                );
            }
        }

        // 显示统计信息
        //public override IEnumerable<StatDrawEntry> SpecialDisplayStats(ThingDef parentDef)
        //{
        //    yield return new StatDrawEntry(
        //        StatCategoryDefOf.Basics,
        //        "AC_TraitGrantChance".Translate(),
        //        chance.ToStringPercent(),
        //        "AC_TraitGrantChanceDesc".Translate(traitDef.LabelCap),
        //        9999
        //    );
        //}
    }
}
