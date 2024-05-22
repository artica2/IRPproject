using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBuilder : MonoBehaviour
{
    private Tree behaviourTree; // The AI's behaviour Tree

    public GameObject targetOBJBlue; 
    public GameObject targetOBJGreen;
    public GameObject targetOBJRed;

    public static TreeBuilder instance; // make this class a singleton

    public Node contextNode; // The current node to be adding to

    public bool inputToProcess; // check whether there is new input to process
    public string stringToProcess; // the string of instructions to be processed

    // Dictionary to hold the instruction/node pairs
    private Dictionary<string, Func<Node>> NodeFactory = new Dictionary<string, Func<Node>>();
    private void Awake()
    {
        // set up the singleton
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        inputToProcess = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // setup a basic tree
        behaviourTree = new Tree();
        behaviourTree.AI = this.gameObject;
        SetupDictionary();
        SetupTree();
        // setup wander behaviour as the default idle behaviour
        Wander wanderNode = new Wander();
        behaviourTree.rootNode.AddChild(wanderNode);
        wanderNode.InitializeNode();
        wanderNode.behaviourTree = behaviourTree;
    }

    private void Update()
    {
        // execute the behaviour tree
        if (behaviourTree != null)
        {
            behaviourTree.Execute();
        } if (inputToProcess) 
        {
            // make sure the tree is cleared and ready
            SetupTree();
            // parse the string
            List<string> instructions = ParseString(stringToProcess);
            // for each word in the instructions
            foreach(string instruction in instructions) {
                string keyToTry = instruction;
                string descriptor = " ";
                if (instruction.Contains(":")) // if there is a qualifier (a descriptor) split the string
                {
                    string[] parts = instruction.Split(':');
                    keyToTry = parts[0];
                    descriptor = parts[1];
                }
                if(NodeFactory.TryGetValue(keyToTry, out Func<Node> nodeFactory)) // refer to the dictionary to retrieve the correct node type
                {
                    Node node = nodeFactory(); // create a new node
                    contextNode.AddChild(node); // add node to the current context node
                    node.InitializeNode(descriptor); // initialize the node
                    node.behaviourTree = behaviourTree; // add the node to the behaviour tree
                }
            }
            // create a wander node on the far right of the tree to be default behaviour after instructions have been carried out
            Wander wanderNode = new Wander(); 
            behaviourTree.rootNode.AddChild(wanderNode);
            wanderNode.InitializeNode();
            wanderNode.behaviourTree = behaviourTree;
            inputToProcess = false;
            
        }
    }
    public List<string> ParseString(string stringToParse)
    {
        // create an empty list of string
        List<string> list = new List<string>();
        string targetString = string.Empty; // target string will the the string that the word is loaded into
        for (int i = 0; i < stringToParse.Length; i++)
        {
            // start a new word
            if (stringToParse[i] == ' ')
            {
                string dupeString = targetString;
                list.Add(dupeString);
                targetString = string.Empty;
            } else // add the letter to the current word
            {
                targetString += stringToParse[i];
            }
        }
        // return the list of words
        list.Add(targetString);
        return list;
    }

    public void SetupTree()
    {
        behaviourTree.nodes.Clear(); // clear the tree
        // set up a root node
        RootNode root = new RootNode();
        root.InitializeNode();
        behaviourTree.rootNode = root;
        root.isActiveNode = true;
        root.behaviourTree = behaviourTree;
        behaviourTree.nodes.Add(root);
        behaviourTree.currentNode = root;
        contextNode = root;
    }

    public void SetupDictionary()
    {
        // add each of the relevant nodes to a dictionary
        NodeFactory.Add("then", () => new SequenceNode());
        NodeFactory.Add("dance", () => new Dance());
        NodeFactory.Add("movetotarget", () => new MoveToTarget());
    }
}
