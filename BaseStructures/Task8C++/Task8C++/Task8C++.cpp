
#include <iostream>
#include <vector>
#include <algorithm>

class Number {
public:
    int data;
    Number* previous;
    long prefixSum;
    int numInMas;

    Number(int data) : data(data), previous(nullptr), prefixSum(0), numInMas(0) {}
};

class NumStek {
public:
    Number* current;
    Number* previous;
    Number* curMin;
    int count;

    NumStek() : current(nullptr), previous(nullptr), curMin(nullptr), count(0) {}

    void Push(Number* num) {
        if (count > 0) {
            if (num->data > current->data) {
                num->previous = current;
                num->numInMas = current->numInMas + 1;
                num->prefixSum = current->prefixSum + num->data;
                previous = current;
                current = num;
                count++;
            }
            else if (num->data < curMin->data) {
                num->previous = nullptr;
                num->prefixSum = current->prefixSum + num->data;
                num->numInMas = 1;
                previous = nullptr;
                current = num;
                curMin = num;
                count = 1;
            }
            else {
                long prefSum = current->prefixSum;
                num->prefixSum = prefSum + num->data;
                while (num->data < current->data && count > 2) {
                    current = previous;
                    previous = previous->previous;
                    count--;
                }
                if (count == 2 && num->data < current->data) {
                    current = previous;
                    previous = nullptr;
                    count--;
                }
                num->previous = current;
                num->numInMas = current->numInMas + 1;
                previous = current;
                current = num;
                count = num->numInMas;
            }
        }
        else {
            num->prefixSum = num->data;
            num->numInMas = 1;
            curMin = num;
            current = num;
            count++;
        }
    }

    Number* Pop() {
        if (count > 2) {
            Number* num = current;
            current = previous;
            previous = previous->previous;
            count--;
            return num;
        }
        else if (count == 2) {
            Number* num = current;
            current = previous;
            previous = nullptr;
            count--;
            return num;
        }
        else if (count == 1) {
            Number* num = current;
            current = nullptr;
            count--;
            return num;
        }
        throw std::runtime_error("Stack is empty");
    }

    Number* Peek() {
        return current;
    }

    Number* getMin() {
        return curMin;
    }
};

int main() {
    NumStek myStack;
    long controlSum = 0;

    int N;
    std::cin >> N;

    for (int i = 0; i < N; ++i) {
        int num;
        std::cin >> num;
        myStack.Push(new Number(num));
        auto prev = myStack.previous;
        if (prev != nullptr && (myStack.current->prefixSum - prev->prefixSum) * myStack.current->data > controlSum) {
            controlSum = (myStack.current->prefixSum - prev->prefixSum) * myStack.current->data;
        }
        else {
            controlSum = std::max(controlSum, static_cast<long>(myStack.current->data) * myStack.current->data);
        }

        auto prev1 = prev;
        auto prev2 = prev1 ? prev1->previous : nullptr;
        while (prev2 != nullptr && prev1 != nullptr) {
            if ((myStack.current->prefixSum - prev2->prefixSum) * prev1->data > controlSum) {
                controlSum = (myStack.current->prefixSum - prev2->prefixSum) * prev1->data;
            }
            prev1 = prev2;
            prev2 = prev2->previous;
        }
        controlSum = std::max(controlSum, myStack.current->prefixSum * myStack.curMin->data);
    }

    std::cout << controlSum << std::endl;

    return 0;
}
