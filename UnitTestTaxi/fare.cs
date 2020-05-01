using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//出租车计价：
//不大于2公里时只收起步价6元。
//超过2公里的部分每公里收取0.8元。
//超过8公里的部分，每公里加收50%长途费。
//停车等待时加收每分钟0.25元。
//最后计价的时候司机会四舍五入只收到元。

namespace UnitTestTaxi
{
    /// <summary>
    /// 测试类
    /// </summary>
    class fare
    {

        #region 根据测试数据计费
        /// <summary>
        /// 计算车费
        /// </summary>
        /// <param name="kilometre">公里</param>
        /// <param name="waitingtime">时间（分钟）</param>
        /// <returns></returns>
        public string Calculatefare(int kilometre, int waitingtime)
        {

            //最终车费
            double ifare = 0;

            //以公里数计算车费
            ifare = Calculate_Kilometre_fare(kilometre);
            //以等候时间计算车费 + 公里数车费
            ifare = ifare + Calculate_waiting_fare(waitingtime);

            return "收费" + Math.Round( ifare).ToString() + "元";

        }
        #endregion

        #region 以公里数计算车费
        /// <summary>
        /// 以公里数计算车费
        /// </summary>
        /// <param name="kilometre">公里数</param>
        /// <returns></returns>
        private double Calculate_Kilometre_fare(int kilometre)
        {
            if (kilometre <=2)
            {
                return 6;
            }
            else if (kilometre > 2 && kilometre <= 8)
            {
                return Convert.ToDouble(((kilometre - 2) * 0.8) + 6);
            }
            else if (kilometre > 8)
            {
                return Convert.ToDouble((6 * 0.8) + ((kilometre - 8) * 1.2)  + 6);
            }
            return 0;
        }
        #endregion

        #region 以等候时间计算车费
        /// <summary>
        /// 以等候时间计算车费
        /// </summary>
        /// <param name="waiting">等候时间</param>
        /// <returns></returns>
        private double Calculate_waiting_fare(int waiting)
        {
            return Convert.ToDouble(waiting * 0.25);
        }
        #endregion


    }
}
