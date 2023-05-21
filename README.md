# Working_with_graph
All programs wrote to C#
<h3>Tree</h3>
<p> Binary tree - with UI. <strong> Problem: not draw line </strong>
<p> Task 1 : Zero out all perfect leaves of the tree, large differences between the maximum and minimum values of the elements of the tree.</p>
<p> Task 2 : Find the sum of elements located at the maximum level from the root. </p>
<p>
  The tree is implemented through the "BinaryTree" class, which has a nested "Node" class to contain references to the following elements (left and right subtree), value and level.<br>
  The "BinaryTree" class contains the following methods and accessors:
  <ul>
    <li>"addNode" - adding an element to the tree</li>
    <li> "maxElem" - getting the maximum element </li>
    <li>"minElem" - getting the minimum element</li>
    <li> "maxLevel" - getting the maximum level of the tree</li>
    <li>"sumMaxLevel_fromRoot" - sum elements maximally located from the tree</li>
    <li>"zeroing_of_perfect_leaves" - zeroing perfect leaves, large differences between the maximum and minimum element</li>
    <li>"Count" - the number of elements in the tree</li>
    <li>"printTree_direct" - saving the tree to a file</li>
    <li>"checkTree" - checking that the data is tree structure</li>
    <li>"cleartree" - clearing the tree</li>
    </ul>
    The graphical interface contains methods for performing the specified operations with the tree, and methods for displaying the tree:
    <ul>
  <li> "pushNodesInList" - fills in the list of vertex coordinates and the list of values of these vertices</li>
  <li>"CheckForScroll" - if the tree exceeds the window size, then expand the window</li>
  <li>"DisplayTree" - Filling out the form with "System.Drawing.Drawing2D.GraphicsPath myPath"</li>
  </ul>
  </p>
<img src="https://github.com/StrongerProgrammer7/Working_with_graph/assets/71569051/01d3f45a-afbc-4e75-bdd7-7d4bb469527a"/>
<h3>Graph</h3>
<p> Include topological sort:
  <ul>
    <li>Type of graph: O</li>
    <li> Presentation Method: Adjacent Lists </li>
    <li>Bypass Method: DFS</li>
 </ul>
An application is allowed to create a graph (directed or undirected via vertex adjacency lists), check for cycles, and perform topological sorting (DFS). <br> The graph is implemented using the <strong>“Graph”</strong> class, in which there is a nested <strong>“Node”</strong> class to contain links to the following elements:
  <ul>
    <li>id</li>
    <li> node processing status</li>
    <li>parent</li>
    <li>coordinates</li>
    <li>name</li>
    <li> number of ancestors</li>
    <li>edges</li>
 </ul>
 The "Graph" class contains the following methods and accessors: 
 <ul>
  <li> "AddNode" - adding an element to the graph (depending on what is selected, directed or undirected, methods will be called to build the selected graph)</li>
    <li> "MaxID" - get maximum id </li>
    <li> "removeNode" - removing a node from the graph</li>
    <li>"loadgraph" - loading a graph from a file</li>
    <li>"Clone" - deep cloning </li>
    <li> "clear" - clearing the graph </li>
    <li>"dfs" - to search for a cycle in the graph</li>
  <li>"topologicalSort" to perform topological sorting graphically</li>
  </ul>
Class " Match" implements methods that allow you to calculate the coordinates of the nodes.<br>
After sorting the graph, the original graph can be viewed through the "CheckBox3" "show source graph".
</p>
<img src="https://github.com/StrongerProgrammer7/Working_with_graph/assets/71569051/a93e7be4-8d0b-43a3-bd0f-87e35ed05a63"/>
<img src="https://github.com/StrongerProgrammer7/Working_with_graph/assets/71569051/7f128550-02dd-4a63-9428-258520ef366b"/>

