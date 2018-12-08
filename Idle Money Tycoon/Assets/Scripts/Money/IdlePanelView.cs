using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class IdlePanelView : MonoBehaviour
{

        [SerializeField] private Text _moneyValue;
        [SerializeField] private Text _timeValue;

        private double _idleMoney;
        
        public void SetMoney(double value)
        {
                _idleMoney = value;
                _moneyValue.text = value.ToString("F0");
        }

        public void SetTime(TimeSpan timeSpan)
        {
                _timeValue.text =  string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        public void Collect()
        {
                ProductionController.Instance.MoneyController.AddMoney(_idleMoney);
                Destroy(this.gameObject);
        }
}
