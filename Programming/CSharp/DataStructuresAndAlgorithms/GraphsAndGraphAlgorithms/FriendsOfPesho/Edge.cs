namespace FriendsOfPesho
{
    public class Edge
    {
        public Edge(Node toNode, int distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public int Distance { get; set; }
    }
}