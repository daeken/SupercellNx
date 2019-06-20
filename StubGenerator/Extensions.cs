using System;
using System.Collections.Generic;
using System.Xml;

namespace StubGenerator {
	public static class Extensions {
		public static XmlNode? Find(this XmlNode node, Func<XmlNode, bool> func) {
			if(func(node)) return node;
			foreach(var elem in node.ChildNodes)
				if(elem is XmlNode enode) {
					var ret = enode.Find(func);
					if(ret != null) return ret;
				}
			return null;
		}
		public static IEnumerable<XmlNode> FindAll(this XmlNode node, Func<XmlNode, bool> func) {
			if(func(node)) yield return node;
			foreach(var elem in node.ChildNodes)
				if(elem is XmlNode enode)
					foreach(var sub in enode.FindAll(func)) yield return sub;
		}
	}
}