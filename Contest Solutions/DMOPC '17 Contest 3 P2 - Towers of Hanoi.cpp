#include <iostream>
#include <vector>
std::vector<int> city;
int steps;
std::vector<int> moves;

int Flip(int i)
{
	return i == 1 ? 0 : 1;
}

void Toggle(int towers[], int i)
{
	steps++;
	moves.push_back(i + 1);

	towers[i] = Flip(towers[i]);
	if (i > 0)
		towers[i - 1] = Flip(towers[i - 1]);
	if (i < city.size() - 1)
		towers[i + 1] = Flip(towers[i + 1]);
}

void DoIt(int towers[], bool flag)
{
	if (flag)
		Toggle(towers, 0);
	for (int i = 0; i < city.size() - 1; i++)
		if (towers[i] == 1)
			Toggle(towers, i + 1);
}

int main()
{
    std::cin.sync_with_stdio(0);
    std::cin.tie(0);
	int n; std::cin >> n;
	for (size_t i = 0; i < n; i++)
	{
		int a; std::cin >> a;
		city.push_back(a);
	}
	int temp[100001];
	std::copy(city.begin(), city.end(), temp);
	DoIt(temp, true);
	if (temp[city.size() - 1] == 1)
	{
		std::copy(city.begin(), city.end(), temp);
		moves.clear();
		steps = 0;
		DoIt(temp, false);
	}
	std::cout << steps << std::endl;
	for (size_t i = 0; i < moves.size(); i++)
	{
		std::cout << moves[i] << std::endl;
	}
    return 0;
}