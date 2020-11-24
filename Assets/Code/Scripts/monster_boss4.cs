public partial class ConScript
{

    static ConAction ABOSS4WALK = new ConAction(0, 4, 5, 1, 30);
    static ConAction ABOSS4DYING = new ConAction(40, 9, 1, 1, 20);
    static ConAction ABOSS4ABOUTTOSHOOT = new ConAction(20, 1, 5, 1, 40);
    static ConAction ABOSS4SHOOT = new ConAction(25, 2, 5, 1, 10);
    static ConAction ABOSS4LAYIT = new ConAction(50, 3, 5, 1, 120);
    static ConAction BOSS4FLINTCH = new ConAction(40, 1, 1, 1, 1);
    static ConAction ABOSS4DEAD = new ConAction(49);
    static MoveAction BOSS4WALKVELS = new MoveAction(128);
    static MoveAction BOSS4STOPPED = new MoveAction();
    static AIAction AIBOSS4LAYEGGS = new AIAction(ABOSS4WALK, BOSS4WALKVELS, randomangle, geth);
    static AIAction AIBOSS4SHOOT = new AIAction(ABOSS4ABOUTTOSHOOT, BOSS4STOPPED, faceplayer);
    static AIAction AIBOSS4DYING = new AIAction(ABOSS4DYING, BOSS4STOPPED, faceplayer);
    private void boss4shootstate()
    {
        if (traps.ifaction(ABOSS4ABOUTTOSHOOT))
            if (traps.ifactioncount(3))
                traps.SetAction(ABOSS4SHOOT);
        if (traps.ifaction(ABOSS4SHOOT))
        {
            if (traps.ifcount(48))
            {
                if (traps.ifrnd(4))
                    traps.Ai(AIBOSS4LAYEGGS);
            }
            if (traps.ifcount(26))
                if (traps.ifrnd(32))
                {
                    if (traps.ifrnd(128))
                    {
                        traps.sound(SHORT_CIRCUIT);
                        traps.addphealth(-2);
                    }
                    else
                    {
                        traps.sound(DUKE_GRUNT);
                        traps.addphealth(-1);
                    }
                    traps.palfrom(32, 32, 0, 0);
                }
        }
    }
    private void boss4layeggs()
    {
        if (traps.ifrnd(2))
            traps.sound(BOS4_ROAM);
        if (traps.ifaction(ABOSS4LAYIT))
        {
            if (traps.ifactioncount(3))
                if (traps.ifcount(32))
                {
                    traps.Ai(AIBOSS4LAYEGGS);
                    if (traps.ifrnd(32))
                        traps.Move(BOSS4WALKVELS, furthestdir, geth);
                    traps.spawn(NEWBEASTHANG);
                }
        }
        else
        if (traps.ifcount(64))
            if (traps.ifrnd(4))
            {
                traps.Move(0);
                if (traps.ifrnd(88))
                {
                    traps.SetAction(ABOSS4LAYIT);
                    traps.sound(BOS4_LAY);
                }
                else
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                    {
                        traps.Ai(AIBOSS4SHOOT);
                        traps.sound(BOS4_ATTACK);
                    }
            }
    }
    private void boss4dyingstate()
    {
        if (traps.ifaction(ABOSS4DEAD))
            return;
        else
        if (traps.ifactioncount(9))
        {
            if (traps.iffloordistl(8))
                traps.sound(THUD);
            traps.endofgame(52);
            traps.SetAction(ABOSS4DEAD);
            traps.cstat(0);
        }
    }
    private void checkboss4hitstate()
    {
        if (traps.ifrnd(2))
            traps.spawn(BLOODPOOL);
        if (traps.ifdead())
        {
            traps.globalsound(DUKE_TALKTOBOSSFALL);
            traps.addkills(1);
            traps.Ai(AIBOSS4DYING);
            traps.sound(BOS4_DYING);
            traps.sound(BOSS4_DEADSPEECH);
        }
        else
        {
            traps.soundonce(BOS4_PAIN);
            traps.debris(SCRAP1, 1);
            traps.guts(JIBS6, 1);
            if (traps.ifaction(ABOSS4LAYIT))
                return;
            if (traps.ifrnd(16))
            {
                traps.SetAction(BOSS4FLINTCH);
                traps.Move(0);
            }
        }
    }
    private void boss4code()
    {
        if (traps.ifai(null))
            traps.Ai(AIBOSS4LAYEGGS);
        else
        if (traps.ifaction(BOSS4FLINTCH))
        {
            if (traps.ifactioncount(3))
                traps.Ai(AIBOSS4LAYEGGS);
        }
        else
        if (traps.ifai(AIBOSS4LAYEGGS))
            boss4layeggs();
        else
        if (traps.ifai(AIBOSS4SHOOT))
            boss4shootstate();
        if (traps.ifai(AIBOSS4DYING))
            boss4dyingstate();
        else
        {
            if (traps.ifhitweapon())
                checkboss4hitstate();
            else
                if (traps.ifp(palive))
                if (traps.ifpdistl(1280))
                {
                    traps.addphealth(-1000);
                    traps.palfrom(63, 63);
                }
        }
    }
    private void A_BOSS4STAYPUT()
    {
        traps.fall();
        traps.cactor(BOSS4);
        traps.spritepal(6);
        boss4code();
        traps.getlastpal();
    }
    private void A_BOSS4()
    {
        traps.fall();
        traps.cactor(BOSS4);
        traps.spritepal(6);
        boss4code();
        traps.getlastpal();
    }
}