using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class PipeController: MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private PipeBlockFactory _blockFactory;

    private GameObject _blockPrefab;
    private List<GameObject> _blocks = new();

    public event Action<PipeController> OnPipeFinished;

    public void Initialize(PipeConfigSO config, PipeBlockFactory blockFactory, int camHeight)
    {
        _moveSpeed = config.MoveSpeed;
        _blockPrefab = config.PipeBlockPrefab;
        _blockFactory = blockFactory;
        _rb = GetComponent<Rigidbody2D>();

        SpawnBlocks(camHeight, config.GapCount);
    }

    private void SpawnBlocks(int camHeight, int gap)
    {
        int highestPoint = camHeight - 1;
        int lowestPoint = camHeight * -1;

        var positions = GenerateFullPipe(lowestPoint, highestPoint);

        GenerateGap(gap, lowestPoint, highestPoint, positions);

        foreach(var pos in positions)
        {
            SpawnBlock(pos);
        }

        positions.Clear();
    }

    private List<Vector3> GenerateFullPipe(int lowestPoint, int highestPoint)
    {
        List<Vector3> positions = new();

        for (int i = lowestPoint; i < highestPoint + 1; i++)
        {
            positions.Add(new Vector3(0, i, 0));
        }

        return positions;
    }

    private void GenerateGap(int gap, int lowestPoint, int highestPoint, List<Vector3> positions)
    {
        Vector3 gapPos;

        int rand = Random.Range(lowestPoint + 1, highestPoint - 1);

        for (int i = 0; i < gap; i++)
        {
            gapPos = new Vector3(0, rand + i, 0);
            positions.Remove(gapPos);
        }
    }

    private void SpawnBlock(Vector3 position)
    {
        var block = _blockFactory.Get(_blockPrefab, transform, position);
        _blocks.Add(block);
    }

    public void ReleaseBlocks()
    {
        foreach(var block in _blocks)
        {
            _blockFactory.Release(block);
        }
    }

    private void Update()
    {
        if (_rb == null) return;

        _rb.linearVelocity = Vector2.left * _moveSpeed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            OnPipeFinished?.Invoke(this);
        }
    }
}