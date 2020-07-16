using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public struct View
{
    public string name;
    public Vector3 offset;
    public string targetTag;
    public bool followTarget;
    public bool alwaysLookForward;

    public View(string name, float x, float y, float z, string targetTag, bool followTarget = true, bool alwaysLookForward = false)
    {
        this.name = name;
        this.offset = new Vector3(x, y, z);
        this.targetTag = targetTag;
        this.followTarget = followTarget;
        this.alwaysLookForward = alwaysLookForward;
    }
}

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private int currentViewIndex = 0;
    // TODO private Transform viewTarget;
    [SerializeField] private GameObject lookat;
    [SerializeField] public bool followTarget;
    View currentView;
    [SerializeField] private TextMeshProUGUI viewText;
    [SerializeField] private TextMeshProUGUI viewTextShadow;

    private View[] views = new[] {
        new View("Follow",   0, 4,-7,          "Player"),
        new View("Dashboard",   0, 2.2f, 0.5f, "Player", true, true),
        new View("BirdsEye",    0,80, 0,       "Road",   false),
        new View("CinemaCam",  10, 1, 10,      "Player", false),   // 10 units away from road, 10 units ahead of player, track but do not follow 
        new View("Opponent",    0, 4, -7,      "Enemy"),           // follow enemy
        new View("KittyCam",    0,0,0,         "Kitty",  false, false)
    };
    
    private void Start()
    {
        SetView(0);
    }

    private void Update()
    {
        transformCamera();
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SetView((currentViewIndex + 1) % views.Length);
        else if (Input.GetKeyDown(KeyCode.V))
            SetView(0);

        transformCamera();
    }

    void transformCamera(bool forceFollowTarget = false)
    {
        if (followTarget || forceFollowTarget)
        {
            transform.rotation = lookat.transform.rotation;
            transform.position = lookat.transform.position;
            transform.Translate(offset);
        }
        if (!currentView.alwaysLookForward)
            transform.LookAt(lookat.transform);
    }

    void SetView(int indexView)
    {
        Debug.Log("SetView(" + indexView + ")");

        Assert.IsTrue(indexView >= 0 && indexView < views.Length);
        currentViewIndex = indexView;

        // skip views with non-existant targets
        while ((lookat = GameObject.FindGameObjectWithTag(views[currentViewIndex].targetTag)) == null)
            currentViewIndex = (currentViewIndex + 1) % views.Length;

        View v = views[currentViewIndex];
        currentView = v;
        offset = v.offset;
        followTarget = v.followTarget;
        transformCamera(true);
        Debug.Log("SetView(" + currentViewIndex + ", " + v.name + ") ALF=" + v.alwaysLookForward);
        viewText.text = v.name;
        viewTextShadow.text = v.name;

    }
}


