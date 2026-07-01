using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [SerializeField] private BirdConfigSO _birdConfig;
    [SerializeField] private Camera _cam;
    [Scene] [SerializeField] private string _scene;

    [Header("Borders")]
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _sky;

    private BirdController _bird;

    private void Awake()
    {
        CreateBorders();
        CreateAndInitializeBird(_birdConfig);
    }

    private void CreateAndInitializeBird(BirdConfigSO config)
    {
        _bird = Instantiate(config.Prefab, config.SpawnPoint, Quaternion.identity).GetComponent<BirdController>();
        _bird.Initialize(config.Movement, _scene);
    }

    private void CreateBorders()
    {
        Instantiate(_ground);
        Instantiate(_sky);
    }
}