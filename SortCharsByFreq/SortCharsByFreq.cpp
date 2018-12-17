/*
Given a string, sort it in decreasing order based on the frequency of characters.

Example 1:

Input:
"tree"

Output:
"eert"

Explanation:
'e' appears twice while 'r' and 't' both appear once.
So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.

Example 2:

Input:
"cccaaa"

Output:
"cccaaa"

Explanation:
Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
Note that "cacaca" is incorrect, as the same characters must be together.

Example 3:

Input:
"Aabb"

Output:
"bbAa"

Explanation:
"bbaA" is also a valid answer, but "Aabb" is incorrect.
Note that 'A' and 'a' are treated as two different characters.

*/
#include <iostream>
#include <string>
#include <map>

using namespace std;

multimap<unsigned, char> generateMap(string s) {
	multimap<char, unsigned> freqMap;
	multimap<unsigned, char> freqMapInverse;

	for (char c : s) {
		auto iterator = freqMap.find(c);

		if (iterator == freqMap.end()) {
			freqMap.insert(make_pair(c, 1));
			freqMapInverse.insert(make_pair(1, c));
		}
		else {
			unsigned numberOfOccurrances = iterator->second;
			iterator->second = iterator->second + 1;
			for (auto it = freqMapInverse.begin(); it != freqMapInverse.end(); it++) {
				if (it->second == c) {
					freqMapInverse.erase(it);
					freqMapInverse.insert(make_pair(numberOfOccurrances + 1, c));
					break;
				}
			}
		}
	}
	return freqMapInverse;
}

string generateStringFromMap(multimap<unsigned, char> freqMapInverse) {
	string returnValue = "";
	for (auto it = freqMapInverse.rbegin(); it != freqMapInverse.rend(); it++) {
		for (int i = 0; i < it->first; i++) {
			returnValue += it->second;
		}
	}

	return returnValue;
}

string frequencySort(string s) {
	if (s == "") {
		return s;
	}
	multimap<unsigned, char> freqMapInverse = generateMap(s);
	string returnValue = generateStringFromMap(freqMapInverse);
	return returnValue;
}

int main() {
	cout << frequencySort("") << endl;
	cout << frequencySort("-1") << endl;
	cout << frequencySort("asdf") << endl;
	cout << frequencySort("aaaa") << endl;
	cout << frequencySort("rkjeywtiruetlrehbsvlgkrhslvgkurebywo5i8t4763wo8756b48p7wtorejsbyvtorie7wytprebytpffff") << endl;
	cout << frequencySort("aass") << endl;
	cout << frequencySort("luhhhl") << endl;

	return 0;
}