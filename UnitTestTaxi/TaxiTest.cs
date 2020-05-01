using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace UnitTestTaxi
{
    [TestClass]
    public class TaxiTest
    {
        
        /// <summary>
        /// 测试数据
        /// </summary>
        public string[] strTestDatas = null;
        /// <summary>
        /// 期望值
        /// </summary>
        public string[] strReceiptDatas = new string[4];

        #region 测试函数
        /// <summary>
        /// 测试函数 
        /// </summary>
        [TestMethod]
        public void Test()
        {
            
            //读取测试数据
            LoadTestData();

            //公里数
            int kilometre;
            //等候时间
            int waitingtime;

            //车费计算类
            fare testfare = new fare();

            //顺序对测试文件进行测试
            for (int i =0; i<= strTestDatas.Length-1;i++)
            {
                //公里数
                kilometre = Convert.ToInt16(strTestDatas[i].Split(',')[0].Replace("公里", "").ToString());
                //等候时间
                waitingtime = Convert.ToInt16(strTestDatas[i].Split(',')[1].Replace("等待", "").Replace("分钟", "").ToString());
                //返回值
                string ret = "";

                //计算
                ret = testfare.Calculatefare(kilometre, waitingtime);

                //对比测试结果
                Assert.AreEqual(strReceiptDatas[i].ToString(), ret);
            }

        }

        #endregion

        #region 读取测试数据
        /// <summary>
        /// 读取测试数据
        /// </summary>
        /// <returns></returns>
        private void LoadTestData()
        {

            strTestDatas = File.ReadAllLines("testData.txt",Encoding.GetEncoding("GB2312"));

            strReceiptDatas[0] = "收费6元";
            strReceiptDatas[1] = "收费7元";
            strReceiptDatas[2] = "收费13元";
            strReceiptDatas[3] = "收费7元";     

        }

        #endregion
     
    }
}
