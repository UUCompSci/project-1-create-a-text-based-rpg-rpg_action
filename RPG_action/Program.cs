// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");



bool running = true;


int[] regions = [1, 2, 3, 4, 5, 6, 7];


string[] dialogue_tree =
[
    "yes",
    "no",
    "start the game already",
    "long time no siege"

];


while (running)
{

    Console.WriteLine("Which number do you want?");

    int n = Convert.ToInt32(Console.ReadLine());
    
    try
    {
        switch (n)
        {
            case 1:
                Console.WriteLine(dialogue_tree[0]);
                break;
            case 2:
                Console.WriteLine(dialogue_tree[1]);
                break;
            case 3:
                Console.WriteLine(dialogue_tree[2]);
                break;
            case 4:
                Console.WriteLine(dialogue_tree[3]);
                break;
            case 5:
                running = false;
                break;
            default:

                break;

        }

    }
    catch (FormatException)
    {

    }
    catch (OverflowException)
    {

    }




}





