#include <iostream>
#include <algorithm>
#include <vector>
std::vector<int> unlucky;
int search(std::vector<int> array, int start_idx, int end_idx, int search_val)
{
    if (start_idx == end_idx)
        return array[start_idx] <= search_val ? start_idx : -1;

    int mid_idx = start_idx + (end_idx - start_idx) / 2;

    if (search_val < array[mid_idx])
        return search(array, start_idx, mid_idx, search_val);

    int ret = search(array, mid_idx + 1, end_idx, search_val);
    return ret == -1 ? mid_idx : ret;
}

int main()
{
    std::cin.sync_with_stdio(0);
    std::cin.tie(0);
    int k;
    std::cin >> k;
    for (size_t i = 0; i < k; i++)
    {
        int a;
        std::cin >> a;
        unlucky.push_back(a);
    }

    std::sort(std::begin(unlucky), std::end(unlucky));

    int n;
    std::cin >> n;
    for (size_t i = 0; i < n; i++)
    {
        int a;
        std::cin >> a;
        auto dangerous = std::lower_bound(std::begin(unlucky), std::end(unlucky), a);
        std::cout << a - (dangerous - unlucky.begin()) << "\n";
    }
    return 0;
}