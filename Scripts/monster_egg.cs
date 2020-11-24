public partial class ConScript
{

    static ConAction EGGOPEN1 = new ConAction(1, 1, 1, 1, 4);
    static ConAction EGGOPEN2 = new ConAction(2, 1, 1, 1, 4);
    static ConAction EGGOPEN3 = new ConAction(2, 1, 1, 1, 4);
    static ConAction EGGWAIT = new ConAction(0);
    static ConAction EGGFROZEN = new ConAction(1);
    static ConAction EGGGROW = new ConAction(1);
    static ConAction EGGSHRUNK = new ConAction(1);
    private void A_EGG()
    {
        traps.fall();
        if (traps.ifaction(null))
        {
            if (traps.ifcount(64))
            {
                if (traps.ifrnd(128))
                {
                    traps.SetAction(EGGWAIT);
                    traps.Move(0);
                }
                else
                {
                    traps.sound(SLIM_HATCH);
                    traps.SetAction(EGGOPEN1);
                }
            }
        }
        else
        if (traps.ifaction(EGGOPEN1))
            if (traps.ifactioncount(4))
                traps.SetAction(EGGOPEN2);
            else
            if (traps.ifaction(EGGOPEN2))
                if (traps.ifactioncount(4))
                {
                    traps.spawn(GREENSLIME);
                    traps.SetAction(EGGOPEN3);
                }
                else
                if (traps.ifaction(EGGGROW))
                    genericgrowcode();
                else
                if (traps.ifaction(EGGSHRUNK))
                    genericshrunkcode();
                else
                if (traps.ifaction(EGGFROZEN))
                {
                    if (traps.ifcount(THAWTIME))
                    {
                        traps.SetAction(null);
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
                        traps.addkills(1);
                        traps.killit();
                    }
                    if (traps.ifp(pfacing))
                        if (traps.ifpdistl(FROZENQUICKKICKDIST))
                            traps.pkick();
                    return;
                }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.sound(SOMETHINGFROZE);
                    traps.spritepal(1);
                    traps.Move(0);
                    traps.SetAction(EGGFROZEN);
                    traps.strength(0);
                    return;
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.cstat(0);
                    traps.Move(0);
                    traps.sound(ACTOR_GROWING);
                    traps.SetAction(EGGGROW);
                    return;
                }
                traps.addkills(1);
                traps.sound(SQUISHED);
                standard_jibs();
                traps.killit();
            }
            else
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.Move(0);
                traps.sound(ACTOR_SHRINKING);
                traps.SetAction(EGGSHRUNK);
                return;
            }
            if (traps.ifwasweapon(GROWSPARK))
                traps.sound(EXPANDERHIT);
        }
        else
            if (traps.ifaction(EGGWAIT))
        {
            if (traps.ifcount(512))
                if (traps.ifrnd(2))
                {
                    if (traps.ifaction(EGGSHRUNK))
                        return;
                    traps.sound(SLIM_HATCH);
                    traps.SetAction(EGGOPEN1);
                }
        }
    }
}