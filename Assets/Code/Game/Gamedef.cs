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
    internal static int[] g_t;
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
        int j;
        bool jj = false;
        int l;
        int s;
        short temphit = 0;

        if (killit_flag != 0)
        {
            return 1;
        }

        //    if(*it == 1668249134L) gameexit("\nERR");
        //Engine.Printf("Executing command: " + scriptptr.buffer[insptr]);
        switch (scriptptr.buffer[insptr])
        {
            case 3:
                insptr++;
                parseifelse(((Engine.krand() >> 8) >= (255 - (scriptptr.buffer[insptr]))));
                break;
            case 45:

                if (g_x > 1024)
                {
                   // short temphit;
                    short sclip;
                    short angdif;

                    if (badguy(g_sp) != 0 && g_sp.xrepeat > 56)
                    {
                        sclip = 3084;
                        angdif = 48;
                    }
                    else
                    {
                        sclip = 768;
                        angdif = 16;
                    }

                    j = hitasprite(g_i, ref temphit);
                    if (j == (1 << 30))
                    {
                        parseifelse(true);
                        break;
                    }
                    if (j > sclip)
                    {
                        if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                        {
                            j = 0;
                        }
                        else
                        {
                            g_sp.ang += angdif;
                            j = hitasprite(g_i, ref temphit);
                            g_sp.ang -= angdif;
                            if (j > sclip)
                            {
                                if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                                {
                                    j = 0;
                                }
                                else
                                {
                                    g_sp.ang -= angdif;
                                    j = hitasprite(g_i, ref temphit);
                                    g_sp.ang += angdif;
                                    if (j > 768)
                                    {
                                        if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                                        {
                                            j = 0;
                                        }
                                        else
                                        {
                                            j = 1;
                                        }
                                    }
                                    else
                                    {
                                        j = 0;
                                    }
                                }
                            }
                            else
                            {
                                j = 0;
                            }
                        }
                    }
                    else
                    {
                        j = 0;
                    }
                }
                else
                {
                    j = 1;
                }

                parseifelse(j != 0);
                break;
            case 91:
                jj = Engine.board.cansee(g_sp.x, g_sp.y, (short)(g_sp.z - ((Engine.krand() & 41) << 8)), g_sp.sectnum, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz, Engine.board.sprite[ps[g_p].i].sectnum);
                parseifelse(jj);
                if (jj)
                {
                    hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
                }
                break;

            case 49:
                parseifelse(hittype[g_i].actorstayput == -1);
                break;
            case 5:
                {
                    spritetype ss;
                    short sect;

                    if (ps[g_p].holoduke_on >= 0)
                    {
                        ss = Engine.board.sprite[ps[g_p].holoduke_on];
                        jj = Engine.board.cansee(g_sp.x, g_sp.y, (int)(g_sp.z - (Engine.krand() & ((32 << 8) - 1))), g_sp.sectnum, ss.x, ss.y, ss.z, ss.sectnum);
                        if (jj == false)
                        {
                            ss = Engine.board.sprite[ps[g_p].i];
                        }
                    }
                    else
                    {
                        ss = Engine.board.sprite[ps[g_p].i];
                    }

                    jj = Engine.board.cansee(g_sp.x, g_sp.y, (int)(g_sp.z - (Engine.krand() & ((47 << 8)))), g_sp.sectnum, ss.x, ss.y, ss.z - (24 << 8), ss.sectnum);

                    if (jj == false)
                    {
                        if ((pragmas.klabs(hittype[g_i].lastvx - g_sp.x) + pragmas.klabs(hittype[g_i].lastvy - g_sp.y)) < (pragmas.klabs(hittype[g_i].lastvx - ss.x) + pragmas.klabs(hittype[g_i].lastvy - ss.y)))
                        {
                            jj = false;
                        }

                        if (jj == false)
                        {
                            j = furthestcanseepoint(g_i, ss, ref hittype[g_i].lastvx, ref hittype[g_i].lastvy);

                            if (j == -1)
                            {
                                jj = false;
                            }
                            else
                            {
                                jj = true;
                            }
                        }
                    }
                    else
                    {
                        hittype[g_i].lastvx = ss.x;
                        hittype[g_i].lastvy = ss.y;
                    }

                    if (jj && (g_sp.statnum == 1 || g_sp.statnum == 6))
                    {
                        hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
                    }

                    parseifelse(jj);
                    break;
                }

            case 6:
                parseifelse(ifhitbyweapon(g_i) >= 0);
                break;
            case 27:
                parseifelse(ifsquished(g_i, g_p) == 1);
                break;
            case 26:
                {
                    j = g_sp.extra;
                    if (g_sp.picnum == DefineConstants.APLAYER)
                    {
                        j--;
                    }
                    parseifelse(j < 0);
                }
                break;
            case 24:
                insptr++;
                g_t[5] = insptr;
                g_t[4] = g_t[5]; // Action
                g_t[1] = g_t[5] + 4; // move
                g_sp.hitag = (short)scriptptr.buffer[g_t[5] + 8]; // Ai
                g_t[0] = g_t[2] = g_t[3] = 0;
                if ((g_sp.hitag & DefineConstants.random_angle) != 0)
                {
                    g_sp.ang = (short)(Engine.krand() & 2047);
                }
                insptr++;
                break;
            case 7:
                insptr++;
                g_t[2] = 0;
                g_t[3] = 0;
                g_t[4] = insptr;
                insptr++;
                break;

            case 8:
                insptr++;
                parseifelse(g_x < scriptptr.buffer[insptr]);
                if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
                {
                    hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
                }
                break;
            case 9:
                insptr++;
                parseifelse(g_x > scriptptr.buffer[insptr]);
                if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
                {
                    hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
                }
                break;
            case 10:
                insptr = scriptptr.buffer[insptr + 1];
                break;
            case 100:
                insptr++;
                g_sp.extra += (short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 11:
                insptr++;
                g_sp.extra = (short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 94:
                insptr++;

                if (ud.coop >= 1 && ud.multimode > 1)
                {
                    if (scriptptr.buffer[insptr] == 0)
                    {
                        for (j = 0; j < ps[g_p].weapreccnt; j++)
                        {
                            if (ps[g_p].weaprecs[j] == g_sp.picnum)
                            {
                                break;
                            }
                        }

                        parseifelse(j < ps[g_p].weapreccnt && g_sp.owner == g_i);
                    }
                    else if (ps[g_p].weapreccnt < 16)
                    {
                        ps[g_p].weaprecs[ps[g_p].weapreccnt++] = g_sp.picnum;
                        parseifelse(g_sp.owner == g_i);
                    }
                }
                else
                {
                    parseifelse(false);
                }
                break;
            case 95:
                insptr++;
                if (g_sp.picnum == DefineConstants.APLAYER)
                {
                    g_sp.pal = (byte)ps[g_sp.yvel].palookup;
                }
                else
                {
                    g_sp.pal = (byte)hittype[g_i].tempang;
                }
                hittype[g_i].tempang = 0;
                break;
            case 104:
                insptr++;
                checkweapons(ps[g_sp.yvel]);
                break;
            case 106:
                insptr++;
                break;
            case 97:
                insptr++;
                if (Sound[g_sp.yvel].num == 0)
                {
                    spritesound((ushort)g_sp.yvel, g_i);
                }
                break;
            case 96:
                insptr++;

                if (ud.multimode > 1 && g_sp.picnum == DefineConstants.APLAYER)
                {
                    if (ps[otherp].quick_kick == 0)
                    {
                        ps[otherp].quick_kick = 14;
                    }
                }
                else if (g_sp.picnum != DefineConstants.APLAYER && ps[g_p].quick_kick == 0)
                {
                    ps[g_p].quick_kick = 14;
                }
                break;
            case 28:
                insptr++;

                j = ((scriptptr.buffer[insptr]) - g_sp.xrepeat) << 1;
                g_sp.xrepeat += (byte)pragmas.ksgn(j);

                insptr++;

                if ((g_sp.picnum == DefineConstants.APLAYER && g_sp.yrepeat < 36) || insptr < g_sp.yrepeat || ((g_sp.yrepeat * (Engine.tilesizy[g_sp.picnum] + 8)) << 2) < (hittype[g_i].floorz - hittype[g_i].ceilingz))
                {
                    j = ((scriptptr.buffer[insptr]) - g_sp.yrepeat) << 1;
                    if (pragmas.klabs(j) != 0)
                    {
                        g_sp.yrepeat += (byte)pragmas.ksgn(j);
                    }
                }

                insptr++;

                break;
            case 99:
                insptr++;
                g_sp.xrepeat = (byte)scriptptr.buffer[insptr];
                insptr++;
                g_sp.yrepeat = (byte)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 13:
                insptr++;
                shoot(g_i, (short)scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 87:
                insptr++;
                if (Sound[scriptptr.buffer[insptr]].num == 0)
                {
                    spritesound((short)scriptptr.buffer[insptr], g_i);
                }
                insptr++;
                break;
            case 89:
                insptr++;
                if (Sound[scriptptr.buffer[insptr]].num > 0)
                {
                    stopsound(scriptptr.buffer[insptr]);
                }
                insptr++;
                break;
            case 92:
                insptr++;
                if (g_p == screenpeek || ud.coop == 1)
                {
                    spritesound(scriptptr.buffer[insptr], ps[screenpeek].i);
                }
                insptr++;
                break;
            case 15:
                insptr++;
                spritesound(scriptptr.buffer[insptr], g_i);
                insptr++;
                break;
            case 84:
                insptr++;
                ps[g_p].tipincs = 26;
                break;
            case 16:
                insptr++;
                g_sp.xoffset = 0;
                g_sp.yoffset = 0;
                //            if(!gotz)
                {
                    int c;

                    if (floorspace(g_sp.sectnum) != 0)
                    {
                        c = 0;
                    }
                    else
                    {
                        if (ceilingspace(g_sp.sectnum) != 0 || Engine.board.sector[g_sp.sectnum].lotag == 2)
                        {
                            c = gc / 6;
                        }
                        else
                        {
                            c = gc;
                        }
                    }

                    if (hittype[g_i].cgg <= 0 || (Engine.board.sector[g_sp.sectnum].floorstat & 2) != 0)
                    {
                        getglobalz(g_i);
                        hittype[g_i].cgg = (char)6;
                    }
                    else
                    {
                        hittype[g_i].cgg--;
                    }

                    if (g_sp.z < (hittype[g_i].floorz - (1 << 8)))
                    {
                        g_sp.zvel += (short)c;
                        g_sp.z += g_sp.zvel;

                        if (g_sp.zvel > 6144)
                        {
                            g_sp.zvel = 6144;
                        }
                    }
                    else
                    {
                        g_sp.z = hittype[g_i].floorz - (1 << 8);

                        if (badguy(g_sp) != 0 || (g_sp.picnum == DefineConstants.APLAYER && g_sp.owner >= 0))
                        {

                            if (g_sp.zvel > 3084 && g_sp.extra <= 1)
                            {
                                if (g_sp.pal != 1 && g_sp.picnum != DefineConstants.DRONE)
                                {
                                    if (g_sp.picnum == DefineConstants.APLAYER && g_sp.extra > 0)
                                    {
                                        goto SKIPJIBS;
                                    }
                                    guts(g_sp, DefineConstants.JIBS6, 15, g_p);
                                    spritesound(DefineConstants.SQUISHED, g_i);
                                    spawn(g_i, DefineConstants.BLOODPOOL);
                                }

                                SKIPJIBS:

                                hittype[g_i].picnum = DefineConstants.SHOTSPARK1;
                                hittype[g_i].extra = 1;
                                g_sp.zvel = 0;
                            }
                            else if (g_sp.zvel > 2048 && Engine.board.sector[g_sp.sectnum].lotag != 1)
                            {

                                j = g_sp.sectnum;
                                short _jj = (short)j;
                                Engine.board.pushmove(ref g_sp.x, ref g_sp.y, ref g_sp.z, ref _jj, 128, (4 << 8), (4 << 8), (((1) << 16) + 1));
                                j = _jj;
                                if (j != g_sp.sectnum && j >= 0 && j < DefineConstants.MAXSECTORS)
                                {
                                    Engine.board.changespritesect(g_i, (short)j);
                                }

                                spritesound(DefineConstants.THUD, g_i);
                            }
                        }
                        if (Engine.board.sector[g_sp.sectnum].lotag == 1)
                        {
                            switch (g_sp.picnum)
                            {
                                case DefineConstants.OCTABRAIN:
                                case DefineConstants.COMMANDER:
                                case DefineConstants.DRONE:
                                    break;
                                default:
                                    g_sp.z += (24 << 8);
                                    break;
                            }
                        }
                        else
                        {
                            g_sp.zvel = 0;
                        }
                    }
                }

                break;
            case 4:
            case 12:
            case 18:
                return 1;
            case 30:
                insptr++;
                return 1;
            case 2:
                insptr++;
                if (ps[g_p].ammo_amount[scriptptr.buffer[insptr]] >= max_ammo_amount[scriptptr.buffer[insptr]])
                {
                    killit_flag = (char)2;
                    break;
                }
                addammo((short)scriptptr.buffer[insptr], ps[g_p], (short)scriptptr.buffer[insptr + 1]);
                if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
                {
                    if (ps[g_p].gotweapon[scriptptr.buffer[insptr]])
                    {
                        addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
                    }
                }
                insptr += 2;
                break;
            case 86:
                insptr++;
                lotsofmoney(g_sp, scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 102:
                insptr++;
                lotsofmail(g_sp, (short)scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 105:
                insptr++;
                hittype[g_i].timetosleep = (short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 103:
                insptr++;
                lotsofpaper(g_sp, (short)scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 88:
                insptr++;
                ps[g_p].actors_killed += (char)scriptptr.buffer[insptr];
                hittype[g_i].actorstayput = -1;
                insptr++;
                break;
            case 93:
                insptr++;
                spriteglass(g_i, (short)scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 22:
                insptr++;
                killit_flag = (char)1;
                break;
            case 23:
                insptr++;
                if (ps[g_p].gotweapon[(short)scriptptr.buffer[insptr]] == false)
                {
                    addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
                }
                else if (ps[g_p].ammo_amount[(short)scriptptr.buffer[insptr]] >= max_ammo_amount[(short)scriptptr.buffer[insptr]])
                {
                    killit_flag = (char)2;
                    break;
                }
                addammo((short)scriptptr.buffer[insptr], ps[g_p], ((short)scriptptr.buffer[insptr + 1]));
                if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
                {
                    if (ps[g_p].gotweapon[(short)scriptptr.buffer[insptr]])
                    {
                        addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
                    }
                }
                insptr += 2;
                break;
            case 68:
                insptr++;
                //Engine.Printf(scriptptr.buffer[insptr]);
                insptr++;
                break;
            case 69:
                insptr++;
                ps[g_p].timebeforeexit = (short)scriptptr.buffer[insptr];
                ps[g_p].customexitsound = -1;
                ud.eog = 1;
                insptr++;
                break;
            case 25:
                insptr++;

                if (ps[g_p].newowner >= 0)
                {
                    ps[g_p].newowner = -1;
                    ps[g_p].posx = ps[g_p].oposx;
                    ps[g_p].posy = ps[g_p].oposy;
                    ps[g_p].posz = ps[g_p].oposz;
                    ps[g_p].ang = ps[g_p].oang;
                    Engine.board.updatesector(ps[g_p].posx, ps[g_p].posy, ref ps[g_p].cursectnum);
                    //setpal(ps[g_p]); // jmarshall palette.

                    j = Engine.board.headspritestat[1];
                    while (j >= 0)
                    {
                        if (Engine.board.sprite[j].picnum == DefineConstants.CAMERA1)
                        {
                            Engine.board.sprite[j].yvel = 0;
                        }
                        j = Engine.board.nextspritestat[j];
                    }
                }

                j = Engine.board.sprite[ps[g_p].i].extra;

                if (g_sp.picnum != DefineConstants.ATOMICHEALTH)
                {
                    if (j > max_player_health && (short)scriptptr.buffer[insptr] > 0)
                    {
                        insptr++;
                        break;
                    }
                    else
                    {
                        if (j > 0)
                        {
                            j += (short)scriptptr.buffer[insptr];
                        }
                        if (j > max_player_health && (short)scriptptr.buffer[insptr] > 0)
                        {
                            j = max_player_health;
                        }
                    }
                }
                else
                {
                    if (j > 0)
                    {
                        j += (short)scriptptr.buffer[insptr];
                    }
                    if (j > (max_player_health << 1))
                    {
                        j = (max_player_health << 1);
                    }
                }

                if (j < 0)
                {
                    j = 0;
                }

                if (ud.god == 0)
                {
                    if ((short)scriptptr.buffer[insptr] > 0)
                    {
                        if ((j - (short)scriptptr.buffer[insptr]) < (max_player_health >> 2) && j >= (max_player_health >> 2))
                        {
                            spritesound(DefineConstants.DUKE_GOTHEALTHATLOW, ps[g_p].i);
                        }

                        ps[g_p].last_extra = (short)j;
                    }

                    Engine.board.sprite[ps[g_p].i].extra = (short)j;
                }

                insptr++;
                break;
            case 17:
                {
                    //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
                    //ORIGINAL LINE: int *tempscrptr;
                    int tempscrptr;

                    tempscrptr = insptr + 2;

                    insptr = (scriptptr.buffer[insptr + 1]); // jmarshall 
                    while (true)
                    {
                        if (parse() != 0)
                        {
                            break;
                        }
                    }
                    insptr = tempscrptr;
                }
                break;
            case 29:
                insptr++;
                while (true)
                {
                    if (parse() != 0)
                    {
                        break;
                    }
                }
                break;
            case 32:
                g_t[0] = 0;
                insptr++;
                g_t[1] = scriptptr.buffer[insptr];
                insptr++;
                g_sp.hitag = (short)scriptptr.buffer[insptr];
                insptr++;
                if ((g_sp.hitag & DefineConstants.random_angle) != 0)
                {
                    g_sp.ang = (short)(Engine.krand() & 2047);
                }
                break;
            case 31:
                insptr++;
                if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
                {
                    spawn(g_i, (short)scriptptr.buffer[insptr]);
                }
                insptr++;
                break;
            case 33:
                insptr++;
                parseifelse(hittype[g_i].picnum == (short)scriptptr.buffer[insptr]);
                break;
            case 21:
                insptr++;
                parseifelse(scriptptr.buffer[g_t[5]] == (short)scriptptr.buffer[insptr]);
                break;
            case 34:
                insptr++;
                parseifelse(g_t[4] == (short)scriptptr.buffer[insptr]);
                break;
            case 35:
                insptr++;
                parseifelse(g_t[2] >= (short)scriptptr.buffer[insptr]);
                break;
            case 36:
                insptr++;
                g_t[2] = 0;
                break;
            case 37:
                {
                    short dnum;

                    insptr++;
                    dnum = (short)scriptptr.buffer[insptr];
                    insptr++;

                    if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
                    {
                        for (j = ((short)scriptptr.buffer[insptr]) - 1; j >= 0; j--)
                        {
                            if (g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                            {
                                s = 0;
                            }
                            else
                            {
                                s = (short)(Engine.krand() % 3);
                            }

                            l = EGS(g_sp.sectnum, g_sp.x + (Engine.krand() & 255) - 128, g_sp.y + (Engine.krand() & 255) - 128, g_sp.z - (8 << 8) - (Engine.krand() & 8191), dnum + s, g_sp.shade, (sbyte)(32 + (Engine.krand() & 15)), (sbyte)(32 + (Engine.krand() & 15)), (short)(Engine.krand() & 2047), (short)((Engine.krand() & 127) + 32), -(Engine.krand() & 2047), g_i, 5);
                            if (g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                            {
                                Engine.board.sprite[l].yvel = weaponsandammosprites[j % 14];
                            }
                            else
                            {
                                Engine.board.sprite[l].yvel = -1;
                            }
                            Engine.board.sprite[l].pal = g_sp.pal;
                        }
                    }
                    insptr++;
                }
                break;
            case 52:
                insptr++;
                g_t[0] = (short)(short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 101:
                insptr++;
                g_sp.cstat |= (short)(short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 110:
                insptr++;
                g_sp.clipdist = (byte)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 40:
                insptr++;
                g_sp.cstat = (short)(short)scriptptr.buffer[insptr];
                insptr++;
                break;
            case 41:
                insptr++;
                parseifelse(scriptptr.buffer[g_t[1]] == (short)scriptptr.buffer[insptr]);
                break;
            case 42:
                insptr++;

                if (ud.multimode < 2)
                {
                    if (lastsavedpos >= 0 && ud.recstat != 2)
                    {
                        ps[g_p].gm = DefineConstants.MODE_MENU;
                        {
                            KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
                        };
                        cmenu(15000);
                    }
                    else
                    {
                        ps[g_p].gm = DefineConstants.MODE_RESTART;
                    }
                    killit_flag = (char)2;
                }
                else
                {
                    pickrandomspot(g_p);
                    g_sp.x = hittype[g_i].bposx = ps[g_p].bobposx = ps[g_p].oposx = ps[g_p].posx;
                    g_sp.y = hittype[g_i].bposy = ps[g_p].bobposy = ps[g_p].oposy = ps[g_p].posy;
                    g_sp.z = hittype[g_i].bposy = ps[g_p].oposz = ps[g_p].posz;
                    Engine.board.updatesector(ps[g_p].posx, ps[g_p].posy, ref ps[g_p].cursectnum);
                    Engine.board.setsprite(ps[g_p].i, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz + (38 << 8));
                    g_sp.cstat = 257;

                    g_sp.shade = -12;
                    g_sp.clipdist = 64;
                    g_sp.xrepeat = 42;
                    g_sp.yrepeat = 36;
                    g_sp.owner = g_i;
                    g_sp.xoffset = 0;
                    //g_sp.pal = ps[g_p].palookup; // jmarshall palette

                    ps[g_p].last_extra = g_sp.extra = (short)max_player_health;
                    ps[g_p].wantweaponfire = -1;
                    ps[g_p].horiz = 100;
                    ps[g_p].on_crane = -1;
                    ps[g_p].frag_ps = g_p;
                    ps[g_p].horizoff = 0;
                    ps[g_p].opyoff = 0;
                    ps[g_p].wackedbyactor = -1;
                    ps[g_p].shield_amount = (short)max_armour_amount;
                    ps[g_p].dead_flag = 0;
                    ps[g_p].pals_time = 0;
                    ps[g_p].footprintcount = (char)0;
                    ps[g_p].weapreccnt = 0;
                    ps[g_p].fta = 0;
                    ps[g_p].ftq = 0;
                    ps[g_p].posxv = ps[g_p].posyv = 0;
                    ps[g_p].rotscrnang = 0;

                    ps[g_p].falling_counter = (char)0;

                    hittype[g_i].extra = -1;
                    hittype[g_i].owner = g_i;

                    hittype[g_i].cgg = (char)0;
                    hittype[g_i].movflag = 0;
                    hittype[g_i].tempang = 0;
                    hittype[g_i].actorstayput = -1;
                    hittype[g_i].dispicnum = 0;
                    hittype[g_i].owner = ps[g_p].i;

                    resetinventory(g_p);
                    resetweapons(g_p);

                    cameradist = 0;
                    cameraclock = totalclock;
                }
                // setpal(ps[g_p]);// jmarshall palette

                break;
            case 43:
                parseifelse(pragmas.klabs(g_sp.z - Engine.board.sector[g_sp.sectnum].floorz) < (32 << 8) && Engine.board.sector[g_sp.sectnum].lotag == 1);
                break;
            case 44:
                parseifelse(Engine.board.sector[g_sp.sectnum].lotag == 2);
                break;
            case 46:
                insptr++;
                parseifelse(g_t[0] >= (short)scriptptr.buffer[insptr]);
                break;
            case 53:
                insptr++;
                parseifelse(g_sp.picnum == (short)scriptptr.buffer[insptr]);
                break;
            case 47:
                insptr++;
                g_t[0] = 0;
                break;
            case 48:
                insptr += 2;
                switch ((short)scriptptr.buffer[insptr - 1])
                {
                    case 0:
                        ps[g_p].steroids_amount = (short)scriptptr.buffer[insptr];
                        ps[g_p].inven_icon = (char)2;
                        break;
                    case 1:
                        ps[g_p].shield_amount += (short)scriptptr.buffer[insptr]; // 100;
                        if (ps[g_p].shield_amount > max_player_health)
                        {
                            ps[g_p].shield_amount = (short)max_player_health;
                        }
                        break;
                    case 2:
                        ps[g_p].scuba_amount = (short)scriptptr.buffer[insptr]; // 1600;
                        ps[g_p].inven_icon = (char)6;
                        break;
                    case 3:
                        ps[g_p].holoduke_amount = (short)scriptptr.buffer[insptr]; // 1600;
                        ps[g_p].inven_icon = (char)3;
                        break;
                    case 4:
                        ps[g_p].jetpack_amount = (short)scriptptr.buffer[insptr]; // 1600;
                        ps[g_p].inven_icon = (char)4;
                        break;
                    case 6:
                        switch (g_sp.pal)
                        {
                            case 0:
                                ps[g_p].got_access |= 1;
                                break;
                            case 21:
                                ps[g_p].got_access |= 2;
                                break;
                            case 23:
                                ps[g_p].got_access |= 4;
                                break;
                        }
                        break;
                    case 7:
                        ps[g_p].heat_amount = (short)scriptptr.buffer[insptr];
                        ps[g_p].inven_icon = (char)5;
                        break;
                    case 9:
                        ps[g_p].inven_icon = (char)1;
                        ps[g_p].firstaid_amount = (short)scriptptr.buffer[insptr];
                        break;
                    case 10:
                        ps[g_p].inven_icon = (char)7;
                        ps[g_p].boot_amount = (short)scriptptr.buffer[insptr];
                        break;
                }
                insptr++;
                break;
            case 50:
                hitradius(g_i, ((short)scriptptr.buffer[insptr + 1]), (insptr + 2), (insptr + 3), (insptr + 4), (insptr + 5));
                insptr += 6;
                break;
            case 51:
                {
                    insptr++;

                    l = (short)scriptptr.buffer[insptr];
                    j = 0;

                    s = g_sp.xvel;

                    if ((l & 8) != 0 && ps[g_p].on_ground != 0 && (sync[g_p].bits & 2) != 0)
                    {
                        j = 1;
                    }
                    else if ((l & 16) != 0 && ps[g_p].jumping_counter == 0 && ps[g_p].on_ground == 0 && ps[g_p].poszv > 2048)
                    {
                        j = 1;
                    }
                    else if ((l & 32) != 0 && ps[g_p].jumping_counter > 348)
                    {
                        j = 1;
                    }
                    else if ((l & 1) != 0 && s >= 0 && s < 8)
                    {
                        j = 1;
                    }
                    else if ((l & 2) != 0 && s >= 8 && 0 == (sync[g_p].bits & (1 << 5)))
                    {
                        j = 1;
                    }
                    else if ((l & 4) != 0 && s >= 8 && 1 == (sync[g_p].bits & (1 << 5)))
                    {
                        j = 1;
                    }
                    else if ((l & 64) != 0 && ps[g_p].posz < (g_sp.z - (48 << 8)))
                    {
                        j = 1;
                    }
                    else if ((l & 128) != 0 && s <= -8 && 0 == (sync[g_p].bits & (1 << 5)))
                    {
                        j = 1;
                    }
                    else if ((l & 256) != 0 && s <= -8 && 1 == (sync[g_p].bits & (1 << 5)))
                    {
                        j = 1;
                    }
                    else if ((l & 512) != 0 && (ps[g_p].quick_kick > 0 || (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON && ps[g_p].kickback_pic > 0)))
                    {
                        j = 1;
                    }
                    else if ((l & 1024) != 0 && Engine.board.sprite[ps[g_p].i].xrepeat < 32)
                    {
                        j = 1;
                    }
                    else if ((l & 2048) != 0 && ps[g_p].jetpack_on != 0)
                    {
                        j = 1;
                    }
                    else if ((l & 4096) != 0 && ps[g_p].steroids_amount > 0 && ps[g_p].steroids_amount < 400)
                    {
                        j = 1;
                    }
                    else if ((l & 8192) != 0 && ps[g_p].on_ground != 0)
                    {
                        j = 1;
                    }
                    else if ((l & 16384) != 0 && Engine.board.sprite[ps[g_p].i].xrepeat > 32 && Engine.board.sprite[ps[g_p].i].extra > 0 && ps[g_p].timebeforeexit == 0)
                    {
                        j = 1;
                    }
                    else if ((l & 32768) != 0 && Engine.board.sprite[ps[g_p].i].extra <= 0)
                    {
                        j = 1;
                    }
                    else if ((l & 65536) != 0)
                    {
                        if (g_sp.picnum == DefineConstants.APLAYER && ud.multimode > 1)
                        {
                            j = getincangle(ps[otherp].ang, (short)Engine.getangle(ps[g_p].posx - ps[otherp].posx, ps[g_p].posy - ps[otherp].posy));
                        }
                        else
                        {
                            j = getincangle(ps[g_p].ang, (short)Engine.getangle(g_sp.x - ps[g_p].posx, g_sp.y - ps[g_p].posy));
                        }

                        if (j > -128 && j < 128)
                        {
                            j = 1;
                        }
                        else
                        {
                            j = 0;
                        }
                    }

                    parseifelse(j == 1);

                }
                break;
            case 56:
                insptr++;
                parseifelse(g_sp.extra <= (short)scriptptr.buffer[insptr]);
                break;
            case 58:
                insptr += 2;
                guts(g_sp, (short)scriptptr.buffer[insptr - 1], (short)scriptptr.buffer[insptr], g_p);
                insptr++;
                break;
            case 59:
                insptr++;
                //            if(g_sp->owner >= 0 && Engine.board.sprite[g_sp->owner].picnum == (short)scriptptr.buffer[insptr])
                //              parseifelse(1);
                //            else
                parseifelse(hittype[g_i].picnum == (short)scriptptr.buffer[insptr]);
                break;
            case 61:
                insptr++;
                forceplayerangle(ps[g_p]);
                return 0;
            case 62:
                insptr++;
                parseifelse(((hittype[g_i].floorz - hittype[g_i].ceilingz) >> 8) < (short)scriptptr.buffer[insptr]);
                break;
            case 63:
                parseifelse((sync[g_p].bits & (1 << 29)) != 0);
                break;
            case 64:
                parseifelse((Engine.board.sector[g_sp.sectnum].ceilingstat & 1) != 0);
                break;
            case 65:
                parseifelse(ud.multimode > 1);
                break;
            case 66:
                insptr++;
                if (Engine.board.sector[g_sp.sectnum].lotag == 0)
                {
                    Engine.board.neartag(g_sp.x, g_sp.y, g_sp.z - (32 << 8), g_sp.sectnum, g_sp.ang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 768, 1);
                    if (neartagsector >= 0 && isanearoperator(Engine.board.sector[neartagsector].lotag))
                    {
                        if ((Engine.board.sector[neartagsector].lotag & 0xff) == 23 || Engine.board.sector[neartagsector].floorz == Engine.board.sector[neartagsector].ceilingz)
                        {
                            if ((Engine.board.sector[neartagsector].lotag & 16384) == 0)
                            {
                                if ((Engine.board.sector[neartagsector].lotag & 32768) == 0)
                                {
                                    j = Engine.board.headspritesect[neartagsector];
                                    while (j >= 0)
                                    {
                                        if (Engine.board.sprite[j].picnum == DefineConstants.ACTIVATOR)
                                        {
                                            break;
                                        }
                                        j = Engine.board.nextspritesect[j];
                                    }
                                    if (j == -1)
                                    {
                                        operatesectors(neartagsector, g_i);
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case 67:
                parseifelse(ceilingspace(g_sp.sectnum) != 0);
                break;

            case 74:
                insptr++;
                if (g_sp.picnum != DefineConstants.APLAYER)
                {
                    hittype[g_i].tempang = g_sp.pal;
                }
                g_sp.pal = (byte)scriptptr.buffer[insptr];
                insptr++;
                break;

            case 77:
                insptr++;
                g_sp.picnum = (short)scriptptr.buffer[insptr];
                insptr++;
                break;

            case 70:
                parseifelse(dodge(g_sp) == 1);
                break;
            case 71:
                if (badguy(g_sp) != 0)
                {
                    parseifelse(ud.respawn_monsters != 0);
                }
                else if (inventory(g_sp) != 0)
                {
                    parseifelse(ud.respawn_inventory != 0);
                }
                else
                {
                    parseifelse(ud.respawn_items != 0);
                }
                break;
            case 72:
                insptr++;
                //            getglobalz(g_i);
                parseifelse((hittype[g_i].floorz - g_sp.z) <= (((short)scriptptr.buffer[insptr]) << 8));
                break;
            case 73:
                insptr++;
                //            getglobalz(g_i);
                parseifelse((g_sp.z - hittype[g_i].ceilingz) <= (((short)scriptptr.buffer[insptr]) << 8));
                break;
            case 14:

                insptr++;
                ps[g_p].pals_time = (short)scriptptr.buffer[insptr];
                insptr++;
                for (j = 0; j < 3; j++)
                {
                    ps[g_p].pals[j] = (byte)scriptptr.buffer[insptr];
                    insptr++;
                }
                break;

            /*        case 74:
                        insptr++;
                        getglobalz(g_i);
                        parseifelse( (( hittype[g_i].floorz - hittype[g_i].ceilingz ) >> 8 ) >= (short)scriptptr.buffer[insptr]);
                        break;
            */
            case 78:
                insptr++;
                parseifelse(Engine.board.sprite[ps[g_p].i].extra < (short)scriptptr.buffer[insptr]);
                break;

            case 75:
                {
                    insptr++;
                    j = 0;
                    switch (scriptptr.buffer[insptr++])
                    {
                        case 0:
                            if (ps[g_p].steroids_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 1:
                            if (ps[g_p].shield_amount != max_player_health)
                            {
                                j = 1;
                            }
                            break;
                        case 2:
                            if (ps[g_p].scuba_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 3:
                            if (ps[g_p].holoduke_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 4:
                            if (ps[g_p].jetpack_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 6:
                            switch (g_sp.pal)
                            {
                                case 0:
                                    if ((ps[g_p].got_access & 1) != 0)
                                    {
                                        j = 1;
                                    }
                                    break;
                                case 21:
                                    if ((ps[g_p].got_access & 2) != 0)
                                    {
                                        j = 1;
                                    }
                                    break;
                                case 23:
                                    if ((ps[g_p].got_access & 4) != 0)
                                    {
                                        j = 1;
                                    }
                                    break;
                            }
                            break;
                        case 7:
                            if (ps[g_p].heat_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 9:
                            if (ps[g_p].firstaid_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                        case 10:
                            if (ps[g_p].boot_amount != (short)scriptptr.buffer[insptr])
                            {
                                j = 1;
                            }
                            break;
                    }

                    parseifelse(j != 0);
                    break;
                }
            case 38:
                insptr++;
                if (ps[g_p].knee_incs == 0 && Engine.board.sprite[ps[g_p].i].xrepeat >= 40)
                {
                    if (Engine.board.cansee(g_sp.x, g_sp.y, g_sp.z - (4 << 8), g_sp.sectnum, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz + (16 << 8), Engine.board.sprite[ps[g_p].i].sectnum))
                    {
                        ps[g_p].knee_incs = 1;
                        if (ps[g_p].weapon_pos == 0)
                        {
                            ps[g_p].weapon_pos = -1;
                        }
                        ps[g_p].actorsqu = g_i;
                    }
                }
                break;
            case 90:
                {
                    short s1;

                    s1 = g_sp.sectnum;

                    j = 0;

                    Engine.board.updatesector(g_sp.x + 108, g_sp.y + 108, ref s1);
                    if (s1 == g_sp.sectnum)
                    {
                        Engine.board.updatesector(g_sp.x - 108, g_sp.y - 108, ref s1);
                        if (s1 == g_sp.sectnum)
                        {
                            Engine.board.updatesector(g_sp.x + 108, g_sp.y - 108, ref s1);
                            if (s1 == g_sp.sectnum)
                            {
                                Engine.board.updatesector(g_sp.x - 108, g_sp.y + 108, ref s1);
                                if (s1 == g_sp.sectnum)
                                {
                                    j = 1;
                                }
                            }
                        }
                    }
                    parseifelse(j != 0);
                }

                break;
            case 80:
                insptr++;
                FTA((short)scriptptr.buffer[insptr], ps[g_p]);
                insptr++;
                break;
            case 81:
                parseifelse(floorspace(g_sp.sectnum) != 0);
                break;
            case 82:
                parseifelse((hittype[g_i].movflag & 49152) > 16384);
                break;
            case 83:
                insptr++;
                switch (g_sp.picnum)
                {
                    case DefineConstants.FEM1:
                    case DefineConstants.FEM2:
                    case DefineConstants.FEM3:
                    case DefineConstants.FEM4:
                    case DefineConstants.FEM5:
                    case DefineConstants.FEM6:
                    case DefineConstants.FEM7:
                    case DefineConstants.FEM8:
                    case DefineConstants.FEM9:
                    case DefineConstants.FEM10:
                    case DefineConstants.PODFEM1:
                    case DefineConstants.NAKED1:
                    case DefineConstants.STATUE:
                        if (g_sp.yvel != 0)
                        {
                            operaterespawns(g_sp.yvel);
                        }
                        break;
                    default:
                        if (g_sp.hitag >= 0)
                        {
                            operaterespawns(g_sp.hitag);
                        }
                        break;
                }
                break;
            case 85:
                insptr++;
                parseifelse(g_sp.pal == (short)scriptptr.buffer[insptr]);
                break;

            case 111:
                insptr++;
                j = pragmas.klabs(getincangle(ps[g_p].ang, g_sp.ang));
                parseifelse(j <= (short)scriptptr.buffer[insptr]);
                break;

            case 109:

                for (j = 1; j < DefineConstants.NUM_SOUNDS; j++)
                {
                    if (SoundOwner[j,0].i == g_i)
                    {
                        break;
                    }
                }

                parseifelse(j == DefineConstants.NUM_SOUNDS);
                break;
            default:
             //   Engine.Printf("Unknown command!");
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