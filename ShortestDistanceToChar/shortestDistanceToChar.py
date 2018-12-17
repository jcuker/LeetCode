'''
Given a string S and a character C, return an array of integers representing the shortest distance from the character C in the string.

Example 1:
Input: S = "loveleetcode", C = 'e'
Output: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]

Note:
    S string length is in [1, 10000].
    C is a single character, and guaranteed to be in string S.
    All letters in S and C are lowercase.

'''
class Node:
    def __init__(self):
        self.children = {}
        self.value = None

class Trie:
    def __init__(self, seed):
        self.root_node = Node()
        self.construct_tree(seed)

    def construct_tree_from_file(self, dictionary_file_location):
        try:
            with open(dictionary_file_location, "r") as dictionary:
                for line in dictionary:
                    self.parse_line(line)
        except IOError:
            print("error reading file")

    def construct_tree(self, seed):
        for word in seed:
            self.add_word_to_trie(word)

    def parse_line(self, line: str):
        all_words = line.split()

        for word in all_words:
            self.add_word_to_trie(word)

    def add_word_to_trie(self, word: str):
        if not self.valid_word(word):
            current_node = self.root_node
            last_char_index = None

            for index_char, char in enumerate(word):
                if char in current_node.children:
                    current_node = current_node.children[char]
                else:
                    last_char_index = index_char
                    break
                
            if last_char_index is not None: 
                # iterate through the remaining chars
                for char in word[last_char_index:]:
                    current_node.children[char] = Node()
                    current_node = current_node.children[char]
            current_node.value = None
                
    def valid_word(self, word: str):
        return self.find_word(self.root_node, word)

    def find_word(self, node, word):
        for char in word:
            if char in node.children:
                node = node.children[char]
            else:
                return False
        return True
