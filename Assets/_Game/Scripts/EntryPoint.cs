using TMPro;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [Scene][SerializeField] private string _scene;
    [SerializeField] private Camera _cam;

    [SerializeField] private BirdConfigSO _birdConfig;
    [SerializeField] private JumpInputSO _jumpInputConfig;

    [SerializeField]  private TextMeshProUGUI _scoreText;

    [Header("Pipes")]
    [SerializeField] private PipesSpawner _pipesSpawner;
    [SerializeField] private PipesConfigSO _pipesConfig;

    [Header("Borders")]
    [SerializeField] private BordersConfigSO _bordersConfig;

    private BirdController _bird;
    private GameManager _gameManager;

    private IJumper _jumper;

    private JumpInputFactory _jumpInputFactory;
    private BirdFactory _birdFactory;


    private void Awake()
    {
        CreateFactories();
        CreateBorders();
        _bird = _birdFactory.Get();
        _pipesSpawner.Initialize(_pipesConfig);
        _gameManager = new(_scene, _bird, _scoreText);
    }

    private void CreateFactories()
    {
        _jumpInputFactory = new(_jumpInputConfig);
        _jumper = _jumpInputFactory.Get();

        _birdFactory = new(_birdConfig, _jumper);
    }

    private void CreateBorders()
    {
        Instantiate(_bordersConfig.Start);
        Instantiate(_bordersConfig.Ground);
        Instantiate(_bordersConfig.Sky);
    }

    private void OnDisable()
    {
        _gameManager.Dispose();
    }
}