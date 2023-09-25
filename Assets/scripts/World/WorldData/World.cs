using System.Collections.Generic;
using World.Generation;

namespace World.WorldData
{
    public class World
    {
        private float seed;

        private Dictionary<int,Chunk[]> chunks = new(20);

        private WorldGenerator worldGenerator;

        public World(WorldGenerator newWorldGenerator, float newSeed)
        {
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

        public bool AddChunk(int x,int y, Chunk newChunk)
        {
            Chunk[] chunkRow = chunks[x];
            //check if row exsists
            if (chunkRow == null)
            {
                Chunk[] newChunkRow = new Chunk[5];
                newChunkRow[y] = newChunk;
                chunks.Add(x,newChunkRow);
                return true;
            }

            //on existing chunk stop method with false
            Chunk chunk = chunkRow[y];
            if (chunk != null) return false;

            //add new chunk
            chunkRow[y] = newChunk;
            chunks[x] = chunkRow;
            return true;
        }

        public Chunk RequestChunk(int x,int y)
        {
            Chunk chunk = chunks[x][y];
            if (chunk == null)
            {
                //generate chunk if non-existent
            }

            return chunk;
        }

        public Chunk[] RequestChunkRowY(int x)
        {
            return chunks[x];
        }
    }
}