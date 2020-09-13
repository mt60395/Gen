var length = 32
function isSpecial(char) {
	var ranges = [48, 57, 65, 90, 97, 122]
	// numbers between each set of 2 are non special characters
	for (var i = 0; i < ranges.length; i ++) {
		if (i % 2 == 0) {
			if (char >= ranges[i] && char <= ranges[i + 1]) {
				return false
			}
		}
	}
	return true
}

newCharacter = () => Math.floor(Math.random() * 94 + 33)

function genString(length, special) {
	password = ""
	for (var i = 0; i < length; i++) {
		var newChar = newCharacter()
		if (!special) {
			while (isSpecial(newChar)) {
				newChar = newCharacter()
			}
		}
		password += String.fromCharCode(newChar)
	}
	return password
}

console.log(genString(length, true)) // special characters
console.log(genString(length)) // no special characters
