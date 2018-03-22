using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orphan_Black
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int tests = 0; tests < 10; tests++)
            {
                string input = Console.ReadLine();
                Console.ReadLine(); //Why does the second string even matter...
                bool valid = true;
                string text = DoIt(input, valid);
                foreach (var l in text)
                {
                    if (!char.IsLetter(l) && !char.IsSeparator(l))
                    {
                        valid = false;
                        break;
                    }
                }
                if (text.Length <= 2)
                    valid = false;
                if (!valid)
                    text = DoIt(input, valid);

                Console.WriteLine(text);
            }
            Console.ReadKey();
        }
        static string DoIt(string input, bool flag)
        {
            var binary = new StringBuilder();

            if (flag)
            {
                foreach (char l in input)
                {
                    if (l == 'C' || l == 'G')
                        binary.Append(0);
                    else
                        binary.Append(1);
                }
            }

            else
            {
                foreach (char l in input)
                {
                    if (l == 'C' || l == 'G')
                        binary.Append(1);
                    else
                        binary.Append(0);
                }
            }

            while (true)
            {
                var temp = new StringBuilder();
                temp.Append(binary);
                while (temp.Length % 8 != 0)
                    temp.Remove(temp.Length - 1, 1);
                var tbytes = GetBytesFromBinaryString(temp.ToString());
                var ttext = Encoding.ASCII.GetString(tbytes);
                bool valid = true;
                foreach (var l in ttext)
                {
                    if (!char.IsUpper(l) && !char.IsSeparator(l))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    break;
                binary.Remove(0, 1);
            }

            while (binary.Length % 8 != 0)
                binary.Remove(binary.Length - 1, 1);
            var bytes = GetBytesFromBinaryString(binary.ToString());
            var text = Encoding.ASCII.GetString(bytes);
            return text;
        }

        static public byte[] GetBytesFromBinaryString(string binary)
        {
            var list = new List<byte>();
            int length = binary.Length;
            for (int i = 0; i < binary.Length; i += 8)
            {
                if (length >= 8)
                {
                    string t = binary.Substring(i, 8);
                    list.Add(Convert.ToByte(t, 2));
                    length -= 8;
                }
            }
            return list.ToArray();
        }
    }
}