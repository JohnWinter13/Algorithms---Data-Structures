#include <iostream>
#include <algorithm>
#define LSOne(S) (S & (-S))

int B1[10000055], B2[10000055];
int N;

int query(int* ft, int b)
{
    int sum = 0;
    for (; b; b -= LSOne(b))
        sum += ft[b];
    return sum;
}

int query(int b)
{
    return query(B1, b) * b - query(B2, b);
}

int range_query(int i, int j)
{
    return query(j) - query(i - 1);
}

void update(int* ft, int k, int v)
{
    for (; k <= N; k += LSOne(k))
        ft[k] += v;
}

void range_update(int i, int j, int v)
{
    update(B1, i, v);
    update(B1, j + 1, -v);
    update(B2, i, v * (i - 1));
    update(B2, j + 1, -v * j);
}

int atMostSum(int n, int k)
{
    long long sum = 0;
    int cnt = 0, maxcnt = 0;

    for (int i = 1; i <= n; i++)
    {

        int temp = range_query(i, i);
        if (sum + temp <= k)
        {
            sum += temp;
            cnt++;
        }

        else if (sum != 0)
        {
            int sub = range_query(i - cnt, i - cnt);
            sum = sum - sub + temp;
        }

        maxcnt = std::max(cnt, maxcnt);
    }
    return maxcnt;
}

int main()
{
    std::cin.sync_with_stdio(0);
    std::cin.tie(0);
    int n, t;
    std::cin >> n >> t;
    N = n + 100;
    for (int i = 0; i < t; i++)
    {
        int a, b, c;
        std::cin >> a >> b >> c;
        range_update(a, b, c);
    }
    int l;
    std::cin >> l;
    // std::cout << range_query(4, 6) << "\n";
    std::cout << atMostSum(n, l);
    return 0;
}