// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace BomberMan
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Serilog;

    /// <summary>
    /// 地图加载器
    /// </summary>
    public class MapLoader
    {
        /// <summary>
        /// 获取地图信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MapInfo GetMapInfo(int id)
        {
            if (this.cachedMapInfos.TryGetValue(id, out MapInfo result))
            {
                return result;
            }

            try
            {
                var options = new JsonSerializerOptions
                {
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                };

                result = JsonSerializer.Deserialize<MapInfo>(File.ReadAllText($"MapData_{id}.json"), options);
                this.cachedMapInfos.Add(id, result);
            }
            catch (Exception e)
            {
                Log.Error($"MapLoader::GetMapInfo Failed, Id:{id}, ex:{e}");
            }

            return result;
        }

        /// <summary>
        /// cache 地图信息
        /// </summary>
        Dictionary<int, MapInfo> cachedMapInfos = new();
    }
}