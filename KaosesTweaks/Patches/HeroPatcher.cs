﻿using HarmonyLib;
using KaosesTweaks.Objects.Experience;
using KaosesTweaks.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace KaosesTweaks.Patches
{
    class HeroPatcher
    {
        [HarmonyPatch(typeof(Hero))]//, "AddSkillXp"
        public class Patches
        {
            [HarmonyPrefix]
            [HarmonyPatch("AddSkillXp")]
            public static void Prefix(Hero __instance, SkillObject skill, ref float xpAmount)
            {
                if (__instance != null && skill != null && __instance.HeroDeveloper != null && skill.GetName() != null && Hero.MainHero != null)
                {
                    //if (__instance.IsHumanPlayerCharacter)
                        //Ux.MessageDebug("AddSkillXpPatcher: Prefix: xpAmount: " + xpAmount.ToString());
                    KaosesAddSkillXp kaosesSkillXp = new KaosesAddSkillXp(__instance, skill, xpAmount);
                    if (kaosesSkillXp.HasModifiedXP())
                    {
                        xpAmount = kaosesSkillXp.GetNewSkillXp();
                        //if (__instance.IsHumanPlayerCharacter)
                            //Ux.MessageDebug("AddSkillXpPatcher: Prefix: GetNewSkillXp: " + xpAmount.ToString());
                    }

/*
                    if (__instance.IsHumanPlayerCharacter)
                    {
                        Ux.MessageDebug("AddSkillXp Original Values :   "
                            + "  maxSkillPoint:  " + maxSkillPoint.ToString()
                            + "  propertyValue:  " + propertyValue.ToString()
                            + "  getFocusVariable:  " + getFocusVariable.ToString()
                            + "  focusFactor:  " + focusFactor.ToString()
                            + "  xpMultipliedByFocusFactor:  " + xpMultipliedByFocusFactor.ToString()
                            + "  propertyValueSkillPlusXpMultipliedByFocusFactor:  " + propertyValueSkillPlusXpMultipliedByFocusFactor.ToString()
                            );
                    }*/

                }
            }


/*
            [HarmonyPostfix]
            [HarmonyPatch("AddSkillXp")]
            public static void Postfix(Hero __instance, SkillObject skill, ref float xpAmount)
            {
                //Ux.MessageDebug("AddSkillXpPatcher: Postfix: xpAmount: " + xpAmount.ToString());
            }*/
        }
    }
}