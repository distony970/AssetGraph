using UnityEngine;

using System;
using System.Linq;
using System.Collections.Generic;

namespace AssetBundleGraph {
	/*
		string:string pseudo dictionary to support Undo
	*/
	[Serializable] public class SerializablePseudoDictionary {
		[SerializeField] private List<string> keys = new List<string>();
		[SerializeField] private List<string> values = new List<string>();

		public List<string> Keys {
			get {
				return keys;
			}
		}

		public List<string> Values {
			get {
				return values;
			}
		}

		public SerializablePseudoDictionary () {
		}

		public SerializablePseudoDictionary (Dictionary<string, string> baseDict) {
			var dict = new Dictionary<string, string>(baseDict);

			keys = dict.Keys.ToList();
			values = dict.Values.ToList();
		}

		public SerializablePseudoDictionary (Dictionary<string, object> json) {
			foreach(var k in json.Keys) {
				keys.Add(k);
				values.Add(json[k] as string);
			}
		}

		public void Add (string key, string val) {
			var dict = new Dictionary<string, string>();
			
			for (var i = 0; i < keys.Count; i++) {
				var currentKey = keys[i];
				var currentVal = values[i];
				dict[currentKey] = currentVal;
			}

			// add or update parameter.
			dict[key] = val;

			keys = new List<string>(dict.Keys);
			values = new List<string>(dict.Values);
		}

		public bool ContainsKey (string key) {
			var dict = new Dictionary<string, string>();
			
			for (var i = 0; i < keys.Count; i++) {
				var currentKey = keys[i];
				var currentVal = values[i];
				dict[currentKey] = currentVal;
			}

			return dict.ContainsKey(key);
		}

		public void Remove (string key) {
			var dict = new Dictionary<string, string>();
			
			for (var i = 0; i < keys.Count; i++) {
				var currentKey = keys[i];
				var currentVal = values[i];
				dict[currentKey] = currentVal;
			}

			dict.Remove(key);
			keys = new List<string>(dict.Keys);
			values = new List<string>(dict.Values);
		}

		public Dictionary<string, string> ReadonlyDict () {
			var dict = new Dictionary<string, string>();
			if (keys == null) return dict;

			for (var i = 0; i < keys.Count; i++) {
				var key = keys[i];
				var val = values[i];
				dict[key] = val;
			}

			return dict;
		}
	}
}