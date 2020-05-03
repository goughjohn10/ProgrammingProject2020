using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRIDCITY
{
    public enum blockType { Block, Arches, Columns, Dishpivot, DomeWithBase, HalfDome, SlitDome, Slope, Tile};

	public class CityManager : MonoBehaviour
    {

        #region Fields
        private static CityManager _instance;
        // public Mesh[] meshArray;
       // public Material[] materialArray;
        public GameObject buildingPrefab;
        public BuildingProfile[] profileArray;

        public BuildingProfile wallProfile;

        private bool[,,] cityArray = new bool [50,50,50];   //increased array size to allow for larger city volume

        public static CityManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        #region Properties	
        #endregion

        #region Methods
        #region Unity Methods

        
        void Awake () {
            if (_instance == null)
            {
                _instance = this;
            }

            else
            {
                Destroy(gameObject);
                Debug.LogError("Multiple CityManager instances in Scene. Destroying clone!");
            };
        }

        private void InstantiateDeluxeTower(int x, int z, int profileArrayIndex)
        {
            var position = new Vector3(x, 0.00f, z);
            Instantiate(buildingPrefab, position, Quaternion.identity).GetComponent<DeluxeTowerBlock>().SetProfile(profileArray[profileArrayIndex]);
        }
		// Use this for external initialization
		void Start ()
        {
            //Centre of map empty.
            for (int ix=4; ix <7; ix++)
            {
                for (int iz = 4; iz < 7; iz++)
                {
                    for (int iy = 0; iy < 3; iy++)
                    {
                        SetSlot(ix + 7, iy, iz + 7, true);
                    }
                }
            }

            //City Walls
            for (int i=-7 ; i < 17 ; i += 23)
            {
                for (int j = -7; j < 17; j += 1)
                {
                    Instantiate(buildingPrefab, new Vector3(i, 0.0f, j), Quaternion.identity).GetComponent<DeluxeTowerBlock>().SetProfile(wallProfile);
                }
                for (int j = -6; j < 16; j += 1)
                {
                    Instantiate(buildingPrefab, new Vector3(j, 0.0f, i), Quaternion.identity).GetComponent<DeluxeTowerBlock>().SetProfile(wallProfile);
                }
            }
            
            

            //Buildings
            for (int i=-20;i<20;i+=5)
            {
                for (int j=-20;j<20;j+=5)
                {
                    int random = Random.Range(0, profileArray.Length);
                    for (int x = i - 1; x < i + 1; x++)
                    {
                        for (int z = j - 1; z < j + 1; z++)
                        {
                            InstantiateDeluxeTower(x, z, random);
                        }
                        
                    }
                   
                }
            }
            
            
		}
		
		#endregion

        public bool CheckSlot(int x, int y, int z)
        {
            if (x < 0 || x > 25 || y < 0 || y > 25 || z < 0 || z > 25) return true;
            else
            {
                return cityArray[x, y, z];
            }

        }

        public void SetSlot(int x, int y, int z, bool occupied)
        {
            if (!(x < 0 || x > 25 || y < 0 || y > 25 || z < 0 || z > 25))
            {
                cityArray[x, y, z] = occupied;
            }

        }

        #endregion

    }
}
