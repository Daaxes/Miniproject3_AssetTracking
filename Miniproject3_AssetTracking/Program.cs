using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Asset Tracking");

//Computer computer = new Computer();
int[] flag = new int[] { 0, 1, 2, 3, 4 };
int strLen = 0;
int counter = 0;
display display = new display();
List<Computer> computers = new List<Computer>();
List<Mobile> mobiles = new List<Mobile>();

/*

    if (flag[counter] == 0)
    {
        PrintOut("Choose between 1: Computer 2: Mobile", 0, 3);
    }

    ConsoleKeyInfo ckey = Console.ReadKey(true);
    string strKey = ckey.KeyChar.ToString().ToUpper();

    if (strKey.Equals("Q"))
    {
        break;
    }
    else if (flag[counter] == 0 && strKey.Equals("1"))
    {
        counter++;
        PrintOut("You have coosed to add a Computer", 0, 3);
    }
    else if (flag[counter] == 0 && strKey.Equals("2"))
    {
        counter++;
        PrintOut("You have coosed to add a Mobile", 0, 3);
    }
    if (ckey.Key == ConsoleKey.Escape)
    {
        if (counter != 0) 
        {
            counter--;
        }
        else
        {
            PrintOut("You cant go back more | To Quit enter [Q/q]", 0, 3);
        }
    }
/*
    else
    {
        PrintOut($"You have pressed:  {ckey.KeyChar}", 0, 3);
    }
*/

string FirstCharToUpper(string input)
{
return Regex.Replace(input, "^[a-z]", c => c.Value.ToUpper());
}

void PrintOut(string str, int posX, int posY)
{ 
    int strLen = str.Length;
    display.ClearLine(posX, posY);
    display.SetCursurPos(posX, posY);
    Console.Write(str);
    display.SetCursurPos(strLen + 2, posY);

}

while (true)
{

    //if (input.ToUpper() == "Q" || input.ToUpper() == "QUIT" || input.ToUpper() == "EXIT")
    //{
    //    break;
    //}

    if (flag[counter] == 0)
    {
        PrintOut("[E] to enter a new product and Follow the steps | [ESC] to go back | To Quit enter [Q/q] [Quit] [Exit]", 0, 2);
    }
    if (flag[counter] == 1)
    {
        PrintOut("Choose between 1: Computer 2: Mobile", 0, 3);
    }

    //    ConsoleKeyInfo ckey = Console.ReadKey(true);
    //    string strKey = ckey.KeyChar.ToString().ToUpper();
    string input = Console.ReadLine();

    if (input.ToUpper().Equals("Q") || input.ToUpper().Equals("Quit".ToUpper()) || input.ToUpper().Equals("Exit".ToUpper()))
    {
        break;
    }
    else if (flag[counter] == 0 && strKey.Equals("1"))
    {
        counter++;
        PrintOut("You have coosed to add a Computer", 0, 3);
    }
    else if (flag[counter] == 0 && strKey.Equals("2"))
    {
        counter++;
        PrintOut("You have coosed to add a Mobile", 0, 3);
    }
    if input == ConsoleKey.Escape)
    {
        if (counter != 0)
        {
            counter--;
        }
        else
        {
            PrintOut("You cant go back more | To Quit enter [Q/q]", 0, 3);
        }
    }




}
//computers.Add(computer);

class display
{
    public display()
    {
    }

    public int PosX { get; set; } 
    public int PosY { get; set; }


    public void ClearLine(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
        Console.Write(new String(' ', Console.BufferWidth));
    }

    // Metods for set the positions
    public void SetCursurPos(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
    }

}

class Country
{
    public string OfficeCountry { get; set; }
    public int Currency { get; set; }
}
class Asset : Country
{ 
    public string ModelName { get; set; }
    public string Price { get; set; }
    public DateTime PurchaseDate { get; set; }
//    public int Currency { get; set; }
//    public string OfficeCountry { get; set; }
}

class Computer : Asset
{
    public Computer()
    {
    }

    public Computer(DateTime endOfLife, string modelName, string officeCountry, int currency)
    {
        EndOfLife = endOfLife;
        ModelName = modelName;
        OfficeCountry = officeCountry;
        Currency = currency;
    }

    public DateTime EndOfLife { get; set; }
//    public string ModelName { get; set; }
}

class Mobile : Asset
{
    public Mobile()
    {
    }

    public Mobile(DateTime endOfLife, string modelName, string officeCountry, int currency)
    {
        EndOfLife = endOfLife;
        ModelName = modelName;
        OfficeCountry = officeCountry;
        Currency = currency;
    }


    public DateTime EndOfLife { get; set; }


}

