#include <iostream>
typedef long long ll;

int main()
{
    ll n, k;
    std::cin >> n >> k;
    if (k == 1)
        std::cout << n;
    else 
    {
        ll ans = 1;
        while (ans <= n)
            ans *= 2;
        std::cout << ans - 1;
    }
    return 0;
}

