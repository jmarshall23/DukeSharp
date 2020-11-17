//-------------------------------------------------------------------------
/*
Copyright (c) 2020 - Blackenmace Studios LLC
Copyright (C) 1996, 2003 - 3D Realms Entertainment

This file is part of the Duke Nukem 3D C# Source Port
This file is part of Duke Nukem 3D version 1.5 - Atomic Edition

Duke Nukem 3D is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  

See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

C# Port Conversion: 2020 - Justin Marshall
Original Source: 1996 - Todd Replogle
Prepared for public release: 03/21/2003 - Charlie Wiederhold, 3D Realms
*/
//-------------------------------------------------------------------------

using Build;
using UnityEngine;
using System;
using System.Text;
public partial class GlobalMembers
{
    internal static short total_lines;
    internal static short line_number;
    internal static int checking_ifelse;
    internal static int parsing_state;
    //internal static string last_used_text;
    internal static short num_squigilly_brackets;
    //internal static int last_used_size;

    internal static short g_i;
    internal static short g_p;
    internal static int g_x;
    internal static scripttemp g_t;
    internal static spritetype g_sp;

    internal struct DefString
    {
        public string buffer;
        public int bufferpos;

        public DefString(int t)
        {
            buffer = "";
            bufferpos = 0;
        }

        public static DefString operator ++(DefString w)
        {
            w.bufferpos++;
            return w;
        }

        public bool IsNumber()
        {
            return char.IsDigit(buffer[bufferpos]);
        }

        public bool IsAlpha()
        {
            if (bufferpos >= buffer.Length)
                return false;

            char c = buffer[bufferpos];
            return char.IsLetter(buffer[bufferpos]) || c == '{' || c == '}' || c == '/' || c == '*' || c == '-' || c == '_' || c == '.' || IsNumber();
        }
        public bool IsAlpha(int indx)
        {
            if (bufferpos + indx >= buffer.Length)
                return false;

            char c = buffer[bufferpos + indx];
            return char.IsLetter(buffer[bufferpos + indx]) || c == '{' || c == '}' || c == '/' || c == '*' || c == '-' || c == '_' || c == '.' || IsNumber();
        }

        public char Get()
        {
            if (bufferpos >= buffer.Length)
                return (char)0;

            return buffer[bufferpos];
        }

        public char GetIdx(int index)
        {
            if (bufferpos + index >= buffer.Length)
                return (char)0;

            return buffer[bufferpos + index];
        }

        public char GetNext()
        {
            if (bufferpos + 1 >= buffer.Length)
                return (char)0;

            return buffer[bufferpos + 1];
        }
    }

    internal static DefString textptr = new DefString(1);


    public static string[] keyw = { "definelevelname", "actor", "addammo", "ifrnd", "enda", "ifcansee", "ifhitweapon", "action", "ifpdistl", "ifpdistg", "else", "strength", "break", "shoot", "palfrom", "sound", "fall", "state", "ends", "define", "//", "ifai", "killit", "addweapon", "ai", "addphealth", "ifdead", "ifsquished", "sizeto", "{", "}", "spawn", "move", "ifwasweapon", "ifaction", "ifactioncount", "resetactioncount", "debris", "pstomp", "/*", "cstat", "ifmove", "resetplayer", "ifonwater", "ifinwater", "ifcanshoottarget", "ifcount", "resetcount", "addinventory", "ifactornotstayput", "hitradius", "ifp", "count", "ifactor", "music", "include", "ifstrength", "definesound", "guts", "ifspawnedby", "gamestartup", "wackplayer", "ifgapzl", "ifhitspace", "ifoutside", "ifmultiplayer", "operate", "ifinspace", "debug", "endofgame", "ifbulletnear", "ifrespawn", "iffloordistl", "ifceilingdistl", "spritepal", "ifpinventory", "betaname", "cactor", "ifphealthl", "definequote", "quote", "ifinouterspace", "ifnotmoving", "respawnhitag", "tip", "ifspritepal", "money", "soundonce", "addkills", "stopsound", "ifawayfromwall", "ifcanseetarget", "globalsound", "lotsofglass", "ifgotweaponce", "getlastpal", "pkick", "mikesnd", "useractor", "sizeat", "addstrength", "cstator", "mail", "paper", "tossweapon", "sleeptime", "nullop", "definevolumename", "defineskillname", "ifnosounds", "clipdist", "ifangdiffl" };
    public static short getincangle(short a, short na)
    {
        a &= 2047;
        na &= 2047;

        if (pragmas.klabs(a - na) < 1024)
            return (short)(na - a);
        else
        {
            if (na > 1024) na -= 2048;
            if (a > 1024) a -= 2048;

            na -= 2048;
            a -= 2048;
            return (short)(na - a);
        }
    }

    public static int ispecial(char c)
    {
        if (c == 0x0a)
        {
            line_number++;
            return 1;
        }

        if (c == ' ' || c == 0x0d)
        {
            return 1;
        }

        return 0;
    }

    public static bool isaltok(char c)
    {
        return (!Char.IsLetter(c) || c == '{' || c == '}' || c == '/' || c == '*' || c == '-' || c == '_' || c == '.');
    }

    public static void getglobalz(short i)
    {
        int hz = 0;
        int lz = 0;
        int zr = 0;

        spritetype s = Engine.board.sprite[i];

        if (s.statnum == 10 || s.statnum == 6 || s.statnum == 2 || s.statnum == 1 || s.statnum == 4)
        {
            if (s.statnum == 4)
            {
                zr = 4;
            }
            else
            {
                zr = 127;
            }

            Engine.board.getzrange(s.x, s.y, s.z - ((1 << 8)), s.sectnum, ref hittype[i].ceilingz, ref hz, ref hittype[i].floorz, ref lz, zr, (((1) << 16) + 1));

            if ((lz & 49152) == 49152 && (Engine.board.sprite[lz & (DefineConstants.MAXSPRITES - 1)].cstat & 48) == 0)
            {
                lz &= (DefineConstants.MAXSPRITES - 1);
                if (badguy(Engine.board.sprite[lz]) != 0 && Engine.board.sprite[lz].pal != 1)
                {
                    if (s.statnum != 4)
                    {
                        hittype[i].dispicnum = -4; // No shadows on actors
                        s.xvel = -256;
                        ssp(i, (uint)(((1) << 16) + 1));
                    }
                }
                else if (Engine.board.sprite[lz].picnum == DefineConstants.APLAYER && badguy(s) != 0)
                {
                    hittype[i].dispicnum = -4; // No shadows on actors
                    s.xvel = -256;
                    ssp(i, (uint)(((1) << 16) + 1));
                }
                else if (s.statnum == 4 && Engine.board.sprite[lz].picnum == DefineConstants.APLAYER)
                {
                    if (s.owner == lz)
                    {
                        hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
                        hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
                    }
                }
            }
        }
        else
        {
            hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
            hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
        }
    }

    public static void makeitfall(short i)
    {
        spritetype s = Engine.board.sprite[i];
        int hz = 0;
        int lz = 0;
        int c;

        if (floorspace(s.sectnum) != 0)
        {
            c = 0;
        }
        else
        {
            if (ceilingspace(s.sectnum) != 0 || Engine.board.sector[s.sectnum].lotag == 2)
            {
                c = gc / 6;
            }
            else
            {
                c = gc;
            }
        }

        if ((s.statnum == 1 || s.statnum == 10 || s.statnum == 2 || s.statnum == 6))
        {
            Engine.board.getzrange(s.x, s.y, s.z - ((1 << 8)), s.sectnum, ref hittype[i].ceilingz, ref hz, ref hittype[i].floorz, ref lz, 127, (((1) << 16) + 1));
        }
        else
        {
            hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
            hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
        }

        if (s.z < hittype[i].floorz - ((1 << 8)))
        {
            if (Engine.board.sector[s.sectnum].lotag == 2 && s.zvel > 3122)
            {
                s.zvel = 3144;
            }
            if (s.zvel < 6144)
            {
                s.zvel += (short)c;
            }
            else
            {
                s.zvel = 6144;
            }
            s.z += s.zvel;
        }
        if (s.z >= hittype[i].floorz - ((1 << 8)))
        {
            s.z = hittype[i].floorz - (1 << 8);
            s.zvel = 0;
        }
    }

    public static void getlabel()
    {
        int i;

        while (textptr.IsAlpha() == false)
        {
            if (textptr.Get() == 0x0a)
            {
                line_number++;
            }
            textptr++;
            if (textptr.Get() == 0)
            {
                return;
            }
        }

        i = 0;
        while (ispecial(textptr.Get()) == 0)
        {
            if ((labelcnt << 6) + i >= label.Length)
                throw new Exception("Labelcnt too high!");

            label[(labelcnt << 6) + i++] = (byte)textptr.Get();
            textptr++;
        }

        label[(labelcnt << 6) + i] = 0;
    }

    public static int keyword()
    {
        int i;        
        DefString temptextptr = new DefString(1);

        temptextptr.buffer = textptr.buffer;
        temptextptr.bufferpos = textptr.bufferpos;

        while (temptextptr.IsAlpha() == false)
        {
            temptextptr++;
            if (temptextptr.Get() == 0)
            {
                return 0;
            }
        }

        i = 0;
        while (temptextptr.IsAlpha())
        {
            tempbuf[i] = (byte)temptextptr.Get();
            temptextptr++;
            i++;
        }
        tempbuf[i] = 0;

        string t = Encoding.UTF8.GetString(tempbuf, 0, i);
        for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
        {            
            if (t == keyw[i])
            {
                return i;
            }
        }

        return -1;
    }

    public static int transword() //Returns its code #
    {
        int i;
        int l;

        while (textptr.IsAlpha() == false)
        {
            if (textptr.Get() == 0x0a)
            {
                line_number++;
            }
            textptr++;
            if (textptr.Get() == 0)
            {
                return -1;
            }
        }

        l = 0;
        DefString temptextptr = new DefString(1);
        temptextptr.buffer = textptr.buffer;
        temptextptr.bufferpos = textptr.bufferpos;

        temptextptr = textptr;
        l = 0;
        while (temptextptr.IsAlpha())
        {
            tempbuf[l] = (byte)temptextptr.Get();
            temptextptr++;
            l++;
        }
        tempbuf[l] = 0;

        string t = Encoding.UTF8.GetString(tempbuf, 0, l);
        for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
        {
            if (t == keyw[i])
            {
                scriptptr.Set(i);
                textptr.bufferpos += l;
                scriptptr++;
                return i;
            }
        }

        textptr.bufferpos += l;

        if (tempbuf[0] == '{' && tempbuf[1] != 0)
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting a SPACE or CR between '{' and '%s'.\n");
        }
        else if (tempbuf[0] == '}' && tempbuf[1] != 0)
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting a SPACE or CR between '}' and '%s'.\n");
        }
        else if (tempbuf[0] == '/' && tempbuf[1] == '/' && tempbuf[2] != 0)
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting a SPACE between '//' and '%s'.\n");
        }
        else if (tempbuf[0] == '/' && tempbuf[1] == '*' && tempbuf[2] != 0)
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting a SPACE between '/*' and '%s'.\n");
        }
        else if (tempbuf[0] == '*' && tempbuf[1] == '/' && tempbuf[2] != 0)
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting a SPACE between '*/' and '%s'.\n");
        }
        else
        {
            Engine.Printf("  * ERROR!(L%ld) Expecting key word, but found " + t + "\n");
        }

        error++;
        return -1;
    }



    public static void transnum()
    {
        int i;
        int l;

        while (textptr.IsAlpha() == false)
        {
            if (textptr.Get() == 0x0a)
            {
                line_number++;
            }
            textptr++;
            if (textptr.Get() == 0)
            {
                return;
            }
        }


        DefString temptextptr = new DefString(1);
        temptextptr.buffer = textptr.buffer;
        temptextptr.bufferpos = textptr.bufferpos;

        temptextptr = textptr;
        l = 0;
        while (temptextptr.IsAlpha())
        {
            tempbuf[l] = (byte)temptextptr.Get();
            temptextptr++;
            l++;
        }
        tempbuf[l] = 0;

        string label1 = GetLabelStr(labelcnt << 6); //Encoding.UTF8.GetString(label, (labelcnt << 6), l);
        string t = Encoding.UTF8.GetString(tempbuf, 0, l);

        for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
        {
            if (label1 == keyw[i])
            {
                error++;
                Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n");
                textptr.bufferpos += l;
            }
        }


        for (i = 0; i < labelcnt; i++)
        {
            label1 = GetLabelStr(i << 6);
            if (t == label1)
            {
                scriptptr.Set(labelcode[i]);
                scriptptr++;
                textptr.bufferpos += l;
                return;
            }
        }

        if (!textptr.IsNumber() && textptr.Get() != '-')
        {
            Engine.Printf("  * ERROR!(L%ld) Parameter " + t + " is undefined.\n");
            error++;
            textptr.bufferpos += l;
            return;
        }

        string num = "";
        for(int d = 0; d < l; d++)
        {
            num += textptr.buffer[textptr.bufferpos + d];
        }

        int value;
        if (!int.TryParse(num, out value)) {
            throw new Exception("Try parse failed?");
        }

        scriptptr.Set(value);
        scriptptr++;

        textptr.bufferpos += l;
    }

    internal static string GetLabelStr(int index)
    {
        int l = 0;
        for(int i = index; i < label.Length; i++)
        {
            if (label[i] == '\0')
                break;
            l++;
        }
        return Encoding.UTF8.GetString(label, index, l);
    }

    internal static string GetTempStr()
    {
        int l = 0;
        for (int i = 0; i < tempbuf.Length; i++)
        {
            if (tempbuf[l] == '\0')
                break;
            l++;
        }
        return Encoding.UTF8.GetString(tempbuf, 0, l);
    }

    public static int parsecommand()
    {
        int i;
        int j;
        int k;
        int tempscrptr;
        int done;
        DefString origtptr = new DefString(1);
        int temp_ifelse_check;
        int tw;
        short temp_line_number;
        kFile fp;

        if (error > 12 || (textptr.Get() == '\0') || (textptr.GetNext() == '\0'))
        {
            return 1;
        }

        tw = transword();
        switch (tw)
        {
            default:
                return 0; //End
            case -1:
                return 0; //End
            case 39: //Rem endrem
                scriptptr--;
                j = line_number;
                do
                {
                    textptr++;
                    if (textptr.Get() == 0x0a)
                    {
                        line_number++;
                    }
                    if (textptr.Get() == 0)
                    {
                        Engine.Printf("  * ERROR!(L%ld) Found '/*' with no '*/'.\n");
                        error++;
                        return 0;
                    }
                } while (textptr.Get() != '*' || textptr.GetNext() != '/');
                textptr.bufferpos += 2;
                return 0;
            case 17:
                if (parsing_actor == 0 && parsing_state == 0)
                {
                    getlabel();
                    scriptptr--;
                    labelcode[labelcnt] = scriptptr.bufferpos;
                    labelcnt++;

                    parsing_state = 1;

                    return 0;
                }

                getlabel();

                for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
                {
                    if (GetLabelStr(labelcnt << 6) == keyw[i])
                    {
                        error++;
                        Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n");
                        return 0;
                    }
                }

                for (j = 0; j < labelcnt; j++)
                {
                    if (GetLabelStr(j << 6) == GetLabelStr(labelcnt << 6))
                    {
                        int code = labelcode[j];
                        scriptptr.Set(code);
                        break;
                    }
                }

                if (j == labelcnt)
                {
                    Engine.Printf("  * ERROR!(L%ld) State '%s' not found.\n");
                    error++;
                }
                scriptptr++;
                return 0;

            case 15:
            case 92:
            case 87:
            case 89:
            case 93:
                transnum();
                return 0;

            case 18:
                if (parsing_state == 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'ends' with no 'state'.\n", line_number);
                    error++;
                }
                {
                    //            else
                    if (num_squigilly_brackets > 0)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Found more '{' than '}' before 'ends'.\n", line_number);
                        error++;
                    }
                    if (num_squigilly_brackets < 0)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Found more '}' than '{' before 'ends'.\n", line_number);
                        error++;
                    }
                    parsing_state = 0;
                }
                return 0;
            case 19:
                getlabel();
                // Check to see it's already defined

                for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
                {
                    if (GetLabelStr(labelcnt << 6) == keyw[i])
                    {
                        error++;
                        //Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n", line_number, label + (labelcnt << 6));
                        return 0;
                    }
                }

                for (i = 0; i < labelcnt; i++)
                {
                    if (GetLabelStr(labelcnt << 6) == GetLabelStr(i << 6))
                    {
                        warning++;
                        //Engine.Printf("  * WARNING.(L%ld) Duplicate definition '%s' ignored.\n", line_number, label + (labelcnt << 6));
                        break;
                    }
                }

                transnum();
                if (i == labelcnt)
                {
                    labelcode[labelcnt++] = scriptptr.buffer[scriptptr.bufferpos - 1];
                }
                scriptptr.bufferpos -= 2;
                return 0;
            case 14:

                for (j = 0; j < 4; j++)
                {
                    if (keyword() == -1)
                    {
                        transnum();
                    }
                    else
                    {
                        break;
                    }
                }

                while (j < 4)
                {
                    scriptptr.Set(0);
                    scriptptr++;
                    j++;
                }
                return 0;

            case 32: // Long comments
                if (parsing_actor != 0 || parsing_state != 0)
                {
                    transnum();

                    j = 0;
                    while (keyword() == -1)
                    {
                        transnum();
                        scriptptr--;
                        j |= scriptptr.Get();
                    }
                    scriptptr.Set(j);
                    scriptptr++;
                }
                else
                {
                    scriptptr--;
                    getlabel();
                    // Check to see it's already defined

                    for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == keyw[i])
                        {
                            error++;
                            //Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n", line_number, label + (labelcnt << 6));
                            return 0;
                        }
                    }

                    for (i = 0; i < labelcnt; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == GetLabelStr(i << 6))
                        {
                            warning++;
                            //Engine.Printf("  * WARNING.(L%ld) Duplicate move '%s' ignored.\n", line_number, label + (labelcnt << 6));
                            break;
                        }
                    }
                    if (i == labelcnt)
                    {
                        labelcode[labelcnt++] = scriptptr.bufferpos;
                    }
                    for (j = 0; j < 2; j++)
                    {
                        if (keyword() >= 0)
                        {
                            break;
                        }
                        transnum();
                    }
                    for (k = j; k < 2; k++)
                    {
                        scriptptr.Set(0);
                        scriptptr++;
                    }
                }
                return 0;

            case 54: // music defintion.
                {
                    scriptptr--;
                    transnum(); // Volume Number (0/4)
                    scriptptr--;

                    k = (int)(scriptptr.Get() - 1);

                    if (k >= 0) // if it's background music
                    {
                        i = 0;
                        while (keyword() == -1)
                        {
                            while (textptr.IsAlpha() == false)
                            {
                                if (textptr.Get() == 0x0a)
                                {
                                    line_number++;
                                }
                                textptr++;
                                if (textptr.Get() == 0)
                                {
                                    break;
                                }
                            }
                            j = 0;
                            music_fn[k, i] = "";
                            while (textptr.IsAlpha(j))
                            {
                                music_fn[k,i] += textptr.GetIdx(j);
                                j++;
                            }
                            //music_fn[k][i][j] = '\0'; // jmarshall: not needed
                            textptr.bufferpos += j;
                            if (i > 9)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        i = 0;
                        while (keyword() == -1)
                        {
                            while (textptr.IsAlpha() == false)
                            {
                                if (textptr.Get() == 0x0a)
                                {
                                    line_number++;
                                }
                                textptr++;
                                if (textptr.Get() == 0)
                                {
                                    break;
                                }
                            }
                            j = 0;
                            env_music_fn[i] = "";
                            while (textptr.IsAlpha(j))
                            {                                
                                env_music_fn[i] += textptr.GetIdx(j);
                                j++;
                            }
                            //env_music_fn[i][j] = '\0';

                            textptr.bufferpos += j;
                            if (i > 9)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                }
                return 0;
            case 55: // include
                scriptptr--;
                while (textptr.IsAlpha() == false)
                {
                    if (textptr.Get() == 0x0a)
                    {
                        line_number++;
                    }
                    textptr++;
                    if (textptr.Get() == 0)
                    {
                        break;
                    }
                }
                j = 0;
                while (textptr.IsAlpha())
                {
                    tempbuf[j] = (byte)textptr.Get();
                    textptr++;
                    j++;
                }
                tempbuf[j] = 0;

                string tstr = GetTempStr();
                fp = Engine.filesystem.kopen4load(tstr);
                if (fp == null)
                {
                    error++;
                    throw new Exception("Could not find include file " + tstr);
                    //Engine.Printf("  * ERROR!(L%ld) Could not find '%s'.\n", line_number, label + (labelcnt << 6));
                    return 0;
                }

                j = fp.Length;

                Engine.Printf("Including: " + tstr);

                temp_line_number = line_number;
                line_number = 1;
                temp_ifelse_check = checking_ifelse;
                checking_ifelse = 0;
                origtptr.buffer = textptr.buffer;
                origtptr.bufferpos = textptr.bufferpos;
                textptr.buffer = ""; // last_used_text.Substring(last_used_size); not sure if we need this.
                textptr.bufferpos = 0;

                //*(textptr + j) = 0;
                textptr.buffer = fp.ReadFile();

                do
                {
                    done = parsecommand();
                } while (done == 0);

                textptr = origtptr;
                total_lines += line_number;
                line_number = temp_line_number;
                checking_ifelse = temp_ifelse_check;

                return 0;
            case 24:
                if (parsing_actor != 0 || parsing_state != 0)
                {
                    transnum();
                }
                else
                {
                    scriptptr--;
                    getlabel();

                    for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == keyw[i])
                        {
                            error++;
                            //Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n", line_number, label + (labelcnt << 6));
                            return 0;
                        }
                    }

                    for (i = 0; i < labelcnt; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == GetLabelStr(i << 6))
                        {
                            warning++;
                            //Engine.Printf("  * WARNING.(L%ld) Duplicate ai '%s' ignored.\n", line_number, label + (labelcnt << 6));
                            break;
                        }
                    }

                    if (i == labelcnt)
                    {
                        labelcode[labelcnt++] = scriptptr.bufferpos;
                    }

                    for (j = 0; j < 3; j++)
                    {
                        if (keyword() >= 0)
                        {
                            break;
                        }
                        if (j == 2)
                        {
                            k = 0;
                            while (keyword() == -1)
                            {
                                transnum();
                                scriptptr--;
                                k |= scriptptr.Get();
                            }
                            scriptptr.Set(k);
                            scriptptr++;
                            return 0;
                        }
                        else
                        {
                            transnum();
                        }
                    }
                    for (k = j; k < 3; k++)
                    {
                        scriptptr.Set(0);
                        scriptptr++;
                    }
                }
                return 0;

            case 7:
                if (parsing_actor != 0|| parsing_state != 0)
                {
                    transnum();
                }
                else
                {
                    scriptptr--;
                    getlabel();
                    // Check to see it's already defined

                    for (i = 0; i < DefineConstants.NUMKEYWORDS; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == keyw[i])
                        {
                            error++;
                            //Engine.Printf("  * ERROR!(L%ld) Symbol '%s' is a key word.\n", line_number, label + (labelcnt << 6));
                            return 0;
                        }
                    }

                    for (i = 0; i < labelcnt; i++)
                    {
                        if (GetLabelStr(labelcnt << 6) == GetLabelStr(i << 6))
                        {
                            warning++;
                            //Engine.Printf("  * WARNING.(L%ld) Duplicate action '%s' ignored.\n", line_number, label + (labelcnt << 6));
                            break;
                        }
                    }

                    if (i == labelcnt)
                    {
                        labelcode[labelcnt++] = scriptptr.bufferpos;
                    }

                    for (j = 0; j < 5; j++)
                    {
                        if (keyword() >= 0)
                        {
                            break;
                        }
                        transnum();
                    }
                    for (k = j; k < 5; k++)
                    {
                        scriptptr.Set(0);
                        scriptptr++;
                    }
                }
                return 0;

            case 1:
                if (parsing_state != 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'actor' within 'state'.\n", line_number);
                    error++;
                }

                if (parsing_actor != 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'actor' within 'actor'.\n", line_number);
                    error++;
                }

                num_squigilly_brackets = 0;
                scriptptr--;
                parsing_actor = scriptptr.bufferpos;

                transnum();
                scriptptr--;
                actorscrptr[scriptptr.Get()] = parsing_actor;

                for (j = 0; j < 4; j++)
                {
                    scriptptr.buffer[parsing_actor + j] = 0;
                    if (j == 3)
                    {
                        j = 0;
                        while (keyword() == -1)
                        {
                            transnum();
                            scriptptr--;
                            j |= scriptptr.Get();
                        }
                        scriptptr.Set(j);
                        scriptptr++;
                        break;
                    }
                    else
                    {
                        if (keyword() >= 0)
                        {
                            scriptptr.bufferpos += (4 - j);
                            break;
                        }
                        transnum();

                        scriptptr.buffer[parsing_actor + j] = scriptptr.GetPrev(); // * (parsing_actor + j) = *(scriptptr - 1);                        
                    }
                }

                checking_ifelse = 0;

                return 0;

            case 98:

                if (parsing_state != 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'useritem' within 'state'.\n", line_number);
                    error++;
                }

                if (parsing_actor != 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'useritem' within 'actor'.\n", line_number);
                    error++;
                }

                num_squigilly_brackets = 0;
                scriptptr--;
                parsing_actor = scriptptr.bufferpos;

                transnum();
                scriptptr--;
                j = scriptptr.Get();

                transnum();
                scriptptr--;

                int ii = scriptptr.Get();
                if (ii <= 0 || ii >= actortype.Length)
                    throw new Exception("actortype out of range!");

                actorscrptr[scriptptr.Get()] = parsing_actor;
                actortype[scriptptr.Get()] = j;

                for (j = 0; j < 4; j++)
                {
                    scriptptr.buffer[(parsing_actor + j)] = 0;
                    if (j == 3)
                    {
                        j = 0;
                        while (keyword() == -1)
                        {
                            transnum();
                            scriptptr--;
                            j |= scriptptr.Get();
                        }
                        scriptptr.Set(j);
                        scriptptr++;
                        break;
                    }
                    else
                    {
                        if (keyword() >= 0)
                        {
                            scriptptr.bufferpos += (4 - j);
                            break;
                        }
                        transnum();

                        scriptptr.buffer[(parsing_actor + j)] = scriptptr.GetPrev(); // *(scriptptr - 1);
                    }
                }

                checking_ifelse = 0;

                return 0;



            case 11:
            case 13:
            case 25:
            case 31:
            case 40:
            case 52:
            case 69:
            case 74:
            case 77:
            case 80:
            case 86:
            case 88:
            case 68:
            case 100:
            case 101:
            case 102:
            case 103:
            case 105:
            case 110:
                transnum();
                return 0;

            case 2:
            case 23:
            case 28:
            case 99:
            case 37:
            case 48:
            case 58:
                transnum();
                transnum();
                break;
            case 50:
                transnum();
                transnum();
                transnum();
                transnum();
                transnum();
                break;
            case 10:
                if (checking_ifelse != 0)
                {
                    checking_ifelse--;
                    tempscrptr = scriptptr.bufferpos;
                    scriptptr++; //Leave a spot for the fail location
                    parsecommand();
                    scriptptr.buffer[tempscrptr] = scriptptr.bufferpos;
                }
                else
                {
                    scriptptr--;
                    error++;
                    //Engine.Printf("  * ERROR!(L%ld) Found 'else' with no 'if'.\n", line_number);
                }

                return 0;

            case 75:
                transnum();
                goto case 3;
            case 3:
            case 8:
            case 9:
            case 21:
            case 33:
            case 34:
            case 35:
            case 41:
            case 46:
            case 53:
            case 56:
            case 59:
            case 62:
            case 72:
            case 73:
            //        case 74:
            case 78:
            case 85:
            case 94:
            case 111:
                transnum();
                goto case 43;
            case 43:
            case 44:
            case 49:
            case 5:
            case 6:
            case 27:
            case 26:
            case 45:
            case 51:
            case 63:
            case 64:
            case 65:
            case 67:
            case 70:
            case 71:
            case 81:
            case 82:
            case 90:
            case 91:
            case 109:                
                if (tw == 51)
                {
                    j = 0;
                    do
                    {
                        transnum();
                        scriptptr--;
                        j |= scriptptr.Get();
                    } while (keyword() == -1);
                    scriptptr.Set(j);
                    scriptptr++;
                }

                tempscrptr = scriptptr.bufferpos;
                scriptptr++; //Leave a spot for the fail location

                do
                {
                    j = keyword();
                    if (j == 20 || j == 39)
                    {
                        parsecommand();
                    }
                } while (j == 20 || j == 39);

                parsecommand();

                scriptptr.buffer[tempscrptr] = scriptptr.bufferpos;

                checking_ifelse++;
                return 0;
            case 29:
                num_squigilly_brackets++;
                do
                {
                    done = parsecommand();
                } while (done == 0);
                return 0;
            case 30:
                num_squigilly_brackets--;
                if (num_squigilly_brackets < 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found more '}' than '{'.\n", line_number);
                    error++;
                }
                return 1;
            case 76:
                scriptptr--;
                j = 0;
                betaname = "";
                while (textptr.Get() != 0x0a)
                {
                    betaname += textptr.Get();
                    j++;
                    textptr++;
                }
                //betaname[j] = 0;
                return 0;
            case 20:
                scriptptr--; //Negate the rem
                while (textptr.Get() != 0x0a)
                {
                    textptr++;
                }

                // line_number++;
                return 0;

            case 107:
                scriptptr--;
                transnum();
                scriptptr--;
                j = scriptptr.Get();
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                i = 0;

                volume_names[j] = "";
                while (textptr.Get() != 0x0a)
                {
                    volume_names[j] += Char.ToUpper(textptr.Get());
                    textptr++;
                    i++;
                    if (i >= 32)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Volume name exceeds character size limit of 32.\n", line_number);
                        error++;
                        while (textptr.Get() != 0x0a)
                        {
                            textptr++;
                        }
                        break;
                    }
                }
                //volume_names[j][i - 1] = '\0';
                return 0;
            case 108:
                scriptptr--;
                transnum();
                scriptptr--;
                j = scriptptr.Get();
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                i = 0;

                skill_names[j] = "";
                while (textptr.Get() != 0x0a)
                {
                    skill_names[j] += Char.ToUpper(textptr.Get());
                    textptr++;
                    i++;
                    if (i >= 32)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Skill name exceeds character size limit of 32.\n", line_number);
                        error++;
                        while (textptr.Get() != 0x0a)
                        {
                            textptr++;
                        }
                        break;
                    }
                }
                //skill_names[j][i - 1] = '\0';
                return 0;

            case 0:
                scriptptr--;
                transnum();
                scriptptr--;
                j = scriptptr.Get();
                transnum();
                scriptptr--;
                k = scriptptr.Get();
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                i = 0;
                level_file_names[j * 11 + k] = "";
                while (textptr.Get() != ' ' && textptr.Get() != 0x0a)
                {
                    level_file_names[j * 11 + k] += textptr.Get();
                    textptr++;
                    i++;
                    if (i > 127)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Level file name exceeds character size limit of 128.\n", line_number);
                        error++;
                        while (textptr.Get() != ' ')
                        {
                            textptr++;
                        }
                        break;
                    }
                }
               // level_names[j * 11 + k][i - 1] = '\0';

                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                partime[j * 11 + k] = ((((textptr.GetIdx(0)) - '0') * 10 + (textptr.GetNext() - '0')) * 26 * 60) + ((((textptr.GetIdx(3)) - '0') * 10 + ((textptr.GetIdx(4)) - '0')) * 26);

                textptr.bufferpos += 5;
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                designertime[j * 11 + k] = ((((textptr.GetIdx(0)) - '0') * 10 + (textptr.GetNext() - '0')) * 26 * 60) + ((((textptr.GetIdx(3)) - '0') * 10 + ((textptr.GetIdx(4)) - '0')) * 26);

                textptr.bufferpos += 5;
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                i = 0;

              //  level_names[j * 11 + k] = 0;
                while (textptr.Get() != 0x0a)
                {
                    level_names[j * 11 + k] += Char.ToUpper(textptr.Get());
                    textptr++;
                    i++;
                    if (i >= 32)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Level name exceeds character size limit of 32.\n", line_number);
                        error++;
                        while (textptr.Get() != 0x0a)
                        {
                            textptr++;
                        }
                        break;
                    }
                }
                //level_names[j * 11 + k][i - 1] = '\0';
                return 0;

            case 79:
                scriptptr--;
                transnum();
                k = scriptptr.GetPrev(); // * (scriptptr - 1);
                if (k >= DefineConstants.NUMOFFIRSTTIMEACTIVE)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Quote amount exceeds limit of %ld characters.\n", line_number, DefineConstants.NUMOFFIRSTTIMEACTIVE);
                    error++;
                }
                scriptptr--;
                i = 0;
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                fta_quotes[k] = "";
                while (textptr.Get() != 0x0a)
                {
                    fta_quotes[k] += textptr.Get();
                    textptr++;
                    i++;
                    if (i >= 64)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Quote exceeds character size limit of 64.\n", line_number);
                        error++;
                        while (textptr.Get() != 0x0a)
                        {
                            textptr++;
                        }
                        break;
                    }
                }
              //  fta_quotes[k][i] = '\0';
                return 0;
            case 57:
                scriptptr--;
                transnum();
                k = scriptptr.GetPrev(); // * (scriptptr - 1);
                if (k >= DefineConstants.NUM_SOUNDS)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Exceeded sound limit of %ld.\n", line_number, DefineConstants.NUM_SOUNDS);
                    error++;
                }
                scriptptr--;
                i = 0;
                while (textptr.Get() == ' ')
                {
                    textptr++;
                }

                sounds[k] = "";
                while (textptr.Get() != ' ')
                {
                    sounds[k] += textptr.Get();
                    textptr++;
                    i++;
                    if (i >= 13)
                    {
                        //puts(sounds[k]);
                        //Engine.Printf("  * ERROR!(L%ld) Sound filename exceeded limit of 13 characters.\n", line_number);
                        error++;
                        while (textptr.Get() != ' ')
                        {
                            textptr++;
                        }
                        break;
                    }
                }
               // sounds[k][i] = '\0';

                transnum();
                soundps[k] = (short)scriptptr.GetPrev(); // * (scriptptr - 1);
                scriptptr--;
                transnum();
                soundpe[k] = (short)scriptptr.GetPrev();
                scriptptr--;
                transnum();
                soundpr[k] = (short)scriptptr.GetPrev();
                scriptptr--;
                transnum();
                soundm[k] = (short)scriptptr.GetPrev();
                scriptptr--;
                transnum();
                soundvo[k] = (short)scriptptr.GetPrev();
                scriptptr--;
                return 0;

            case 4:
                if (parsing_actor == 0)
                {
                    //Engine.Printf("  * ERROR!(L%ld) Found 'enda' without defining 'actor'.\n", line_number);
                    error++;
                }
                {
                    //            else
                    if (num_squigilly_brackets > 0)
                    {
                        //Engine.Printf("  * ERROR!(L%ld) Found more '{' than '}' before 'enda'.\n", line_number);
                        error++;
                    }
                    parsing_actor = 0;
                }

                return 0;
            case 12:
            case 16:
            case 84:
            //        case 21:
            case 22: //KILLIT
            case 36:
            case 38:
            case 42:
            case 47:
            case 61:
            case 66:
            case 83:
            case 95:
            case 96:
            case 97:
            case 104:
            case 106:
                return 0;
            case 60:
                j = 0;
                while (j < 30)
                {
                    transnum();
                    scriptptr--;

                    switch (j)
                    {
                        case 0:
                            ud.const_visibility = scriptptr.Get();
                            break;
                        case 1:
                            impact_damage = scriptptr.Get();
                            break;
                        case 2:
                            max_player_health = scriptptr.Get();
                            break;
                        case 3:
                            max_armour_amount = scriptptr.Get();
                            break;
                        case 4:
                            respawnactortime = scriptptr.Get();
                            break;
                        case 5:
                            respawnitemtime = scriptptr.Get();
                            break;
                        case 6:
                            dukefriction = scriptptr.Get();
                            break;
                        case 7:
                            gc = scriptptr.Get();
                            break;
                        case 8:
                            rpgblastradius = scriptptr.Get();
                            break;
                        case 9:
                            pipebombblastradius = scriptptr.Get();
                            break;
                        case 10:
                            shrinkerblastradius = scriptptr.Get();
                            break;
                        case 11:
                            tripbombblastradius = scriptptr.Get();
                            break;
                        case 12:
                            morterblastradius = scriptptr.Get();
                            break;
                        case 13:
                            bouncemineblastradius = scriptptr.Get();
                            break;
                        case 14:
                            seenineblastradius = scriptptr.Get();
                            break;

                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                            if (j == 24)
                            {
                                max_ammo_amount[11] = scriptptr.Get();
                            }
                            else
                            {
                                max_ammo_amount[j - 14] = scriptptr.Get();
                            }
                            break;
                        case 25:
                            camerashitable = (char)scriptptr.Get();
                            break;
                        case 26:
                            numfreezebounces = scriptptr.Get();
                            break;
                        case 27:
                            freezerhurtowner = scriptptr.Get();
                            break;
                        case 28:
                            spriteqamount = (short)scriptptr.Get();
                            if (spriteqamount > 1024)
                            {
                                spriteqamount = 1024;
                            }
                            else if (spriteqamount < 0)
                            {
                                spriteqamount = 0;
                            }
                            break;
                        case 29:
                            lasermode = (char)scriptptr.Get();
                            break;
                    }
                    j++;
                }
                scriptptr++;
                return 0;
        }
        return 0;
    }

    public static void passone()
    {

        while (parsecommand() == 0)
        {
            ;
        }

        if ((error + warning) > 12)
        {
            throw new Exception("  * ERROR! Too many warnings or errors.");
        }

    }    

    public static string[][] defaultcons =
    {
        new string[] {"GAME.CON"},
        new string[] {"USER.CON"},
        new string[] {"DEFS.CON"}
    };

    public static void copydefaultcons()
    {
        // jmarshall: not used
    }

    public static void loadefs(string filenam)
    {
        int i;
        int fs;
        kFile fp;
        /*
        // jmarshall not used
        if (SafeFileExists(filenam) == null && loadfromgrouponly == 0)
        {
            puts("Missing external con file(s).");
            puts("COPY INTERNAL DEFAULTS TO DIRECTORY(Y/n)?");

            KB_FlushKeyboardQueue();
            while (KB_KeyWaiting() != null)
            {
                ;
            }

            i = KB_Getch();
            if (i == 'y' || i == 'Y')
            {
                puts(" Yes");
                copydefaultcons();
            }
        }
        */

        fp = Engine.filesystem.kopen4load(filenam);
        if (fp == null)
        {
            if (loadfromgrouponly == 1)
            {
                gameexit("\nMissing con file(s).");
            }

            //loadfromgrouponly = 1;
            return; //Not there
        }
        else
        {
            Engine.Printf("Compiling: " + filenam);

            fs = fp.Length;

            textptr.buffer = fp.ReadFile();
            textptr.bufferpos = 0;            
        }

        //textptr.buffer[fs - 2] = (char)0; // jmarshall
        actorscrptr = new int[DefineConstants.MAXTILES * 10];
        actortype = new int[DefineConstants.MAXTILES * 10];

        //clearbuf(actorscrptr, DefineConstants.MAXSPRITES, 0);
        //clearbufbyte(actortype, DefineConstants.MAXSPRITES, 0);

        labelcnt = 0;
        scriptptr.buffer = new int[DefineConstants.MAXSCRIPTSIZE];// script + 1;
        scriptptr.bufferpos = 0;
        warning = 0;
        error = 0;
        line_number = 1;
        total_lines = 0;

        scriptptr.bufferpos = 1;

        passone(); //Tokenize
        //*script = (int)scriptptr;

// jmarshall - debugging
        //int[] debug_actorscript = new int[actorscrptr.Length];
        //for(int d = 0;  d < actorscrptr.Length; d++)
        //{
        //    debug_actorscript[d] = scriptptr.buffer[actorscrptr[d]];
        //}

        if ((warning | error) != 0)
        {
            Engine.Printf("Found " + warning + "warning(s), " + error + "error(s).\n");
        }

        // jmarshall
        /*
        if (error == 0 && warning != 0)
        {
            if (groupfile != -1 && loadfromgrouponly == 0)
            {
                printf("\nWarnings found in %s file.  You should backup the original copies before\n", filenam);
                puts("before attempting to modify them.  Do you want to use the");
                puts("INTERNAL DEFAULTS (y/N)?");

                KB_FlushKeyboardQueue();
                while (KB_KeyWaiting() != null)
                {
                    ;
                }
                i = KB_Getch();
                if (i == 'y' || i == 'Y')
                {
                    loadfromgrouponly = 1;
                    puts(" Yes");
                    return;
                }
            }
        }
        
        if (error)
        {
            if (loadfromgrouponly)
            {
                sprintf(buf, "\nError in %s.", filenam);
                gameexit(ref buf);
            }
            else
            {
                if (groupfile != -1 && loadfromgrouponly == 0)
                {
                    printf("\nErrors found in %s file.  You should backup the original copies\n", filenam);
                    puts("before attempting to modify them.  Do you want to use the");
                    puts("internal defaults (Y/N)?");

                    KB_FlushKeyboardQueue();
                    while (KB_KeyWaiting() == null)
                    {
                        ;
                    }

                    i = KB_Getch();
                    if (i == 'y' || i == 'Y')
                    {
                        puts(" Yes");
                        loadfromgrouponly = 1;
                        return;
                    }
                    else
                    {
                        gameexit("");
                    }
                }
            }
        }
        else
        {
            total_lines += line_number;
            printf("Code Size:%ld bytes(%ld labels).\n", (int)((scriptptr - script) << 2) - 4, labelcnt);
        }
        */
        // jmarshall end
        if(error > 0)
        {
            gameexit("Script parsing error\n");
        }
        else
        {
            total_lines += line_number;
            Engine.Printf("Code: " + labelcnt + "labels");
        }
    }

    public static int dodge(spritetype s)
    {
        int i;
        int bx;
        int by;
        int mx;
        int my;
        int bxvect;
        int byvect;
        int mxvect;
        int myvect;
        int d;

        mx = s.x;
        my = s.y;
        mxvect = Engine.table.sintable[(s.ang + 512) & 2047];
        myvect = Engine.table.sintable[s.ang & 2047];

        for (i = Engine.board.headspritestat[4]; i >= 0; i = Engine.board.nextspritestat[i]) //weapons list
        {
            if (Engine.board.sprite[i].owner == i || Engine.board.sprite[i].sectnum != s.sectnum)
            {
                continue;
            }

            bx = Engine.board.sprite[i].x - mx;
            by = Engine.board.sprite[i].y - my;
            bxvect = Engine.table.sintable[(Engine.board.sprite[i].ang + 512) & 2047];
            byvect = Engine.table.sintable[Engine.board.sprite[i].ang & 2047];

            if (mxvect * bx + myvect * by >= 0)
            {
                if (bxvect * bx + byvect * by < 0)
                {
                    d = bxvect * by - byvect * bx;
                    if (pragmas.klabs(d) < 65536 * 64)
                    {
                        s.ang -= (short)(512 + (Engine.krand() & 1024));
                        return 1;
                    }
                }
            }
        }
        return 0;
    }

    public static short furthestangle(short i, short angs)
    {
        short j = 0;
        int hitsect = 0;
        short hitwall = 0;
        short hitspr = 0;
        short furthest_angle = 0;
        short angincs = 0;
        int hx= 0;
        int hy= 0;
        int hz = 0;
        int d = 0;
        int greatestd = 0;
        spritetype s = Engine.board.sprite[i];

        greatestd = -(1 << 30);
        angincs = (short)(2048 / angs);

        if (s.picnum != DefineConstants.APLAYER)
        {
            if ((g_t[0] & 63) > 2)
            {
                return (short)(s.ang + 1024);
            }
        }

        for (j = s.ang; j < (2048 + s.ang); j += angincs)
        {
            Engine.board.hitscan(s.x, s.y, s.z - (8 << 8), s.sectnum, Engine.table.sintable[(j + 512) & 2047], Engine.table.sintable[j & 2047], 0, ref hitsect, ref hitwall, ref hitspr, ref hx,ref hy, ref hz, (((256) << 16) + 64));

            d = pragmas.klabs(hx - s.x) + pragmas.klabs(hy - s.y);

            if (d > greatestd)
            {
                greatestd = d;
                furthest_angle = j;
            }
        }
        return (short)(furthest_angle & 2047);
    }

    public static short furthestcanseepoint(short i, spritetype ts, ref int dax, ref int day)
    {
        short j = 0;
        int hitsect = 0;
        short hitwall = 0;
        short hitspr = 0;
        short angincs = 0;
        short tempang = 0;
        int hx = 0; //, d, cd, ca,tempx,tempy,cx,cy;
        int hy = 0;
        int hz = 0;
        int d = 0;
        int da = 0;
        spritetype s = Engine.board.sprite[i];

        if ((g_t[0] & 63) != 0)
        {
            return -1;
        }

        if (ud.multimode < 2 && ud.player_skill < 3)
        {
            angincs = (short)(2048 / 2);
        }
        else
        {
            angincs = (short)(2048 / (1 + (Engine.krand() & 1)));
        }

        for (j = ts.ang; j < (2048 + ts.ang); j += (short)(angincs - (Engine.krand() & 511)))
        {
            Engine.board.hitscan(ts.x, ts.y, ts.z - (16 << 8), ts.sectnum, Engine.table.sintable[(j + 512) & 2047], Engine.table.sintable[j & 2047], (int)(16384 - (Engine.krand() & 32767)), ref hitsect, ref hitwall, ref hitspr, ref hx, ref hy, ref hz, (((256) << 16) + 64));

            d = pragmas.klabs(hx - ts.x) + pragmas.klabs(hy - ts.y);
            da = pragmas.klabs(hx - s.x) + pragmas.klabs(hy - s.y);

            if (d < da)
            {
                if (Engine.board.cansee(hx, hy, hz, (short)hitsect, s.x, s.y, s.z - (16 << 8), s.sectnum))
                {
                    dax = hx;
                    day = hy;
                    return (short)hitsect;
                }
            }
        }
        return -1;
    }

    public static void alterang(short a)
    {
        short aang;
        short angdif;
        short goalang;
        short j;
        int ticselapsed;

        ticselapsed = (g_t[0]) & 31;

        aang = g_sp.ang;

        g_sp.xvel += (short)((g_t[0] - g_sp.xvel) / 5);
        if (g_sp.zvel < 648)
        {
            g_sp.zvel += (short)(((g_t[1] << 4) - g_sp.zvel) / 5);
        }

        if ((a & DefineConstants.seekplayer) != 0)
        {
            j = ps[g_p].holoduke_on;

            if (j >= 0 && Engine.board.cansee(Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z, Engine.board.sprite[j].sectnum, g_sp.x, g_sp.y, g_sp.z, g_sp.sectnum))
            {
                g_sp.owner = j;
            }
            else
            {
                g_sp.owner = ps[g_p].i;
            }

            if (Engine.board.sprite[g_sp.owner].picnum == DefineConstants.APLAYER)
            {
                goalang = (short)Engine.getangle(hittype[g_i].lastvx - g_sp.x, hittype[g_i].lastvy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(Engine.board.sprite[g_sp.owner].x - g_sp.x, Engine.board.sprite[g_sp.owner].y - g_sp.y);
            }

            if (g_sp.xvel != 0 && g_sp.picnum != DefineConstants.DRONE)
            {
                angdif = getincangle(aang, goalang);

                if (ticselapsed < 2)
                {
                    if (pragmas.klabs(angdif) < 256)
                    {
                        j = (short)(128 - (Engine.krand() & 256));
                        g_sp.ang += j;
                        if (hits(g_i) < 844)
                        {
                            g_sp.ang -= j;
                        }
                    }
                }
                else if (ticselapsed > 18 && ticselapsed < 26) // choose
                {
                    if (pragmas.klabs(angdif >> 2) < 128)
                    {
                        g_sp.ang = goalang;
                    }
                    else
                    {
                        g_sp.ang += (short)(angdif >> 2);
                    }
                }
            }
            else
            {
                g_sp.ang = goalang;
            }
        }

        if (ticselapsed < 1)
        {
            j = 2;
            if ((a & DefineConstants.furthestdir) != 0)
            {
                goalang = furthestangle(g_i, j);
                g_sp.ang = goalang;
                g_sp.owner = ps[g_p].i;
            }

            if ((a & DefineConstants.fleeenemy) != 0)
            {
                goalang = furthestangle(g_i, j);
                g_sp.ang = goalang; // += angdif; //  = getincangle(aang,goalang)>>1;
            }
        }
    }

    public static void move()
    {
        int l;
        short j;
        short a;
        short goalang;
        short angdif;
        int daxvel;

        a = g_sp.hitag;

        if (a == -1)
        {
            a = 0;
        }

        g_t[0]++;

        if ((a & DefineConstants.face_player) != 0)
        {
            if (ps[g_p].newowner >= 0)
            {
                goalang = (short)Engine.getangle(ps[g_p].oposx - g_sp.x, ps[g_p].oposy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);
            }
            angdif = (short)(getincangle(g_sp.ang, goalang) >> 2);
            if (angdif > -8 && angdif < 0)
            {
                angdif = 0;
            }
            g_sp.ang += angdif;
        }

        if ((a & DefineConstants.spin) != 0)
        {
            g_sp.ang += (short)(Engine.table.sintable[((g_t[0] << 3) & 2047)] >> 6);
        }

        if ((a & DefineConstants.face_player_slow) != 0)
        {
            if (ps[g_p].newowner >= 0)
            {
                goalang = (short)Engine.getangle(ps[g_p].oposx - g_sp.x, ps[g_p].oposy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);
            }
            angdif = (short)(pragmas.ksgn(getincangle(g_sp.ang, goalang)) << 5);
            if (angdif > -32 && angdif < 0)
            {
                angdif = 0;
                g_sp.ang = goalang;
            }
            g_sp.ang += angdif;
        }


        if ((a & DefineConstants.jumptoplayer) == DefineConstants.jumptoplayer)
        {
            if (g_t[0] < 16)
            {
                g_sp.zvel -= (short)((Engine.table.sintable[(512 + (g_t[0] << 4)) & 2047] >> 5));
            }
        }

        if ((a & DefineConstants.face_player_smart) != 0)
        {
            int newx;
            int newy;

            newx = ps[g_p].posx + (ps[g_p].posxv / 768);
            newy = ps[g_p].posy + (ps[g_p].posyv / 768);
            goalang = (short)Engine.getangle(newx - g_sp.x, newy - g_sp.y);
            angdif = (short)(getincangle(g_sp.ang, goalang) >> 2);
            if (angdif > -8 && angdif < 0)
            {
                angdif = 0;
            }
            g_sp.ang += angdif;
        }

        if (g_t[1] == 0 || a == 0)
        {
            if ((badguy(g_sp) != 0 && g_sp.extra <= 0) || (hittype[g_i].bposx != g_sp.x) || (hittype[g_i].bposy != g_sp.y))
            {
                hittype[g_i].bposx = g_sp.x;
                hittype[g_i].bposy = g_sp.y;
                Engine.board.setsprite(g_i, g_sp.x, g_sp.y, g_sp.z);
            }
            return;
        }

        if ((a & DefineConstants.geth) != 0)
        {
            g_sp.xvel += (short)((g_t[0] - g_sp.xvel) >> 1);
        }
        if ((a & DefineConstants.getv) != 0)
        {
            g_sp.zvel += (short)(((g_t[1] << 4) - g_sp.zvel) >> 1);
        }

        if ((a & DefineConstants.dodgebullet) != 0)
        {
            dodge(g_sp);
        }

        if (g_sp.picnum != DefineConstants.APLAYER)
        {
            alterang(a);
        }

        if (g_sp.xvel > -6 && g_sp.xvel < 6)
        {
            g_sp.xvel = 0;
        }

        a = badguy(g_sp);

        if (g_sp.xvel != 0 || g_sp.zvel != 0)
        {
            if (a != 0 && g_sp.picnum != DefineConstants.ROTATEGUN)
            {
                if ((g_sp.picnum == DefineConstants.DRONE || g_sp.picnum == DefineConstants.COMMANDER) && g_sp.extra > 0)
                {
                    if (g_sp.picnum == DefineConstants.COMMANDER)
                    {
                        hittype[g_i].floorz = l = Engine.board.getflorzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if (g_sp.z > (l - (8 << 8)))
                        {
                            if (g_sp.z > (l - (8 << 8)))
                            {
                                g_sp.z = l - (8 << 8);
                            }
                            g_sp.zvel = 0;
                        }

                        hittype[g_i].ceilingz = l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if ((g_sp.z - l) < (80 << 8))
                        {
                            g_sp.z = l + (80 << 8);
                            g_sp.zvel = 0;
                        }
                    }
                    else
                    {
                        if (g_sp.zvel > 0)
                        {
                            hittype[g_i].floorz = l = Engine.board.getflorzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                            if (g_sp.z > (l - (30 << 8)))
                            {
                                g_sp.z = l - (30 << 8);
                            }
                        }
                        else
                        {
                            hittype[g_i].ceilingz = l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                            if ((g_sp.z - l) < (50 << 8))
                            {
                                g_sp.z = l + (50 << 8);
                                g_sp.zvel = 0;
                            }
                        }
                    }
                }
                else if (g_sp.picnum != DefineConstants.ORGANTIC)
                {
                    if (g_sp.zvel > 0 && hittype[g_i].floorz < g_sp.z)
                    {
                        g_sp.z = hittype[g_i].floorz;
                    }
                    if (g_sp.zvel < 0)
                    {
                        l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if ((g_sp.z - l) < (66 << 8))
                        {
                            g_sp.z = l + (66 << 8);
                            g_sp.zvel >>= 1;
                        }
                    }
                }
            }
            else if (g_sp.picnum == DefineConstants.APLAYER)
            {
                if ((g_sp.z - hittype[g_i].ceilingz) < (32 << 8))
                {
                    g_sp.z = hittype[g_i].ceilingz + (32 << 8);
                }
            }

            daxvel = g_sp.xvel;
            angdif = g_sp.ang;

            if (a != 0 && g_sp.picnum != DefineConstants.ROTATEGUN)
            {
                if (g_x < 960 && g_sp.xrepeat > 16)
                {

                    daxvel = -(1024 - g_x);
                    angdif = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);

                    if (g_x < 512)
                    {
                        ps[g_p].posxv = 0;
                        ps[g_p].posyv = 0;
                    }
                    else
                    {
                        ps[g_p].posxv = pragmas.mulscale(ps[g_p].posxv, dukefriction - 0x2000, 16);
                        ps[g_p].posyv = pragmas.mulscale(ps[g_p].posyv, dukefriction - 0x2000, 16);
                    }
                }
                else if (g_sp.picnum != DefineConstants.DRONE && g_sp.picnum != DefineConstants.SHARK && g_sp.picnum != DefineConstants.COMMANDER)
                {
                    if (hittype[g_i].bposz != g_sp.z || (ud.multimode < 2 && ud.player_skill < 2))
                    {
                        if ((g_t[0] & 1) != 0 || ps[g_p].actorsqu == g_i)
                        {
                            return;
                        }
                        else
                        {
                            daxvel <<= 1;
                        }
                    }
                    else
                    {
                        if ((g_t[0] & 3) != 0 || ps[g_p].actorsqu == g_i)
                        {
                            return;
                        }
                        else
                        {
                            daxvel <<= 2;
                        }
                    }
                }
            }

            hittype[g_i].movflag = (short)movesprite(g_i, (daxvel * (Engine.table.sintable[(angdif + 512) & 2047])) >> 14, (daxvel * (Engine.table.sintable[angdif & 2047])) >> 14, g_sp.zvel, (uint)(((1) << 16) + 1));
        }

        if (a != 0)
        {
            if ((Engine.board.sector[g_sp.sectnum].ceilingstat & 1) != 0)
            {
                g_sp.shade += (sbyte)((Engine.board.sector[g_sp.sectnum].ceilingshade - g_sp.shade) >> 1);
            }
            else
            {
                g_sp.shade += (sbyte)((Engine.board.sector[g_sp.sectnum].floorshade - g_sp.shade) >> 1);
            }

            if (Engine.board.sector[g_sp.sectnum].floorpicnum == DefineConstants.MIRROR)
            {
                Engine.board.deletesprite(g_i);
            }
        }
    }

    public static int parse()
    {
        if (killit_flag != 0)
        {
            return 1;
        }

        //    if(*it == 1668249134L) gameexit("\nERR");
        //Engine.Printf("Executing command: " + scriptptr.buffer[insptr]);
        switch (scriptptr.buffer[insptr])
        {
            case 3:
                ConActions.ifrnd();
                break;
            case 45:
                ConActions.ifcanshoottarget();
                break;
            case 91:
                ConActions.ifcanseetarget();
                break;

            case 49:
                ConActions.ifactornotstayput();
                break;
            case 5:
                ConActions.ifcansee();
                break;

            case 6:
                ConActions.ifhitweapon();
                break;
            case 27:
                ConActions.ifsquished();
                break;
            case 26:
                ConActions.ifdead();
                break;
            case 24:
                ConActions.ai();
                break;
            case 7:
                ConActions.action();
                break;

            case 8:
                ConActions.ifpdistl();
                break;
            case 9:
                ConActions.ifpdistg();
                break;
            case 10:
                ConActions._else();
                break;
            case 100:
                ConActions.addstrength();
                break;
            case 11:
                ConActions.strength();
                break;
            case 94:
                ConActions.ifgotweaponce();
                break;
            case 95:
                ConActions.getlastpal();
                break;
            case 104:
                ConActions.tossweapon();
                break;
            case 106:
                ConActions.nullop();
                break;
            case 97:
                ConActions.mikesnd();
                break;
            case 96:
                ConActions.pkick();
                break;
            case 28:
                ConActions.sizeto();
                break;
            case 99:
                ConActions.sizeat();
                break;
            case 13:
                ConActions.shoot();
                break;
            case 87:
                ConActions.soundonce();
                break;
            case 89:
                ConActions.stopsound();
                break;
            case 92:
                ConActions.globalsound();
                break;
            case 15:
                ConActions.sound();
                break;
            case 84:
                ConActions.tip();
                break;
            case 16:
                ConActions.fall();
                break;
            case 4: // enda
            case 12: // break;
            case 18: // ends
                return 1;
            case 30: // close bracket
                insptr++;
                return 1;
            case 2:
                ConActions.addammo();
                break;
            case 86:
                ConActions.money();
                break;
            case 102:
                ConActions.mail();
                break;
            case 105:
                ConActions.sleeptime();
                break;
            case 103:
                ConActions.paper();
                break;
            case 88:
                ConActions.addkills();
                break;
            case 93:
                ConActions.lotsofglass();
                break;
            case 22:
                ConActions.killit();
                break;
            case 23:
                ConActions.addweapon();
                break;
            case 68:
                ConActions.debug();
                break;
            case 69:
                ConActions.endofgame();
                break;
            case 25:
                ConActions.addphealth();
                break;
            case 17:
                ConActions.state();
                break;
            case 29:
                ConActions.openbracket();
                break;
            case 32:
                ConActions.move();
                break;
            case 31:
                ConActions.spawn();
                break;
            case 33:
                ConActions.ifwasweapon();
                break;
            case 21:
                ConActions.ifai();
                break;
            case 34:
                ConActions.ifaction();
                break;
            case 35:
                ConActions.ifactioncount();
                break;
            case 36:
                ConActions.resetactioncount();
                break;
            case 37:
                ConActions.debris();
                break;
            case 52:
                ConActions.count();
                break;
            case 101:
                ConActions.cstator();
                break;
            case 110:
                ConActions.clipdist();
                break;
            case 40:
                ConActions.cstat();
                break;
            case 41:
                ConActions.ifmove();
                break;
            case 42:
                ConActions.resetplayer();
                break;
            case 43:
                ConActions.ifonwater();
                break;
            case 44:
                ConActions.ifinwater();
                break;
            case 46:
                ConActions.ifcount();
                break;
            case 53:
                ConActions.ifactor();
                break;
            case 47:
                ConActions.resetcount();
                break;
            case 48:
                ConActions.addinventory();
                break;
            case 50:
                ConActions.hitradius();
                break;
            case 51:
                ConActions.ifp();
                break;
            case 56:
                ConActions.ifstrength();
                break;
            case 58:
                ConActions.guts();
                break;
            case 59:
                ConActions.ifspawnedby();
                break;
            case 61:
                ConActions.wackplayer();
                return 0;
            case 62:
                ConActions.ifgapzl();
                break;
            case 63:
                ConActions.ifhitspace();
                break;
            case 64:
                ConActions.ifoutside();
                break;
            case 65:
                ConActions.ifmultiplayer();
                break;
            case 66:
                ConActions.operate();
                break;
            case 67:
                ConActions.ifinspace();
                break;

            case 74:
                ConActions.spritepal();
                break;

            case 77:
                ConActions.cactor();
                break;

            case 70:
                ConActions.ifbulletnear();
                break;
            case 71:
                ConActions.ifrespawn();
                break;
            case 72:
                ConActions.iffloordistl();
                break;
            case 73:
                ConActions.ifceilingdistl();
                break;
            case 14:
                ConActions.palfrom();
                break;

            /*        case 74:
                        insptr++;
                        getglobalz(g_i);
                        parseifelse( (( hittype[g_i].floorz - hittype[g_i].ceilingz ) >> 8 ) >= (short)scriptptr.buffer[insptr]);
                        break;
            */
            case 78:
                ConActions.ifphealthl();
                break;

            case 75:
                ConActions.ifpinventory();
                break;
            case 38:
                ConActions.pstomp();
                break;
            case 90:
                ConActions.ifawayfromwall();
                break;
            case 80:
                ConActions.quote();
                break;
            case 81:
                ConActions.ifinouterspace();
                break;
            case 82:
                ConActions.ifnotmoving();
                break;
            case 83:
                ConActions.respawnhitag();
                break;
            case 85:
                ConActions.ifspritepal();
                break;

            case 111:
                ConActions.ifangdiffl();
                break;

            case 109:
                ConActions.ifnosounds();
                break;
            default:
                throw new Exception("Unknown command!");
                killit_flag = (char)1;
                break;
        }
        return 0;
    }

    public static void parseifelse(bool condition)
    {
        if (condition)
        {
            insptr += 2;
            parse();
        }
        else
        {
            insptr = scriptptr.buffer[insptr + 1];// (int)*(insptr + 1);
            if (scriptptr.buffer[insptr] == 10)
            {
                insptr += 2;
                parse();
            }
        }
    }

    public static void execute(int i, short p, int x)
    {
        char done;

        g_i = (short)i;
        g_p = p;
        g_x = x;
        g_sp = Engine.board.sprite[g_i];
        g_t = hittype[g_i].temp_data;

        if (scriptptr.buffer[actorscrptr[g_sp.picnum]] == 0)
        {
            return;
        }

        insptr = 4 +(actorscrptr[g_sp.picnum]); 

        killit_flag = (char)0;

        if (g_sp.sectnum < 0 || g_sp.sectnum >= DefineConstants.MAXSECTORS)
        {
            if (badguy(g_sp) != 0)
            {
                ps[g_p].actors_killed++;
            }
            Engine.board.deletesprite(g_i);
            return;
        }

        g_t.inScriptExecute = true;
        if (g_t[4] != 0)
        {
            g_sp.lotag += (DefineConstants.TICRATE / 26);
            if (g_sp.lotag > scriptptr.buffer[g_t[4] + 16])
            {
                g_t[2]++;
                g_sp.lotag = 0;
                g_t[3] += scriptptr.buffer[(g_t[4] + 12)];
            }
            if (pragmas.klabs(g_t[3]) >= pragmas.klabs(scriptptr.buffer[(g_t[4] + 4)] * scriptptr.buffer[(g_t[4] + 12)]))
            {
                g_t[3] = 0;
            }
        }
        
        do
        {
            done = (char)parse();
        } while (done == 0);
        g_t.inScriptExecute = false;

        if (killit_flag == 1)
        {
            if (ps[g_p].actorsqu == g_i)
            {
                ps[g_p].actorsqu = -1;
            }
            Engine.board.deletesprite(g_i);
        }
        else
        {
            move();

            if (g_sp.statnum == 1)
            {
                if (badguy(g_sp) != 0)
                {
                    if (g_sp.xrepeat > 60)
                    {
                        return;
                    }
                    if (ud.respawn_monsters == 1 && g_sp.extra <= 0)
                    {
                        return;
                    }
                }
                else if (ud.respawn_items == 1 && (g_sp.cstat & 32768) != 0)
                {
                    return;
                }

                if (hittype[g_i].timetosleep > 1)
                {
                    hittype[g_i].timetosleep--;
                }
                else if (hittype[g_i].timetosleep == 1)
                {
                    Engine.board.changespritestat(g_i, 2);
                }
            }

            else if (g_sp.statnum == 6)
            {
                switch (g_sp.picnum)
                {
                    case DefineConstants.RUBBERCAN:
                    case DefineConstants.EXPLODINGBARREL:
                    case DefineConstants.WOODENHORSE:
                    case DefineConstants.HORSEONSIDE:
                    case DefineConstants.CANWITHSOMETHING:
                    case DefineConstants.FIREBARREL:
                    case DefineConstants.NUKEBARREL:
                    case DefineConstants.NUKEBARRELDENTED:
                    case DefineConstants.NUKEBARRELLEAKED:
                    case DefineConstants.TRIPBOMB:
                    case DefineConstants.EGG:
                        if (hittype[g_i].timetosleep > 1)
                        {
                            hittype[g_i].timetosleep--;
                        }
                        else if (hittype[g_i].timetosleep == 1)
                        {
                            Engine.board.changespritestat(g_i, 2);
                        }
                        break;
                }
            }
        }
    }


}