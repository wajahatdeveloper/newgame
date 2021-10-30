using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public float spawnDelayMin;
	public float spawnDelayMax;
	public float obstacleLifetime;
    public float obstacleSpeed;
    public Transform spawnTransformTop;
    public Transform spawnTransformBottom;
	public List<GameObject> obstacles = new List<GameObject>();

	public void StartSpawning()
	{
		StartCoroutine( SpawnObstacle() );
	}

	public IEnumerator SpawnObstacle()
	{
		while (true)
		{
            GameObject obstacle = Instantiate( obstacles.PickRandom(), (UnityEngine.Random.Range( 0, 2 ) == 0) ? spawnTransformTop : spawnTransformBottom );
            obstacle.GetComponent<Rigidbody2D>().velocity = Vector2.left * obstacleSpeed;
            Destroy( obstacle, obstacleLifetime);
            yield return new WaitForSecondsRealtime( UnityEngine.Random.Range(spawnDelayMin,spawnDelayMax) );
        }
    }
}

public static class EnumerableExtension
{
    public static T PickRandom<T>( this IEnumerable<T> source )
    {
        return source.PickRandom( 1 ).Single();
    }

    public static IEnumerable<T> PickRandom<T>( this IEnumerable<T> source, int count )
    {
        return source.Shuffle().Take( count );
    }

    public static IEnumerable<T> Shuffle<T>( this IEnumerable<T> source )
    {
        return source.OrderBy( x => Guid.NewGuid() );
    }
}