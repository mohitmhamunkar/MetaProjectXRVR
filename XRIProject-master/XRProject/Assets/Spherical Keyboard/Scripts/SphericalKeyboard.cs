using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalKeyboard : MonoBehaviour 
{
	[Space(10)]
	[Header("General")]

	[SerializeField]
	private float radius = 1f;
	[SerializeField]
	private bool AddABoxCollider = false;

	[Space(10)]
	[Header("Nodes")]
	[SerializeField]
	private GameObject node;
	[Range(0.1f, 10.0f)]
	[SerializeField]
	private float nodeScale = .1f; 
	[SerializeField]
	private bool OverrideNodeMaterial = false;
	[SerializeField]
	private Material nodeMaterial;

	[Space(10)]
	[Header("Lines")]
	[SerializeField]
	private Material lineMaterial;
	[Range(0.1f, 10.0f)]
	[SerializeField]
	private float lineWidth = .1f;


	[Space(10)]
	[Header("Gizmos")]
	[SerializeField]
	private bool showGizmos = false; 

	private static string dodecahedronIcon = "Dodecahedron";

	private BoxCollider boxCollider;
	private GameObject[] nodes;
	private LineRenderer[] linerenderers;
	private int destroyedNodeIndex = -1;
	private Material materialBrokenLink;

	public int vertexCount = 28; // number of vertices to generate
	public float sphereRadius = 0.3f; // radius of the sphere
	private Vector3[] vertices;
	public float rotateSpeed = 360f;
	List<string> alphabets =new List<string>(new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","Space","Clear"});

	// private Vector3[] vertices = new Vector3[] 
	// 	{ 
	// 		new Vector3(0.00f, -0.20f, 0.00f),
	// 		new Vector3(-0.06f, -0.19f, 0.05f), 
	// 		new Vector3(0.01f, -0.17f, -0.10f),
	// 		new Vector3(0.08f, -0.16f, 0.10f), 
	// 		new Vector3(-0.14f, -0.14f, -0.02f),
	// 		new Vector3(0.13f, -0.13f, -0.08f),
	// 		new Vector3(-0.04f, -0.11f, 0.16f),
	// 		new Vector3(-0.08f, -0.10f, -0.16f),
	// 		new Vector3(0.17f, -0.08f, 0.06f),
	// 		new Vector3(-0.17f, -0.07f, 0.07f),
	// 		new Vector3(0.08f, -0.05f, -0.17f),
	// 		new Vector3(0.06f, -0.04f, 0.19f),
	// 		new Vector3(-0.17f, -0.02f, -0.10f),
	// 		new Vector3(0.20f, -0.01f, -0.04f),
	// 		new Vector3(-0.11f, 0.01f, 0.16f),
	// 		new Vector3(-0.03f, 0.02f, -0.20f),
	// 		new Vector3(0.15f, 0.04f, 0.13f),
	// 		new Vector3(-0.19f, 0.05f, 0.01f),
	// 		new Vector3(0.13f, 0.07f, -0.13f),
	// 		new Vector3(-0.01f, 0.08f, 0.18f),
	// 		new Vector3(-0.11f, 0.10f, -0.13f),
	// 		new Vector3(0.16f, 0.11f, 0.02f),
	// 		new Vector3(-0.13f, 0.13f, 0.09f),
	// 		new Vector3(0.03f, 0.14f, -0.14f),
	// 		new Vector3(0.06f, 0.16f, 0.11f),
	// 		new Vector3(-0.10f, 0.17f, -0.03f),
	// 		new Vector3(0.07f, 0.19f, -0.03f),
	// 		new Vector3(0.00f, 0.20f, 0.00f)
	// 		// new Vector3(  0.4f,  0.8f,  0.5f ),
	// 		// new Vector3(  0.4f,  0.8f,  0.5f ),
	// 		
	// 	};
	

	// Use this for initialization
	void Start () {
		initializeSphericalkeyboard();

		materialBrokenLink = new Material( Shader.Find("Standard") );
		materialBrokenLink.SetColor( "_Color",  Color.red );
	}

	void Update () {
	
		for(int i=0; i < nodes.Length; ++i)
		{
			GameObject goNode = nodes[i];
			if( goNode )
				goNode.transform.rotation = Quaternion.Euler( 0f, 0f, 0f );
		}
		RotateSphere();

	}

	void OnDrawGizmos()
	{
		if( ! showGizmos )
			return;

		Gizmos.DrawIcon( transform.position, dodecahedronIcon, true );

		Gizmos.color = Color.green;

		Gizmos.color = Color.blue;
		for( int i=0; i < vertices.Length; ++i )
		{
			Gizmos.DrawWireSphere( transform.position + ( vertices[i] * transform.lossyScale.x * radius ) , 1f );
		}
	}

	public void destroyRandomNode()
	{
		destroyNode( Random.Range(0,20) );
	}

	public void destroyNode( int nodeIndex )
	{
		destroyedNodeIndex = nodeIndex;
		updateAppearance();
	}

	public void repairNode( GameObject newNodeDummy )
	{
		if( destroyedNodeIndex >= 0 && destroyedNodeIndex < nodes.Length && newNodeDummy != null )
		{
			GameObject newNode = Instantiate( newNodeDummy );

			GameObject oldNode = nodes[destroyedNodeIndex];
			newNode.transform.SetParent( oldNode.transform.parent );
			newNode.transform.localScale = oldNode.transform.localScale;
			newNode.transform.localRotation = oldNode.transform.localRotation;
			newNode.transform.localPosition = oldNode.transform.localPosition;

			nodes[destroyedNodeIndex] = newNode;
			Destroy( oldNode );
		}
		destroyedNodeIndex = -1;

		updateAppearance();
	}

	public void destroyTopNode()
	{
		destroyNode( getIndexOfHighestNode() );
	}

	public int getIndexOfHighestNode()
	{
		int indexOfHighestNode = 0;

		for( int i = 1; i < nodes.Length; ++i )
		{
			if( nodes[i].transform.position.y > nodes[indexOfHighestNode].transform.position.y )
			{
				indexOfHighestNode = i;
			}
		}

		return indexOfHighestNode;
	}

	public Vector3 positionOfDestroyedNode()
	{
		if( destroyedNodeIndex >= 0 && destroyedNodeIndex < nodes.Length )
		{
			return ( nodes[ destroyedNodeIndex ] != null ) ? nodes[destroyedNodeIndex].transform.position : transform.position;
		}
		else
		{
			return transform.position;
		}
	
	}

	public void initializeSphericalkeyboard()
	{
		createVertices();
		transform.rotation = Quaternion.Euler( Vector3.zero );
		Vector3 point = transform.position;

		//Create the hierarchy
		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--)
		{
			if( Application.isEditor )
			{
				GameObject.DestroyImmediate( transform.GetChild(i).gameObject, false );
			}
			else
			{
				GameObject.Destroy(transform.GetChild(i).gameObject);
			}	
		}

		if( lineMaterial == null )
		{
			lineMaterial = new Material( Shader.Find("Standard") );
			lineMaterial.SetColor( "_Color",  Color.green );
		}

		if( nodeMaterial == null )
		{
			nodeMaterial = new Material( Shader.Find("Standard") );
			nodeMaterial.SetColor( "_Color",  Color.blue );
		}
		//Create vertices / nodes
		nodes = new GameObject[vertices.Length];
		for( int i  = 0; i < vertices.Length ; ++i )
		{
			GameObject goNode;
			if( node!=null )
			{
				goNode = Instantiate<GameObject>( node );
			}
			else
			{
				goNode = GameObject.CreatePrimitive( PrimitiveType.Sphere );
			}

			if( OverrideNodeMaterial )
			{
				goNode.GetComponent<Renderer>().sharedMaterial = nodeMaterial;
			}

			
			 goNode.name = "node_"+alphabets[i];
			 goNode.transform.LookAt(point);
			goNode.GetComponent<ChangeText>().textComponent.text=alphabets[i];
			// /* Adjust height */
			 goNode.transform.Translate (new Vector3 (0, goNode.transform.localScale.y / 2, 0));
			
			//goNode.name = "node_"+i;
			goNode.transform.SetParent( transform );
			goNode.transform.localPosition = vertices[i] * radius;
			goNode.transform.localScale = new Vector3(nodeScale,nodeScale,nodeScale);
			goNode.SetActive( i != destroyedNodeIndex );

			nodes[i] = goNode;
		}
		
		//Create BoxCollider if required
		if( AddABoxCollider )
		{
			boxCollider = gameObject.AddComponent<BoxCollider>();
			boxCollider.size = new Vector3( radius * 1.8f, radius * 1.6f, radius * 1.6f );
		}
	}

	public void updateAppearance()
	{
		for( int i  = 0; i < nodes.Length ; ++i )
		{
			GameObject goNode = nodes[i];
			goNode.SetActive( i != destroyedNodeIndex );
		}
	}

	public void createVertices()
	{
		// generate vertices on the surface of the sphere
		vertices = new Vector3[vertexCount];
		for (int i = 0; i < vertexCount; i++)
		{
			float latitude = Mathf.Asin(2f * i / (float)(vertexCount - 1) - 1f);
			float longitude = i * Mathf.PI * (3f - Mathf.Sqrt(5f));
			Vector3 position = new Vector3(
				Mathf.Cos(longitude) * Mathf.Cos(latitude),
				Mathf.Sin(latitude),
				Mathf.Sin(longitude) * Mathf.Cos(latitude)
			);
			vertices[i] = position * sphereRadius;
		}
	}

	public void createVertices2()
	{
		// Set up arrays to hold vertex and triangle data
		Vector3[] vertices = new Vector3[vertexCount * vertexCount];

		// Calculate the angle between vertices
		float angleDelta = Mathf.PI / (vertexCount - 1);

		// Create vertices
		for (int i = 0; i < vertexCount; i++)
		{
			for (int j = 0; j < vertexCount; j++)
			{
				float x = Mathf.Cos(j * angleDelta) * Mathf.Sin(i * angleDelta);
				float y = Mathf.Sin(j * angleDelta) * Mathf.Sin(i * angleDelta);
				float z = Mathf.Cos(i * angleDelta);
				vertices[i * vertexCount + j] = new Vector3(x, y, z) * sphereRadius;
			}
		}
	}
	void RotateSphere ()
	{
		if (Input.GetAxisRaw ("Vertical") > 0) {
// transform.Rotate (Vector3.right, rotateSpeed * Time.deltaTime);
		} else if (Input.GetAxisRaw ("Vertical") < 0) {
// transform.Rotate (Vector3.left, rotateSpeed * Time.deltaTime);
		} else if (Input.GetAxisRaw ("Horizontal") > 0) {
			RotateRight();
		} else if (Input.GetAxisRaw ("Horizontal") < 0) {
			RotateLeft();
		}
	}
	public void RotateRight(){
		transform.Rotate (Vector3.down , rotateSpeed * Time.deltaTime);

	}
	public void RotateLeft(){
		transform.Rotate (Vector3.up , rotateSpeed * Time.deltaTime);

	}
}
