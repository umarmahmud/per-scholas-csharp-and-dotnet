import random

'''
//Find all Of the unique characters In Moby Dick.
//Use the above To create a simple cypher
//1.	Randomize the array of unique characters
//2.	Rewrite Moby Dick using the randomized array as a map.
//3.	Demonstrate the you can also decode the encrypted text.
'''

def encode(path):
    # get text from file
    with open(path) as f:
        text = f.read().replace('\n', ' ')

    # find all unique characters in text
    unique_char_list = []

    for i in text:
        if i not in unique_char_list:
            unique_char_list.append(i)

    # create randomized list and cypher mapping
    randomized_char_list = unique_char_list.copy()

    random.shuffle(randomized_char_list)

    cypher_mapping = list(zip(unique_char_list, randomized_char_list))

    # encode text using mapping
    encoded_result = []

    for i in range(len(text)):
        for j in range(len(cypher_mapping)):
            if text[i] == cypher_mapping[j][0]:
                encoded_result.append(cypher_mapping[j][1])

    return cypher_mapping, ''.join(encoded_result)

# cypher_mapping should be a list of tuples
def decode(cypher_mapping, text):
    decoded_result = []

    for i in range(len(text)):
        for j in range(len(cypher_mapping)):
            if text[i] == cypher_mapping[j][1]:
                decoded_result.append(cypher_mapping[j][0])

    return ''.join(decoded_result)

def main():
    result = encode("mobydick.txt")
    print(result[1])
    print("\n\n\n\n\n")
    print(decode(result[0], result[1]))

if __name__ == "__main__":
    main()
