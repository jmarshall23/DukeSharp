public partial class ConScript
{
    private void toughgalspeech()
    {
        if (traps.ifrnd(64))
        {
            if (traps.ifnosounds())
                traps.soundonce(TOUGHGALSND1);
        }
        else
        if (traps.ifrnd(64))
        {
            if (traps.ifnosounds())
                traps.soundonce(TOUGHGALSND2);
        }
        else
        if (traps.ifrnd(64))
        {
            if (traps.ifnosounds())
                traps.soundonce(TOUGHGALSND3);
        }
        else
        if (traps.ifnosounds())
            traps.soundonce(TOUGHGALSND4);
    }

    static ConAction FEMSHRUNK = new ConAction();
    static ConAction FEMFROZEN1 = new ConAction(1);
    static ConAction FEMGROW = new ConAction();
    static ConAction FEMFROZEN2 = new ConAction();
    static ConAction FEMDANCE1 = new ConAction(19, 1, 1, 1, 16);
    static ConAction FEMDANCE3 = new ConAction(19, 1, 1, 1, 26);
    static ConAction FEMDANCE2 = new ConAction(20, 2, 1, 1, 10);
    static ConAction FEMANIMATESLOW = new ConAction(0, 2, 1, 1, 100);
    static ConAction TOUGHGALANIM = new ConAction(0, 5, 1, 1, 25);
    static ConAction FEMANIMATE = new ConAction();
    private void femcode()
    {
        if (traps.ifactor(NAKED1))
        {
        }
        else
        if (traps.ifactor(FEM6))
        {
        }
        else
        {
            traps.fall();
            if (traps.ifactor(BLOODYPOLE))
                if (traps.ifhitweapon())
                    if (traps.ifdead())
                    {
                        standard_jibs();
                        traps.killit();
                    }
        }
        if (traps.ifaction(FEMSHRUNK))
        {
            if (traps.ifcount(SHRUNKDONECOUNT))
            {
                traps.SetAction(FEMANIMATE);
                traps.cstat(257);
            }
            else
            if (traps.ifcount(SHRUNKCOUNT))
                traps.sizeto(40, 40);
            else
                genericshrunkcode();
        }
        else
        if (traps.ifaction(FEMGROW))
        {
            if (traps.ifcount(32))
            {
                traps.respawnhitag();
                traps.guts(JIBS4, 20);
                traps.guts(JIBS6, 20);
                traps.spritepal(6);
                traps.soundonce(LADY_SCREAM);
                if (traps.ifactor(NAKED1))
                    traps.debris(SCRAP3, 4);
                else
                if (traps.ifactor(PODFEM1))
                    traps.debris(SCRAP3, 4);
                traps.sound(SQUISHED);
                traps.killit();
            }
            else
                traps.sizeto(MAXXSTRETCH, MAXYSTRETCH);
        }
        else
        if (traps.ifaction(FEMDANCE1))
        {
            if (traps.ifactioncount(2))
                traps.SetAction(FEMDANCE2);
        }
        else
        if (traps.ifaction(FEMDANCE2))
        {
            if (traps.ifactioncount(8))
                traps.SetAction(FEMDANCE3);
        }
        else
        if (traps.ifaction(FEMDANCE3))
        {
            if (traps.ifactioncount(2))
                traps.SetAction(FEMANIMATE);
        }
        else
        if (traps.ifaction(FEMFROZEN1))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.SetAction(FEMANIMATE);
                traps.getlastpal();
            }
            else
            if (traps.ifcount(FROZENDRIPTIME))
            {
                if (traps.ifactioncount(26))
                {
                    traps.spawn(WATERDRIP);
                    traps.resetactioncount();
                }
            }
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.strength(0);
                    return;
                }
                traps.lotsofglass(30);
                traps.sound(GLASS_BREAKING);
                traps.respawnhitag();
                if (traps.ifrnd(84))
                    traps.spawn(BLOODPOOL);
                traps.killit();
            }
            else
                if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        else
        if (traps.ifaction(FEMFROZEN2))
        {
            if (traps.ifcount(THAWTIME))
            {
                if (traps.ifactor(TOUGHGAL))
                    traps.SetAction(TOUGHGALANIM);
                else
                if (traps.ifactor(FEM10))
                    traps.SetAction(FEMANIMATESLOW);
                else
                    traps.SetAction(FEMANIMATE);
                traps.getlastpal();
            }
            else
            if (traps.ifcount(FROZENDRIPTIME))
            {
                if (traps.ifactioncount(26))
                {
                    traps.spawn(WATERDRIP);
                    traps.resetactioncount();
                }
            }
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.strength(0);
                    return;
                }
                traps.lotsofglass(30);
                traps.sound(GLASS_BREAKING);
                if (traps.ifrnd(84))
                    traps.spawn(BLOODPOOL);
                traps.respawnhitag();
                if (traps.ifrnd(128))
                    traps.sound(DUKE_HIT_STRIPPER1);
                else
                    traps.sound(DUKE_HIT_STRIPPER2);
                traps.killit();
            }
            else
                if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.cstat(0);
                    traps.Move(0);
                    traps.sound(ACTOR_GROWING);
                    traps.SetAction(FEMGROW);
                    return;
                }
                else
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    if (traps.ifaction(FEMSHRUNK))
                        return;
                    if (traps.ifactor(NAKED1))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(FEM5))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(FEM6))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(FEM8))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(FEM9))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(FEM10))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(TOUGHGAL))
                        traps.SetAction(FEMFROZEN2);
                    else
                    if (traps.ifactor(PODFEM1))
                        traps.SetAction(FEMFROZEN2);
                    else
                        traps.SetAction(FEMFROZEN1);
                    traps.Move(0);
                    traps.spritepal(1);
                    traps.strength(0);
                    traps.sound(SOMETHINGFROZE);
                    return;
                }
                if (traps.ifrnd(128))
                    traps.sound(DUKE_HIT_STRIPPER1);
                else
                    traps.sound(DUKE_HIT_STRIPPER2);
                traps.respawnhitag();
                standard_jibs();
                random_wall_jibs();
                traps.spawn(BLOODPOOL);
                if (traps.ifactor(FEM1))
                    traps.money(5);
                else
                if (traps.ifactor(FEM2))
                {
                    traps.money(7);
                    traps.cactor(BARBROKE);
                    traps.cstat(0);
                }
                else
                if (traps.ifactor(FEM3))
                    traps.money(4);
                else
                if (traps.ifactor(FEM7))
                    traps.money(8);
                if (traps.ifactor(FEM5))
                {
                    traps.strength(TOUGH);
                    traps.cactor(BLOODYPOLE);
                }
                else
                if (traps.ifactor(FEM6))
                {
                    traps.cstat(0);
                    traps.cactor(FEM6PAD);
                }
                else
                if (traps.ifactor(FEM8))
                {
                    traps.strength(TOUGH);
                    traps.cactor(BLOODYPOLE);
                }
                else
                {
                    traps.spritepal(6);
                    traps.soundonce(LADY_SCREAM);
                    if (traps.ifactor(NAKED1))
                        traps.debris(SCRAP3, 18);
                    else
                    if (traps.ifactor(PODFEM1))
                        traps.debris(SCRAP3, 18);
                    traps.killit();
                }
            }
            else
            {
                if (traps.ifwasweapon(SHRINKSPARK))
                {
                    traps.sound(ACTOR_SHRINKING);
                    traps.Move(0);
                    traps.SetAction(FEMSHRUNK);
                    traps.cstat(0);
                    return;
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                    traps.sound(EXPANDERHIT);
                if (traps.ifactor(FEM8))
                    return;
                if (traps.ifactor(TOUGHGAL))
                    toughgalspeech();
                else
                    traps.sound(SQUISHED);
                traps.guts(JIBS6, 1);
            }
        }
    }
    private void killme()
    {
        if (traps.ifinwater())
        {
        }
        else
        if (traps.ifp(pfacing))
            if (traps.ifpdistl(1280))
                if (traps.ifhitspace())
                    traps.soundonce(KILLME);
    }
    private void tipme()
    {
        if (traps.ifp(pfacing))
            if (traps.ifpdistl(1280))
                if (traps.ifhitspace())
                {
                    traps.tip();
                    if (traps.ifrnd(128))
                        traps.soundonce(DUKE_TIP1);
                    else
                        traps.soundonce(DUKE_TIP2);
                    if (traps.ifactor(FEM1))
                        traps.SetAction(FEMDANCE1);
                }
    }
    private void toughgaltalk()
    {
        if (traps.ifp(pfacing))
            if (traps.ifpdistl(1280))
                if (traps.ifhitspace())
                    toughgalspeech();
    }
    private void A_FEM1()
    {
        tipme();
        femcode();
    }
    private void A_FEM2()
    {
        tipme();
        femcode();
    }
    private void A_FEM3()
    {
        tipme();
        femcode();
    }
    private void A_FEM4()
    {
        femcode();
    }
    private void A_FEM5()
    {
        killme();
        femcode();
    }
    private void A_FEM6()
    {
        killme();
        femcode();
    }
    private void A_FEM7()
    {
        tipme();
        femcode();
    }
    private void A_FEM8()
    {
        femcode();
    }
    private void A_FEM9()
    {
        femcode();
    }
    private void A_FEM10()
    {
        tipme();
        femcode();
    }
    private void A_TOUGHGAL()
    {
        toughgaltalk();
        femcode();
    }
    private void A_NAKED1()
    {
        killme();
        femcode();
    }
    private void A_PODFEM1()
    {
        killme();
        femcode();
    }
    private void A_BLOODYPOLE()
    {
        femcode();
    }
    private void A_STATUEFLASH()
    {
        traps.fall();
        if (traps.ifcount(32))
            traps.cactor(STATUE);
    }
    private void A_STATUE()
    {
        traps.fall();
        if (traps.ifp(pfacing))
            if (traps.ifpdistl(1280))
                if (traps.ifhitspace())
                {
                    traps.cactor(STATUEFLASH);
                    traps.Move(0);
                }
    }
    private void A_MIKE()
    {
        if (traps.ifp(pfacing))
            if (traps.ifpdistl(1280))
                if (traps.ifhitspace())
                    traps.mikesnd();
    }
}