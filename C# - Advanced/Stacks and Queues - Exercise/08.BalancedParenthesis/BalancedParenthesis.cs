string parentheses = Console.ReadLine();

Stack<char> stack = new Stack<char>();

foreach (char parenthes in parentheses)
{
    switch (parenthes)
    {
        case '(':
        case '[':
        case '{':
            stack.Push(parenthes);
            break;
        case ')':
            if (stack.Count == 0 || stack.Pop() != '(')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case ']':
            if (stack.Count == 0 || stack.Pop() != '[')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case '}':
            if (stack.Count == 0 || stack.Pop() != '{')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
    }
}

if (stack.Count > 0)
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}