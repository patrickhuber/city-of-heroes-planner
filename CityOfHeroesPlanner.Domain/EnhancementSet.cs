namespace CityOfHeroesPlanner.Domain
{
    public class EnhancementSet
    {
        public EnhancementSetBonusGroup[] Tiers { get; set; }
        public Enhancement[] Enhancements { get; set; }
    }
}