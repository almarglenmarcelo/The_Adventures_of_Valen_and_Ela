using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DrawScript : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    int reloadSketchPad = 3;

    LineRenderer currentLineRenderer;


    
    Vector2 lastPos;

   
    private void Update()
    {
        Draw();

    }


    void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            AddAPoint(mousePos);

            if(mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLineRenderer = null;
        }

    }
    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);

        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();


        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }


    // To be revised -- Need to clear brush without exiting to last scene
    public void ClearBrushes()
    {
        GameObject[] brushes = GameObject.FindGameObjectsWithTag("Brush");

        

        for(int i = 1;i < brushes.Length; i++)
        {
            Destroy(brushes[i]);
        }

    }


    public void sketchpadActive(GameObject sketchpad)
    {
        sketchpad.SetActive(true);

    }

    public void sketchpadInactive(GameObject sketchpad)
    {
        sketchpad.SetActive(false);

    }
    public void quizpanelActive(GameObject quizpanel)
    {

        quizpanel.SetActive(true);
    }

    public void quizpanelInactive(GameObject quizpanel)
    {

        quizpanel.SetActive(false);
    }

}
