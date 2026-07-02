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
    [SerializeField] private PoolConfig _pipesPoolConfig;

    [Header("Borders")]
    [SerializeField] private BordersConfigSO _bordersConfig;

    private BirdController _bird;
    private GameManager _gameManager;

    private IJumpInput _jumpInput;

    private PipesFactory _pipesFactory;


    private void Awake()
    {
        _jumpInput = new JumpInputFactory(_jumpInputConfig).Get();
        _pipesFactory = new(_pipesPoolConfig);

        CreateBorders();

        _bird = CreateBird();

        _pipesSpawner.Initialize(_pipesConfig, _pipesFactory);
        _gameManager = new(_scene, _bird, _scoreText);
    }

    private void CreateBorders()
    {
        Instantiate(_bordersConfig.Start);
        Instantiate(_bordersConfig.Ground);
        Instantiate(_bordersConfig.Sky);
    }

    private BirdController CreateBird()
    {
        var bird = Instantiate(_birdConfig.Prefab, _birdConfig.SpawnPoint, Quaternion.identity).GetComponent<BirdController>();
        bird.Initialize(_birdConfig.Movement, _jumpInput);
        return bird;
    }

    private void OnDisable()
    {
        _gameManager.Dispose();
    }
}