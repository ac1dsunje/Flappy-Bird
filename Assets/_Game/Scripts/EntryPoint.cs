using _Game.Scripts.Camera;
using _Game.Scripts.Factory;
using _Game.Scripts.Movement.Jump;
using _Game.Scripts.PipesSpawner;
using _Game.Scripts.Player;
using TMPro;
using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint: MonoBehaviour
{
    [Scene][SerializeField] private string _scene;
    [SerializeField] private CameraController _cam;

    [SerializeField]  private TextMeshProUGUI _scoreText;
    
    [Header("Player")]
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private JumpInputSO _jumpInputConfig;

    [Header("Pipes")] 
    [SerializeField] private PipesSpawner.PipesSpawner _pipesSpawner;
    [SerializeField] private PipeSpawnerConfig _pipesConfig;
    [SerializeField] private PoolConfig _pipesPoolConfig;
    [SerializeField] private PoolConfig _pipesBlockPoolConfig;

    [Header("Borders")]
    [SerializeField] private Transform _skyBorder;
    [SerializeField] private Transform _endBorder;
    [SerializeField] private Transform _downBorder;

    private PlayerController _player;
    private GameManager _gameManager;

    private IJumpInput _jumpInput;

    private PipesFactory _pipesFactory;
    private PipeBlockFactory _pipesBlockFactory;

    private void Awake()
    {
        CreateBorders();
        
        _pipesBlockFactory = new(_pipesBlockPoolConfig);
        _pipesFactory = new(_pipesPoolConfig, _pipesBlockFactory);
        _pipesSpawner.Initialize(_pipesConfig, _pipesFactory, _cam.GetHeight(), new Vector3(_cam.GetRightEdge(), 0, 0));

        _jumpInput = new JumpInputFactory(_jumpInputConfig).Get();
        PlayerModel model = new(_playerConfig.JumpSpeed);
        _playerView.Initialize(_playerConfig.Animation);
        _player = new(model, _playerView, _jumpInput); 

        _gameManager = new(_scene, _player, _scoreText);
    }

    private void CreateBorders()
    {
        _endBorder.position = new Vector3(_cam.GetLeftEdge(), 0, 0);
        _skyBorder.position = new Vector3(0, _cam.GetLowestPoint(), 0);
        _downBorder.position = new Vector3(0, _cam.GetHighestPoint(), 0);
    }

    private void OnDisable()
    {
        _player.Dispose();
        _gameManager.Dispose();
    }
}
}