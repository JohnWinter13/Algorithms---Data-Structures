#include <iostream>

int main()
{
    int a, b;
    std::cin >> a >> b;
    if (a % b == 0)
        std::cout << "yes " << a / b;
    else
    {
        int count = 0;
        while (a % b != 0)
        {
            b++;
            count++;
        }
        std::cout << "no " << count;
    }
    return 0;
}