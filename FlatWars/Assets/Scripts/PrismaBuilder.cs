using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaBuilder : MonoBehaviour
{     
    public enum TypeEnum{
        Grid,
        Radial,
        Custom
    };  
    
    public TypeEnum type = TypeEnum.Grid;
    //used if grid
    public int widthSteps = 1;
    public int heightSteps = 1;
    public int depthSteps = 1;
    
    public float sectorWidth = 1;
    public float sectorHeight = 1;
    public float sectorDepth = 1;
    //used if radial
    public float radius = 1;
    public int radialSteps = 6;
    
    public bool reverse = false;
    public bool doubleFace = false;
    public bool addBases = false;
    
    public Vector3[] basev = null;
    
    public bool buildOnStart = true;
    
    void Start(){
        if(buildOnStart)
            this.buildPrisma();
    }
    
    [ContextMenu("buildPrisma")]
    public void buildPrisma(){
        
        Mesh mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        
        if(type == TypeEnum.Custom)
            basev = mesh.vertices;
        else
            mesh.Clear();
        
        Vector3 v3 = gameObject.transform.position;
        if(type == TypeEnum.Grid){
            int W = widthSteps + 1;
            int H = heightSteps + 1;
            
            basev = new Vector3[2*(H-2)+2*W];
            
            v3.x = v3.x - widthSteps*sectorWidth/2 - sectorWidth;
            v3.y = v3.y + heightSteps*sectorHeight/2;  
            Debug.Log(v3);
            int k = 0;     
            for(int i = 0; i < W; i++, k++){   
                v3.x = v3.x + sectorWidth;
                basev[k] = v3; 
            }        
            for(int i = 0; i < H - 1; i++, k++){
                 v3.y = v3.y - sectorHeight;
                 basev[k] = v3;
            }
            for(int i = 0; i < W - 1; i++, k++){
                 v3.x = v3.x - sectorWidth;
                 basev[k] = v3;;
            }
            for(int i = 0; i < H - 2; i++, k++){
                 v3.y = v3.y + sectorHeight;
                 basev[k] = v3;
            }
        }
        else if(type == TypeEnum.Radial){
            float angleStep = Mathf.PI*2/radialSteps;
            basev = new Vector3[radialSteps];
            float currentAngle = 0f;
            for(int i = 0; i < radialSteps; i++){
                basev[i].x = v3.x + radius*Mathf.Cos(currentAngle);
                basev[i].y = v3.y + radius*Mathf.Sin(currentAngle);
                currentAngle -= angleStep; //clockwise
            }
        }
        
        //BUILD PRISMA
        int L = basev.Length;
        List<Vector3> verticesList = new List<Vector3>();
        List<int> trianglesList = new List<int>();
        
        float x, y, z;
        int idx = 0;
        for(int i = 0; i < depthSteps; i++){
            for(int j = 0; j < L; j++){
                //first
                x = basev[j].x;
                y = basev[j].y;
                z = basev[j].z + (i-depthSteps/2)*sectorDepth;
                verticesList.Add(new Vector3(x, y, z));
                //second
                z = basev[j].z + (i+1-depthSteps/2)*sectorDepth;
                verticesList.Add(new Vector3(x, y, z));
                //third
                x = basev[(j+1) % L].x;
                y = basev[(j+1) % L].y;
                z = basev[(j+1) % L].z + (i-depthSteps/2)*sectorDepth;
                verticesList.Add(new Vector3(x, y, z));
                //fourth
                z = basev[(j+1) % L].z + (i+1-depthSteps/2)*sectorDepth;
                verticesList.Add(new Vector3(x, y, z));
                
                trianglesList.Add(idx);
                trianglesList.Add(idx+1);
                trianglesList.Add(idx+3);
                
                trianglesList.Add(idx);
                trianglesList.Add(idx+3);
                trianglesList.Add(idx+2);
                idx += 4;
            }
        }
        
        //ADD BASES IF REQUIRED
        if(addBases){
            float nearZ = verticesList[0].z;
            float farZ = verticesList[verticesList.Count-1].z;
            if(type == TypeEnum.Grid){
                
                Vector3 topLeft = basev[0]; //top left vertex
                            
                for(int k = 0; k < 2; k++){
                    if(k == 0)
                        z = nearZ;
                    else
                        z = farZ;
                    for(int i = 0; i < widthSteps; i++){
                        for(int j = 0; j < heightSteps; j++){
                            //top left
                            x = topLeft.x + i*sectorWidth;
                            y = topLeft.y - j*sectorHeight;
                            verticesList.Add(new Vector3(x, y, z));
                            //top right
                            x = topLeft.x + (i+1)*sectorWidth;
                            verticesList.Add(new Vector3(x, y, z));
                            //bottom right
                            y = topLeft.y - (j+1)*sectorHeight;
                            verticesList.Add(new Vector3(x, y, z));
                            //bottom left
                            x = topLeft.x + i*sectorWidth;
                            verticesList.Add(new Vector3(x, y, z));
                            
                            if(k == 0){
                                trianglesList.Add(idx);
                                trianglesList.Add(idx+1);
                                trianglesList.Add(idx+3);
                                
                                trianglesList.Add(idx+3);
                                trianglesList.Add(idx+1);
                                trianglesList.Add(idx+2);
                            }
                            else{
                                trianglesList.Add(idx+3);
                                trianglesList.Add(idx+1);
                                trianglesList.Add(idx);
                                
                                trianglesList.Add(idx+2);
                                trianglesList.Add(idx+1);
                                trianglesList.Add(idx+3);       
                            }
                            
                            idx += 4;
                        }
                    }
                }                               
            }
            else if(type == TypeEnum.Radial){
                int centerIdx;
                for(int k = 0; k <2; k++){
                    if(k == 0)
                        z = nearZ;
                    else
                        z = farZ;
                    verticesList.Add(new Vector3(transform.position.x, transform.position.y, z));
                    centerIdx = idx;
                    idx++;
                    for(int i = 0; i < L; i++){
                        x = basev[i].x;
                        y = basev[i].y;
                        verticesList.Add(new Vector3(x, y, z));
                        x = basev[(i+1) % L].x;
                        y = basev[(i+1) % L].y;
                        verticesList.Add(new Vector3(x, y, z));
                        
                        
                        if(k == 0){
                            trianglesList.Add(idx);
                            trianglesList.Add(centerIdx);
                            trianglesList.Add(idx+1);
                        }
                        else{
                            trianglesList.Add(idx+1);
                            trianglesList.Add(centerIdx);
                            trianglesList.Add(idx);
                        }
                        
                        idx += 2;
                        
                    }
                }
                
            }          
        }
        
        Vector3[] vertices = verticesList.ToArray();
        int[] triangles = trianglesList.ToArray();
               
        //HANDLE ADDITIONAL OPTIONS
        if(doubleFace){
            Vector3[] newVertices = new Vector3[vertices.Length*2];
            for(int i = 0; i < 2*vertices.Length; i++)
                newVertices[i] = vertices[i % vertices.Length];
                
            int[] newTriangles = new int[triangles.Length*2];
            for(int i = 0; i < triangles.Length; i++)
                newTriangles[i] = triangles[i];
            for(int i = 0; i < triangles.Length; i++)
                newTriangles[triangles.Length + i] = vertices.Length + triangles[triangles.Length - 1 - i];
            vertices = newVertices;
            triangles = newTriangles;
        }
        else if(reverse){
            int[] newTriangles = new int[triangles.Length];
            for(int i = 0; i < triangles.Length; i++)
                newTriangles[i] = triangles[triangles.Length - 1 - i];
            triangles = newTriangles;
                
        } 
        
        //SAVE MESH
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        
        DestroyImmediate(gameObject.GetComponent<MeshCollider>());
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();
        collider.sharedMesh = mesh;
        
    } 
}

