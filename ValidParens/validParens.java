import java.util.*;

public class validParens {
  final static String OPEN_PARENS = "({[";
  final static String CLOSE_PARENS = ")}]";
  final static Map<Character, Character> PARENS_MAP = createMap();

  private static Map<Character, Character> createMap() {
    Map<Character, Character> map = new HashMap<>();
    map.put('(', ')');
    map.put('{', '}');
    map.put('[', ']');
    return map;
  }

  public static String removeInvalidChars(String s) {
    StringBuilder sb1 = new StringBuilder(s);
    StringBuilder sb2 = new StringBuilder();
    
    for (int i =0; i <sb1.length(); i++) {
      final char currChar = sb1.charAt(i);
      if (currChar == '(' || currChar == '{' || currChar == '[' || currChar == ')' || currChar == '}' || currChar == ']') {
        sb2.append(currChar);
      }
    }

    return sb2.toString();
  }

  
  public static boolean isValid(String s) {
    if (s.length() == 0) {
      return true;
    }
    String safe = removeInvalidChars(s);
    if (safe.length()%2 != 0) {
      return false;
    }
    Stack<Character> stack = new Stack<>();

    for (int i = 0; i < safe.length(); i++) {
      Character currChar = new Character(safe.charAt(i));

      if (currChar == '(' || currChar == '{' || currChar == '[') {
        stack.push(new Character(currChar));
      } else if (!stack.empty()){
        Character poppedChar = stack.pop();
        Character compliment = PARENS_MAP.get(poppedChar);
        // System.out.println(poppedChar);
        // System.out.println(compliment);
        // System.out.println(currChar);
        // System.out.println(compliment.equals(currChar));
        if (!compliment.equals(currChar)) {
          return false;
        }
      } else {
        return false;
      }
    }
    return stack.empty();
  }

  // https://stackoverflow.com/questions/8128227/find-first-occurrence-of-any-symbol-of-string-in-other-string
  public static int indexOfFirstContainedCharacter(String s1, String s2) {
    Set<Character> set = new HashSet<Character>();
    for (int i = 0; i < s2.length(); i++) {
      set.add(s2.charAt(i)); // Build a constant-time lookup table.
    }
    for (int i =0; i < s1.length(); i++) {
      if (set.contains(s1.charAt(i))) {
        return i; // Found a character in s1 also in s2.
      }
    }
    return -1; // No matches.
  }

  public static void main(String[] args) {
    System.out.println(isValid("") == true);
    System.out.println(isValid("((") == false);
    System.out.println(isValid("-1") == true);
    System.out.println(isValid("()") == true);
    System.out.println(isValid("(asd)") == true);
    System.out.println(isValid("(") == false);
    System.out.println(isValid(")") == false);
    System.out.println(isValid("()[]{}") == true);
    System.out.println(isValid("(]") == false);
    System.out.println(isValid("([)]") == false);
    System.out.println(isValid("{[]}") == true);
  }
}




/*abstract
 public static int indexOfLastCharBound(String s1, char c1, int startingPos, int endingPos) {
    for (int i = endingPos; i >= startingPos; i--) {
      if (s1.charAt(i) == c1) {
        return i;
      }
    }
    return -1; // No matches.
  }
  */