﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace BlockGame.BlockWorld
{
	public struct RegionLoader : IComponentData
	{
		public int range;
		public int2 regionIndex;
		public GenerateRegionHeightMapSettings heightMapSettings;
	}

	public class RegionLoaderAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		[SerializeField]
		int _range =1 / 5;

		[SerializeField]
		GenerateRegionHeightMapSettings _heightMapSettings = GenerateRegionHeightMapSettings.Default;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			dstManager.AddComponentData(entity, new RegionLoader
			{
				range = _range,
				heightMapSettings = _heightMapSettings
			});
		}
	}
}
