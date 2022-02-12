using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATP1_CW2
{
    public class GameData : MonoBehaviour
    {
        //Checkpoint variables
        public Transform[] spawnPoints;
        public Checkpoint checkpoint;

        //using to disable the movement and triggerring the death
        private HeroKnight heroKnight;

        //Using to trigger jump animation
        private Animator m_animator;

        public GameObject resumePanel;

        private void Awake()
        {
            heroKnight = GetComponent<HeroKnight>();
            m_animator = GetComponent<Animator>();
        }

        private void Start()
        {
            resumePanel.SetActive(false);
            UpdatePlayerPosition();
        }

        private void UpdatePlayerPosition()
        {
            switch (checkpoint)
            {
                case Checkpoint.CheckpointOne:
                    this.transform.position = spawnPoints[0].transform.position;
                    break;

                case Checkpoint.CheckpointTwo:
                    this.transform.position = spawnPoints[1].transform.position;
                    break;

                case Checkpoint.CheckpointThree:
                    this.transform.position = spawnPoints[2].transform.position;
                    break;

                case Checkpoint.CheckpointFour:
                    this.transform.position = spawnPoints[3].transform.position;
                    break;

                case Checkpoint.CheckpointFive:
                    this.transform.position = spawnPoints[4].transform.position;
                    break;

                default:
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Checkpoint")
            {
                checkpoint = Checkpoint.CheckpointOne;
            }

            if (collision.gameObject.tag == "CheckpointTwo")
            {
                checkpoint = Checkpoint.CheckpointTwo;
            }

            if (collision.gameObject.tag == "CheckpointThree")
            {
                checkpoint = Checkpoint.CheckpointThree;
            }

            if (collision.gameObject.tag == "CheckpointFour")
            {
                checkpoint = Checkpoint.CheckpointFour;
            }


            if (collision.gameObject.tag == "CheckpointFive")
            {
                checkpoint = Checkpoint.CheckpointFive;
            }

            if (collision.gameObject.tag == "Respawn")
            {
                UpdatePlayerPosition();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Trap")
            {
                heroKnight.Death();
                collision.gameObject.GetComponent<AudioSource>().Play();
                heroKnight.enabled = false;
                StartCoroutine("FreezeTime");
            }
        }

        private IEnumerator FreezeTime()
        {
            yield return new WaitForSeconds(2);
            resumePanel.SetActive(true);

            StopCoroutine("FreezeTime");
        }

        public void Replay()
        {
            UpdatePlayerPosition();
            resumePanel.SetActive(false);
            heroKnight.enabled = true;
            m_animator.SetTrigger("Jump");
        }
        public void Checkpoint1()
        {
            checkpoint = Checkpoint.CheckpointOne;
            UpdatePlayerPosition();
        }

        public void Checkpoint2()
        {
            checkpoint = Checkpoint.CheckpointTwo;
            UpdatePlayerPosition();
        }

        public void Checkpoint3()
        {
            checkpoint = Checkpoint.CheckpointThree;
            UpdatePlayerPosition();
        }

        public void Checkpoint4()
        {
            checkpoint = Checkpoint.CheckpointFour;
            UpdatePlayerPosition();
        }

        public void PlayAgain()
        {
            Checkpoint1();
        }

    }

    public enum Checkpoint
    {
        CheckpointOne,
        CheckpointTwo,
        CheckpointThree,
        CheckpointFour,
        CheckpointFive
    }


}