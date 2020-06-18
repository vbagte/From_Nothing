using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public IEnumerator Death()
    {
        LevelManager.canPause = false;
        Chimera.bossStop = true;
        Vector2 stop = new Vector2(0, 0);
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = stop;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
        yield return new WaitForSeconds(1);
        GameObject.Find("DeathMessage").GetComponent<Animation>().Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
