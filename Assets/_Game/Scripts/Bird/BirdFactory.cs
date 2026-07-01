using UnityEngine;

public class BirdFactory
{
    private readonly BirdConfigSO _config;
    private readonly IJumpInput _jumper;

    public BirdFactory(BirdConfigSO config, IJumpInput jumper)
    {
        _config = config;
        _jumper = jumper;
    }

    public BirdController Get()
    {
        var bird = Object.Instantiate(_config.Prefab, _config.SpawnPoint, Quaternion.identity).GetComponent<BirdController>();
        bird.Initialize(_config.Movement, _jumper);

        return bird;
    }
}