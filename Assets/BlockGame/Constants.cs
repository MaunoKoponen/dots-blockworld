using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class Constants
{
    public const int ChunkSizeX = 4;//16;
    public const int ChunkSizeY = 2;//15;
    public const int ChunkSizeZ = 4;//16;

    public const int ChunkHeight = ChunkSizeY;

    public static int2 ChunkSurfaceSize => new int2(ChunkSizeX, ChunkSizeZ);
    public static int3 ChunkSize => new int3(ChunkSizeX, ChunkSizeY, ChunkSizeZ);

    public const int ChunkVolume = ChunkSizeX * ChunkSizeY * ChunkSizeZ;
    public const int ChunkSurfaceVolume = ChunkSizeX * ChunkSizeZ;

}
