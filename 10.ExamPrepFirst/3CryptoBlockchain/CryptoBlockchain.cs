using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            string blocksPattern = @"\[[^[{}]+]|{[^{[\]]+}";
            string digitsPattern = @"[0-9]{3}";
            int rows = int.Parse(Console.ReadLine());

            string sequence = "";
            for (int i = 0; i < rows; i++)
            {
                sequence += Console.ReadLine();
            }

            MatchCollection validBlocks = Regex.Matches(sequence, blocksPattern);

            string digits = "";
            foreach (var criptoBlock in validBlocks)
            {
                digits = string.Join("", criptoBlock.ToString().Where(x => char.IsDigit(x)));

                if (digits.Length >= 3 && digits.Length % 3 == 0)
                {

                    MatchCollection numbers = Regex.Matches(digits, digitsPattern);
                    foreach (var num in numbers)
                    {
                        int blockLength = criptoBlock.ToString().Length;
                        Console.Write((char)(int.Parse(num.ToString()) - blockLength));
                    }
                }
            }
        }
    }
}
