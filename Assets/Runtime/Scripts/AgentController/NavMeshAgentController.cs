using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : MonoBehaviour
{
    private readonly string TAG = "[NavMeshAgentController]";
    private const float maxDistToCamera = 4.0f;
    private const float minDistToCamera = 1.0f;
    private const float maxDistToCameraOnBack = 5.0f;
    [SerializeField]
    private Transform m_AgentHead;
    [SerializeField]
    private Transform _goal;
    public Transform goal
    {
        get
        {
            if (_goal == null)
                _goal = Camera.main.transform;
            return _goal;
        }
        set
        {
            if (_goal != value)
            {
                _goal = value;
            }
        }
    }
    private bool isBack { get => goal == Camera.main.transform; }
    private NavMeshAgent _agent;
    private NavMeshAgent agent
    {
        get
        {
            if (_agent == null)
                _agent = GetComponent<NavMeshAgent>();
            return _agent;
        }
    }
    private int wallLayer;
    private LookAt lookAt;
    //[SerializeField]
    //private UIDialog m_Dialog;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_Subtitle;
    [SerializeField]
    private string m_HurryUpContent;
    [SerializeField]
    private string m_ArriveContent;


    private void Awake()
    {
        wallLayer = LayerMask.NameToLayer("Wall");
        lookAt = GetComponent<LookAt>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    var _groundPos = new Vector3(goal.position.x, 0.0f, goal.position.z);
        //    agent.destination = _groundPos;
        //}
        UpdateAgentStatus();
    }

    private void UpdateAgentStatus()
    {
        if (!GlobalProps.IsLogin) return;

        Vector3 goalPos = goal.position;

        if (isBack)
        {
            goalPos = goal.position + Camera.main.transform.forward * 2;
            if (!CheckMinDistance(goalPos))
            {
                lookAt?.SetLookAtCamera();
                return;
            }
        }
        else if (!CheckMaxCameraDistance() || !CheckNoObstacle())
        {
            goalPos = agent.transform.position;
        }

        agent.destination = goalPos;

        if (CheckIsArrived())
        {
            lookAt?.SetLookAtCamera();

            if (m_Subtitle == null || isBack) return;
            if (!CheckMaxCameraDistance() || !CheckNoObstacle())
            {
                m_Subtitle.text = string.Format(m_HurryUpContent, GlobalProps.UserName);
                m_Subtitle.GetComponent<DoozyUI.UIElement>().Show(true);
            }
            else if (Vector3.Distance(Camera.main.transform.position, goal.position) <= 2.0f)
            {
                goal = null;
            }
            else if (Vector3.Distance(m_AgentHead.position, goal.position) <= 2.0f && Vector3.Distance(Camera.main.transform.position, goal.position) <= 3.0f)
            {
                m_Subtitle.text = string.Format(string.Format(m_ArriveContent, goal.name));
                m_Subtitle.GetComponent<DoozyUI.UIElement>().Show(true);
            }
            //Debug.Log("SSS" + Vector3.Distance(m_AgentHead.position, goal.position));
        }
    }

    private bool CheckMinDistance(Vector3 pos)
    {
        //return Vector3.Distance(m_AgentHead.position, goal.position) >= minDistToCamera;
        return Vector3.SqrMagnitude(m_AgentHead.position - pos) >= Mathf.Sqrt(minDistToCamera);
    }

    private bool CheckMaxCameraDistance()
    {
        return Vector3.Distance(m_AgentHead.position, Camera.main.transform.position) < maxDistToCamera;
        //return Vector3.SqrMagnitude(m_AgentHead.position - Camera.main.transform.position) < Mathf.Sqrt(maxDistToCamera);
    }

    private bool CheckNoObstacle()
    {
        return !Physics.Linecast(Camera.main.transform.position, transform.position, layerMask: wallLayer);
    }

    private bool CheckIsArrived()
    {
        return agent.remainingDistance <= 0.1f;
    }
}
