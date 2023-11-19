
// Display class for managing console output
class Display
{
    public Display()
    {
    }

    public int PosX { get; set; } 
    public int PosY { get; set; }

    public void ClearLine(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
        Console.Write(new String(' ', Console.BufferWidth));
    }
    
    public void ClearOutputOnScreen()
    { 
        Console.Clear(); 
    }


    // Metods for set the positions
    public void SetCursurPos(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
    }

    public void ShowCategory()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(14) + "Price in USD".PadRight(17) + "Currency".PadRight(10) + "Local price");
        Console.WriteLine("-------".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(14) + "------------".PadRight(17) + "--------".PadRight(10) + "-----------");
        Console.ResetColor();
    }

    public void ShowMenu(ConsoleColor menuColor, string menuText, int posX, int posY)
    {
        int len = menuText.Length;
        
        ClearLine(posX, posY);
        Console.ForegroundColor = menuColor;
        SetCursurPos(posX, posY);
        Console.WriteLine(menuText);
        Console.ResetColor();
        SetCursurPos(len + 1, posY);
    }
}
