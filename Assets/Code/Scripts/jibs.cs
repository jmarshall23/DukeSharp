public partial class ConScript
{
    private void standard_pjibs()
    {
        traps.guts(JIBS1, 1);
        traps.guts(JIBS3, 2);
        traps.guts(JIBS4, 1);
        traps.guts(JIBS5, 1);
        traps.guts(JIBS6, 2);
        traps.guts(DUKETORSO, 1);
        traps.guts(DUKELEG, 2);
        traps.guts(DUKEGUN, 1);
        if (traps.ifrnd(16))
            traps.money(1);
    }

    private void random_wall_jibs()
    {
        if (traps.ifrnd(96))
            traps.shoot(BLOODSPLAT1);
        if (traps.ifrnd(96))
            traps.shoot(BLOODSPLAT2);
        if (traps.ifrnd(96))
            traps.shoot(BLOODSPLAT3);
        if (traps.ifrnd(96))
            traps.shoot(BLOODSPLAT4);
        if (traps.ifrnd(96))
            traps.shoot(BLOODSPLAT1);
    }

    private void troop_body_jibs()
    {
        if (traps.ifrnd(64))
            traps.guts(HEADJIB1, 1);
        if (traps.ifrnd(64))
            traps.guts(LEGJIB1, 2);
        if (traps.ifrnd(64))
            traps.guts(ARMJIB1, 1);
        if (traps.ifrnd(48))
            traps.spawn(BLOODPOOL);
    }
    private void liz_body_jibs()
    {
        if (traps.ifrnd(64))
            traps.guts(LIZMANHEAD1, 1);
        if (traps.ifrnd(64))
            traps.guts(LIZMANLEG1, 2);
        if (traps.ifrnd(64))
            traps.guts(LIZMANARM1, 1);
        if (traps.ifrnd(48))
            traps.spawn(BLOODPOOL);
    }
    static ConAction BLOODFRAMES = new ConAction(0, 4, 1, 1, 15);
    private void A_BLOOD()
    {
        traps.sizeto(72, 72);
        traps.sizeto(72, 72);
        traps.sizeto(72, 72);
        if (traps.ifpdistg(3144))
            traps.killit();
        if (traps.ifactioncount(4))
            traps.killit();
    }
    private void jibfood()
    {
        traps.sound(SQUISHED);
        traps.guts(JIBS6, 3);
        traps.killit();
    }

    private void jib_sounds()
    {
        if (traps.ifrnd(SWEARFREQUENCY))
        {
            if (traps.ifrnd(128))
            {
                if (traps.ifrnd(128))
                {
                    if (traps.ifrnd(128))
                    {
                        if (traps.ifrnd(128))
                        {
                            if (traps.ifrnd(128))
                                traps.globalsound(JIBBED_ACTOR12);
                            else
                                traps.globalsound(JIBBED_ACTOR1);
                        }
                        else
                        {
                            if (traps.ifrnd(128))
                                traps.globalsound(JIBBED_ACTOR9);
                            else
                                traps.globalsound(JIBBED_ACTOR14);
                        }
                    }
                    else
                    {
                        if (traps.ifrnd(128))
                            traps.globalsound(SMACKED);
                        else
                            traps.globalsound(JIBBED_ACTOR2);
                    }
                }
                else
                {
                    if (traps.ifrnd(128))
                        traps.globalsound(MDEVSPEECH);
                    else
                        traps.globalsound(JIBBED_ACTOR5);
                }
            }
            else
            {
                if (traps.ifrnd(128))
                {
                    if (traps.ifrnd(128))
                    {
                        if (traps.ifrnd(128))
                            traps.globalsound(JIBBED_ACTOR11);
                        else
                            traps.globalsound(JIBBED_ACTOR13);
                    }
                    else
                    {
                        if (traps.ifrnd(128))
                            traps.globalsound(JIBBED_ACTOR3);
                        else
                            traps.globalsound(JIBBED_ACTOR8);
                    }
                }
                else
                {
                    if (traps.ifrnd(128))
                    {
                        if (traps.ifrnd(128))
                            traps.globalsound(JIBBED_ACTOR6);
                        else
                            traps.globalsound(JIBBED_ACTOR4);
                    }
                    else
                    {
                        if (traps.ifrnd(128))
                        {
                            if (traps.ifrnd(128))
                                traps.globalsound(JIBBED_ACTOR10);
                            else
                                traps.globalsound(JIBBED_ACTOR15);
                        }
                        else
                            traps.globalsound(JIBBED_ACTOR7);
                    }
                }
            }
        }
    }
    private void standard_jibs()
    {
        traps.guts(JIBS2, 1);
        traps.guts(JIBS3, 2);
        traps.guts(JIBS4, 3);
        traps.guts(JIBS5, 2);
        traps.guts(JIBS6, 3);
        if (traps.ifrnd(6))
        {
            traps.guts(JIBS1, 1);
            traps.spawn(BLOODPOOL);
        }
        jib_sounds();
    }
}