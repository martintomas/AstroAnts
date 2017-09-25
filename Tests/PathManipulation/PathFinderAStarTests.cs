using AstroAnts.Graphs;
using NUnit.Framework;
using AstroAnts.PathManipulation;
using Moq;

namespace Tests.PathManipulation
{
    [TestFixture]
    public class PathFinderAStarTests
    {
        //private APathFinder _pathFinder;

        //[SetUp]
        //public void SetUpPath()
        //{
        //    Mock<Graph> graph = new Mock<Graph>();
        //    graph.SetupGet(m => m.PlanetSize).Returns(9); // !!!IMPOSSIBLE TO MOCK NON VIRTUAL (MUST BE INTERFACE OR VIRTUAL METHOD/PROPERTY)
        //    graph.SetupGet(m => m.RowSize).Returns(3);

        //    Mock<GraphNode> node1 = BuildGraphNode(0, 5, new int[4] { 1, -1, -1, -1});
        //    Mock<GraphNode> node2 = BuildGraphNode(1, 1, new int[4] { 2, -1, 0, 4 });
        //    Mock<GraphNode> node3 = BuildGraphNode(2, 10, new int[4] { -1, -1, 1, 5 });
        //    Mock<GraphNode> node4 = BuildGraphNode(3, 2, new int[4] { 4, -1, -1, 6 });
        //    Mock<GraphNode> node5 = BuildGraphNode(4, 1, new int[4] { -1, 1, 3, -1 });
        //    Mock<GraphNode> node6 = BuildGraphNode(5, 1, new int[4] { -1, 2, -1, 8 });
        //    Mock<GraphNode> node7 = BuildGraphNode(6, 2, new int[4] { 7, 3, -1, -1 });
        //    Mock<GraphNode> node8 = BuildGraphNode(7, 1, new int[4] { 8, -1, 6, -1 });
        //    Mock<GraphNode> node9 = BuildGraphNode(8, 2, new int[4] { -1, 5, 7, -1 });

        //    GraphNode[] nodes = new GraphNode[]{ node1.Object, node1.Object, node1.Object,
        //        node1.Object, node1.Object, node1.Object, node1.Object, node1.Object, node1.Object};

        //    graph.SetupGet(m => m.GraphBody).Returns(nodes);
        //    graph.SetupGet(m => m.StartNode).Returns(node2.Object);
        //    graph.SetupGet(m => m.EndNode).Returns(node6.Object);

        //    _pathFinder = new PathFinderAStar(graph.Object);
        //}

        //[Test]
        //public void PathFinderAStarTest()
        //{
        //    var res = _pathFinder.FindPath();

        //    Assert.AreEqual(res, "DLDRRU");
        //}

        //public Mock<GraphNode> BuildGraphNode(int code, short val, int[] conn)
        //{
        //    Mock<GraphNode> graphNode = new Mock<GraphNode>();
        //    graphNode.SetupGet(m => m.NodeConnections).Returns(conn);
        //    graphNode.SetupGet(m => m.NodeCode).Returns(code);
        //    graphNode.SetupGet(m => m.NodeValue).Returns(val);

        //    return graphNode;
        //}

    }
}