﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEngineX
{
	[RequireComponent(typeof(Button))]
	public class ButtonX : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler , IPointerUpHandler
	{
		public UnityEvent<ButtonX> OnClick;
		
		public bool clickSound;
		public string customSoundID = "custom";
		public bool useCustomSound;
		public AudioClip customSound;

		public UnityEvent<ButtonX> OnPointerDown;
		public UnityEvent<ButtonX> OnPointerUp;
		public UnityEvent<ButtonX> OnPointerEnter;
		public UnityEvent<ButtonX> OnPointerExit;

		public object Data
		{
			get => _data;
			set => _data = value;
		}
		
		public Button Button
		{
			get => _button;
			set => _button = value;
		}

		private object _data;
		private Button _button;

		private void Start()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener( () => {
				OnClick?.Invoke(this);
			} );
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			OnPointerEnter?.Invoke(this);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			OnPointerExit?.Invoke(this);
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			OnPointerDown?.Invoke(this);
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			OnPointerUp?.Invoke(this);
		}
	}
}