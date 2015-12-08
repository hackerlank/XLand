//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace xy3d.tstd.lib.publicTools
{
	public class PublicTools
	{
		public static readonly string NORMAL_TAG_NAME = "Untagged";

		public static void ClearTag(GameObject _obj){
			
			_obj.tag = NORMAL_TAG_NAME;
			
			for(int i = 0 ; i < _obj.transform.childCount ; i++){
				
				ClearTag(_obj.transform.GetChild(i).gameObject);
			}
		}
		
		public static void SetTag(GameObject _obj,string _tag){
			
			_obj.tag = _tag;
			
			for(int i = 0 ; i < _obj.transform.childCount ; i++){
				
				SetTag(_obj.transform.GetChild(i).gameObject,_tag);
			}
		}

		public static GameObject FindChild(GameObject _obj,string _name){

			return FindChild(_obj,_name,0);
		}

		public static GameObject FindChildForce(GameObject _obj,string _name){
			
			if (_obj.name == _name) 
			{
				return _obj;
			}
			else 
			{
				for (int i = 0; i < _obj.transform.childCount; i++)
				{
					GameObject tmpObj = FindChildForce(_obj.transform.GetChild(i).gameObject, _name);
					
					if (tmpObj != null)
					{
						return tmpObj;
					}
				}
				
				return null;
			}
		}

		private static GameObject FindChild(GameObject _obj,string _name,int _index){

			if (_obj.name == _name) 
            {
				return _obj;
			}
            else 
            {
                _index++;
				
				for (int i = 0; i < _obj.transform.childCount; i++)
                {
                    GameObject tmpObj = FindChild(_obj.transform.GetChild(i).gameObject, _name, _index);

                    if (tmpObj != null)
                    {
                        return tmpObj;
                    }
				}

                if (_index == 1)
                {
                    throw new ArgumentOutOfRangeException("【PublicTools】----" + "找不到名字为" + _name + "的GameObject");
                }
                else{
                    
                    return null;
				}
			}
		}

		public static void AddChild(GameObject _parent, GameObject _child, string _jointName){

			if (!string.IsNullOrEmpty(_jointName)) {

				GameObject joint = FindChild(_parent,_jointName).gameObject;
				
				if (joint != null) {

					_child.transform.SetParent(joint.transform,false);

				}else{

					_child.transform.SetParent(_parent.transform,false);
				}

			} else {

				_child.transform.SetParent(_parent.transform,false);
			}
		}

		public static void SetLayer(GameObject _go, int _layer){

			_go.layer = _layer;
				
			for (int i = 0; i < _go.transform.childCount; i++) {
				
				SetLayer(_go.transform.GetChild(i).gameObject,_layer);
			}
		}

		public static void SetGameObjectVisible(GameObject _go,bool _visible){

			Renderer[] renderers = _go.GetComponentsInChildren<Renderer> ();

			foreach (Renderer ren in renderers) {

				ren.enabled = _visible;
			}
		}

		public static void StopParticle(GameObject _go){

			ParticleSystem[] systems = _go.GetComponentsInChildren<ParticleSystem> ();

			foreach (ParticleSystem system in systems) {

				system.Stop ();
			}
		}

		public static void PlayParticle(GameObject _go){
			
			ParticleSystem[] systems = _go.GetComponentsInChildren<ParticleSystem> ();
			
			foreach (ParticleSystem system in systems) {
				
				system.Play();
			}
		}

		public static byte[] StringToBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
		
		public static string BytesToString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		public static string XmlFix(string _str){

			int index = _str.IndexOf("<");

			if(index == -1){

				return "";

			}else{

				return _str.Substring(index,_str.Length - index);
			}
		}
	}
}
