using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour {
    
    //public EnemySpawner enemySpawner;
    //public WallSpawnerLogic wallSpawner;
    public PrismaBuilder tunnelPrismaBuilder;
    
    public PrismaBuilder.TypeEnum tunnelType = PrismaBuilder.TypeEnum.Grid;
    //used if grid
    public int tunnelWidthSteps = 3;
    public int tunnelHeightSteps = 2;
    public int tunnelDepthSteps = 14;
    
    public float tunnelSectorWidth = 12;
    public float tunnelSectorHeight = 10;
    public float tunnelSectorDepth = 50;
    //used if radial
    public float tunnelRadius = 12;
    public int tunnelRadialSteps = 6;
    
    public bool tunnelReverse = false;
    public bool tunnelDoubleFace = false;
    public bool tunnelAddBases = false;
    
	// Use this for initialization
	void Start () {
	
	    tunnelPrismaBuilder.type = tunnelType;
	    if(tunnelType == PrismaBuilder.TypeEnum.Grid){
	        tunnelPrismaBuilder.widthSteps = tunnelWidthSteps;
            tunnelPrismaBuilder.heightSteps = tunnelHeightSteps;
            tunnelPrismaBuilder.depthSteps = tunnelDepthSteps;
            
            tunnelPrismaBuilder.sectorWidth = tunnelSectorWidth;
            tunnelPrismaBuilder.sectorHeight = tunnelSectorHeight;
            tunnelPrismaBuilder.sectorDepth = tunnelSectorDepth;
        }
        else if(tunnelType == PrismaBuilder.TypeEnum.Radial){
            tunnelPrismaBuilder.radius = tunnelRadius;
            tunnelPrismaBuilder.radialSteps = tunnelRadialSteps;
        }
        tunnelPrismaBuilder.reverse = tunnelReverse;
        tunnelPrismaBuilder.doubleFace = tunnelDoubleFace;
        tunnelPrismaBuilder.addBases = tunnelAddBases;
        
        tunnelPrismaBuilder.buildPrisma();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
