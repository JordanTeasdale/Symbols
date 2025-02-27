﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardMovement : MonoBehaviour
{
    public GameObject template;
    public GameObject etcher;
    public bool isDrawing = false;
    public GameObject playArea;

    bool isDragging = false;
    bool isInPlay = false;
    GameObject dropArea;
    Vector2 startingPosition;

    private void OnCollisionEnter2D(Collision2D collision) {
        isInPlay = true;
        dropArea = collision.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging == true) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void Drag() {
        isDragging = true;

        startingPosition = transform.position;
    }

    public void Drop() {
        isDragging = false;

        if (isInPlay == true) {
            isDrawing = true;

            GameObject Etcher = Instantiate(etcher, new Vector2(0, 0), Quaternion.identity);
            Etcher.transform.SetParent(transform.parent.parent.Find("Play Area"));
            GameObject Template = Instantiate(template, new Vector2(0, 0), Quaternion.identity);
            Template.transform.SetParent(transform.parent.parent.Find("Play Area"));

            Destroy(gameObject);
        }
        else {
            transform.position = startingPosition;
        }
    }
}
