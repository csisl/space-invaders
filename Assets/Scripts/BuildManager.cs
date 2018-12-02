using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuildManager : MonoBehaviour
{

    // singleton pattern
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject laserPrefab;
    public GameObject missilePrefab;
    public Text moneyText;
    private float timeLeft = 60.0f;
    public Text timeLeftText;
    private int round = 1;
	private int level = 1;
	public Text levelText;

    void Awake()
    {
        // every time we start the game there will only be one instance of the build manager
        instance = this;
    }

    void Start()
    {
        moneyText.text = "$50" + PlayerStats.money.ToString();
		levelText.text = "Level " + level.ToString();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
			
            if (round == 1)
            {
				WaveSpawner.waveNumber = 1;
				timeLeft = 60.0f;
				level = 2;
				round++;
				levelText.text = "Level " + level.ToString();
				PlayerStats.money = 500;
				Health.health = 100;
            }
            else if (round == 2)
            {
				WaveSpawner.waveNumber = 1;
				timeLeft = 60.0f;
				level = 3;
				round++;
				levelText.text = "Level " + level.ToString();
				PlayerStats.money = 500;
				Health.health = 100;
            }
            else if (round == 3)
            {
                SceneManager.LoadScene("WinnerScreen");
            }
        }
        timeLeftText.text = Mathf.Floor(timeLeft % 60).ToString() + " seconds left";
    }

    // public void SetTurretToBuild(GameObject turret){
    // 	// change what turret we want to build
    // 	turretToBuild = turret;
    // }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.money < turretToBuild.cost)
        {
            // they don't have enough money to build that turret
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        moneyText.text = "$" + PlayerStats.money.ToString();

        // build on particular node
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void UpgradeWeapons()
    {
        if (PlayerStats.money < 100)
        {
            return;
        }
        PlayerStats.money -= 100;
        moneyText.text = "$" + PlayerStats.money.ToString();
    }


}
