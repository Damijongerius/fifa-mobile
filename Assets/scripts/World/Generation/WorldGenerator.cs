using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using World.WorldData;

namespace World.Generation
{
    public class WorldGenerator : MonoBehaviour
    {
        private World.WorldData.World world;

        private void Start()
        {
            Debug.Log("WorldGenerator started");
            world = new World.WorldData.World(this, Random.Range(0, 1000000));
            
        }


        public async Task LoadChunksAsync(List<int> chunkPositions, int chunksInHeight)
        {
            // Concurrently request and load chunks
            List<Task<Chunk>[]> chunkTasks = new List<Task<Chunk>[]>();
            
            foreach (var x in chunkPositions)
            {
                Task<Chunk>[] chunkRow = new Task<Chunk>[chunksInHeight];
                for (int y = 0; y < chunksInHeight; y++)
                {
                    chunkRow[y] = RequestChunkAsync(new Vector2Int(x, y));
                }
                
                chunkTasks.Add(chunkRow);
            }

            for(int x = 0; x < chunkTasks.Count; x++)
            {
                await Task.WhenAll(chunkTasks[x]);
                
                world.AddChunkRowY(chunkPositions[x],chunkTasks[x].Select(task => task.Result).ToArray());
            }
            
        }

        private async Task<Chunk> RequestChunkAsync(Vector2Int position)
        {
            await Task.Yield(); // Simulated async operation
            return RequestChunkData(position);
            

        }

        private Chunk RequestChunkData(Vector2Int position)
        {
            // Simulated asynchronous loading of chunk data
            
            // Generate chunk data
            Debug.Log("Generating Chunk data");
            int chunkSize = world.getChunkSize();
            bool[,] blockStates = new bool[chunkSize, chunkSize];
            float seed = world.GetSeed();
            for (int x = 0; x < chunkSize; x++)
            {
                for (int y = 0; y < chunkSize; y++)
                {
                    blockStates[x, y] = Mathf.PerlinNoise(x + seed + (position.x * chunkSize), y + seed + (position.y * chunkSize)) > 0.5f;
                }
            }
            Debug.Log(blockStates);
            
            return new Chunk(blockStates);
        }
    }
}
