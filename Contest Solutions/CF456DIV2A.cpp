#include <iostream>
#include <algorithm>
typedef long long ll;
int main()
{
    ll a, b, x, y, z;
    std::cin >> a >> b >> x >> y >> z;
    ll buy = 0;
    a -= x * 2;
    a -= y;
    b -= y;
    b -= z * 3;
    if (a < 0)
        buy += std::abs(a);
    if (b < 0)
        buy += std::abs(b);
    std::cout << buy;
    return 0;
}

