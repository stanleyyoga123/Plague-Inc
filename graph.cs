using System;
using System.Collections.Generic;

class Graph{
    Dictionary<string,Tuple<string,int>> graf;

    public Graph(string[] node){
        int i;
        graf = new Dictionary<string,Tuple<string,int>>();
        for(i=0;i<node.Length;i++){
            graf.Add(node[i],new Tuple<string,int>("0",0));
        }
    }

    public void AddEdge(string City1, string City2, int weight){
        if(graf.ContainsKey(City1)){
            graf.Remove(City1);
        }
        graf.Add(City1, new Tuple<string,int>(City2,weight));
    }

    static public void Main(){
        Graph g = new Graph(new string[] {"a","b","c"});
        g.AddEdge("a","b",2);
        g.AddEdge("a","c",1);
        g.AddEdge("b","c",5);
    }
}