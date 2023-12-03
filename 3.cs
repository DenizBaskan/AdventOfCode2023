class Solution
{
    private readonly List<string> _lines;

    public Solution(string path)
    {
        _lines = File.ReadAllLines(path).ToList();
    }

    private int _GetFullDigitPartOne(int row, int col, Dictionary<string, bool> dict)
    {
        if (!Char.IsDigit(_lines[row][col]))
            return 0;

        string temp = "";

        for (int i = col; i < _lines[row].Length && Char.IsDigit(_lines[row][i]); i++) // get digits after index
        {
            temp += _lines[row][i];
            string key = row.ToString() + "." + i.ToString();
            
            if (dict.ContainsKey(key))
                return 0;

            dict[key] = true; // make sure we are not added already visited numbers to the sum so we add the coordinates to a hashmap to check
        }

        for (int i = col - 1; i >= 0 && Char.IsDigit(_lines[row][i]); i--) // get digits before index
            temp = _lines[row][i] + temp;

        return Convert.ToInt32(temp);
    }

    // returns 1 if the digit has been visited or the position does not contain a digit, returns 1 so the multiplication in PartTwo() does not change the value
    private int _GetFullDigitPartTwo(int row, int col, Dictionary<string, bool> dict, ref int connected)
    {
        if (!Char.IsDigit(_lines[row][col]))
            return 1;

        string temp = "";

        for (int i = col; i < _lines[row].Length && Char.IsDigit(_lines[row][i]); i++) // get digits after index
        {
            temp += _lines[row][i];
            string key = row.ToString() + "." + i.ToString();

            if (dict.ContainsKey(key))
                return 1; // we have run into another digit however it is connected to another one we have visited so we dont count it as its own

            dict[key] = true;
        }

        for (int i = col - 1; i >= 0 && Char.IsDigit(_lines[row][i]); i--) // get digits before index
            temp = _lines[row][i] + temp;

        connected++;
        return Convert.ToInt32(temp);
    }

    public int PartOne()
    {
        int sum = 0;
        Dictionary<string, bool> dict = new Dictionary<string, bool>();

        for (int i = 0; i < _lines.Count; i++)
        {
            for (int j = 0; j < _lines[i].Length; j++)
            {
                if (!Char.IsDigit(_lines[i][j]) && _lines[i][j] != '.')
                {
                    sum += _GetFullDigitPartOne(i, j - 1, dict); // check left
                    sum += _GetFullDigitPartOne(i, j + 1, dict); // check right
                    sum += _GetFullDigitPartOne(i - 1, j, dict); // check down
                    sum += _GetFullDigitPartOne(i + 1, j, dict); // check up
                    sum += _GetFullDigitPartOne(i + 1, j - 1, dict); // check upper left
                    sum += _GetFullDigitPartOne(i + 1, j + 1, dict); // check upper right
                    sum += _GetFullDigitPartOne(i - 1, j - 1, dict); // check lower left
                    sum += _GetFullDigitPartOne(i - 1, j + 1, dict); // check lower right
                }
            }
        }

        return sum;
    }

    public int PartTwo()
    {
        int sum = 0;

        for (int i = 0; i < _lines.Count; i++)
        {
            for (int j = 0; j < _lines[i].Length; j++)
            {
                if (_lines[i][j] == '*')
                {
                    Dictionary<string, bool> dict = new Dictionary<string, bool>();

                    int multiplied = 1;
                    int connected = 0;

                    multiplied *= _GetFullDigitPartTwo(i, j - 1, dict, ref connected); // check left
                    multiplied *= _GetFullDigitPartTwo(i, j + 1, dict, ref connected); // check right
                    multiplied *= _GetFullDigitPartTwo(i - 1, j, dict, ref connected); // check down
                    multiplied *= _GetFullDigitPartTwo(i + 1, j, dict, ref connected); // check up
                    multiplied *= _GetFullDigitPartTwo(i + 1, j - 1, dict, ref connected); // check upper left
                    multiplied *= _GetFullDigitPartTwo(i + 1, j + 1, dict, ref connected); // check upper right
                    multiplied *= _GetFullDigitPartTwo(i - 1, j - 1, dict, ref connected); // check lower left
                    multiplied *= _GetFullDigitPartTwo(i - 1, j + 1, dict, ref connected); // check lower right

                    if (connected == 2)
                        sum += multiplied;
                }
            }
        }

        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution("C:\\MSVC projects\\aoc\\aoc\\input.txt");

        Console.WriteLine($"Part one: {sol.PartOne()}");
        Console.WriteLine($"Part two: {sol.PartTwo()}");
    }
}
