namespace ConsolePlayground;

public static class Transliterator
{
    public static string SwapSimilarToLatin(string word)
    {
        word = word.ToLower();

        word = word.Replace("а", "a");
        word = word.Replace("А", "A");
        word = word.Replace("В", "B");
        word = word.Replace("с", "c");
        word = word.Replace("С", "C");
        word = word.Replace("Д", "D");
        word = word.Replace("е", "e");
        word = word.Replace("Е", "E");
        word = word.Replace("Н", "H");
        word = word.Replace("к", "k");
        word = word.Replace("К", "K");
        word = word.Replace("м", "m");
        word = word.Replace("М", "M");
        word = word.Replace("о", "o");
        word = word.Replace("О", "O");
        word = word.Replace("р", "p");
        word = word.Replace("Р", "P");
        word = word.Replace("Т", "T");
        word = word.Replace("х", "x");
        word = word.Replace("Х", "X");
        word = word.Replace("у", "y");
        word = word.Replace("У", "Y");

        return word;
    }

    public static string SwapSimilarToCyrillic(string word)
    {
        word = word.ToLower();
        
        word = word.Replace("a", "а");
        word = word.Replace("A", "А");
        word = word.Replace("B", "В");
        word = word.Replace("c", "с");
        word = word.Replace("C", "С");
        word = word.Replace("e", "е");
        word = word.Replace("E", "Е");
        word = word.Replace("H", "Н");
        word = word.Replace("k", "к");
        word = word.Replace("K", "К");
        word = word.Replace("m", "м");
        word = word.Replace("M", "М");
        word = word.Replace("o", "о");
        word = word.Replace("O", "О");
        word = word.Replace("p", "р");
        word = word.Replace("P", "Р");
        word = word.Replace("T", "Т");
        word = word.Replace("x", "х");
        word = word.Replace("X", "Х");
        word = word.Replace("y", "у");
        word = word.Replace("Y", "У");

        return word;
    }

    public static string ToLatin(string word)
    {
        word = word.ToLower();

        word = word.Replace("ви", "vy");
        word = word.Replace("ги", "gy");
        word = word.Replace("ди", "dy");
        word = word.Replace("ни", "ny");
        word = word.Replace("си", "sy");
        word = word.Replace("ти", "ty");
        word = word.Replace("жд", "zd");
        word = word.Replace("ай", "ay");
        word = word.Replace("ей", "ey");
        word = word.Replace("ёй", "ey");
        word = word.Replace("ий", "iy");
        word = word.Replace("ия", "ia");
        word = word.Replace("ой", "oy");
        word = word.Replace("ый", "uy");
        word = word.Replace("эй", "ey");
        word = word.Replace("ья", "ia");
        word = word.Replace("ье", "ye");
        word = word.Replace("ьё", "ye");
        word = word.Replace("ьа", "ia");
        word = word.Replace("ьи", "yi");
        word = word.Replace("ьо", "yo");
        word = word.Replace("ьу", "yu");
        word = word.Replace("ьы", "yy");
        word = word.Replace("ьэ", "ye");
        word = word.Replace("ью", "yu");
        word = word.Replace("юй", "yuy");
        word = word.Replace("яй", "yay");
        word = word.Replace("лю", "liu");
        word = word.Replace("кс", "x");
        word = word.Replace("ж", "zh");
        word = word.Replace("х", "kh");
        word = word.Replace("ц", "ts");
        word = word.Replace("ч", "ch");
        word = word.Replace("ш", "sh");
        word = word.Replace("я", "ya");
        word = word.Replace("ю", "yu");
        word = word.Replace("а", "a");
        word = word.Replace("б", "b");
        word = word.Replace("в", "v");
        word = word.Replace("г", "g");
        word = word.Replace("д", "d");
        word = word.Replace("е", "e");
        word = word.Replace("ё", "e");
        word = word.Replace("з", "z");
        word = word.Replace("и", "i");
        word = word.Replace("й", "y");
        word = word.Replace("к", "k");
        word = word.Replace("л", "l");
        word = word.Replace("м", "m");
        word = word.Replace("н", "n");
        word = word.Replace("о", "o");
        word = word.Replace("п", "p");
        word = word.Replace("р", "r");
        word = word.Replace("с", "s");
        word = word.Replace("т", "t");
        word = word.Replace("у", "u");
        word = word.Replace("ф", "f");
        word = word.Replace("ы", "y");
        word = word.Replace("э", "e");
        word = word.Replace("ъ", "");
        word = word.Replace("ь", "");

        return word;
    }

    public static string ToCyrillic(string word)
    {
        word = word.ToLower();

        word = word.Replace("ture", "чэр");
        word = word.Replace("sure", "жэр");
        word = word.Replace("tion", "шн");
        word = word.Replace("sion", "жн");
        word = word.Replace("zd", "жд");
        word = word.Replace("ay", "ай");
        word = word.Replace("ey", "ей");
        word = word.Replace("ey", "ёй");
        word = word.Replace("iy", "ий");
        word = word.Replace("ia", "ия");
        word = word.Replace("oy", "ой");
        word = word.Replace("uy", "ый");
        word = word.Replace("ey", "эй");
        word = word.Replace("ia", "ья");
        word = word.Replace("ye", "ье");
        word = word.Replace("ye", "ьё");
        word = word.Replace("ia", "ьа");
        word = word.Replace("yi", "ьи");
        word = word.Replace("yo", "ьо");
        word = word.Replace("yu", "ьу");
        word = word.Replace("yy", "ьы");
        word = word.Replace("ye", "ьэ");
        word = word.Replace("yu", "ью");
        word = word.Replace("ca", "ка");
        word = word.Replace("co", "ко");
        word = word.Replace("cu", "ка");
        word = word.Replace("ce", "йс");
        word = word.Replace("ci", "си");
        word = word.Replace("yuy", "юй");
        word = word.Replace("yay", "яй");
        word = word.Replace("liu", "лю");
        word = word.Replace("cy", "йси");
        word = word.Replace("gi", "джи");
        word = word.Replace("gy", "джи");
        word = word.Replace("zh", "ж");
        word = word.Replace("kh", "х");
        word = word.Replace("ts", "ц");
        word = word.Replace("ch", "ч");
        word = word.Replace("sh", "ш");
        word = word.Replace("ya", "я");
        word = word.Replace("yu", "ю");
        word = word.Replace("ph", "ф");
        word = word.Replace("ck", "к");
        word = word.Replace("th", "з");
        word = word.Replace("j", "дж");
        word = word.Replace("a", "а");
        word = word.Replace("b", "б");
        word = word.Replace("v", "в");
        word = word.Replace("g", "г");
        word = word.Replace("d", "д");
        word = word.Replace("e", "е");
        word = word.Replace("e", "ё");
        word = word.Replace("z", "з");
        word = word.Replace("i", "и");
        word = word.Replace("y", "й");
        word = word.Replace("k", "к");
        word = word.Replace("l", "л");
        word = word.Replace("m", "м");
        word = word.Replace("n", "н");
        word = word.Replace("o", "о");
        word = word.Replace("p", "п");
        word = word.Replace("r", "р");
        word = word.Replace("s", "с");
        word = word.Replace("t", "т");
        word = word.Replace("u", "у");
        word = word.Replace("f", "ф");
        word = word.Replace("y", "ы");
        word = word.Replace("e", "э");
        word = word.Replace("q", "к");
        word = word.Replace("h", "х");

        return word;
    }
}