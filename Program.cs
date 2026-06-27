using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.IO;
List <string> todolist = new List<string>();
int userchoose = 0;


string fileName = Path.Combine(AppContext.BaseDirectory, "../../../taskmanager.txt");
// to make sure the file exists before reading it
if (File.Exists(fileName))
{
    string[] lines = File.ReadAllLines(fileName);
    todolist.AddRange(lines);
}


System.Console.WriteLine("\"choose what you want to do\"");


while ( userchoose != 4){
System.Console.WriteLine(" 1.add task \n 2.show tasks \n 3.remove task \n 4.exit");
// handle posssbile errors
if (!int.TryParse(Console.ReadLine() , out userchoose)){
     System.Console.WriteLine("write intger numpers only");
     continue;
}

else if (  userchoose > 4 || userchoose < 1)
{
    System.Console.WriteLine("choose between 1 and 4 only");
    continue;
}



// now only numpers between 1 and 4 here

if ( userchoose == 1)
    {
        System.Console.WriteLine("enter your task:");
        todolist.Add(Console.ReadLine());
        File.WriteAllLines(fileName, todolist);
    }

if (userchoose == 2)
    {
        if (todolist.Count == 0)
        {
            System.Console.WriteLine("your list is empty");
        }

        else
        {
           showlist(todolist);
        }
    
 
    }

if (userchoose == 3)
    {
       
        showlist (todolist);
        
        int removetask = 0;

        do {

            if ( todolist.Count == 0)
            {
                System.Console.WriteLine("you dont have a list to remove");
                break;
            }

        System.Console.WriteLine("write numper of what you want to remove:");

         if (!int.TryParse(Console.ReadLine() , out removetask )){
            System.Console.WriteLine("write intger numpers only");
            continue;
             }

        else if (removetask > todolist.Count || removetask < 1)
        {
            
            if (todolist.Count == 1)
                {
                 System.Console.WriteLine("you only have 1 task");   
                }

            else {
                System.Console.WriteLine($"choose between 1 and {todolist.Count} only");
            }

            continue;
        }

        todolist.RemoveAt(removetask - 1);
        File.WriteAllLines(fileName, todolist);
        break;

    } while (true);


}


// short-cut for showing the list
void showlist (List <String> list)
{
            System.Console.WriteLine("--------------------------------------");
     for (int i = 0; i < list.Count; i++)
        {
            
            System.Console.WriteLine($"{i + 1}.{list[i]}"); 
        }
            System.Console.WriteLine("--------------------------------------");

}

}