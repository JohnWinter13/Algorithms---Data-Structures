#include <iostream>
#include <iomanip>
double distA[1001], distB[1001];

int main()
{
    int n;
    std::cin >> n;
    for (size_t i = 0; i < n; i++) 
    {
        double a;
        std::cin >> a;
        distA[i] = a;
    }
    for (size_t i = 0; i < n; i++)
    {
        double a;
        std::cin >> a;
        distB[i] = a;
    }
    double dist = 0.0;
    for (size_t i = 0; i < n; i++)
        dist += (distA[i] - distB[i]) * (distA[i] - distB[i]);

    std::cout << std::setprecision(7) << std::sqrt(dist);
    return 0;
}
