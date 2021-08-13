using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace BlockGame.BlockWorld
{
	public struct RegionVolumeMap : IComponentData
	{
		public BlobAssetReference<VolumeMap> volumeMapBlob;

		public ref BlobArray<int> Array => ref volumeMapBlob.Value.values;
	} 
}

