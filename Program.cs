// Write a function called SumIntervals that accepts an array of intervals, and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.
int SumIntervals((int, int)[] intervals)
{
    var orderedInterval = from interval in intervals
        orderby interval.Item1, interval.Item2
        select interval;

    int sum = 0;
    int begin = Int32.MinValue;
    int end = Int32.MinValue;
    foreach (var item in orderedInterval)
    {
        bool newBegin = item.Item1 > end;
        if (newBegin)
        {
            sum += end - begin;
            begin = item.Item1;
        }

        end = item.Item2 > end ? item.Item2 : end;
    }
    sum += end - begin;
    return sum;
}

(int, int)[] numbers = { (1, 4), (7, 10), (3, 5) };
(int, int)[] numbers2 = { ( 1, 2 ), (6, 10 ), ( 11, 15 ) };
var sum1 = SumIntervals(numbers);
int sum2 = SumIntervals(numbers2);
Console.WriteLine("Sum of intervals (numbers1): " + sum1);
Console.WriteLine("Sum of intervals (numbers2): " + sum2);

