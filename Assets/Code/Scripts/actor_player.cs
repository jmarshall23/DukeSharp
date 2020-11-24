public partial class ConScript
{
    static MoveAction DUKENOTMOVING = new MoveAction();
    private void handle_dead_dukes()
    {
        traps.fall();
        if (traps.ifmove(null))
        {
            if (traps.ifrnd(128))
                traps.cstat(4);
            else
                traps.cstat(0);
            traps.Move(DUKENOTMOVING);
        }
        if (traps.ifsquished())
        {
            traps.sound(SQUISHED);
            random_ooz();
            traps.killit();
        }
        else
        if (traps.ifcount(1024))
            if (traps.ifpdistg(4096))
                traps.killit();
            else
            {
                traps.strength(0);
                if (traps.ifhitweapon())
                    if (traps.ifwasweapon(RADIUSEXPLOSION))
                    {
                        standard_jibs();
                        traps.killit();
                    }
            }
    }
    static ConAction PLYINGFRAMES = new ConAction(0, 1, 0, 1, 1);
    private void A_DUKELYINGDEAD()
    {
        handle_dead_dukes();
    }
    static ConAction PGROWING = new ConAction(0);
    static ConAction PSTAND = new ConAction(0, 1, 5, 1, 1);
    static ConAction PEXPLODE = new ConAction(106, 5, 1, 1, 10);
    static ConAction PEXPLODEAD = new ConAction(113, 1, 1);
    static ConAction PJPHOUVER = new ConAction(15, 1, 5, 1);
    static ConAction PWALK = new ConAction(20, 4, 5, 1, 16);
    static ConAction PRUN = new ConAction(20, 4, 5, 1, 10);
    static ConAction PWALKBACK = new ConAction(45, 4, 5, -1, 16);
    static ConAction PRUNBACK = new ConAction(45, 4, 5, -1, 10);
    static ConAction PJUMPING = new ConAction(50, 4, 5, 1, 30);
    static ConAction PFALLING = new ConAction(65, 1, 5);
    static ConAction PDUCKING = new ConAction(86, 1, 5);
    static ConAction PCRAWLING = new ConAction(86, 3, 5, 1, 20);
    static ConAction PAKICKING = new ConAction(40, 2, 5, 1, 25);
    static ConAction PFLINTCHING = new ConAction(106, 1, 1, 1, 10);
    static ConAction PTHROWNBACK = new ConAction(106, 5, 1, 1, 18);
    static ConAction PFROZEN = new ConAction(20, 1, 5);
    static ConAction PLYINGDEAD = new ConAction(113, 1, 1);
    static ConAction PSWIMMINGGO = new ConAction(375, 1, 5, 1, 10);
    static ConAction PSWIMMING = new ConAction(375, 4, 5, 1, 13);
    static ConAction PSWIMMINGWAIT = new ConAction(395, 1, 5, 1, 13);
    static ConAction PTREDWATER = new ConAction(395, 2, 5, 1, 17);
    static MoveAction PSTOPED = new MoveAction();
    static MoveAction PSHRINKING = new MoveAction();
    private void check_pstandard()
    {
        if (traps.ifp(pwalking))
            traps.SetAction(PWALK);
        else
        if (traps.ifp(pkicking))
            traps.SetAction(PAKICKING);
        else
        if (traps.ifp(pwalkingback))
            traps.SetAction(PWALKBACK);
        else
        if (traps.ifp(prunning))
            traps.SetAction(PRUN);
        else
        if (traps.ifp(prunningback))
            traps.SetAction(PRUNBACK);
        else
        if (traps.ifp(pjumping))
            traps.SetAction(PJUMPING);
        else
        if (traps.ifp(pducking))
            traps.SetAction(PDUCKING);
    }
    static MoveAction PGROWINGPOP = new MoveAction();
    private void A_APLAYER()
    {
        if (traps.ifaction(null))
            traps.SetAction(PSTAND);
        if (traps.ifaction(PFROZEN))
        {
            traps.cstat(257);
            traps.fall();
            traps.palfrom(16, 0, 0, 24);
            if (traps.ifmove(null))
            {
                if (traps.ifhitweapon())
                {
                    if (traps.ifwasweapon(FREEZEBLAST))
                        return;
                    traps.lotsofglass(60);
                    if (traps.ifrnd(84))
                        traps.spawn(BLOODPOOL);
                    traps.sound(GLASS_BREAKING);
                    traps.spawn(ATOMICHEALTH);
                    traps.getlastpal();
                    traps.Move(1);
                    return;
                }
            }
            else
            {
                traps.cstat(32768);
                traps.quote(13);
                if (traps.ifhitspace())
                {
                    traps.SetAction(PSTAND);
                    traps.resetplayer();
                }
                return;
            }
            if (traps.ifactioncount(THAWTIME))
            {
                traps.getlastpal();
                traps.strength(1);
                traps.Move(0);
                traps.SetAction(PSTAND);
            }
            else
            if (traps.ifactioncount(FROZENDRIPTIME))
            {
                if (traps.ifrnd(32))
                    traps.spawn(WATERDRIP);
            }
            if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        if (traps.ifdead())
        {
            if (traps.ifaction(PGROWING))
            {
                if (traps.ifmove(PGROWINGPOP))
                {
                    traps.quote(13);
                    if (traps.ifhitspace())
                    {
                        traps.SetAction(null);
                        traps.resetplayer();
                    }
                    return;
                }
                else
                {
                    if (traps.ifcount(32))
                    {
                        traps.sound(SQUISHED);
                        traps.palfrom(48, 64);
                        standard_pjibs();
                        traps.guts(JIBS4, 20);
                        traps.guts(JIBS6, 20);
                        traps.Move(PGROWINGPOP);
                        traps.cstat(32768);
                        traps.tossweapon();
                        traps.hitradius(2048, 60, 70, 80, 90);
                    }
                    else
                        traps.sizeto(MAXXSTRETCH, MAXYSTRETCH);
                }
                return;
            }
            if (traps.ifsquished())
                traps.palfrom(32, 63, 63, 63);
            else
                traps.fall();
            if (traps.ifactioncount(7))
                traps.Move(0);
            else
            if (traps.ifactioncount(6))
            {
                if (traps.ifmultiplayer())
                {
                }
                else
                {
                    if (traps.ifrnd(32))
                        traps.sound(DUKE_KILLED5);
                    else
                    if (traps.ifrnd(32))
                        traps.sound(DUKE_KILLED3);
                    else
                    if (traps.ifrnd(32))
                        traps.sound(DUKE_KILLED1);
                    else
                    if (traps.ifrnd(32))
                        traps.sound(DUKE_KILLED2);
                }
            }
            if (traps.ifaction(PLYINGDEAD))
            {
                if (traps.ifactioncount(3))
                    traps.Move(PSTOPED);
                traps.quote(13);
                if (traps.ifhitspace())
                {
                    traps.SetAction(PSTAND);
                    traps.spawn(DUKELYINGDEAD);
                    traps.resetplayer();
                }
                return;
            }
            if (traps.ifaction(PTHROWNBACK))
            {
                if (traps.ifactioncount(5))
                {
                    traps.spawn(BLOODPOOL);
                    traps.SetAction(PLYINGDEAD);
                }
                else
                if (traps.ifactioncount(1))
                    traps.Move(0);
                return;
            }
            if (traps.ifaction(PEXPLODEAD))
            {
                traps.quote(13);
                if (traps.ifhitspace())
                {
                    traps.resetplayer();
                    traps.SetAction(PSTAND);
                }
                return;
            }
            if (traps.ifaction(PEXPLODE))
            {
                if (traps.ifactioncount(5))
                {
                    traps.SetAction(PEXPLODEAD);
                    traps.spawn(BLOODPOOL);
                }
                return;
            }
            if (traps.ifp(pshrunk))
            {
                standard_pjibs();
                traps.spawn(BLOODPOOL);
                traps.sound(SQUISHED);
                traps.sound(DUKE_DEAD);
                traps.cstat(32768);
                traps.SetAction(PLYINGDEAD);
            }
            else
            {
                if (traps.ifinwater())
                {
                    traps.SetAction(PLYINGDEAD);
                    traps.spawn(WATERBUBBLE);
                    traps.spawn(WATERBUBBLE);
                }
                else
                {
                    traps.SetAction(PEXPLODE);
                    standard_pjibs();
                    traps.cstat(32768);
                    traps.sound(SQUISHED);
                    traps.sound(DUKE_DEAD);
                }
            }
            traps.tossweapon();
            return;
        }
        if (traps.ifsquished())
        {
            traps.strength(-1);
            traps.sound(SQUISHED);
            random_ooz();
            return;
        }
        if (traps.ifp(ponsteroids))
        {
            if (traps.ifp(pstanding))
            {
            }
            else
                traps.spawn(FRAMEEFFECT1);
        }
        if (traps.ifmove(PSHRINKING))
        {
            if (traps.ifcount(32))
            {
                if (traps.ifcount(SHRUNKDONECOUNT))
                {
                    traps.Move(0);
                    traps.cstat(257);
                }
                else
                if (traps.ifcount(SHRUNKCOUNT))
                {
                    traps.sizeto(42, 36);
                    if (traps.ifgapzl(24))
                    {
                        traps.strength(0);
                        traps.sound(SQUISHED);
                        traps.palfrom(48, 64);
                        return;
                    }
                }
                else
                if (traps.ifp(ponsteroids))
                    traps.count(SHRUNKCOUNT);
            }
            else
            {
                if (traps.ifp(ponsteroids))
                    traps.count(SHRUNKCOUNT);
                else
                {
                    traps.sizeto(8, 9);
                    traps.spawn(FRAMEEFFECT1);
                }
            }
        }
        else
    if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                if (traps.ifmultiplayer())
                    traps.sound(DUKE_KILLED4);
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.palfrom(48, 48);
                    traps.SetAction(PGROWING);
                    traps.count(0);
                    traps.Move(0);
                    traps.sound(ACTOR_GROWING);
                    traps.cstat(0);
                    return;
                }
            }
            else
            {
                if (traps.ifmultiplayer())
                {
                    if (traps.ifphealthl(YELLHURTSOUNDSTRENGTHMP))
                    {
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN2);
                        else
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN3);
                        else
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN4);
                        else
                            traps.sound(DUKE_DEAD);
                    }
                    else
                    {
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN5);
                        else
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN6);
                        else
                        if (traps.ifrnd(64))
                            traps.sound(DUKE_LONGTERM_PAIN7);
                        else
                            traps.sound(DUKE_LONGTERM_PAIN8);
                    }
                }
                else
                {
                    if (traps.ifphealthl(YELLHURTSOUNDSTRENGTH))
                    {
                        if (traps.ifrnd(74))
                            traps.sound(DUKE_LONGTERM_PAIN2);
                        else
                        if (traps.ifrnd(8))
                            traps.sound(DUKE_LONGTERM_PAIN3);
                        else
                            traps.sound(DUKE_LONGTERM_PAIN4);
                    }
                    if (traps.ifrnd(128))
                        traps.sound(DUKE_LONGTERM_PAIN);
                }
            }
            if (traps.ifstrength(TOUGH))
            {
                headhitstate();
                traps.sound(DUKE_GRUNT);
                if (traps.ifp(pstanding))
                    traps.SetAction(PFLINTCHING);
            }
            if (traps.ifwasweapon(RPG))
            {
                if (traps.ifrnd(32))
                    traps.spawn(BLOOD);
                if (traps.ifdead())
                    standard_pjibs();
                traps.palfrom(48, 52);
                return;
            }
            if (traps.ifwasweapon(RADIUSEXPLOSION))
            {
                if (traps.ifrnd(32))
                    traps.spawn(BLOOD);
                if (traps.ifdead())
                    standard_pjibs();
                traps.palfrom(48, 52);
                return;
            }
            if (traps.ifwasweapon(FIREEXT))
            {
                if (traps.ifrnd(32))
                    traps.spawn(BLOOD);
                if (traps.ifdead())
                    standard_pjibs();
                traps.palfrom(48, 52);
                return;
            }
            if (traps.ifwasweapon(GROWSPARK))
            {
                traps.palfrom(48, 52);
                traps.sound(EXPANDERHIT);
                return;
            }
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.palfrom(48, 0, 48);
                traps.Move(PSHRINKING);
                traps.sound(ACTOR_SHRINKING);
                traps.cstat(0);
                return;
            }
            if (traps.ifwasweapon(SHOTSPARK1))
                traps.palfrom(24, 48);
            if (traps.ifwasweapon(FREEZEBLAST))
            {
                traps.palfrom(48, 0, 0, 48);
                if (traps.ifdead())
                {
                    traps.sound(SOMETHINGFROZE);
                    traps.spritepal(1);
                    traps.Move(0);
                    traps.SetAction(PFROZEN);
                    return;
                }
            }
            if (traps.ifwasweapon(COOLEXPLOSION1))
                traps.palfrom(48, 48, 0, 48);
            if (traps.ifwasweapon(KNEE))
                traps.palfrom(16, 32);
            if (traps.ifwasweapon(FIRELASER))
                traps.palfrom(32, 32);
            if (traps.ifdead())
            {
                traps.SetAction(PTHROWNBACK);
                traps.tossweapon();
            }
            random_wall_jibs();
            return;
        }
        if (traps.ifaction(PFLINTCHING))
        {
            if (traps.ifactioncount(2))
                traps.SetAction(PSTAND);
            return;
        }
        if (traps.ifinwater())
        {
            if (traps.ifaction(PTREDWATER))
            {
                if (traps.ifp(pwalking, prunning))
                    traps.SetAction(PSWIMMINGGO);
            }
            else
            if (traps.ifp(pstanding, pwalkingback, prunningback))
                traps.SetAction(PTREDWATER);
            else
            {
                if (traps.ifaction(PSWIMMING))
                {
                    if (traps.ifrnd(4))
                        traps.spawn(WATERBUBBLE);
                    if (traps.ifactioncount(4))
                        traps.SetAction(PSWIMMINGWAIT);
                }
                else
                if (traps.ifaction(PSWIMMINGWAIT))
                {
                    if (traps.ifactioncount(2))
                        traps.SetAction(PSWIMMINGGO);
                }
                else
                if (traps.ifaction(PSWIMMINGGO))
                {
                    if (traps.ifactioncount(2))
                        traps.SetAction(PSWIMMING);
                }
                else
                    traps.SetAction(PTREDWATER);
            }
            if (traps.ifrnd(4))
                traps.spawn(WATERBUBBLE);
            return;
        }
        else
        if (traps.ifp(pjetpack))
        {
            if (traps.ifaction(PJPHOUVER))
            {
                if (traps.ifactioncount(4))
                    traps.resetactioncount();
            }
            else
                traps.SetAction(PJPHOUVER);
            return;
        }
        else
        {
            if (traps.ifaction(PTREDWATER))
                traps.SetAction(PSTAND);
            if (traps.ifaction(PSWIMMING))
                traps.SetAction(PSTAND);
            if (traps.ifaction(PSWIMMINGWAIT))
                traps.SetAction(PSTAND);
            if (traps.ifaction(PSWIMMINGGO))
                traps.SetAction(PSTAND);
            if (traps.ifaction(PJPHOUVER))
                traps.SetAction(PFALLING);
        }
        if (traps.ifaction(PFALLING))
        {
            if (traps.ifp(ponground))
                traps.SetAction(PSTAND);
            else
            {
                if (traps.ifp(pfalling))
                    return;
                else
                    check_pstandard();
            }
        }
        if (traps.ifaction(PDUCKING))
        {
            if (traps.ifgapzl(48))
            {
                if (traps.ifp(pwalking, pwalkingback, prunning, prunningback))
                    traps.SetAction(PCRAWLING);
            }
            else
            if (traps.ifp(pducking))
            {
                if (traps.ifp(pwalking, pwalkingback, prunning, prunningback))
                    traps.SetAction(PCRAWLING);
            }
            else
            {
                if (traps.ifp(pstanding))
                    traps.SetAction(PSTAND);
                else
                    check_pstandard();
            }
        }
        else
        if (traps.ifaction(PCRAWLING))
        {
            if (traps.ifgapzl(48))
            {
                if (traps.ifp(pstanding))
                    traps.SetAction(PCRAWLING);
            }
            else
            if (traps.ifp(pducking))
            {
                if (traps.ifp(pstanding))
                    traps.SetAction(PDUCKING);
            }
            else
            {
                if (traps.ifp(pstanding))
                    traps.SetAction(PSTAND);
                else
                    check_pstandard();
            }
        }
        else
        if (traps.ifgapzl(48))
            traps.SetAction(PDUCKING);
        else
        if (traps.ifaction(PJUMPING))
        {
            if (traps.ifp(ponground))
                traps.SetAction(PSTAND);
            else
            if (traps.ifactioncount(4))
                if (traps.ifp(pfalling))
                    traps.SetAction(PFALLING);
        }
        if (traps.ifp(pfalling))
            traps.SetAction(PFALLING);
        else
        if (traps.ifaction(PSTAND))
            check_pstandard();
        else
        if (traps.ifaction(PAKICKING))
        {
            if (traps.ifactioncount(2))
                traps.SetAction(PSTAND);
            return;
        }
        else
        if (traps.ifaction(PWALK))
        {
            if (traps.ifp(pfalling))
                traps.SetAction(PFALLING);
            else
            if (traps.ifp(pstanding))
                traps.SetAction(PSTAND);
            else
            if (traps.ifp(prunning))
                traps.SetAction(PRUN);
            else
            if (traps.ifp(pwalkingback))
                traps.SetAction(PWALKBACK);
            else
            if (traps.ifp(prunningback))
                traps.SetAction(PRUNBACK);
            else
            if (traps.ifp(pjumping))
                traps.SetAction(PJUMPING);
            else
            if (traps.ifp(pducking))
                traps.SetAction(PDUCKING);
        }
        else
        if (traps.ifaction(PRUN))
        {
            if (traps.ifp(pstanding))
                traps.SetAction(PSTAND);
            else
            if (traps.ifp(pwalking))
                traps.SetAction(PWALK);
            else
            if (traps.ifp(pwalkingback))
                traps.SetAction(PWALKBACK);
            else
            if (traps.ifp(prunningback))
                traps.SetAction(PRUNBACK);
            else
            if (traps.ifp(pjumping))
                traps.SetAction(PJUMPING);
            else
            if (traps.ifp(pducking))
                traps.SetAction(PDUCKING);
        }
        else
        if (traps.ifaction(PWALKBACK))
        {
            if (traps.ifp(pstanding))
                traps.SetAction(PSTAND);
            else
            if (traps.ifp(pwalking))
                traps.SetAction(PWALK);
            else
            if (traps.ifp(prunning))
                traps.SetAction(PRUN);
            else
            if (traps.ifp(prunningback))
                traps.SetAction(PRUNBACK);
            else
            if (traps.ifp(pjumping))
                traps.SetAction(PJUMPING);
            else
            if (traps.ifp(pducking))
                traps.SetAction(PDUCKING);
        }
        else
        if (traps.ifaction(PRUNBACK))
        {
            if (traps.ifp(pstanding))
                traps.SetAction(PSTAND);
            else
            if (traps.ifp(pwalking))
                traps.SetAction(PWALK);
            else
            if (traps.ifp(prunning))
                traps.SetAction(PRUN);
            else
            if (traps.ifp(pwalkingback))
                traps.SetAction(PWALKBACK);
            else
            if (traps.ifp(pjumping))
                traps.SetAction(PJUMPING);
            else
            if (traps.ifp(pducking))
                traps.SetAction(PDUCKING);
        }
    }
}