namespace DijkstraAlgorithm;

using NUnit.Framework;
using System;

public class Tests
{

    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#/media/File:Dijkstra_Animation.gif
    private readonly Func<Graph<char, int>> wikipediaBuilder = () =>
    {
        var builder = new GraphBuilder<char, int>();
        builder.AddEdge(from: 'A', to: 'B', weight: 70, bidirectional: true);
        builder.AddEdge(from: 'A', to: 'C', weight: 9, bidirectional: true);
        builder.AddEdge(from: 'A', to: 'F', weight: 14, bidirectional: true);
        builder.AddEdge(from: 'B', to: 'C', weight: 10, bidirectional: true);
        builder.AddEdge(from: 'B', to: 'D', weight: 15, bidirectional: true);
        builder.AddEdge(from: 'C', to: 'D', weight: 11, bidirectional: true);
        builder.AddEdge(from: 'C', to: 'F', weight: 2, bidirectional: true);
        builder.AddEdge(from: 'D', to: 'E', weight: 6, bidirectional: true);
        builder.AddEdge(from: 'E', to: 'F', weight: 9, bidirectional: true);
        return builder.Build();
    };

    // https://www.programiz.com/dsa/dijkstra-algorithm
    private readonly Func<Graph<char, int>> programizBuilder = () =>
    {
        var builder = new GraphBuilder<char, int>();
        builder.AddEdge(from: 'A', to: 'B', weight: 4, bidirectional: true);
        builder.AddEdge(from: 'A', to: 'C', weight: 4, bidirectional: true);
        builder.AddEdge(from: 'B', to: 'C', weight: 2, bidirectional: true);
        builder.AddEdge(from: 'C', to: 'D', weight: 3, bidirectional: true);
        builder.AddEdge(from: 'C', to: 'E', weight: 6, bidirectional: true);
        builder.AddEdge(from: 'C', to: 'F', weight: 1, bidirectional: true);
        builder.AddEdge(from: 'D', to: 'E', weight: 2, bidirectional: true);
        builder.AddEdge(from: 'E', to: 'F', weight: 3, bidirectional: true);
        return builder.Build();
    };

    [SetUp]
    public void Setup()
    {
    }

    [Test(ExpectedResult = 20)]
    public int Test_Wikipedia_Example_Length()
    {
        var graph = wikipediaBuilder.Invoke();
        var dijkstra = new Dijkstra(graph);
        var result = dijkstra.Solve();
        return result.Sum(e => e.Weight);
    }

    [Test(ExpectedResult = "A,C,F,E")]
    public int Test_Wikipedia_Example_Path()
    {
        var graph = wikipediaBuilder.Invoke();
        var dijkstra = new Dijkstra(graph);
        var result = dijkstra.Solve();
        return String.Join(",", result.Select(e => e.Origin));
    }

    [Test(ExpectedResult = 8)]
    public int Test_Programiz_Example_Length()
    {
        var graph = programizBuilder.Invoke();
        var dijkstra = new Dijkstra(graph);
        var result = dijkstra.Solve();
        return result.Sum(e => e.Weight);
    }

    [Test(ExpectedResult = "A,C,F,E")]
    public int Test_Programiz_Example_Path()
    {
        var graph = programizBuilder.Invoke();
        var dijkstra = new Dijkstra(graph);
        var result = dijkstra.Solve();
        return String.Join(",", result.Select(e => e.origin));
    }

}
