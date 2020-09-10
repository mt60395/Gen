#include <iostream>

using namespace std;

int newCharacter(long int index) {
	srand(time(NULL) + index);
	return rand() % 94 + 33;
}

string genString(int length) {
	string password = "";
	for (int i = 0; i < length; i++) {
		int newChar = newCharacter(i);
		password += (char) newChar;
	}
	return password;
}

int main () {
	int length = 32;
	cout << "Length: ";
	cin >> length;
	if (cin) {
		cout << genString(length) << "\n";
	}
	else { // 32 by default if an invalid length is provided
		cout << genString(32) << "\n";
	}
}
