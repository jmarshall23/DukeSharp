public partial class ConScript
{
    private void breakobject()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ANULLACTION);
            traps.cstator(257);
            if (traps.ifactor(ROBOTMOUSE))
                traps.clipdist(64);
        }
        else
        if (traps.ifactor(ROBOTMOUSE))
        {
            if (traps.ifdead())
            {
                if (traps.ifcount(32))
                {
                    traps.globalsound(MOUSEANNOY);
                    traps.killit();
                }
                return;
            }
            if (traps.ifcount(64))
                if (traps.ifrnd(6))
                {
                    if (traps.ifrnd(128))
                        traps.Move(MOUSEVELS, randomangle, geth);
                    else
                    {
                        if (traps.ifrnd(64))
                            traps.soundonce(HAPPYMOUSESND1);
                        else
                        if (traps.ifrnd(64))
                            traps.soundonce(HAPPYMOUSESND2);
                        else
                        if (traps.ifrnd(64))
                            traps.soundonce(HAPPYMOUSESND3);
                        else
                            traps.soundonce(HAPPYMOUSESND4);
                    }
                    traps.resetcount();
                }
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                if (traps.ifactor(FOODOBJECT6))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT11))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT12))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT13))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT14))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT15))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT16))
                    jibfood();
                else
                if (traps.ifactor(FOODOBJECT17))
                    jibfood();
                else
                if (traps.ifactor(SKINNEDCHICKEN))
                    jibfood();
                else
                if (traps.ifactor(SHOPPINGCART))
                {
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP2, 5);
                    traps.debris(SCRAP3, 5);
                    traps.sound(GLASS_HEAVYBREAK);
                    traps.killit();
                }
                else
                if (traps.ifactor(ROBOTDOG2))
                {
                    traps.soundonce(DEAD_DOG);
                    traps.guts(JIBS2, 1);
                    traps.guts(JIBS3, 2);
                    traps.guts(JIBS6, 3);
                    traps.killit();
                }
                else
                if (traps.ifactor(FEATHEREDCHICKEN))
                    jibfood();
                else
                if (traps.ifactor(DOLPHIN1))
                {
                    traps.guts(JIBS2, 1);
                    traps.guts(JIBS3, 2);
                    traps.guts(JIBS4, 3);
                    traps.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (traps.ifactor(DOLPHIN2))
                {
                    traps.guts(JIBS2, 1);
                    traps.guts(JIBS3, 2);
                    traps.guts(JIBS4, 3);
                    traps.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (traps.ifactor(SNAKEP))
                {
                    traps.guts(JIBS2, 1);
                    traps.guts(JIBS3, 2);
                    traps.guts(JIBS4, 3);
                    traps.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (traps.ifactor(DONUTS))
                {
                    traps.spritepal(7);
                    traps.guts(JIBS6, 2);
                    traps.killit();
                }
                else
                if (traps.ifactor(DONUTS2))
                {
                    traps.debris(SCRAP1, 1);
                    traps.spritepal(7);
                    traps.guts(JIBS6, 2);
                    traps.killit();
                }
                else
                if (traps.ifactor(MAILBAG))
                {
                    traps.mail(30);
                    traps.debris(SCRAP3, 5);
                    traps.debris(SCRAP4, 3);
                    traps.killit();
                }
                else
                if (traps.ifactor(TEDDYBEAR))
                {
                    traps.debris(SCRAP3, 5);
                    traps.spritepal(1);
                    traps.debris(SCRAP3, 6);
                }
                else
                {
                    if (traps.ifrnd(128))
                        traps.sound(GLASS_BREAKING);
                    else
                        traps.sound(GLASS_HEAVYBREAK);
                }
                if (traps.ifactor(CLOCK))
                {
                    traps.cactor(BROKENCLOCK);
                    return;
                }
                else
                if (traps.ifactor(JOLLYMEAL))
                {
                    traps.spawn(ATOMICHEALTH);
                    traps.debris(SCRAP3, 1);
                    traps.debris(SCRAP4, 2);
                }
                else
                if (traps.ifactor(GUMBALLMACHINE))
                {
                    traps.cactor(GUMBALLMACHINEBROKE);
                    traps.strength(1);
                    traps.debris(SCRAP4, 2);
                    traps.lotsofglass(10);
                    return;
                }
                else
                if (traps.ifactor(GUMBALLMACHINEBROKE))
                {
                    traps.debris(SCRAP3, 3);
                    traps.debris(SCRAP4, 2);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(DUKEBURGER))
                {
                    traps.debris(SCRAP3, 14);
                    traps.debris(SCRAP1, 13);
                    traps.debris(SCRAP4, 12);
                    traps.debris(SCRAP2, 12);
                    traps.debris(SCRAP5, 11);
                }
                else
                if (traps.ifactor(POLICELIGHTPOLE))
                {
                    traps.debris(SCRAP3, 4);
                    traps.debris(SCRAP1, 3);
                    traps.debris(SCRAP4, 2);
                    traps.debris(SCRAP2, 2);
                    traps.debris(SCRAP5, 1);
                }
                else
                if (traps.ifactor(TOPSECRET))
                    traps.paper(10);
                else
                if (traps.ifactor(GUNPOWDERBARREL))
                {
                    traps.spawn(EXPLOSION2);
                    traps.sound(PIPEBOMB_EXPLODE);
                    traps.hitradius(2048, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                    if (traps.ifpdistl(2048))
                        traps.wackplayer();
                    traps.debris(SCRAP1, 10);
                    traps.debris(SCRAP2, 13);
                    traps.debris(SCRAP3, 4);
                    traps.debris(SCRAP4, 17);
                    traps.debris(SCRAP5, 6);
                }
                else
                if (traps.ifactor(FLOORBASKET))
                {
                    traps.spawn(PUKE);
                    traps.debris(SCRAP1, 2);
                    traps.debris(SCRAP3, 3);
                    traps.debris(SCRAP4, 2);
                }
                else
                if (traps.ifactor(ROBOTMOUSE))
                {
                    traps.debris(SCRAP2, 10);
                    traps.spritepal(1);
                    traps.debris(SCRAP3, 4);
                    traps.resetcount();
                    traps.cstat(32768);
                    return;
                }
                else
                if (traps.ifactor(ROBOTPIRATE))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE1A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(MAN))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(MAN2))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE2A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE3A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE4A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE4A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE5A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                if (traps.ifactor(PIRATE6A))
                {
                    traps.debris(SCRAP2, 10);
                    traps.debris(SCRAP1, 5);
                    traps.debris(SCRAP3, 3);
                    traps.lotsofglass(10);
                }
                else
                {
                    traps.lotsofglass(10);
                    traps.debris(SCRAP4, 3);
                }
                traps.killit();
            }
            else
            if (traps.ifactor(DOLPHIN1))
            {
                traps.guts(JIBS6, 1);
                traps.soundonce(DOLPHINSND);
                if (traps.ifstrength(TOUGH))
                {
                    traps.cactor(DOLPHIN2);
                    traps.sound(SQUISHED);
                }
            }
            else
            if (traps.ifactor(DOLPHIN2))
            {
                traps.guts(JIBS6, 1);
                traps.soundonce(DOLPHINSND);
            }
            else
            if (traps.ifactor(ROBOTDOG2))
            {
                traps.guts(JIBS6, 1);
                traps.soundonce(WHINING_DOG);
            }
        }
        else
        {
            if (traps.ifactor(CLOCK))
            {
            }
            else
            if (traps.ifactor(TOPSECRET))
            {
            }
            else
            if (traps.ifactor(SKINNEDCHICKEN))
            {
            }
            else
            if (traps.ifactor(FEATHEREDCHICKEN))
            {
            }
            else
            if (traps.ifactor(FOODOBJECT2))
            {
            }
            else
            if (traps.ifactor(FOODOBJECT6))
            {
            }
            else
            if (traps.ifactor(DOLPHIN1))
            {
            }
            else
            if (traps.ifactor(DOLPHIN2))
            {
            }
            else
                traps.fall();
        }
    }
    static ConAction ABURGERROTS = new ConAction(0, 1, 5);
    private void A_DUKEBURGER()
    {
        breakobject();
    }
    private void A_MOP()
    {
        breakobject();
    }
    private void A_BROOM()
    {
        breakobject();
    }
    private void A_WETFLOOR()
    {
        breakobject();
    }
    private void A_DESKLAMP()
    {
        breakobject();
    }
    private void A_HATRACK()
    {
        breakobject();
    }
    private void A_GUNPOWDERBARREL()
    {
        breakobject();
    }
    private void A_COFFEEMACHINE()
    {
        breakobject();
    }
    private void A_TEDDYBEAR()
    {
        breakobject();
    }
    private void A_TOPSECRET()
    {
        breakobject();
    }
    private void A_ROBOTMOUSE()
    {
        breakobject();
    }
    private void A_MAN()
    {
        breakobject();
    }
    private void A_MAN2()
    {
        breakobject();
    }
    private void A_WOMAN()
    {
        breakobject();
    }
    private void A_PIRATE1A()
    {
        breakobject();
    }
    private void A_PIRATE2A()
    {
        breakobject();
    }
    private void A_PIRATE3A()
    {
        breakobject();
    }
    private void A_PIRATE4A()
    {
        breakobject();
    }
    private void A_PIRATE5A()
    {
        breakobject();
    }
    private void A_PIRATE6A()
    {
        breakobject();
    }
    private void A_ROBOTPIRATE()
    {
        breakobject();
    }
    private void A_PIRATEHALF()
    {
        breakobject();
    }
    private void A_CHESTOFGOLD()
    {
        breakobject();
    }
    private void A_ROBOTDOG()
    {
        breakobject();
    }
    private void A_ROBOTDOG2()
    {
        breakobject();
    }
    private void A_PLEASEWAIT()
    {
        breakobject();
    }
    private void A_FOODOBJECT1()
    {
        breakobject();
    }
    private void A_FOODOBJECT2()
    {
        breakobject();
    }
    private void A_FOODOBJECT3()
    {
        breakobject();
    }
    private void A_FOODOBJECT4()
    {
        breakobject();
    }
    private void A_FOODOBJECT5()
    {
        breakobject();
    }
    private void A_FOODOBJECT6()
    {
        breakobject();
    }
    private void A_FOODOBJECT7()
    {
        breakobject();
    }
    private void A_FOODOBJECT8()
    {
        breakobject();
    }
    private void A_FOODOBJECT9()
    {
        breakobject();
    }
    private void A_FOODOBJECT10()
    {
        breakobject();
    }
    private void A_FOODOBJECT11()
    {
        breakobject();
    }
    private void A_FOODOBJECT12()
    {
        breakobject();
    }
    private void A_FOODOBJECT13()
    {
        breakobject();
    }
    private void A_FOODOBJECT14()
    {
        breakobject();
    }
    private void A_FOODOBJECT15()
    {
        breakobject();
    }
    private void A_FOODOBJECT16()
    {
        breakobject();
    }
    private void A_FOODOBJECT17()
    {
        breakobject();
    }
    private void A_FOODOBJECT18()
    {
        breakobject();
    }
    private void A_FOODOBJECT19()
    {
        breakobject();
    }
    private void A_FOODOBJECT20()
    {
        breakobject();
    }
    private void A_JOLLYMEAL()
    {
        breakobject();
    }
    private void A_GUMBALLMACHINE()
    {
        breakobject();
    }
    private void A_GUMBALLMACHINEBROKE()
    {
        breakobject();
    }
    private void A_POLICELIGHTPOLE()
    {
        breakobject();
    }
    private void A_CLOCK()
    {
        breakobject();
    }
    private void A_MAILBAG()
    {
        breakobject();
    }
    private void A_FEATHEREDCHICKEN()
    {
        breakobject();
    }
    private void A_SKINNEDCHICKEN()
    {
        breakobject();
    }
    private void A_HEADLAMP()
    {
        breakobject();
    }
    private void A_DOLPHIN1()
    {
        breakobject();
    }
    private void A_DOLPHIN2()
    {
        breakobject();
    }
    private void A_SNAKEP()
    {
        breakobject();
    }
    private void A_DONUTS()
    {
        breakobject();
    }
    private void A_GAVALS()
    {
        breakobject();
    }
    private void A_GAVALS2()
    {
        breakobject();
    }
    private void A_CUPS()
    {
        breakobject();
    }
    private void A_DONUTS2()
    {
        breakobject();
    }
    private void A_FLOORBASKET()
    {
        breakobject();
    }
    private void A_METER()
    {
        breakobject();
    }
    private void A_DESKPHONE()
    {
        breakobject();
    }
    private void A_MACE()
    {
        breakobject();
    }
    private void A_SHOPPINGCART()
    {
        breakobject();
    }
    private void A_COFFEEMUG()
    {
        breakobject();
    }
}