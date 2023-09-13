Object dateTimeString = "01/01/1753 08:00:00";
Object timeString = "08:00:00"; 
var dtStrValue = Convert.ToString(dateTimeString)!;
var toStrValue = Convert.ToString(timeString)!;
var dresult = TimeOnly.ParseExact(dtStrValue, "HH:mm:ss");
var tresult = TimeOnly.ParseExact(toStrValue, "HH:mm:ss");
Console.WriteLine(dresult);
Console.WriteLine(tresult);

Console.WriteLine();
// using System.Data;
//
// var testArr = new int[3][];
// testArr[0] = new[] { 0, 0, 0 };
// testArr[1] = new[] { 0, 0, 0 };
// testArr[2] = new[] { 0, 0, 0 };
// Console.WriteLine(testArr.Length);
//
// var result = Solution.UpdateMatrix(testArr);
//
// foreach (var arr in result)
// {
//     Console.WriteLine(string.Join(' ', arr));
// }
//
// public class Solution
// {
//     private enum Direction
//     {
//         Up,
//         Down,
//         Left,
//         Right
//     }
//
//     public int[][] UpdateMatrix(int[][] mat)
//     {
//         var result = mat;
//         for (var i = 0; i < mat.Length; i++)
//         {
//             for (var j = 0; j < mat[i].Length; j++)
//             {
//                 result[i][j] = Update(mat[i][j], i, j);
//             }
//         }
//     }
//
//     private static int Update(int value, int i, int j)
//     {
//         if (value == 0)
//             return 0;
//         
//     }
//     
//     private static f
// }