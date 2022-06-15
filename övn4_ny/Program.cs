using System;

//1:Frågor sid 3
//stacken sparar värden från value types och minnesadresser till heapen för reference types.
//heapen sparar de värden som pekarna i referencetype i stacken refererar till
//
//2:
//valuetypes har ett värde i stacken.  reference types innehåller adressen i heapen till värdet
//reference types har en adress lagrad i stacken som pekar på en adress i heapen där något är lagrat
//
//3:i den första bilden kopieras värdet av x till y,varefter y ändras till 4: således x=3
// i den andra bilden  kopieras adressen från x.MyValue till y.myValue vilka sedan pekar till samma värde på heapen.
//när y.MyValue ändras till 4 så ändras ju också x.MyValue då de ju pekar på samma heapadress där värdet finns.


namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack or reverse a string"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            char nav = ' ';
            string input = " ";
            bool stopExaminList = false;
            List<string> theList = new List<string>();
            Console.Clear();

            while (stopExaminList == false)
            {

                Console.WriteLine("Please input +string to add a string to list ");
                Console.WriteLine("Or input -string to remove string from the list ");
                Console.WriteLine("Or input q to quit to main meny ");
                input = Console.ReadLine();

                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException) { nav = ' '; }                            //skriv om

                if ((nav != 'q') && (input.Length < 2)) { nav = ' '; input = "  "; }        //och bättre!
                input = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        {
                            theList.Add(input);
                            Console.WriteLine($"The length of the list is: {theList.Count} and its capacity is {theList.Capacity}");
                            break;
                        }
                    case '-':
                        {
                            if (theList.Contains(input))
                            {
                                theList.Remove(input);
                            }
                            else
                            {
                                Console.WriteLine($"TheList list does not contain the string: {input}, try again");
                            }

                            Console.WriteLine($"The length of the list is: {theList.Count} and its capacity is {theList.Capacity}");
                            break;
                        }
                    //Arrayens grundkapacitet är 4 och den dubbleras varje gång
                    case 'q':                                   //kapaciteten är fylld
                        {                                       //storleken på kapaciten är internt binär och en bit till fördubblar
                                                                //kapaciteten
                            stopExaminList = true;              //När element tas bort minskar inte kapaciteten automatiskt
                            break;                              //Det är fördelaktigt att använda en array när man på förhand vet
                        }                                       //antalet element och vid stora mängder element då ju listans 
                                                                //kapacitet fördubblas hela tiden
                    default:
                        {
                            Console.WriteLine(" please enter a valid input");
                            break;
                        }
                }
            }

        }

        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        //List<string> theList = new List<string>();
        //string input = Console.ReadLine();
        //char nav = input[0];
        //string value = input.substring(1);

        //switch(nav){...}


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            string listChoise = " ";
            Queue<string> queue = new Queue<string>();
            Console.Clear();
            while (listChoise != "q")
            {
                Console.WriteLine("Input 1 to add item to queue");
                Console.WriteLine("input 2 to make item leave queue");
                Console.WriteLine("Input q to  to return to main meny");
                listChoise = Console.ReadLine();
                Console.Clear();
                switch (listChoise)
                {
                    case "1":
                        {
                            Console.WriteLine("Input item to queue");
                            string item = Console.ReadLine();
                            TestQueue(queue, item);
                            break;
                        }

                    case "2":
                        {
                            TestQueue(queue);
                            break;
                        }

                    case "q":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("please enter a valid input");
                            break;
                        }
                }
            }

        }

        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        //Stack i ICA kön:
        //Om det kommer kunder snabbare än de expedieras så kommer den första kunden
        //aldrig att expedieras.
        {
            Stack<string> stack = new Stack<string>();
            Console.Clear();

            string listChoise = " ";
            while (listChoise != "q")
            {
                Console.WriteLine("Input 1 to add item to stack");
                Console.WriteLine("Input 2 to remove item from stack");
                Console.WriteLine("Input 3 to reverse a string");
                Console.WriteLine("Input q to  to return to main meny");

                listChoise = Console.ReadLine();
                Console.Clear();
                switch (listChoise)
                {
                    case "1":
                        {
                            Console.WriteLine("Input item to stack");
                            string item = Console.ReadLine();

                            stack = TestStack(stack, item);                                          //To add item to stack
                            break;
                        }

                    case "2":
                        {
                            stack = TestStack(stack);                                                //To remove item from stack
                            break;
                        }
                    case "q":
                        {
                            break;
                        }

                    case "3":
                        {
                            ReverseText();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("please enter a valid input");
                            break;
                        }

                }





            }

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            Console.Clear();
            Console.WriteLine("Input a string to test for correct parentheses");
            string testParenteses = Console.ReadLine();
            CheckParantheses(testParenteses);
            Console.WriteLine($"It is {CheckParantheses(testParenteses)} that the string is correct");

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        public static void TestQueue(Queue<string> queue, string item)    //Increses items in queue
        {
            Console.Clear();
            queue.Enqueue(item);
            Console.WriteLine($"The item {item} enters the queue");
            Console.WriteLine();
            Console.WriteLine("The new queue :");
            foreach (var queueItem in queue)
            {
                Console.Write($"{queueItem} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TestQueue(Queue<string> queue)             //Decreases items in queue
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"{queue.Peek()} leaves the queue");      //prints the first item in the queue and checks
            }                                                               //if the queue is empty
            catch (InvalidOperationException)
            {
                Console.WriteLine("The string was empty, try again"); return;
            }
            queue.Dequeue();
            Console.WriteLine("The new queue :");
            foreach (var queueItem in queue)
            {
                Console.Write($"{queueItem} ");
            }
            Console.WriteLine();
            Console.WriteLine();

        }




        public static Stack<string> TestStack(Stack<string> stackTest, string itemTest)   // Increases items in stack
        {
            Console.Clear();
            stackTest.Push(itemTest);
            Console.WriteLine($"The item {itemTest} enters the stack");
            Console.WriteLine("The new stack :");
            foreach (var stackItem in stackTest)
            {
                Console.Write($"{stackItem} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            return stackTest;
        }


        public static Stack<string> TestStack(Stack<string> stackTest)                   //Decreses items in stack
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"{stackTest.Peek()} leaves the queue");      //prints the first item in the queue and checks
            }                                                               //if the queue is empty
            catch (InvalidOperationException)
            {
                Console.WriteLine("The string was empty, try again"); return stackTest;
            }
            stackTest.Pop();
            Console.WriteLine("The new queue :");
            foreach (var stackItem in stackTest)
            {
                Console.Write($"{stackItem} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            return stackTest;

        }

        public static void ReverseText()                                         //Reverses a string
        {
            Stack<char> stack = new Stack<char>();
            Console.Clear();
            Console.WriteLine("Please input a string");
            string inputToReverse = Console.ReadLine();
            if (inputToReverse == "") { Console.WriteLine("The string must not be empty, try again"); return; }
            foreach (var item in inputToReverse)
            {
                stack.Push(item);
            }
            foreach (var item in stack)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public static bool CheckParantheses(string toTest)       //stack är klart lämpligare
        {
            Stack<char> stack = new Stack<char>();
            bool isOk = false;
            for (int i = 0; i < toTest.Length; i++)
            {
                if ((toTest[i] == '{') || (toTest[i] == '[') || (toTest[i] == '('))
                { stack.Push(toTest[i]); }
                if ((toTest[i] == ')') && ((stack.Peek() == '('))) { stack.Pop(); }
                if ((toTest[i] == ']') && ((stack.Peek() == '['))) { stack.Pop(); }
                if ((toTest[i] == '}') && ((stack.Peek() == '{'))) { stack.Pop(); }
            }
            if (stack.Count == 0) isOk = true;
            return isOk;
        }
    }
}

