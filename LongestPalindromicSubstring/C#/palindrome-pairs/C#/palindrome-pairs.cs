//https://leetcode.com/problems/palindrome-pairs/description/
public class Solution
{
    public bool IsStringPalindrome(string str)
    {
        int intLength = str.Length;
        int intHalfLength = intLength / 2;
        
        for (int i = 0; i < intHalfLength; i++)
        {
            if (str[i] != str[intLength - i - 1])
                return false;
        }
        
        return true;
    }
    
    
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        List<List<int>> lstPalindromeIndices = new List<List<int>>();
        
        for(int i = 0; i < words.Length; i++)
        {
            for(int j = 0; j < words.Length; j++)
            {
                if(i != j)
                {
                    string strCombined = words[i] + words[j];
                
                    if(IsStringPalindrome(strCombined))
                    {
                        lstPalindromeIndices.Add(new List<int>(new int[] {i, j}));
                    }
                }
            }
        }
        
        return lstPalindromeIndices.ToArray();
    }
    
    
    /*
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        int intLeftPos = 0;
        int intRightPos = 1;
        int intRightMostPos = words.Length - 1;
        List<List<int>> lstPalindromeIndices = new List<List<int>>();
        
        while(intLeftPos != intRightMostPos)
        {
            string strLeft = words[intLeftPos];
            string strRight = words[intRightPos];
            int intLengthOfRightWord = strRight.Length;
            int intLengthOfLeftWord = strLeft.Length;
            string strReversedPattern = "";
            
            if(intLengthOfLeftWord > intLengthOfRightWord)
            {
                for(int i = 0; i < intLengthOfRightWord; i++)
                {
                    strReversedPattern = strLeft[i] + strReversedPattern;
                }
                if(strRight.EndsWith(strReversedPattern))
                {
                    
                }
            }
            else if(intLengthOfLeftWord < intLengthOfRightWord)
            {
                for(int i = 0; i < intLengthOfLeftWord; i++)
                {
                    strReversedPattern = strRight[i] + strReversedPattern;                    
                }
                if(strLeft.EndsWith(strReversedPattern))
                {
                    
                }
            }
            else
            {
                if(IsStringPalindrome(strLeft + strRight))
                {
                    lstPalindromeIndices.Add(new List<int>(new int[] {intLeftPos, intRightPos}));
                } 
            }
            
            if(IsStringPalindrome(strLeft + strRight))
            {
                lstPalindromeIndices.Add(new List<int>(new int[] {intLeftPos, intRightPos}));
            }
            if(IsStringPalindrome(strRight + strLeft))
            {
                lstPalindromeIndices.Add(new List<int>(new int[] {intRightPos, intLeftPos}));
            }
            
            if(intRightPos != intRightMostPos)
            {
                intRightPos++;
            }
            else
            {
                intLeftPos++;
                intRightPos = intLeftPos + 1;
            }
        }
        
        return lstPalindromeIndices.ToArray();
    }
    */
    
}