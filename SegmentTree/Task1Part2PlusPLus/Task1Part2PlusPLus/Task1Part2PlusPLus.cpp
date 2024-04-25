#include <iostream>
#include <vector>
#include <algorithm>
#include <unordered_map>
#include <climits>

using namespace std;

class SegmentTree {
private:
    int len;
    vector<long long> tree;
    unordered_map<int, long long> promises;

    void up(int ind, int tl, int tr) {
        tree[ind] += promises[ind];
        if (tr - tl > 1) {
            promises[ind * 2 + 1] += promises[ind];
            promises[ind * 2 + 2] += promises[ind];
        }
        promises[ind] = 0;
    }

    void update(int l, int r, long long val, int tl, int tr, int ind) {
        up(ind, tl, tr);
        if (tl >= l && tr <= r) {
            tree[ind] += val;
            if (tr - tl > 1) {
                promises[ind * 2 + 1] += val;
                promises[ind * 2 + 2] += val;
            }
            return;
        }
        if (tl >= r || tr <= l) {
            return;
        }
        int tm = (tl + tr) / 2;
        update(l, r, val, tl, tm, ind * 2 + 1);
        update(l, r, val, tm, tr, ind * 2 + 2);
        tree[ind] = min(tree[ind * 2 + 1], tree[ind * 2 + 2]);
    }

    long long getMin(int l, int r, int tl, int tr, int ind) {
        up(ind, tl, tr);
        if (tl >= l && tr <= r) {
            return tree[ind];
        }
        if (tl >= r || tr <= l) {
            return LLONG_MAX;
        }
        int tm = (tl + tr) / 2;
        long long min1 = getMin(l, r, tl, tm, ind * 2 + 1);
        long long min2 = getMin(l, r, tm, tr, ind * 2 + 2);
        return min(min1, min2);
    }

    void build(int n) {
        for (int i = 0; i < 4 * n; i++) {
            promises[i] = 0;
        }
    }

public:
    SegmentTree(int n) {
        len = n;
        tree.resize(4 * n);
        build(n);
    }

    void update(int l, int r, long long val) {
        update(l, r, val, 0, len, 0);
    }

    long long getMin(int l, int r) {
        return getMin(l, r, 0, len, 0);
    }
};

int main() {
    int n, m;
    cin >> n >> m;
    SegmentTree tr(n);
    for (int i = 0; i < m; i++) {
        int com;
        cin >> com;
        if (com == 1) {
            int l, r;
            long long val;
            cin >> l >> r >> val;
            tr.update(l, r, val);
        }
        else {
            int l, r;
            cin >> l >> r;
            cout << tr.getMin(l, r) << endl;
        }
    }
    return 0;
}