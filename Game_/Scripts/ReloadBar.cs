using DG.Tweening;
using UnityEngine;

public class ReloadBar : MonoBehaviour
{
    [SerializeField] private Transform pointStart;
    [SerializeField] private Transform pointEnd;
    [SerializeField] private Transform load;
    public float timeReload;

    public void Reload()
    {      
        load.DOLocalMoveX(pointEnd.localPosition.x, timeReload).From(pointStart.localPosition).OnComplete(() => gameObject.SetActive(false));
    }

    private void Update()
    {
        transform.localRotation = transform.parent.rotation;
    }
}
