using UnityEngine;

//manages wich chunks to load and unload
namespace World.Generation
{
    public class ChunkManager : MonoBehaviour
    {
        private World.WorldData.World world;
        private int chunkSize;
        
        private Vector2Int PlayerChunkPosition
        {
            get
            {
                int x = Mathf.FloorToInt(transform.position.x / chunkSize);
                int y = Mathf.FloorToInt(transform.position.y / chunkSize);
                return new Vector2Int(x, y);
            }
        }
        void Start()
        {
            world = World.WorldData.World.GetInstance();
            this.chunkSize = world.getChunkSize();
        }
    
        void Update()
        {
            //set chunks 7 ahead and 5 behind to active
            //delete behind 5
            
        }
        
    }
}
