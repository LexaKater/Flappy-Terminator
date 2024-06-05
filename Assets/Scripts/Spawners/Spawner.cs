using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T Prefab;
    [SerializeField] private int PoolCapacity;
    [SerializeField] private int MaxSizePool;
    [SerializeField] private float _delayBetweenSpawn = 5;

    private ObjectPool<T> _pool;
    private bool _isCoroutineWork = true;

    public float DelayBetweenSpawn => _delayBetweenSpawn;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(Prefab),
            actionOnGet: (figure) => OnGet(figure),
            actionOnRelease: (figure) => OnRelease(figure),
            actionOnDestroy: (figure) => Destroy(figure),
            collectionCheck: true,
            defaultCapacity: PoolCapacity,
            maxSize: MaxSizePool);
    }

    private void Start() => StartCoroutine(StartCreate());

    protected void PutObject(T figure) => _pool.Release(figure);

    protected void GetObject() => _pool.Get();

    protected virtual void OnRelease(T figure) => figure.gameObject.SetActive(false);

    protected virtual void OnGet(T figure)
    {
        figure.transform.position = transform.position;
        figure.gameObject.SetActive(true);
    }

    protected virtual IEnumerator StartCreate()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayBetweenSpawn);

        while (_isCoroutineWork)
        {
            GetObject();

            yield return wait;
        }
    }
}