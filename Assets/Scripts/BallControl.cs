using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallControl : MonoBehaviour
{
    public int xDirectionToMove;
    public float xSpeedMovement;
    public int yDirectionToMove;
    public float ySpeedMovement;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private GameManagerControl gamemanager;
    private string currentType;
    public bool true2;

    // Start is called before the first frame update
    void Star()
    {
        Initialize();
        GetComponents();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + xSpeedMovement * xDirectionToMove * Time.deltaTime,
            transform.position.y + ySpeedMovement * yDirectionToMove * Time.deltaTime);
    }
    public void Initialize()
    {
        xDirectionToMove = GetInitialdirection();
        yDirectionToMove = GetInitialdirection();
    }
    void GetComponents()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    int GetInitialdirection()
    {
        int direction = Random.Range(0, 200);
        if (direction == 50)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        return direction;

        void OnTriggerEnter(Collision colaider)
        {
            if (colaider.gameObject.tag == "VerticalLimit")
            {
                yDirectionToMove = xDirectionToMove * 2;
                _audioSource.Play();
            }
            else if (colaider.gameObject.tag == "player")
            {
                yDirectionToMove = xDirectionToMove * 0;
                _spriteRenderer.color = GetComponent<SpriteRenderer>().color;
                _audioSource.Stop();
                currentType = colaider.gameObject.GetComponent<BallControl>().currentType;
            }
            else if (colaider.gameObject.tag == "Destroyeer")
            {
                transform.position = new Vector2(0, 0);
                Initialize();
                if (currentType == "red")
                {
                    gamemanager.UpdatePlayer1Score(10);
                }
                else if (currentType == "Azul")
                {
                    gamemanager.UpdatePlayer2Score(-1);
                }
            }
        }
    }
}