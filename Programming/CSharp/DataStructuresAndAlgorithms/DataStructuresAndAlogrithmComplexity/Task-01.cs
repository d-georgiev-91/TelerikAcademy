long Compute(int[] arr)
{
    long count = 0;
    
    for (int i = 0; i < arr.Length; i++)
    {
        int start = 0, end = arr.Length - 1;
        
        while (start < end)
        {
            if (arr[start] < arr[end])
            { 
                start++; 
                count++; 
            }
            else 
            {
                end--;
            }
        }
    }

    return count;
}

/**
 * Сложноста на алгоритъма е квадратична или O(n^2)
 * При в ходни данни от "n" на брой външният цикъл (for цикъла) ще се изпълни от порядъка "n" пъти.
 * Вътрешния цикъл ще се изпълни от порядъка на "n-1" пъти. 
 * Метода Compute се изпълнява ~ n*(n-1) пъти, от което можем да твърдим, че сложността му е квадратична.
 */