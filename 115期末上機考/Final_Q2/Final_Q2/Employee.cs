using System;

namespace Final_Q2
{
    /// <summary>
    /// 員工資料實體類別 (Model)
    /// </summary>
    public class Employee
    {
        // --- 自動實作屬性 (Properties) ---

        /// <summary>
        /// 取得或設定員工編號
        /// </summary>
        public int IdNumber { get; set; }

        /// <summary>
        /// 取得或設定員工姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定所屬部門
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 取得或設定職稱
        /// </summary>
        public string Position { get; set; }


        // --- 建構子多載 (Constructor Overloading) ---

        /// <summary>
        /// 無參數建構子（預設建構子）
        /// 使用建構子串聯，將預設值傳遞給四個參數的建構子
        /// </summary>
        public Employee() : this(0, "", "", "")
        {
            // 邏輯已移至四個參數的建構子，此處保持空白即可
        }

        /// <summary>
        /// 兩個參數的建構子（適用於僅知道工號與姓名的情況）
        /// 使用建構子串聯，將部門與職稱帶入空字串
        /// </summary>
        /// <param name="id">員工編號</param>
        /// <param name="name">員工姓名</param>
        public Employee(int id, string name) : this(id, name, "", "")
        {
            // 邏輯已移至四個參數的建構子，此處保持空白即可
        }

        /// <summary>
        /// 四個參數的建構子（最完整的初始化方法）
        /// </summary>
        /// <param name="id">員工編號</param>
        /// <param name="name">員工姓名</param>
        /// <param name="department">所屬部門</param>
        /// <param name="position">職稱</param>
        public Employee(int id, string name, string department, string position)
        {
            IdNumber = id;
            Name = name;
            Department = department;
            Position = position;
        }


        // --- 自訂方法與覆寫 (Methods & Overrides) ---

        /// <summary>
        /// 覆寫 Object 的 ToString 方法。
        /// 當此物件被直接加入 ListBox 或 ComboBox 時，控制項會自動顯示此方法回傳的字串。
        /// </summary>
        /// <returns>以 Tab (\t) 分隔的工號與姓名</returns>
        public override string ToString()
        {
            return $"{IdNumber}\t{Name}";
        }

        /// <summary>
        /// 將員工物件轉為符合文字檔儲存格式的單行字串
        /// </summary>
        /// <returns>以管線符號 (|) 分隔的完整欄位字串</returns>
        public string ToTxtLine()
        {
            return $"{IdNumber}|{Name}|{Department}|{Position}";
        }
    }
}
