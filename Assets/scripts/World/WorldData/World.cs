using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using World.Generation;

namespace World.WorldData
{
    public class World
    {
        private static World instance;
        private int chunksInHeight = 5;
        private int chunkSize = 10;
        private float seed;

        private Dictionary<int,Chunk[]> chunks = new(20);

        private WorldGenerator worldGenerator;

        public World(WorldGenerator newWorldGenerator, float newSeed)
        {
            instance = this;
            this.worldGenerator = newWorldGenerator;
            this.seed = newSeed;
        }

        public float GetSeed()
        {
            return seed;
        }

        public void SetSeed(float newSeed)
        {
            this.seed = newSeed;
        }

        public void RemoveChunkRowY(int x)
        {
            chunks.Remove(x);
        }

        public int getChunkSize()
        {
            return chunkSize;
        }

        public bool AddChunk(int x,int y, Chunk newChunk)
        {
            Debug.Log(x);
            Chunk[] chunkRow = null;
            try
            {
                chunkRow = chunks[x];
            }
            catch(KeyNotFoundException exception)
            {
                Debug.Log("no chunkRow found");
                Chunk[] newChunkRow = new Chunk[chunksInHeight];
                newChunkRow[y] = newChunk;
                chunks.Add(x,newChunkRow);
                return true;
            }
            Debug.Log("chunkRow found");

            //on existing chunk stop method with false
            Chunk chunk = chunkRow[y];
            if (chunk != null) return false;

            //add new chunk
            chunkRow[y] = newChunk;
            chunks[x] = chunkRow;
            return true;
        }
        
        public void AddChunkRowY(int x, Chunk[] chunkRow)
        {
            chunks.Add(x,chunkRow);
        }

        public Chunk RequestChunk(int x,int y)
        {
            Chunk chunk = null;
            try
            {
                //try getting chunks
                chunk = chunks[x][y];
            }
            catch(KeyNotFoundException exception)
            {
                //generate non-existent chunkRow
                List<int> xChunks = new(){x};
                Task chunkloader = Task.Run(() => worldGenerator.LoadChunksAsync(xChunks,chunksInHeight));
                
                chunkloader.Wait();
            }

            chunk = chunks[x][y];

            return chunk;
        }

        public Chunk[] RequestChunkRowY(int x)
        {
            return chunks[x];
        }
        
        public static World GetInstance()
        {
            return instance;
        }
    }
}