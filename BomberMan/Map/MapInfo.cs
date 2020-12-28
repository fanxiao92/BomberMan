namespace BomberMan
{
    using System.Text.Json.Serialization;

    public readonly struct MapInfo
    {
        [JsonConstructor]
        public MapInfo(int id, int width, int height, GridInfo[] grids)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.Grids = grids;
        }

        /// <summary>
        /// 地图 Id
        /// </summary>
        public int Id { get;}
        
        /// <summary>
        /// 地图宽度
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// 地图高度
        /// </summary>
        public int Height { get; }

        public enum GridType
        {
           Invalid = 0, 
           // 砖块
           Brick = 1,
        }
        
        /// <summary>
        /// 地图网格信息，左上角为原点
        /// </summary>
        public readonly struct GridInfo
        {
            [JsonConstructor]
            public GridInfo(int x, int y, GridType gridType)
            {
                this.X = x;
                this.Y = y;
                this.GridType = gridType;
            }

            /// <summary>
            /// X 轴值
            /// </summary>
            public int X { get; } 

            /// <summary>
            /// Y 轴值
            /// </summary>
            public int Y { get; }

            /// <summary>
            /// 网格类型
            /// </summary>
            public GridType GridType { get; }
        }

        /// <summary>
        /// 地图格子信息
        /// </summary>
        public GridInfo[] Grids { get; }
    }
}