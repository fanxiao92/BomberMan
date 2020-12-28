namespace BomberMan.World
{
	using System.Collections.Generic;

	public class World
    {
	    /// <summary>
	    /// 初始化
	    /// </summary>
	    public void Init(int mapId)
	    {
		    var mapInfo = new MapInfo();
		    foreach (MapInfo.GridInfo grid in mapInfo.Grids)
		    {
			    // 初始化砖块信息
			    if (grid.GridType == MapInfo.GridType.Brick)
			    {
				   // 将这个添加到世界中 
			    }
		    }
	    }

	    /// <summary>
	    /// Tick 驱动
	    /// </summary>
	    /// <param name="deltaMilliseconds"></param>
	    public void Tick(int deltaMilliseconds)
	    {
		    foreach (KeyValuePair<int, Unit.Unit> unitPair in this.units)
		    {
			    unitPair.Value.Tick(deltaMilliseconds);
		    }
	    }

	    /// <summary>
	    /// Tick 驱动善后处理
	    /// </summary>
	    public void PostTick()
	    {
		    
	    }
	    
	    /// <summary>
	    /// 是否暂停
	    /// </summary>
        bool isPaused;
	    
	    /// <summary>
	    /// 当前运行总帧数
	    /// </summary>
        long  frameCount;
	    
	    /// <summary>
	    /// 下一个单位 Id
	    /// </summary>
    	int nextUnitId;	// 用于生产单位对象id
	    
	    /// <summary>
	    /// 下一个道具 Id
	    /// </summary>
        int nextItemId;  
	    
	    /// <summary>
	    /// 单位集合
	    /// </summary>
    	Dictionary<int, Unit.Unit> units = new();
	    
	    /// <summary>
	    /// 英雄集合
	    /// </summary>
    	Dictionary<int, Unit.Hero> heroes = new();
	    
	    /// <summary>
	    /// updateEnd 添加到世界中的单位， 防止迭代异常
	    /// </summary>
    	Dictionary<int, Unit.Unit> newAddUnits; 
	    
	    /// <summary>
	    /// updateEnd 后需要从世界中移除的单位
	    /// </summary>
    	Queue<int> needRemovUnits;

	    /// <summary>
	    /// 地图地形
	    /// </summary>
	    WorldTerrain worldTerrain;
    }
}