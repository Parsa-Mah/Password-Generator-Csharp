using System;
using System.Windows.Forms;

namespace Password_Generator
{
    class Program
    {
        // STAThread is needed to copy to clipboard
        [STAThread]
        static void Main(string[] args)
        {
            int lenghtOfPassWord = 0;
            Console.WriteLine("Please enter an Integer positive number as the lenght of the password: ");
            var useriput = Console.ReadLine();

            //Handels all exeptions
            while (!int.TryParse(useriput, out int result) | result<1 )
            {
                Console.WriteLine("Error! Please enter an Integer positive number as the lenght of the password: ");
                useriput = Console.ReadLine();
            }
            lenghtOfPassWord = int.Parse(useriput);

            //For copy to clipboard you need to add reference System.Windows.Forms to your project
            bool copyToClipboard = true;

            var generatedPassword = PasswordGenerator(lenghtOfPassWord, copyToClipboard);
            Console.WriteLine("Password for lenght of "+lenghtOfPassWord+" generated! \n \n" +generatedPassword+"\n");
            if(copyToClipboard)
            Console.WriteLine("Password automatically copied to clipboard! \n");
            Console.WriteLine("Press any key to continue.... ");
            Console.ReadLine();
        }

        static String PasswordGenerator(int lenght, bool copyToClipboard)
        {
            char[] capitalChar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] smallChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] specialChar = { ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
            String password = "";
            Random random = new Random();

            //Generating Password for the provided int of lenght
            for (int i = 0; i < lenght; i++)
            {
                var range = random.Next(0, 5);
                switch (range)
                {
                    case 0:
                        range = random.Next(0, capitalChar.Length);
                        password += capitalChar[range];
                        break;
                    case 1:
                        range = random.Next(0, smallChar.Length);
                        password += smallChar[range];
                        break;
                    case 2:
                        range = random.Next(0, numbers.Length);
                        password += numbers[range];
                        break;
                    default:
                        range = random.Next(0, specialChar.Length);
                        password += specialChar[range];
                        break;
                }
            }
            if (copyToClipboard)
            Clipboard.SetText(password);

            return password;
        }
    }
}
