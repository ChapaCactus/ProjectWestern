using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("ClearedStageNum", "TotalCoin")]
	public class ES3Type_UserData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_UserData() : base(typeof(CCG.UserData)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (CCG.UserData)obj;
			
			writer.WritePrivateProperty("ClearedStageNum", instance);
			writer.WritePrivateProperty("TotalCoin", instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (CCG.UserData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "ClearedStageNum":
					reader.SetPrivateProperty("ClearedStageNum", reader.Read<System.Int32>(), instance);
					break;
					case "TotalCoin":
					reader.SetPrivateProperty("TotalCoin", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new CCG.UserData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_UserDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UserDataArray() : base(typeof(CCG.UserData[]), ES3Type_UserData.Instance)
		{
			Instance = this;
		}
	}
}