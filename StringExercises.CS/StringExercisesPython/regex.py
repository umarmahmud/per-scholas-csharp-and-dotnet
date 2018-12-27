import re

'''
//Use Regex To perform wildcard searches
	//	Again, use mobydick.txt as the search document.
	// In a loop, ask the user to enter a search phrase.
	// Provide instructions :    _ (underscore) represents a single character; * (asterisk) represents zero Or more characters.
	// Run the search. If no results are found output “No results found.”
	// Otherwise, output the number of results found followed by the position in the document And the matched text for each match.
'''

def user_search(path):
    # get text from file
    with open(path) as f:
        text = f.read().replace('\n', ' ')

    # user search
    while True:
        ans = input("Enter a search: ")
        pattern = re.compile(ans)
        if pattern.search(text) == None:
            print("No results found\n")
            continue
        print("{} results found".format(len(pattern.findall(text))))
        for i in pattern.finditer(text):
            print("{} at {} - {}".format(i.group(), i.start(), i.end()))
        print("\n")

def main():
    user_search("mobydick.txt")

if __name__ == "__main__":
    main()

