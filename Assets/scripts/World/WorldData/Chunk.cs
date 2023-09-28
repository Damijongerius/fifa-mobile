using UnityEngine;

namespace World.WorldData
{
    public class Chunk
    {
        private bool[,] blockStates;

        public Chunk(bool[,] newBlockStates)
        {
            this.blockStates = blockStates;
        }

        public bool[,] GetBlockStates()
        {
            return blockStates;
        }
    }
}
