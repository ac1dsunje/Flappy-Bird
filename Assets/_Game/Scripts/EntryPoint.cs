using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [Scene][SerializeField] private string _scene;
    [SerializeField] private Camera _cam;

    [SerializeField] private BirdConfigSO _birdConfig;
    [SerializeField] private JumpInputSO _jumpInputConfig;
    [SerializeField] private PipesConfigSO _pipesConfig;

    [SerializeField] private CoroutineRunner _coroutineRunner;

    [Header("Borders")]
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _sky;

    private BirdController _bird;
    private GameManager _gameManager;
    private PipesSpawner _pipesSpawner;

    private IJumper _jumper;

    private JumpInputFactory _jumpInputFactory;
    private BirdFactory _birdFactory;


    private void Awake()
    {
        CreateFactories();
        CreateBorders();
        _bird = _birdFactory.Get();
        _gameManager = new(_scene, _bird);
        _pipesSpawner = new(_coroutineRunner, _pipesConfig);
    }

    private void CreateFactories()
    {
        _jumpInputFactory = new(_jumpInputConfig);
        _jumper = _jumpInputFactory.Get();

        _birdFactory = new(_birdConfig, _jumper);
    }

    private void CreateBorders()
    {
        Instantiate(_ground);
        Instantiate(_sky);
    }

    private void OnDisable()
    {
        _gameManager.Dispose();
    }
}