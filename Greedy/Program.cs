namespace Greedy
{
    public class Activity
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Activity(int start, int end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"({Start}, {End})";
        }
    }

    internal class Program
    {
        public static List<Activity> SelectActivities(List<Activity> activities)
        {
            // thời gian kết thúc tăng dần
            activities.Sort((a, b) => a.End.CompareTo(b.End));

            var selected = new List<Activity>();

            // chọn hoạt động đầu tiên
            int currentEndTime = -1;

            foreach (var activity in activities)
            {
                // chọn nếu không chồng chéo
                if (activity.Start >= currentEndTime)
                {
                    selected.Add(activity);
                    currentEndTime = activity.End;
                }
            }

            return selected;
        }


        static void Main(string[] args)
        {
            var activities = new List<Activity>
            {
                new Activity(1, 4),
                new Activity(3, 5),
                new Activity(0, 6),
                new Activity(5, 7),
                new Activity(8, 9),
                new Activity(5, 9),
                new Activity(6, 10)
            };

            var selected = SelectActivities(activities);

            Console.WriteLine("Hoạt động:");
            foreach (var activity in selected)
            {
                Console.WriteLine(activity);
            }
        }
    }
}
