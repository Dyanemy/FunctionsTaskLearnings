using System.Text.RegularExpressions;

namespace FunctionsTask
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Строки с уникальными символами
            Console.WriteLine("1. Строки с уникальными символами:");
            var strings1 = new List<string> { "abc", "aabbcc", "xyz", "hello", "world" };
            var uniqueStrings = GetStringsWithUniqueChars(strings1);
            Console.WriteLine($"Входные данные: {string.Join(", ", strings1)}");
            Console.WriteLine($"Результат: {string.Join(", ", uniqueStrings)}\n");

            // 2. Сортировка по количеству гласных
            Console.WriteLine("2. Сортировка строк по количеству гласных:");
            var strings2 = new List<string> { "привет", "мир", "программирование", "код", "функция" };
            var sortedByVowels = SortByVowelCount(strings2);
            Console.WriteLine($"Входные данные: {string.Join(", ", strings2)}");
            Console.WriteLine($"Результат: {string.Join(", ", sortedByVowels)}\n");

            // 3. Общие элементы двух списков
            Console.WriteLine("3. Общие элементы двух списков:");
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            var list2 = new List<int> { 4, 5, 6, 7, 8, 9 };
            var commonElements = GetCommonElements(list1, list2);
            Console.WriteLine($"Список 1: {string.Join(", ", list1)}");
            Console.WriteLine($"Список 2: {string.Join(", ", list2)}");
            Console.WriteLine($"Общие элементы: {string.Join(", ", commonElements)}\n");

            // 4. Извлечение слов из строки
            Console.WriteLine("4. Извлечение слов из строки:");
            var text = "Привет, мир! Как дела? Это - тестовая строка.";
            var words = ExtractWords(text);
            Console.WriteLine($"Входная строка: {text}");
            Console.WriteLine($"Результат: {string.Join(", ", words)}\n");

            // 5. Строки с буквами а, б, я
            Console.WriteLine("5. Строки, содержащие буквы 'а', 'б', 'я':");
            var strings5 = new List<string> { "яблоко", "банан", "апельсин", "груша", "абрикос" };
            var filteredStrings = FilterByLetters(strings5);
            Console.WriteLine($"Входные данные: {string.Join(", ", strings5)}");
            Console.WriteLine($"Результат: {string.Join(", ", filteredStrings)}\n");

            // 1. Степени двойки
            Console.WriteLine("1. Числа, являющиеся степенями двойки:");
            var numbers1 = new List<int> { 1, 2, 3, 4, 5, 8, 15, 16, 32, 50, 64 };
            var powersOfTwo = GetPowersOfTwo(numbers1);
            Console.WriteLine($"Входные данные: {string.Join(", ", numbers1)}");
            Console.WriteLine($"Результат: {string.Join(", ", powersOfTwo)}\n");

            // 2. Числа-палиндромы
            Console.WriteLine("2. Числа-палиндромы:");
            var numbers2 = new List<int> { 121, 123, 454, 1000, 1221, 12321, 456 };
            var palindromes = GetPalindromeNumbers(numbers2);
            Console.WriteLine($"Входные данные: {string.Join(", ", numbers2)}");
            Console.WriteLine($"Результат: {string.Join(", ", palindromes)}\n");

            // 3. Общие символы во всех строках
            Console.WriteLine("3. Символы, встречающиеся во всех строках:");
            var strings3 = new List<string> { "программа", "парад", "правда" };
            var commonChars = GetCommonChars(strings3);
            Console.WriteLine($"Входные данные: {string.Join(", ", strings3)}");
            Console.WriteLine($"Результат: {string.Join(", ", commonChars)}\n");
            Console.ReadKey();
        }

        /// <summary>
        /// 1. Возвращает список строк, содержащих только уникальные символы
        /// </summary>
        private static List<string> GetStringsWithUniqueChars(List<string> strings)
        {
            return strings.Where(s => s.Distinct().Count() == s.Length).ToList();
        }

        /// <summary>
        /// 2. Сортирует строки по количеству гласных букв
        /// </summary>
        private static List<string> SortByVowelCount(List<string> strings)
        {
            var vowels = new HashSet<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                                             'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я',
                                             'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            return strings.OrderBy(s => s.Count(c => vowels.Contains(c))).ToList();
        }

        /// <summary>
        /// 3. Возвращает общие элементы двух списков
        /// </summary>
        private static List<T> GetCommonElements<T>(List<T> list1, List<T> list2)
        {
            return list1.Intersect(list2).ToList();
        }

        /// <summary>
        /// 4. Извлекает слова из строки, удаляя знаки препинания
        /// </summary>
        private static List<string> ExtractWords(string text)
        {
            var matches = Regex.Matches(text, @"\b[\wа-яА-ЯёЁ]+\b");
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }

        /// <summary>
        /// 5. Фильтрует строки, содержащие буквы а, б, я
        /// </summary>
        private static List<string> FilterByLetters(List<string> strings)
        {
            var requiredLetters = new HashSet<char> { 'а', 'б', 'я', 'А', 'Б', 'Я' };
            return strings.Where(s => s.Any(c => requiredLetters.Contains(c))).ToList();
        }

        /// <summary>
        /// 1. Возвращает числа, являющиеся степенями двойки
        /// </summary>
        private static List<int> GetPowersOfTwo(List<int> numbers)
        {
            return numbers.Where(n => n > 0 && (n & (n - 1)) == 0).ToList();
        }

        /// <summary>
        /// 2. Возвращает числа-палиндромы
        /// </summary>
        private static List<int> GetPalindromeNumbers(List<int> numbers)
        {
            return numbers.Where(n =>
            {
                string numStr = Math.Abs(n).ToString();
                string reversed = new string(numStr.Reverse().ToArray());
                return numStr == reversed;
            }).ToList();
        }

        /// <summary>
        /// 3. Возвращает символы, встречающиеся во всех строках
        /// </summary>
        private static List<string> GetCommonChars(List<string> strings)
        {
            if (strings == null || strings.Count == 0)
            {
                return new List<string>();
            }

            var commonChars = new HashSet<char>(strings[0].ToLower());
            foreach (var str in strings.Skip(1))
            {
                commonChars.IntersectWith(str.ToLower());
            }

            return commonChars.OrderBy(c => c).Select(c => c.ToString()).ToList();
        }
    }
}