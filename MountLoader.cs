using System;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.ModLoader
{
	public static class MountLoader
	{
		private static int nextMount = MountID.Count;
		internal static readonly IDictionary<int, ModMount> Mounts = new Dictionary<int, ModMount>();
		internal static readonly IDictionary<string, string> textures = new Dictionary<string, string>();

		internal static int ReserveMountID()
		{
			int result = nextMount;
			nextMount++;
			return result;
		}

		internal static int MountCount()
		{
			return nextMount;
		}

		public static ModMount GetMount(int type)
		{
			if (Mounts.ContainsKey(type))
			{
				return Mounts[type];
			}
			return null;
		}

		internal static void ResizeArrays()
		{
			//Array.Resize(ref Main.itemTexture, nextItem);
           
			Array.Resize(ref MountID.Sets.Cart, nextMount);
			Array.Resize(ref Mount.mounts, nextMount);
            
		}

		internal static void Unload()
		{
			Mounts.Clear();
			nextMount = MountID.Count;
			
		}

		internal static bool IsModMount(Mount Mount)
		{
			return Mount._type >= MountID.Count;
		}

		internal static void SetupMount(Mount mount)
		{
			if (IsModMount(mount))
			{
				GetMount(mount._type).SetupMount(mount);
			}
            
		}
		
	}
}
