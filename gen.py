import random
def isSpecial(char):
    ranges = [48, 57, 65, 90, 97, 122]
    # numbers between each set of 2 are non special characters
    for i in range(len(ranges)):
        if i % 2 == 0:
            if char >= ranges[i] and char <= ranges[i + 1]:
                return False
    return True
def newCharacter():
    return random.random() * 94 + 33
def genString(length, special):
	password = ""
	for i in range(length):
		newChar = newCharacter()
		if not special:
			while isSpecial(newChar):
				newChar = newCharacter()
		password += chr(int(newChar))
	return password
if __name__ == "__main__":
	while True:
		length = input("Length: ")
		try:
			length = int(length)
			print(genString(length, True)) # special characters
			print(genString(length, False)) # no special characters
			print("")
		except:
			print("")
