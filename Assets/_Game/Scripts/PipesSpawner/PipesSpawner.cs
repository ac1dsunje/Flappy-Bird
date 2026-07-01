public class PipesSpawner
{
    private readonly CoroutineRunner _coroutineRunner;
    private readonly PipesConfigSO _config;

    public PipesSpawner(CoroutineRunner coroutineRunner, PipesConfigSO config)
    {
        _coroutineRunner = coroutineRunner;
        _config = config;
    }


}