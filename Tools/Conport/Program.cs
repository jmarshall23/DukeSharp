using System;
using System.Collections.Generic;
using System.IO;

namespace Conport
{
    class Program
    {
        public static string con_code = "";
        public static string con_construct_code = "";


        class ConFile
        {
            public string[] _tokens;
            public int currentToken;
            private bool inState = false;

            public string token
            {
                get
                {
                    if (currentToken >= _tokens.Length)
                        return "";

                    while (_tokens[currentToken] == "NEWLINE")
                    {
                        currentToken++;

                        if (currentToken >= _tokens.Length)
                            return "";                        
                    }
                    return _tokens[currentToken++];
                }
            }

            //
            // NukeComments
            //
            public string NukeComments(char[] inputData)
            {
                string data = "";
                bool inLongComment = false;

                bool insideComment = false;
                for (int i = 0; i < inputData.Length; i++)
                {
                    if(inLongComment)
                    {
                        if (inputData[i] == '*' && inputData[i + 1] == '/')
                        {
                            inLongComment = false;
                            i++;
                        }

                        continue;
                    }

                    if (insideComment)
                    {
                        if (inputData[i] == '\n' || inputData[i] == '\r')
                        {
                            insideComment = false;
                        }
                        continue;
                    }

                    // if (inputData[i] == '\t' || inputData[i] == '\n' || inputData[i] == '\r' || inputData[i] == ' ')
                    //     continue;

                    if (inputData[i] == '/' && inputData[i + 1] == '*')
                    {
                        inLongComment = true;
                        i++;
                        continue;
                    }



                    if (inputData[i] == '/' && inputData[i + 1] == '/')
                    {
                        insideComment = true;
                        i++;
                        continue;
                    }

                    if (inputData[i] == '\n')
                        data += " NEWLINE ";

                    data += inputData[i];
                }

                return data;
            }

            public ConFile(string fileName)
            {
                Console.Write("Compiling " + fileName + " \n");

                Dictionary<string, Action> keywords = new Dictionary<string, Action>
                {
                    ["define"] = () =>
                    {
                        string _name = token;
                        string _value = token;
                        con_code += "public const int " + _name + " = " + _value + ";\n";
                    },
                    ["include"] = () =>
                    {
                        ConFile file = new ConFile(token);
                    },
                    ["definequote"] = () =>
                    {
                        int id = int.Parse(token);
                        string str = "";

                        while(_tokens[currentToken] != "NEWLINE")
                        {
                            str += _tokens[currentToken];
                            str += " ";
                            currentToken++;
                        }

                        con_construct_code += "\tGlobalMembers.ConActions.definequote(";
                        con_construct_code += id;
                        con_construct_code += ",";
                        con_construct_code += "\"" + str + "\"";
                        con_construct_code += ");\n";
                    },
                    ["definevolumename"] = () =>
                    {
                        int id = int.Parse(token);
                        string str = "";

                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            str += _tokens[currentToken];
                            str += " ";
                            currentToken++;
                        }

                        con_construct_code += "\tGlobalMembers.ConActions.definevolumename(";
                        con_construct_code += id;
                        con_construct_code += ",";
                        con_construct_code += "\"" + str + "\"";
                        con_construct_code += ");\n";
                    },
                    ["defineskillname"] = () =>
                    {
                        int id = int.Parse(token);
                        string str = "";

                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            str += _tokens[currentToken];
                            str += " ";
                            currentToken++;
                        }

                        con_construct_code += "\tGlobalMembers.ConActions.defineskillname(";
                        con_construct_code += id;
                        con_construct_code += ",";
                        con_construct_code += "\"" + str + "\"";
                        con_construct_code += ");\n";
                    },
                    ["music"] = () =>
                    {
                        int id = int.Parse(token);
                        con_construct_code += "\tGlobalMembers.ConActions.definemusic(";
                        con_construct_code += id;

                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            con_construct_code += ",";
                            con_construct_code += "\"" + token + "\"";
                        }

                        con_construct_code += ");\n";
                    },
                    ["definelevelname"] = () =>
                    {
                        int id = int.Parse(token);
                        int id2 = int.Parse(token);
                        string mapname = token;
                        string time1 = token;
                        string time2 = token;

                        string str = "";

                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            str += _tokens[currentToken];
                            str += " ";
                            currentToken++;
                        }

                        con_construct_code += "\tGlobalMembers.ConActions.definelevelname(";
                        con_construct_code += id;
                        con_construct_code += ",";
                        con_construct_code += id2;
                        con_construct_code += ",";
                        con_construct_code += "\"" + mapname + "\"";
                        con_construct_code += ",";
                        con_construct_code += "\"" + time1 + "\"";
                        con_construct_code += ",";
                        con_construct_code += "\"" + time2 + "\"";
                        con_construct_code += ",";
                        con_construct_code += "\"" + str + "\"";
                        con_construct_code += ");\n";
                    },
                    ["action"] = () =>
                    {
                        string name = token;
                        con_code += "GlobalMembers.ConActions.ConAction " + name + " = new GlobalMembers.ConActions.ConAction(";
                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            con_code += _tokens[currentToken];

                            if (_tokens[currentToken + 1] != "NEWLINE")
                                con_code += ",";

                            currentToken++;
                        }

                        con_code += ");\n";
                    },
                    ["actor"] = () =>
                    {
                        string name = token;

                        if (inState == false)
                        {
                            inState = true;
                            con_construct_code += "GlobalMembers.ConActions.RegisterActor(A_" + name + "," + name;
                            while (_tokens[currentToken] != "NEWLINE" && _tokens[currentToken] != "enda" && _tokens[currentToken] != "state")
                            {
                                con_construct_code += ",";

                                con_construct_code += _tokens[currentToken];

                                currentToken++;
                            }
                            con_construct_code += ");\n";

                            con_code += "private void A_";
                            con_code += name;
                            con_code += "()\n";
                            con_code += "{\n";
                        }
                        else
                        {
                            con_code += name;
                            con_code += "();\n";
                        }
                    },
                    ["useractor"] = () =>
                    {
                        string name = token;

                        inState = true;

                        con_construct_code += "GlobalMembers.ConActions.RegisterActor(A_" + name + "," + name;
                        while (_tokens[currentToken] != "NEWLINE" && _tokens[currentToken] != "enda" && _tokens[currentToken] != "state")
                        {
                            con_construct_code += ",";

                            con_construct_code += _tokens[currentToken];

                            currentToken++;
                        }
                        con_construct_code += ");\n";

                        con_code += "private void A_";
                        con_code += name;
                        con_code += "()\n";
                        con_code += "{\n";
                    },
                    ["seekplayer"] = () =>
                    {
                        // Not sure what to do here?
                    },
                    ["move"] = () =>
                    {
                        if(inState)
                        {
                            con_code += "GlobalMembers.ConActions.Move(";
                            while (_tokens[currentToken] != "NEWLINE")
                            {
                                con_code += _tokens[currentToken];
                                if(_tokens[currentToken + 1] != "NEWLINE")
                                    con_code += ",";

                                currentToken++;
                            }

                            con_code += ");\n";
                        }
                        else
                        {
                            string name = token;
                            con_code += "GlobalMembers.ConActions.MoveAction " + name + " = new GlobalMembers.ConActions.MoveAction(";
                            while (_tokens[currentToken] != "NEWLINE")
                            {                                
                                con_code += _tokens[currentToken];                                
                                if(_tokens[currentToken + 1] != "NEWLINE")
                                    con_code += ",";
                                currentToken++;
                            }

                            con_code += ");\n";
                        }
                    },
                    ["ai"] = () =>
                    {
                        if (inState)
                        {
                            con_code += "GlobalMembers.ConActions.Ai(";
                            while (_tokens[currentToken] != "NEWLINE")
                            {
                                con_code += _tokens[currentToken];
                                if (_tokens[currentToken + 1] != "NEWLINE")
                                    con_code += ",";

                                currentToken++;
                            }

                            con_code += ");\n";
                        }
                        else
                        {
                            string name = token;
                            con_code += "GlobalMembers.ConActions.AIAction " + name + " = new GlobalMembers.ConActions.AIAction(";
                            while (_tokens[currentToken] != "NEWLINE")
                            {
                                con_code += _tokens[currentToken];
                                if (_tokens[currentToken + 1] != "NEWLINE")
                                    con_code += ",";
                                currentToken++;
                            }

                            con_code += ");\n";
                        }
                    },
                    ["state"] = () =>
                    {
                        string name = token;

                        if (!inState)
                        {
                            inState = true;
                            con_code += "private void ";
                            con_code += name;
                            con_code += "()";
                            con_code += "{\n";
                        }
                        else
                        {
                            con_code += name;
                            con_code += "();\n";
                        }
                    },
                    ["ifpdistl"] = () =>
                    {
                        string name = token;

                        con_code += "if(GlobalMembers.ConActions.ifpdistl(" + name + "))\n";
                    },
                    ["ifpdistg"] = () =>
                    {
                        string name = token;

                        con_code += "if(GlobalMembers.ConActions.ifpdistg(" + name + "))\n";
                    },
                    ["ifcansee"] = () =>
                    {
                        con_code += "if(GlobalMembers.ConActions.ifcansee())\n";
                    },
                    ["ifhitweapon"] = () =>
                    {
                        con_code += "if(GlobalMembers.ConActions.ifhitweapon())\n";
                    },
                    ["{"] = () =>
                    {
                        con_code += "{\n";
                    },
                    ["}"] = () =>
                    {
                        con_code += "}\n";
                    },
                    ["else"] = () =>
                    {
                        con_code += "else\n";
                    },
                    ["break"] = () =>
                    {
                        con_code += "return;\n";
                    },
                    ["fall"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.fall();\n";
                    },
                    ["pstomp"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.pstomp();\n";
                    },
                    ["killit"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.killit();\n";
                    },
                    ["wackplayer"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.wackplayer();\n";
                    },
                    ["resetcount"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.resetcount();\n";
                    },
                    ["resetplayer"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.resetplayer();\n";
                    },
                    ["operate"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.operate();\n";
                    },
                    ["mikesnd"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.mikesnd();\n";
                    },
                    ["tossweapon"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.tossweapon();\n";
                    },
                    ["respawnhitag"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.respawnhitag();\n";
                    },
                    ["pkick"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.pkick();\n";
                    },
                    ["tip"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.tip();\n";
                    },
                    ["getlastpal"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.getlastpal();\n";
                    },
                    ["resetactioncount"] = () =>
                    {
                        con_code += "GlobalMembers.ConActions.resetactioncount();\n";
                    },
                    ["endofgame"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.endofgame(" + v1 + ");\n";
                    },
                    ["spritepal"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.spritepal(" + v1 + ");\n";
                    },
                    ["quote"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.quote(" + v1 + ");\n";
                    },
                    ["shoot"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.shoot(" + v1 + ");\n";
                    },
                    ["cstator"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.cstator(" + v1 + ");\n";
                    },
                    ["stopsound"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.stopsound(" + v1 + ");\n";
                    },
                    ["lotsofglass"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.lotsofglass(" + v1 + ");\n";
                    },
                    ["mail"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.mail(" + v1 + ");\n";
                    },
                    ["clipdist"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.clipdist(" + v1 + ");\n";
                    },
                    ["cstat"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.cstat(" + v1 + ");\n";
                    },
                    ["paper"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.paper(" + v1 + ");\n";
                    },
                    ["addstrength"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.addstrength(" + v1 + ");\n";
                    },
                    ["money"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.money(" + v1 + ");\n";
                    },
                    ["soundonce"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.soundonce(" + v1 + ");\n";
                    },
                    ["addkills"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.addkills(" + v1 + ");\n";
                    },
                    ["sleeptime"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.sleeptime(" + v1 + ");\n";
                    },
                    ["count"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.count(" + v1 + ");\n";
                    },
                    ["cactor"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.cactor(" + v1 + ");\n";
                    },
                    ["debris"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "\tGlobalMembers.ConActions.debris(" + v1 + "," + v2 + ");\n";
                    },
                    ["sizeat"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "\tGlobalMembers.ConActions.sizeat(" + v1 + "," + v2 + ");\n";
                    },
                    ["sizeto"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "\tGlobalMembers.ConActions.sizeto(" + v1 + "," + v2 + ");\n";
                    },
                    ["addinventory"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "\tGlobalMembers.ConActions.addinventory(" + v1 + "," + v2 + ");\n";
                    },
                    ["sound"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.sound(" + v1 + ");\n";
                    },
                    ["addphealth"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.addphealth(" + v1 + ");\n";
                    },
                    ["palfrom"] = () =>
                    {                        
                        string parms = token;
                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            parms += ",";
                            parms += token;
                        }
                        con_code += "\tGlobalMembers.ConActions.palfrom(" + parms + ");\n";
                    },
                    ["ifrnd"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifrnd(" + v1 + "))\n";
                    },
                    ["ifcount"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifcount(" + v1 + "))\n";
                    },
                    ["ifai"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifai(" + v1 + "))\n";
                    },
                    ["ifwasweapon"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifwasweapon(" + v1 + "))\n";
                    },
                    ["ifpinventory"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifwasweapon(" + v1 + "," + v2 + "))\n";
                    },
                    ["ifaction"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifaction(" + v1 + "))\n";
                    },
                    ["ifp"] = () =>
                    {
                        string parms = token;
                        while (_tokens[currentToken] != "NEWLINE")
                        {
                            parms += ",";
                            parms += token;
                        }
                        con_code += "\tif(GlobalMembers.ConActions.ifp(" + parms + "))\n";
                    },
                    ["ifphealthl"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifphealthl(" + v1 + "))\n";
                    },
                    ["ifspritepal"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifspritepal(" + v1 + "))\n";
                    },
                    ["ifgotweaponce"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifgotweaponce(" + v1 + "))\n";
                    },
                    ["ifactor"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifactor(" + v1 + "))\n";
                    },
                    ["ifangdiffl"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifangdiffl(" + v1 + "))\n";
                    },
                    ["ifactioncount"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifactioncount(" + v1 + "))\n";
                    },
                    ["ifmove"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifmove(" + v1 + "))\n";
                    },
                    ["ifstrength"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifstrength(" + v1 + "))\n";
                    },
                    ["iffloordistl"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.iffloordistl(" + v1 + "))\n";
                    },
                    ["ifceilingdistl"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifceilingdistl(" + v1 + "))\n";
                    },
                    ["ifspawnedby"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifspawnedby(" + v1 + "))\n";
                    },
                    ["ifgapzl"] = () =>
                    {
                        string v1 = token;
                        con_code += "\tif(GlobalMembers.ConActions.ifgapzl(" + v1 + "))\n";
                    },
                    ["ifhitspace"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifhitspace())\n";
                    },
                    ["ifbulletnear"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifbulletnear())\n";
                    },
                    ["ifrespawn"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifrespawn())\n";
                    },
                    ["ifcanshoottarget"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifcanshoottarget())\n";
                    },
                    ["ifoutside"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifoutside())\n";
                    },
                    ["ifmultiplayer"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifmultiplayer())\n";
                    },
                    ["ifnosounds"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifnosounds())\n";
                    },
                    ["ifinspace"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifinspace())\n";
                    },
                    ["ifawayfromwall"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifawayfromwall())\n";
                    },
                    ["ifactornotstayput"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifactornotstayput())\n";
                    },
                    ["ifonwater"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifonwater())\n";
                    },
                    ["ifinwater"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifinwater())\n";
                    },
                    ["ifcanseetarget"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifcanseetarget())\n";
                    },
                    ["ifinouterspace"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifinouterspace())\n";
                    },
                    ["ifnotmoving"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifnotmoving())\n";
                    },
                    ["nullop"] = () =>
                    {
                        con_code += "// nullop\n";
                    },
                    ["ifdead"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifdead())\n";
                    },
                    ["ifsquished"] = () =>
                    {
                        con_code += "\tif(GlobalMembers.ConActions.ifsquished())\n";
                    },
                    ["ends"] = () =>
                    {
                        inState = false;
                        con_code += "}\n";
                    },
                    ["enda"] = () =>
                    {
                        inState = false;
                        con_code += "}\n";
                    },
                    ["strength"] = () =>
                    {
                        string v1 = token;
                        con_code += "GlobalMembers.ConActions.strength(" + v1 + ");\n";
                    },
                    ["spawn"] = () =>
                    {
                        string v1 = token;
                        con_code += "GlobalMembers.ConActions.spawn(" + v1 + ");\n";
                    },
                    ["globalsound"] = () =>
                    {
                        string v1 = token;
                        con_code += "GlobalMembers.ConActions.globalsound(" + v1 + ");\n";
                    },
                    ["addkills"] = () =>
                    {
                        string v1 = token;
                        con_code += "GlobalMembers.ConActions.addkills(" + v1 + ");\n";
                    },
                    ["guts"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        con_code += "GlobalMembers.ConActions.guts(" + v1 + "," + v2 + ");\n";
                    },
                    ["hitradius"] = () =>
                    {
                        string v1 = token;
                        string v2 = token;
                        string v3 = token;
                        string v4 = token;
                        string v5 = token;
                        con_code += "GlobalMembers.ConActions.hitradius(" + v1 + "," + v2 + "," + v3 + "," + v4 + "," + v5 + ");\n";
                    },
                    ["addweapon"] = () =>
                    {
                        string name = token;
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.addweapon(";
                        con_code += name;
                        con_code += ",";
                        con_code += v1;
                        con_code += ");\n";
                    },
                    ["addammo"] = () =>
                    {
                        string name = token;
                        string v1 = token;
                        con_code += "\tGlobalMembers.ConActions.addammo(";
                        con_code += name;
                        con_code += ",";
                        con_code += v1;
                        con_code += ");\n";
                    },
                    ["definesound"] = () =>
                    {
                        string name = token;
                        string sndfile = token;
                        int v1 = int.Parse(token);
                        int v2 = int.Parse(token);
                        int v3 = int.Parse(token);
                        int v4 = int.Parse(token);
                        int v5 = int.Parse(token);

                        con_construct_code += "\tGlobalMembers.ConActions.definesound(";
                        con_construct_code += name;
                        con_construct_code += ",";
                        con_construct_code += "\"" + sndfile + "\"";
                        con_construct_code += ",";
                        con_construct_code += v1;
                        con_construct_code += ",";
                        con_construct_code += v2;
                        con_construct_code += ",";
                        con_construct_code += v3;
                        con_construct_code += ",";
                        con_construct_code += v4;
                        con_construct_code += ",";
                        con_construct_code += v5;
                        con_construct_code += ");\n";
                    },
                    ["gamestartup"] = () =>
                    {
                        con_construct_code += "\tGlobalMembers.ConActions.gamestartup(";
                        con_construct_code += token;
                        for(int i = 1; i < 30; i++)
                        {
                            con_construct_code += ",";
                            con_construct_code += token;
                        }
                        con_construct_code += ");\n";
                    }
                };

                byte[] script = File.ReadAllBytes(fileName);

                char[] cArray = System.Text.Encoding.ASCII.GetString(script).ToCharArray();
                string parseData = NukeComments(cArray);

                _tokens = parseData.Split(new char[] {'\n', '\r', '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                currentToken = 0;


                string lastValidToken = "";
                while(currentToken < _tokens.Length)
                {
                    string t = token;
                    if (t.Length <= 0)
                        break;

                    try
                    {
                        if (keywords[t] == null)
                        {
                            throw new Exception("Unknown token " + keywords[t]);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Aborting fatal error! " + t + " " + lastValidToken );
                        return;
                    }

                    lastValidToken = t;

                    keywords[t]();
                }
            }
        }

        static void Main(string[] args)
        {
            con_code = "internal class ConScript\n";
            con_code += "{\n";

            ConFile conFile = new ConFile("game.con");

            con_code += "\tpublic ConScript()\n";
            con_code += "\t{\n";
            con_code += con_construct_code;
            con_code += "\t}\n";

            con_code += "}\n";

            File.WriteAllText("conscript.cs", con_code);
        }
    }
}
