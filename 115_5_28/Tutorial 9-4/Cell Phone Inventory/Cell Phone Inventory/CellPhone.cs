using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Inventory
{
    // CellPhone 類別 - 代表一支手機的資訊
    class CellPhone
    {
        // 私有欄位 - 儲存手機的基本資訊
        private string _brand;   // 手機品牌
        private string _model;   // 手機型號
        private decimal _price;  // 手機零售價格

        // 建構子 - 初始化新建立的 CellPhone 物件
        // 將所有欄位設定為預設值
        public CellPhone()
        {
            _brand = "";      // 品牌初始為空字串
            _model = "";      // 型號初始為空字串
            _price = 0m;      // 價格初始為零
        }

        // 品牌屬性 - 用於取得或設定手機品牌
        public string Brand
        {
            get { return _brand; }     // 取得品牌值
            set { _brand = value; }    // 設定品牌值
        }

        // 型號屬性 - 用於取得或設定手機型號
        public string Model
        {
            get { return _model; }     // 取得型號值
            set { _model = value; }    // 設定型號值
        }

        // 價格屬性 - 用於取得或設定手機零售價格
        public decimal Price
        {
            get { return _price; }     // 取得價格值
            set { _price = value; }    // 設定價格值
        }
    }
}
