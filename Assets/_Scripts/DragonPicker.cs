using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    
    public List<GameObject> shieldList;
    void Start()
    {
        int[] numOfShieldsPerLevel = { 3, 3, 3, 3, 2, 2, 2, 1, 1, 1};
        shieldList = new List<GameObject>();
        for (int i = 1; i <= numOfShieldsPerLevel[SceneManager.GetActiveScene().buildIndex - 1]; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i,1*i,1*i);
            shieldList.Add(tShieldGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragonEggDestroyed(){
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (GameObject tGO in tDragonEggArray){
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0){
            SceneManager.LoadScene("_0Scene");
        }
    }
}
