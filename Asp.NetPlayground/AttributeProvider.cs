// using System;
// using System.Reflection;
//
// namespace Asp.NetPlayground;
//
// internal static class AttributeProvider<T> where T : Attribute
// {
//
//     public static T? FirstOrDefault(MemberInfo methodInfo)
//     {
//
//             var attribute = GetFirstOfType(methodInfo.GetCustomAttributes(true));
//
//             if (attribute != null)
//                 return attribute;
//
//             var declaringTypeInfo = methodInfo.DeclaringType!.GetTypeInfo();
//             
//             return GetFirstOfType(declaringTypeInfo.GetCustomAttributes(true));
//     }
//
//     private static T? GetFirstOfType(object[] arr)
//     {
//         foreach (var obj in arr)
//         {
//             if (obj is T marker)
//                 return marker;
//         }
//
//         return null;
//     }
// }