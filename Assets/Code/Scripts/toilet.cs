public partial class ConScript
{
    static ConAction TOILETWATERFRAMES = new ConAction(0, 4, 1, 1, 1);
    private void A_TOILETWATER()
    {
        if (traps.ifpdistl(8192))
        {
            traps.soundonce(WATER_GURGLE);
            if (traps.ifspawnedby(TOILET))
                traps.sizeto(34, 34);
            else
            {
                if (traps.ifspawnedby(WATERFOUNTAINBROKE))
                    traps.sizeto(6, 15);
                else
                if (traps.ifspawnedby(TOILETWATER))
                {
                }
                else
                    traps.sizeto(24, 32);
            }
            if (traps.ifp(palive))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifp(pfacing))
                        if (traps.ifactioncount(32))
                            if (traps.ifphealthl(MAXPLAYERHEALTH))
                                if (traps.ifhitspace())
                                    if (traps.ifcansee())
                                    {
                                        traps.addphealth(1);
                                        traps.globalsound(DUKE_DRINKING);
                                        traps.resetactioncount();
                                    }
        }
    }
}