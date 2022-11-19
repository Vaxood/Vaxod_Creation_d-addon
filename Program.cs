
//AppDomain.CurrentDomain.BaseDirectory
Console.Clear();
Console.Write("Nom du dossier : ");
string dossier = Console.ReadLine();
int weps = 0;
bool Wep = false;
while(weps == 0 ) 
{
    Console.Write("Weapon ? y/n : ");
    string wep = Console.ReadLine();
    if (wep ==  "y" || wep == "n" )
    {
        if (wep == "y" ) 
        {
            Wep = true ;
        }
        weps = 1;
    }   
}
string dossierwep = "";
if (Wep)
{
Console.Write("Nom du weapons :");
dossierwep = Console.ReadLine();
}
bool Ent = false ;
int ents = 0;
while(ents == 0 ) 
{
    Console.Write("Entities ? y/n : ");
    string ent = Console.ReadLine();
    if (ent ==  "y" || ent == "n" )
    {
        if (ent == "y" ) 
        {
            Ent = true ;
        }
       
        ents = 1;
    }   
}
string dossierent = "";
if (Ent)
{
Console.Write("Nom de l'entiter :");
dossierent = Console.ReadLine();
}

bool Mat = false;
int mats = 0;
while(mats == 0 ) 
{
    Console.Write("Materials ? y/n : ");
    string mat = Console.ReadLine();
    if (mat ==  "y" || mat == "n" )
    {
        if (mat == "y" ) 
        {
            Mat = true ;
        }
        mats = 1;
    }   
}
string dossiermat = "";
if (Mat == true )
{
Console.Write("Nom du dossier Materials: ");
dossiermat = Console.ReadLine();
}

string toutenhaut = "// addon create with Vaxod's tool";
string path = AppDomain.CurrentDomain.BaseDirectory;
Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/autorun");
Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/"+dossier+"/client");
Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/"+dossier+"/server");
Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/"+dossier+"/shared");
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/"+dossier.ToLower()+"/shared/sh_"+dossier+".lua",toutenhaut);
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/"+dossier.ToLower()+"/server/sv_"+dossier+".lua",toutenhaut);
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/"+dossier.ToLower()+"/client/cl_"+dossier+".lua",toutenhaut);

//File.Create(path+"/"+ dossier + "/lua/autorun/sh_"+dossier+".lua");
string loader = 
toutenhaut+
"\nlocal path = '"+dossier+"'"+
"\nif SERVER then" + 
"\n    local files = file.Find(path..'/shared/*.lua', 'LUA')"+
"\n    for _, file in ipairs(files) do"+
"\n        AddCSLuaFile(path..'/shared/'..file)"+
"\n        include(path..'/shared/'..file)" +
"\n    end" +
"\n    local files = file.Find(path..'/client/*.lua', 'LUA')"+
"\n    for _, file in ipairs(files) do"+
"\n          AddCSLuaFile(path..'/client/'..file)"+
"\n    end"+
"\n    local files = file.Find(path..'/server/*.lua', 'LUA')"+
"\n    for _, file in ipairs(files) do"+
"\n        include(path..'/server/'..file)" +
"\n    end"+
"\nend"+
"\nif CLIENT then"+
"\n    local files = file.Find(path..'/shared/*.lua', 'LUA')"+
"\n    for _, file in ipairs(files) do"+
"\n         include(path..'/shared/'..file)"+
"\n    end"+
"\n    local files = file.Find(path..'/client/*.lua', 'LUA')"+
"\n    for _, file in ipairs(files) do"+
"\n         include(path..'/client/'..file)"+
"\n    end"+
"\nend"
;
if (Mat) 
{
    Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/materials/"+dossiermat.ToLower());
}
if(Ent)
{
Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/entities/"+dossierent);
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/entities/"+dossierent+"/cl_init.lua",toutenhaut+"\ninclude('shared.lua')");
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/entities/"+dossierent+"/init.lua",toutenhaut+"\nAddCSLuaFile('cl_init.lua')\nAddCSLuaFile('shared.lua')\ninclude('shared.lua')");
File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/entities/"+dossierent+"/shared.lua",toutenhaut+"\nENT.Base = 'base_anim'\nENT.Type = 'ai' \nENT.PrintName = '"+dossierent+"'\nENT.Author = 'Vaxod'\nENT.Category = '"+dossierent+"'\nENT.Spawnable = true");

}
if(Wep)
{
    Directory.CreateDirectory(path+"/"+ dossier.ToLower() + "/lua/weapons/"+dossierwep);
    File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/weapons/"+dossierwep+"/cl_init.lua",toutenhaut+"\ninclude('shared.lua') \nSWEP.PrintName = '"+dossierwep+"' \nSWEP.Author = 'Vaxod' \nSWEP.Purpose = '' \nSWEP.Instructions = '' ");
    File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/weapons/"+dossierwep+"/init.lua",toutenhaut + "\nAddCSLuaFile('shared.lua') \nAddCSLuaFile('cl_init.lua') \ninclude('shared.lua')");
    File.WriteAllText(path+"/"+ dossier.ToLower() + "/lua/weapons/"+dossierwep+"/shared.lua",toutenhaut+"\nSWEP.ViewModel = ''\nSWEP.WorldModel = '' \nSWEP.HoldType = 'normal' \nSWEP.Spawnable = true \nSWEP.AdminOnly = false \nSWEP.Primary.ClipSize = -1 \nSWEP.Primary.DefaultClip = -1 \nSWEP.Primary.Automatic = false \nSWEP.Primary.Ammo = 'none' \nSWEP.UseHands = true \nSWEP.ViewModelFOV = 90 \nSWEP.Secondary.ClipSize = -1 \nSWEP.Secondary.DefaultClip	= -1 \nSWEP.Secondary.Automatic	= false \nSWEP.Secondary.Ammo = 'none' \nSWEP.Category = '"+dossierwep+"'");
}
File.WriteAllText(path+"/"+ dossier + "/lua/autorun/sh_"+dossier+".lua",loader);
