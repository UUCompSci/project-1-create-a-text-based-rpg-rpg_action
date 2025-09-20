// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.WriteLine("Which number do you want?");


int n = Convert.ToInt32(Console.ReadLine());

int[] regions = [1, 2, 3, 4, 5, 6, 7];



string[] dialogue_tree = [
    "yes",
    "no",
    "start the game already",
    "long time no siege"];



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
    default:

        break;

}
