using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeDrop : MonoBehaviour
{
    public GameObject TreeDropedElement;
    public GameObject Gem;
    private SpriteRenderer _renderer;
    public Color AddColor;
    private Color _cirrentAddColor;
    private Color _clearColor = new Color (1,1,1,1);
    public int count;
    private float Health = 100;
 
    private bool _isClear;



   
    private void Start()
    {
        
        _renderer = GetComponent<SpriteRenderer>();
        _cirrentAddColor = _clearColor;

    }




    private void FixedUpdate()
    {
        _cirrentAddColor = Color.Lerp(_cirrentAddColor, _clearColor, Time.deltaTime);
        _renderer.color = _cirrentAddColor;
    }


    public void OnClick(AudioClip clip)
    {


        Health -= 25;
        
        GetComponent<AudioSource>().PlayOneShot(clip);
        if (Health <= 0)
        {
            int count = Random.Range(3, 5);
            int countGem = Random.Range(1, 3);
            var p = transform.position;

            for (int i = 0; i < count; i++)
            {
                Instantiate(TreeDropedElement, new Vector3(p.x, p.y + i, p.z), Quaternion.identity);

            }
            for (int i = 0; i < countGem; i++)
            {

                Instantiate(Gem, new Vector3(p.x, p.y + i, p.z), Quaternion.identity);
            }

            Destroy(gameObject);
        }



    }

    public void OnEnter()
    {

        _isClear = false;
    }

    public void OnExit()
    {
        _isClear = true;
    }
}
