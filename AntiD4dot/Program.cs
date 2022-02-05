
using dnlib.DotNet;
using System;
using System.Threading;

void Main()
{

    Console.WriteLine("-----------------------------------\n\r" +
        "De4Dot Protector by @0DAYtug\n\r" +
        "-----------------------------------\n\r");
    Console.Write("Enter File Path : ");
    string dosyaYolu = Console.ReadLine();

    AssemblyDef dosya = AssemblyDef.Load(dosyaYolu);
    ModuleContext contexmodul = ModuleDefMD.CreateModuleContext();
    ModuleDefMD modul = ModuleDefMD.Load(dosyaYolu, contexmodul);
    
    Random rnd = new Random();
    InterfaceImpl Interface = new InterfaceImplUser(modul.GlobalType);
    for (int i = 200; i < 300; i++)
    {
        TypeDef typedef = new TypeDefUser("", $"Form{i.ToString()}", modul.CorLibTypes.GetTypeRef("System", "Attribute"));
        InterfaceImpl interfacefake = new InterfaceImplUser(typedef);
        modul.Types.Add(typedef);
        typedef.Interfaces.Add(interfacefake);
        typedef.Interfaces.Add(Interface);
    }

    Console.Write("Protected File Name : ");
    string protecte = Console.ReadLine();
    modul.Write(protecte + ".exe");
    Console.WriteLine("\n\r[i] Protected File Created !\n\r");
    Thread.Sleep(5000);
    System.Environment.Exit(0);
}

Main();
