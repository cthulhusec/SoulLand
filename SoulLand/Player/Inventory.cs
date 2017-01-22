using System;
using System.Collections.Generic;
namespace SoulLand
{
	[Serializable]
	public class Inventory
	{
		int slots = 10;
		public List<Item> items;
		public Charm equiped;
		public Inventory()
		{
			items = new List<Item>();
			items.Capacity = slots;
		}

		public bool AddItem(Item item)
		{
			/*
			for(int i = 0;i < items.Capacity; i++)
			{
				if (items[i] == null) {
					items[i] = item;
					return true;
				}
			}
			*/
			items.Add (item);
			return true;
			return false;
		}
			

		public Item RemoveItem(int slot)
		{
			Item item = items [slot];
			if (items[slot] != null) {
				items.RemoveAt (slot);
				return item;
			}
			Logger.LogError ("Attempted to remove null slot from inventory!");
			return null;
		}

		public bool EquipCharm(int slot)
		{
			if (items [slot].GetType() == typeof(Charm)) {
				Charm prev = equiped;
				equiped = (Charm)RemoveItem (slot);
				AddItem (prev);
				return true;
			}
			return false;
		}

		public bool ContainsItem()
		{
			if (items.Count > 0) {
				return true;
			}
			return false;
		}
			

		public bool UseKey(String keypass)
		{
			foreach (Key k in items) {
				if (k.keyPass == keypass) {
					items.Remove ((Item)k);
					return true;
				}
			}
			return false;
		}
	}
}

