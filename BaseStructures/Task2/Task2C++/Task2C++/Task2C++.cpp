// Task2C++.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>
#include <sstream>

void minNums(int N, int K, std::vector<std::string> nums) {
    std::vector<int> deque;

    int l = 0;
    int r = K - 1;
    for (int i = 0; i < K; i++) {
        deque.push_back(std::stoi(nums[i]));
        while (deque.size() > 1 && deque[deque.size() - 1] < deque[deque.size() - 2]) {
            deque.erase(deque.begin() + deque.size() - 2);
        }
    }
    std::cout << deque[0] << " ";

    for (int i = K; i < nums.size(); i++) {
        if (std::stoi(nums[i - K]) == deque[0]) {
            deque.erase(deque.begin());
        }
        deque.push_back(std::stoi(nums[i]));
        while (deque.size() > 1 && deque[deque.size() - 1] < deque[deque.size() - 2]) {
            deque.erase(deque.begin() + deque.size() - 2);
        }
        std::cout << deque[0] << " ";
    }
}

int main()
{
    std::string N_K;
    std::getline(std::cin, N_K);
    int N = std::stoi(N_K.substr(0, N_K.find(' ')));
    int K = std::stoi(N_K.substr(N_K.find(' ') + 1));
    std::string input;
    std::vector<std::string> N_Seq_Str;
    std::getline(std::cin, input);
    std::istringstream iss(input);
    for (std::string s; iss >> s;) {
        N_Seq_Str.push_back(s);
    }

    minNums(N, K, N_Seq_Str);

    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
