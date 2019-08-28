using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSetType
    {
        public static readonly EnhancementSetType Untyped = new EnhancementSetType { Name ="Untyped", Value = 0 };
        public static readonly EnhancementSetType MeleeSingleTarget = new EnhancementSetType { Name ="MeleeSingleTarget", Value = 1 };
        public static readonly EnhancementSetType RangedSingleTarget = new EnhancementSetType { Name ="RangedSingleTarget", Value = 2 };
        public static readonly EnhancementSetType RangedAreaOfEffect = new EnhancementSetType { Name ="RangedAreaOfEffect", Value = 3 };
        public static readonly EnhancementSetType MeleeAreaOfEffect = new EnhancementSetType { Name ="MeleeAreaOfEffect", Value = 4 };
        public static readonly EnhancementSetType Snipe = new EnhancementSetType { Name ="Snipe", Value = 5 };
        public static readonly EnhancementSetType Pets = new EnhancementSetType { Name ="Pets", Value = 6 };
        public static readonly EnhancementSetType Defense = new EnhancementSetType { Name ="Defense", Value = 7 };
        public static readonly EnhancementSetType Resistance = new EnhancementSetType { Name ="Resistance", Value = 8 };
        public static readonly EnhancementSetType Heal = new EnhancementSetType { Name ="Heal", Value = 9 };
        public static readonly EnhancementSetType Hold = new EnhancementSetType { Name ="Hold", Value = 10 };
        public static readonly EnhancementSetType Stun = new EnhancementSetType { Name ="Stun", Value = 11 };
        public static readonly EnhancementSetType Immobilize = new EnhancementSetType { Name ="Immobilize", Value = 12 };
        public static readonly EnhancementSetType Slow = new EnhancementSetType { Name ="Slow", Value = 13 };
        public static readonly EnhancementSetType Sleep = new EnhancementSetType { Name ="Sleep", Value = 14 };
        public static readonly EnhancementSetType Fear = new EnhancementSetType { Name ="Fear", Value = 15 };
        public static readonly EnhancementSetType Confuse = new EnhancementSetType { Name ="Confuse", Value = 16 };
        public static readonly EnhancementSetType Flight = new EnhancementSetType { Name ="Flight", Value = 17 };
        public static readonly EnhancementSetType Jump = new EnhancementSetType { Name ="Jump", Value = 18 };
        public static readonly EnhancementSetType Run = new EnhancementSetType { Name ="Run", Value = 19 };
        public static readonly EnhancementSetType Teleport = new EnhancementSetType { Name ="Teleport", Value = 20 };
        public static readonly EnhancementSetType DefenseDebuff = new EnhancementSetType { Name ="DefenseDebuff", Value = 21 };
        public static readonly EnhancementSetType EnduranceModification = new EnhancementSetType { Name ="EnduranceModification", Value = 22 };
        public static readonly EnhancementSetType Knockback = new EnhancementSetType { Name ="Knockback", Value = 23 };
        public static readonly EnhancementSetType Taunt = new EnhancementSetType { Name ="Taunt", Value = 24 };
        public static readonly EnhancementSetType ToHit = new EnhancementSetType { Name ="ToHit", Value = 25 };
        public static readonly EnhancementSetType ToHitDebbuff = new EnhancementSetType { Name ="ToHitDebbuff", Value = 26 };
        public static readonly EnhancementSetType PetRech = new EnhancementSetType { Name ="PetRech", Value = 27 };
        public static readonly EnhancementSetType Travel = new EnhancementSetType { Name ="Travel", Value = 28 };
        public static readonly EnhancementSetType AccurateHeal = new EnhancementSetType { Name ="AccurateHeal", Value = 29 };
        public static readonly EnhancementSetType AccurateDefenceDebuff = new EnhancementSetType { Name ="AccurateDefenceDebuff", Value = 30 };
        public static readonly EnhancementSetType AccToHitDebuff = new EnhancementSetType { Name ="AccToHitDebuff", Value = 31 };
        public static readonly EnhancementSetType Arachnos = new EnhancementSetType { Name ="Arachnos", Value = 32 };
        public static readonly EnhancementSetType Blaster = new EnhancementSetType { Name ="Blaster", Value = 33 };
        public static readonly EnhancementSetType Brute = new EnhancementSetType { Name ="Brute", Value = 34 };
        public static readonly EnhancementSetType Controller = new EnhancementSetType { Name ="Controller", Value = 35 };
        public static readonly EnhancementSetType Corruptor = new EnhancementSetType { Name ="Corruptor", Value = 36 };
        public static readonly EnhancementSetType Defender = new EnhancementSetType { Name ="Defender", Value = 37 };
        public static readonly EnhancementSetType Dominator = new EnhancementSetType { Name ="Dominator", Value = 38 };
        public static readonly EnhancementSetType Kheldian = new EnhancementSetType { Name ="Kheldian", Value = 39 };
        public static readonly EnhancementSetType Mastermind = new EnhancementSetType { Name ="Mastermind", Value = 40 };
        public static readonly EnhancementSetType Scrapper = new EnhancementSetType { Name ="Scrapper", Value = 41 };
        public static readonly EnhancementSetType Stalker = new EnhancementSetType { Name ="Stalker", Value = 42 };
        public static readonly EnhancementSetType Tanker = new EnhancementSetType { Name ="Tanker", Value = 43 };
        public static readonly EnhancementSetType UniversalDamage = new EnhancementSetType { Name ="UniversalDamage", Value = 44 };
        public static readonly EnhancementSetType Sentinel = new EnhancementSetType { Name ="Sentinel", Value = 45 };
        public string Name { get; set; }
        public int Value { get; set; }

        public static readonly EnhancementSetType[] EnhancementSetTypes = new EnhancementSetType[] 
        {
            Untyped,
            MeleeSingleTarget,
            RangedSingleTarget,
            RangedAreaOfEffect,
            MeleeAreaOfEffect,
            Snipe,
            Pets,
            Defense,
            Resistance,
            Heal,
            Hold,
            Stun,
            Immobilize,
            Slow,
            Sleep,
            Fear,
            Confuse,
            Flight,
            Jump,
            Run,
            Teleport,
            DefenseDebuff,
            EnduranceModification,
            Knockback,
            Taunt,
            ToHit,
            ToHitDebbuff,
            PetRech,
            Travel,
            AccurateHeal,
            AccurateDefenceDebuff,
            AccToHitDebuff,
            Arachnos,
            Blaster,
            Brute,
            Controller,
            Corruptor,
            Defender,
            Dominator,
            Kheldian,
            Mastermind,
            Scrapper,
            Stalker,
            Tanker,
            UniversalDamage,
            Sentinel
        };
    }
}
