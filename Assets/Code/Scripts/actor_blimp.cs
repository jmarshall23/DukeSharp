public partial class ConScript
{
    static ConAction BLIMPWAITTORESPAWN = new ConAction();
    private void blimphitstate()
    {
        traps.cstat(0);
        traps.spawn(FIRSTGUNSPRITE);
        traps.spawn(EXPLOSION2);
        traps.debris(SCRAP1, 40);
        traps.debris(SCRAP2, 32);
        traps.debris(SCRAP3, 32);
        traps.debris(SCRAP4, 32);
        traps.debris(SCRAP5, 32);
        traps.sound(PIPEBOMB_EXPLODE);
        if (traps.ifrespawn())
        {
            traps.SetAction(BLIMPWAITTORESPAWN);
            traps.count(0);
            traps.cstat(32768);
        }
        else
            traps.killit();
    }
    private void A_BLIMP()
    {
        if (traps.ifaction(BLIMPWAITTORESPAWN))
        {
            if (traps.ifcount(BLIMPRESPAWNTIME))
            {
                traps.SetAction(null);
                traps.cstat(0);
            }
            return;
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifwasweapon(RADIUSEXPLOSION))
                blimphitstate();
            if (traps.ifwasweapon(RPG))
                blimphitstate();
            traps.strength(1);
        }
    }
}