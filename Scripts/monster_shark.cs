public partial class ConScript
{

    static ConAction ASHARKCRUZING = new ConAction(0, 8, 5, 1, 24);
    static ConAction ASHARKFLEE = new ConAction(0, 8, 5, 1, 10);
    static ConAction ASHARKATACK = new ConAction(0, 8, 5, 1, 6);
    static ConAction ASHARKSHRUNK = new ConAction(0, 8, 5, 1, 24);
    static ConAction ASHARKGROW = new ConAction(0, 8, 5, 1, 24);
    static ConAction ASHARKFROZEN = new ConAction(0, 1, 5, 1, 24);
    static MoveAction SHARKVELS = new MoveAction(24);
    static MoveAction SHARKFASTVELS = new MoveAction(72);
    static MoveAction SHARKFLEEVELS = new MoveAction(40);
    private void A_SHARK()
    {
        if (traps.ifaction(ASHARKSHRUNK))
        {
            if (traps.ifcount(SHRUNKDONECOUNT))
                traps.SetAction(ASHARKCRUZING);
            else
            if (traps.ifcount(SHRUNKCOUNT))
                traps.sizeto(60, 60);
            else
                genericshrunkcode();
            return;
        }
        else
        if (traps.ifaction(ASHARKGROW))
        {
            if (traps.ifcount(SHRUNKDONECOUNT))
                traps.SetAction(ASHARKCRUZING);
            else
            if (traps.ifcount(SHRUNKCOUNT))
                traps.sizeto(24, 24);
            else
                genericgrowcode();
        }
        else
        if (traps.ifaction(ASHARKFROZEN))
        {
            traps.fall();
            if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            if (traps.ifcount(THAWTIME))
            {
                traps.SetAction(ASHARKFLEE);
                traps.getlastpal();
                return;
            }
            else
            if (traps.ifcount(FROZENDRIPTIME))
                if (traps.ifactioncount(26))
                    traps.resetactioncount();
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                    return;
                traps.lotsofglass(30);
                traps.sound(GLASS_BREAKING);
                traps.addkills(1);
                traps.killit();
            }
            return;
        }
        else
        if (traps.ifaction(ASHARKFLEE))
        {
            if (traps.ifcount(16))
                if (traps.ifrnd(48))
                {
                    traps.SetAction(ASHARKCRUZING);
                    traps.Move(SHARKVELS, randomangle, geth);
                }
        }
        else
        if (traps.ifaction(ASHARKCRUZING))
        {
            if (traps.ifcansee())
                if (traps.ifcount(48))
                    if (traps.ifrnd(2))
                        if (traps.ifcanshoottarget())
                        {
                            traps.SetAction(ASHARKATACK);
                            traps.Move(SHARKFASTVELS, faceplayerslow, getv);
                            return;
                        }
            if (traps.ifcount(32))
                if (traps.ifnotmoving())
                {
                    if (traps.ifrnd(128))
                        traps.Move(SHARKVELS, randomangle, geth);
                    else
                        traps.Move(SHARKFASTVELS, randomangle, geth);
                }
        }
        else
        if (traps.ifaction(ASHARKATACK))
        {
            if (traps.ifcount(4))
            {
                if (traps.ifpdistl(1280))
                {
                    if (traps.ifp(palive))
                    {
                        if (traps.ifcanshoottarget()) // jmarshall: hand change
                        {
                            traps.sound(DUKE_GRUNT);
                            traps.palfrom(32, 32);
                            traps.addphealth(SHARKBITESTRENGTH);
                        }
                    }
                    traps.SetAction(ASHARKFLEE);
                    traps.Move(SHARKFLEEVELS, fleeenemy);
                }
            }
            else
            if (traps.ifnotmoving())
            {
                if (traps.ifcount(32))
                {
                    traps.SetAction(ASHARKCRUZING);
                    traps.Move(SHARKVELS, randomangle, geth);
                }
            }
            else
            if (traps.ifcount(48))
                if (traps.ifrnd(2))
                {
                    traps.SetAction(ASHARKCRUZING);
                    traps.Move(SHARKFASTVELS, randomangle, geth);
                }
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.Move(0);
                    traps.cstat(0);
                    traps.SetAction(ASHARKGROW);
                    traps.sound(ACTOR_GROWING);
                    return;
                }
                else
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.spritepal(1);
                    traps.strength(0);
                    traps.SetAction(ASHARKFROZEN);
                    traps.sound(SOMETHINGFROZE);
                }
                else
                {
                    traps.sound(SQUISHED);
                    traps.guts(JIBS6, 5);
                    traps.addkills(1);
                    traps.killit();
                }
            }
            else
            {
                if (traps.ifwasweapon(SHRINKSPARK))
                {
                    traps.SetAction(ASHARKSHRUNK);
                    traps.sound(ACTOR_SHRINKING);
                    traps.Move(0);
                    return;
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                    traps.sound(EXPANDERHIT);
                traps.Move(SHARKVELS, randomangle, geth);
            }
        }
    }
}