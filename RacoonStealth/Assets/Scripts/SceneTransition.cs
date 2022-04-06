using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")&& !other.isTrigger)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
    IEnumerator LoadLevel(int index){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);

    }
}
