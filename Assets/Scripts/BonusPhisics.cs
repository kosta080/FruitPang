using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPhisics : MonoBehaviour
{
    [SerializeField] private int bonusScoreValue;
    [SerializeField] private float bonusSpoilTime;
    public void SetPos(Vector3 _position)
    {
        transform.position = _position;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        
        if (_collision.gameObject.tag == "Player")
        {
            GameManager.Instance.BonusCollected(bonusScoreValue);
            SoundManager.Instance.PlaySfx(SoundManager.Instance.bonusCollected);
            Destroy(gameObject); // destroy this bonus
        }
        if (_collision.gameObject.tag == "Ground")
        {
            StartCoroutine(destroyBonus());
        }

    }
    private IEnumerator destroyBonus()
    {
        yield return new WaitForSeconds(bonusSpoilTime);
        Destroy(gameObject); // destroy this bonus
    }
}
