using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace BlockGame.BlockWorld
{
	public struct VolumeMap
	{
		public BlobArray<int> values;

		public int this[int i]
		{
			get => values[i];
			set => values[i] = value;
		}
	}

	public static class VolumeMapBuilder
	{
		
		// Map here is a set of "floorplans" arranged so that bottom most floor is at top
		// to keep it human readable
		// so accessing tem would be like [y,x,z] 


		private static int floorplanMaxY = 2;

		public static int[,,] floorPlan = new int[2, 9, 9] { 
			{ 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 				
			},{ 
				{ 0, 0, 0, 1, 0, 1, 1, 0, 1 }, 
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
				{ 0, 1, 1, 2, 0, 0, 1, 1, 1 }, 
				{ 0, 1, 1, 1, 1, 0, 1, 1, 1 }, 
				{ 0, 0, 0, 0, 1, 0, 0, 0, 0 }, 
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1 }, 
				{ 1, 0, 1, 1, 1, 0, 0, 0, 0 }, 
				{ 0, 0, 1, 1, 1, 0, 0, 0, 0 }, 
				{ 1, 0, 0, 0, 0, 0, 1, 0, 1 } 
			} };

		
		public static BlobAssetReference<VolumeMap> BuildVolumeMap(
			int2 worldPos, int2 size,
			GenerateRegionHeightMapSettings settings,
			Allocator allocator)
		{
			var builder = new BlobBuilder(Allocator.Temp);
			ref var root = ref builder.ConstructRoot<VolumeMap>();

			var values = builder.Allocate(ref root.values,Constants.ChunkVolume);


			// This soultion copies same content to each chunk now, but th aim is to
			// have  different contents, using worldPosition


			for( int i = 0; i < values.Length; ++i )
			{
				int3 xyz = GridUtil.Grid3D.IndexToPos(i);
				
				values[i] = floorPlan[xyz.y,xyz.x,xyz.z]; // note flipped order!
			}

			var rootRef = builder.CreateBlobAssetReference<VolumeMap>(allocator);

			return rootRef;
		}
	}

}
