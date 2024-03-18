internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = new List<int>();

        var n = Convert.ToInt32(Console.ReadLine());

        var inp = Console.ReadLine();
        var ints = inp.Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < n; i++)
        {
            list.Add(ints[i]);
        }
        var m = Convert.ToInt32(Console.ReadLine());

        node root = build(0, list.Count - 1, ref list);
        int cnt = 0;

        while (true)
        {
            int l = cnt;
            int r = m + cnt - 1;

            if (r > n - 1) 
                break;

            Console.Write(query(l, r, root) + " ");
            cnt++;
        }
    }

    public static node build(int left, int right, ref List<int> a)
    {
        if (left > right) { return null; }

        node res = new node();
        res.left = left;
        res.right = right;

        if (left == right)
        {
            res.child_left = null;
            res.child_right = null;
            res.max = a[left];
        }
        else
        {
            var mid = (left + right) / 2;
            res.child_left = build(left, mid, ref a);
            res.child_right= build(mid + 1, right, ref a);
            res.max = Math.Max(res.child_right.max, res.child_right.max);
        }
        return res;
    }

    public static int query(int left, int right, node root)
    {
        if (right < root.left || left > root.right)
        {
            int inf = (int)2E9;
            return -inf;
        }
        if (root.left >= left && root.right <= right)
        {
            return root.max;
        }
        return Math.Max(query(left, right, root.child_left), query(left, right, root.child_right));
    }

    public class node
    {
        public int left;
        public int right;
        public int max;
        public node child_left;
        public node child_right;
    }
}