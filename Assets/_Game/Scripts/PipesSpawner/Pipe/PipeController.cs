using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class PipeController: MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private int _gap;
    private PipeBlockFactory _blockFactory;

    private GameObject _blockPrefab;
    private List<GameObject> _blocks = new();

    public event Action<PipeController> OnPipeFinished;

    public void Initialize(PipeConfigSO config, PipeBlockFactory blockFactory)
    {
        _moveSpeed = config.MoveSpeed;
        _blockPrefab = config.PipeBlockPrefab;
        _gap = config.GapCount;
        _blockFactory = blockFactory;
        _rb = GetComponent<Rigidbody2D>();

        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        List<Vector3> positions = new();
        int highestPoint = 4;
        int lowestPoint = -5;
        Vector3 gapPos;

        for (int i = lowestPoint; i < highestPoint + 1; i++)
        {
            positions.Add(new Vector3(0, i, 0));
        }

        int rand = Random.Range(lowestPoint + 1, highestPoint - 1);

        for (int i = 0; i < _gap; i++)
        {
            gapPos = new Vector3(0, rand + i, 0);
            positions.Remove(gapPos);
        }

        foreach(var pos in positions)
        {
            SpawnBlock(pos);
        }

        positions.Clear();
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