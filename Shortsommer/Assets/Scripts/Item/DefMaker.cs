using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using UnityEngine;



public class DefMaker : MonoBehaviour
{
    List<Def> Defs = new();

    [SerializeField] BaseMeleeWeapon defWeapon;
    [SerializeField] BaseItem defItem;

    [SerializeField] BaseMeleeWeapon tdefWeapon;
    [SerializeField] BaseItem tdefItem;

    readonly Type[] knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Def)).ToArray();

    [ContextMenu("Make Base Def")]
    public void MakeBaseDef()
    {
        Defs.Add(defWeapon);
        Defs.Add(defItem);
        SaveXML(Defs, "Defs.xml");
    }

    [ContextMenu("Load")]
    public void Load()
    {
    }

    public void SaveXML<T>(T toXml, string path)
    {
        foreach(var type in knownTypes)
        {
            Debug.Log(type.ToString());
        }
        MemoryStream stream = new MemoryStream();
        using (StreamWriter fs = new StreamWriter(Path.Combine("Assets", path)))
        {
            DataContractSerializer serializer = new DataContractSerializer(toXml.GetType(), knownTypes);

            using (var writer = XmlWriter.Create(fs, new XmlWriterSettings() { Indent = true }))
            { 
                serializer.WriteObject(writer, toXml);
            }
        }
    }

    public T LoadXML<T>(string path)
    {
        using (StreamReader fs = new StreamReader(Path.Combine("Assets", path)))
        {
            DataContractSerializerSettings settings = new DataContractSerializerSettings() { KnownTypes = knownTypes };
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), settings);

            var reader = XmlReader.Create(fs);
            return (T)serializer.ReadObject(reader);
        }
    }
}