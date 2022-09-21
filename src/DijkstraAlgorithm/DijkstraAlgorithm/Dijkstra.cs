namespace DijkstraAlgorithm;

using System;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra<TKey, TWeight>
{

    public Tuple<List<TKey>, TWeight> Solve(Graph<TKey, TWeight> graph)
    {
        // Solve
        var start = graph.Vertices.First(v => v.Key.Equals('A'));
        var verticesOut = new List<Vertex<char, int>>();
        var result = new List<Edge<char, int>>();
        var track = new Dictionary<char, List<Edge<char, int>>>();
        foreach(var edge in start.Edges)
        {
            if(verticesOut.Contains(edge.Destination))
            {
                continue;
            }
            if(!track.TryGetValue(edge.Destination.Key, out var path))
            {
                path = new List<Edge<char, int>>();
                track.Add(edge.Destination.Key, path);
            }
            var sum = path.Sum(e => e.Weight);

        }

        return new Tuple<List<char>, int>(
            result.Select(e => e.Origin.Key).ToList(),
            result.Sum(e => e.Weight));

    }

}

public class GraphBuilder<TKey, TWeight> where TKey : notnull
{

    private readonly Dictionary<TKey, List<Tuple<TKey, TWeight>>> edges = new();

    public void AddEdge(TKey from, TKey to, TWeight weight, bool bidirectional = false)
    {
        edges.TryAdd(from, new List<Tuple<TKey, TWeight>>());
        edges.TryAdd(to, new List<Tuple<TKey, TWeight>>());
        edges[from].Add(new(to, weight));
        if(bidirectional)
        {
            edges[to].Add(new(from, weight));
        }
    }

    public Graph<TKey, TWeight> Build()
    {
        var graph = new Graph<TKey, TWeight>();
        foreach(var pair in edges)
        {
            var vertex = graph.AddVertex(pair.Key);
            foreach (var edge in pair.Value)
            {
                vertex.AddEdge(
                    to: edge.Item1, 
                    weight: edge.Item2);
            }
        }
        return graph;
    }

    public void Reset()
    {
        edges.Clear();
    }

}

public class Graph<TKey, TWeight>
{

    private readonly HashSet<Vertex<TKey, TWeight>> vertices = new();

    public IEnumerable<Vertex<TKey, TWeight>> Vertices => vertices;

    public Vertex<TKey, TWeight> AddVertex(TKey key)
    {
        var vertex = new Vertex<TKey, TWeight>(this, key);
        vertices.Add(vertex);
        return vertex;
    }

}
public class Vertex<TKey, TWeight>
{

    private readonly Graph<TKey, TWeight> graph;

    private readonly List<Edge<TKey, TWeight>> edges;

    public IEnumerable<Edge<TKey, TWeight>> Edges => edges;

    public TKey Key { get; }

    public Vertex(Graph<TKey, TWeight>  graph, TKey key)
    {
        this.graph = graph;
        Key = key;
        edges = new List<Edge<TKey, TWeight>>();
    }

    public Edge<TKey, TWeight> AddEdge(TKey to, TWeight weight)
    {
        // Find neighbor
        var neighbor = graph.Vertices.FirstOrDefault(vertex =>
            vertex?.Key?.Equals(to)?? false, null);
        neighbor ??= graph.AddVertex(to);
        // Create and add edge
        var edge = new Edge<TKey, TWeight>(this, neighbor, weight);
        edges.Add(edge);
        return edge;
    }

    public override bool Equals(object? obj)
    {
        return obj is Vertex<TKey, TWeight> vertex && Equals(vertex);
    }

    public bool Equals(Vertex<TKey, TWeight> vertex)
    {
        return vertex != null && Equals(vertex.Key);
    }

    public bool Equals(TKey key)
    {
        return key?.Equals(Key) ?? false;
    }

    public override int GetHashCode()
    {
        return Key?.GetHashCode()?? base.GetHashCode();
    }

}
public class Edge<TKey, TWeight>
{

    public Vertex<TKey, TWeight> Origin { get; }

    public Vertex<TKey, TWeight> Destination { get; }

    public TWeight Weight { get; }

    public Edge(
        Vertex<TKey, TWeight> origin, 
        Vertex<TKey, TWeight> destination,
        TWeight weight)
    {
        Origin = origin;
        Destination = destination;
        Weight = weight;
    }

}
