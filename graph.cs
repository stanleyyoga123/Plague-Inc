using System;
using System.Collections.Generic;

class Graph{
    Dictionary<char,Tuple<char,int>> graf;

    public Graph(char[] node){
        int i;
        graf = new Dictionary<char,Tuple<char,int>>();
        for(i=0;i<node.Length;i++){
            graf.Add(node[i],new Tuple<char,int>('0',0));
        }
    }

    public void AddEdge(char City1, char City2, int weight){
        if(graf.ContainsKey(City1)){
            graf.Remove(City1);
        }
        graf.Add(City1, new Tuple<char,int>(City2,weight));
    }

    static public void Main(){
        Graph g = new Graph(new char[] {'a','b','c'});
        g.AddEdge('a','b',2);
        g.AddEdge('a','c',1);
        g.AddEdge('b','c',5);
    }
}