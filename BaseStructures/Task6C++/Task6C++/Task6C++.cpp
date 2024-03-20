#include <iostream>
#include <sstream>
#include <vector>
#include <unordered_map>

class Person {
public:
    int Id;
    Person* previous;
    Person* next;
    int NumberBefore;

    Person(int id) : Id(id), previous(nullptr), next(nullptr), NumberBefore(0) {}
};

class Deq {
public:
    Person* Current;
    Person* Head;
    Person* Previous;
    Person* Next;
    int Count;
    std::unordered_map<int, int> dict;

    Deq() : Current(nullptr), Head(nullptr), Previous(nullptr), Next(nullptr), Count(0) {}

    void Add(Person* person);
    void PopLast();
    void PopFirst();
    void UpdateDeq();
    int GetPeopleBefore(int id);
    int GetHead();
};

void Deq::Add(Person* person) {
    if (Count > 0) {
        Current->next = person;
        person->previous = Current;
        person->NumberBefore = Current->NumberBefore + 1;
        dict[person->Id] = Current->NumberBefore + 1;
    }
    else {
        person->NumberBefore = 0;
        dict[person->Id] = 0;
    }

    Previous = Current;
    Current = person;
    Count++;

    if (Count == 1) {
        Head = Current;
    }
}

void Deq::PopLast() {
    if (Count > 2) {
        Current = Previous;
        Current->next = nullptr;
        Previous = Previous->previous;
        Count--;
    }
    else if (Count == 2) {
        Current = Previous;
        Current->next = nullptr;
        Previous = nullptr;
        Count--;
    }
    else if (Count == 1) {
        Current = nullptr;
        Count--;
    }
}

void Deq::PopFirst() {
    if (Count > 1) {
        Head->next->previous = nullptr;
        Head = Head->next;
        Head->NumberBefore = 0;
        dict[Head->Id] = 0;
        UpdateDeq();
    }
    else {
        Head = Head->next;
        dict[Head->Id] = 0;
    }
    Count--;
}

void Deq::UpdateDeq() {
    Person* curPers = Head->next;
    while (curPers != nullptr) {
        curPers->NumberBefore = curPers->previous->NumberBefore + 1;
        dict[curPers->Id] = curPers->previous->NumberBefore + 1;
        curPers = curPers->next;
    }
}

int Deq::GetPeopleBefore(int id) {
    return dict[id];
}

int Deq::GetHead() {
    return Head->Id;
}

int main() {
    Deq deq;
    int N;
    std::cin >> N;

    std::stringstream ans;
    for (int i = 0; i < N; i++) {
        std::string input;
        std::getline(std::cin, input);
        std::stringstream ss(input);

        std::vector<std::string> coms;
        std::string temp;
        while (ss >> temp) {
            coms.push_back(temp);
        }

        if (coms[0] == "1") {
            deq.Add(new Person(std::stoi(coms[1])));
        }
        else if (coms[0] == "2") {
            deq.PopFirst();
        }
        else if (coms[0] == "3") {
            deq.PopLast();
        }
        else if (coms[0] == "4") {
            ans << deq.GetPeopleBefore(std::stoi(coms[1])) << "\n";
        }
        else if (coms[0] == "5") {
            ans << deq.GetHead() << "\n";
        }
    }

    std::cout << ans.str();

    return 0;
}

