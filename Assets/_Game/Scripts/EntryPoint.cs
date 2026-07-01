using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [SerializeField] private BirdConfigSO _birdConfig;
    [SerializeField] private Camera _cam;
    [SerializeField] private JumpInputSO _jumpInput;
    [Scene] [SerializeField] private string _scene;

    [Header("Borders")]
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _sky;

    private BirdController _bird;
    private GameManager _gm;
    private IJumper _jumper;

    private void Awake()
    {
        CreateBorders();
        CreateJumpInput();
        CreateAndInitializeBird(_birdConfig);
        _gm = new(_scene, _bird);
    }

    private void CreateAndInitializeBird(BirdConfigSO config)
    {
        _bird = Instantiate(config.Prefab, config.SpawnPoint, Quaternion.identity).GetComponent<BirdController>();
        _bird.Initialize(config.Movement, _jumper);
    }

    private void CreateBorders()
    {
        Instantiate(_ground);
        Instantiate(_sky);
    }

    private void CreateJumpInput()
    {
        if (_jumpInput.Type == JumpInputTypes.keyboard)
        {
            _jumper = Instantiate(_jumpInput.KeyboardPrefab).GetComponent<IJumper>();
        }
        else if (_jumpInput.Type == JumpInputTypes.mouse)
        {
            _jumper = Instantiate(_jumpInput.MousePrefab).GetComponent<IJumper>();
        }
    }

    private void OnDisable()
    {
        _gm.Dispose();
    }
}