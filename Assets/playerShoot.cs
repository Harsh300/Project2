using UnityEngine;

public class playerShoot : MonoBehaviour
{
    [SerializeField] private Transform camera = null;
    public GameObject wallSplatter;
    public GameObject enemySplatter;


    private float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            LayerMask enemyMask = LayerMask.GetMask("Enemy");
            LayerMask wallsMask = LayerMask.GetMask("Terrain");

            
            if (Physics.Raycast(camera.position, camera.forward, out hit, range, wallsMask))
            {
                Debug.Log("Shot the terrain: " + hit.collider.name);
                GameObject wallSpatter = Instantiate(wallSplatter, hit.point, Quaternion.identity);

            }
            if (Physics.Raycast(camera.position, camera.forward, out hit, range, enemyMask))
            {
                Debug.Log("Shot the enemy: " + hit.collider.name);
                GameObject enemySpatter = Instantiate(enemySplatter, hit.point, Quaternion.identity);
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.takeDamage();
               

            }
            

        }
    }
}
