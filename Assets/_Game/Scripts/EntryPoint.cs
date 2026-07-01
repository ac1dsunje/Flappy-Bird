using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [SerializeField] private BirdConfigSO _birdConfig;
    [SerializeField] private Camera _cam;
    [SerializeField] private JumpInputSO _jumpInputConfig;
    [Scene] [SerializeField] private string _scene;

    [Header("Borders")]
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _sky;

    private BirdController _bird;
    private GameManager _gm;
    private IJumper _jumper;

    [Header("Factories")]
    private JumpInputFactory _jumpInputFactory;
    private BirdFactory _birdFactory;


    private void Awake()
    {
        CreateFactories();
        CreateBorders();
        _bird = _birdFactory.Get();
        _gm = new(_scene, _bird);
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
        _gm.Dispose();
    }
}