#include <iostream>

int main()
{
    int n;
    std::cin >> n;
    unsigned long long int sum = 0;
    for (size_t i = 0; i < n; i++)
    {
        long long num;
        std::cin >> num;
        sum += -num;
    }
    if (sum != 0)
        std::cout << "-";

    std::cout << sum;
    return 0;
}
