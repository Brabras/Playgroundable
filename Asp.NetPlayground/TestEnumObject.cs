// using System;
// using Infrastructure.Seedwork.DataTypes;
//
// namespace Asp.NetPlayground;
//
// public sealed class TestEnumObject : EnumObject
// {
//     public TestEnumObject(string key, string name) : base(key, name)
//     {
//     }
//
//     private const string KGSKey = "KGS";
//     private const string KZTKey = "KZT";
//
//     public static readonly TestEnumObject KGS = new(KGSKey, "Киргизский сом");
//     public static readonly TestEnumObject KZT = new(KZTKey, "Казахский тенге");
//
//     public override string ToString()
//     {
//         return Name;
//     }
//
//     public static TestEnumObject Create(string type)
//     {
//         return type switch
//         {
//             KGSKey => KGS,
//             KZTKey => KZT,
//             _ => throw new InvalidOperationException($"Unsupported type '{type}'")
//         };
//     }
// }