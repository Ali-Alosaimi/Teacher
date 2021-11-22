using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        struct Teacher
        {
            //declare variables
            int id;
            string name;
            string subject;
            char section;
            
            //create setters and getters for the variables
            public int ID 
            { 
                get { return this.id; }
                set { this.id = value; }
            }
            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
            public string Subject
            {
                get { return this.subject; }
                set { this.subject = value; }
            }
            public char Section
            {
                get { return this.section; }
                set { this.section = value; }
            }

        }
        static void Main()
        {  
            //create a new teacher instance
            Teacher teach = new Teacher();
            //get the directory of the text file
            string dir = Directory.GetCurrentDirectory();
            string filename = dir + "\\data.txt";
            //choose what action to do
            Console.WriteLine("Enter your choice: 1 for inputing new data, or 2 to update data, 3 to view data, and 4 to exit program.");
            //flag for making a choice
            int flag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You chose: " + flag);
            if (flag == 1)
            {
                //get inputs for teacher
                Console.WriteLine("Enter the class teacher's id");
                teach.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the class teacher's name");
                teach.Name = Console.ReadLine();
                Console.WriteLine("Enter the class teacher's subject");
                teach.Subject = Console.ReadLine();
                Console.WriteLine("Enter the class teacher's section");
                teach.Section = Convert.ToChar(Console.ReadLine());
                //use streamwriter to write in textfile
                using StreamWriter wrt = File.CreateText(filename);
                wrt.WriteLine(teach.Name);
                wrt.WriteLine(teach.ID);
                wrt.WriteLine(teach.Section);
                wrt.WriteLine(teach.Subject);
                wrt.Dispose();
                Main();
            }
            else if (flag == 2)
            {
                Console.WriteLine("What to replace?");
                //choose text to replace
                string original = Console.ReadLine();
                //choose the replacement
                Console.WriteLine("What to replace it with?");
                string replacement = Console.ReadLine();
                string text = File.ReadAllText(filename);
                text = text.Replace(original, replacement);
                File.WriteAllText(filename, text);
                Main();
            }
            else if (flag == 3)
            {
                //output text
                string textfile = File.ReadAllText(filename);
                Console.WriteLine(textfile);
                Main();
            }
            else if (flag==4)
            {
                //close system
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid option, please choose between 1, 2, 3, and 4");
                Main();
            }
        }
    }
}
