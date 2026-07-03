using TMPro;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [Scene][SerializeField] private string _scene;
    [SerializeField] private CameraController _cam;

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private JumpInputSO _jumpInputConfig;

    [SerializeField]  private TextMeshProUGUI _scoreText;

    [Header("Pipes")]
    [SerializeField] private PipeSpawnerConfig _pipesConfig;
    [SerializeField] private PoolConfig _pipesPoolConfig;
    [SerializeField] private PoolConfig _pipesBlockPoolConfig;

    [Header("Borders")]
    [SerializeField] private BordersConfigSO _bordersConfig;

    private PlayerController _player;
    private GameManager _gameManager;
    private PipesSpawner _pipesSpawner;

    private IJumpInput _jumpInput;

    private PipesFactory _pipesFactory;
    private PipeBlockFactory _pipesBlockFactory;


    private void Awake()
    {
        _jumpInput = new JumpInputFactory(_jumpInputConfig).Get();
        _pipesBlockFactory = new(_pipesBlockPoolConfig);
        _pipesFactory = new(_pipesPoolConfig, _pipesBlockFactory);

        CreateBorders();

        _player = CreatePlayer();

        _pipesSpawner = Instantiate(_pipesConfig.PipeSpawnerPrefab, new Vector3(_cam.GetRightEdge(), 0, 0), Quaternion.identity, transform)
            .GetComponent<PipesSpawner>().Initialize(_pipesConfig, _pipesFactory, _cam.GetHeight());

        _gameManager = new(_scene, _player, _scoreText);
    }

    private void CreateBorders()
    {
        Instantiate(_bordersConfig.Start, new Vector3(_cam.GetLeftEdge(), 0, 0), Quaternion.identity);
        Instantiate(_bordersConfig.Ground, new Vector3(0, _cam.GetHighestPoint(), 0), Quaternion.identity);
        Instantiate(_bordersConfig.Sky, new Vector3(0, _cam.GetLowestPoint(), 0), Quaternion.identity);
    }

    private PlayerController CreatePlayer()
    {
        PlayerModel model = new(_playerConfig.JumpSpeed);
        var view = Instantiate(_playerConfig.Prefab, _playerConfig.SpawnPoint, Quaternion.identity)
            .GetComponent<PlayerView>().Initialize(_playerConfig.Animation);

        PlayerController controller = new(model, view, _jumpInput); 
        return controller;
    }

    private void OnDisable()
    {
        _player.Dispose();
        _gameManager.Dispose();
    }
}