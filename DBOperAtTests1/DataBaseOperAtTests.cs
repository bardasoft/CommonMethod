using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBOperAt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBOperAt.Tests
{
    [TestClass()]
    public class DataBaseOperAtTests
    {
        public DataBaseOperAtTests()
        {
            //DataBaseOperAt.SetDBInfo("192.168.2.19 ", 3306, "skl9000test3", "root", "security999", Enum_DataBase.MySQL);
            DataBaseOperAt.SetDBInfo("192.168.2.19 ", 3306, "Traversaltestdb", "root", "security999", Enum_DataBase.MySQL);
        }
        [TestMethod()]
        public void ExecSQLTest()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            int intIndex = 0;
            int intResult = 0;
            while (intIndex < 1000000)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT T_Device(Cen_Code,Dev_UniqueCode) Value ");
                for (int i = 0; i < 100000; i++)
                {
                    sbExecSQL.Append("('05950002','" + intIndex.ToString().PadLeft(14, '0') + "'),");
                    intIndex++;
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }
        [TestMethod()]
        public void ExecSQLTest1()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            int intIndex = 0;
            int intResult = 0;
            while (intIndex < 100000)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT T_EventRecord(Cen_Code,Dev_ID,Ev_Content) Value ");
                for (int i = 0; i < 10000; i++)
                {
                    sbExecSQL.Append("('05950002','00000000011000','测试数据" + intIndex + "'),");
                    intIndex++;
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void ExecSQLTest2()
        {
            int intIndex =2;
            int intResult = 0;
            int intLevel = 2;
            int intLevelCount = 7;
            int intNodeCount = 10;
            int Temp_intIndex = 1;
            int ineLevelIndex = 1;

            //for (int level = 1; level < intLevelCount; level++)
            //{
            //    DataTable dtResult = GetLevel(level - 1);
            //    if (dtResult.Rows.Count > 0)
            //    {
            //        StringBuilder sbExecSQL = new StringBuilder();
            //        sbExecSQL.Append("INSERT Traversaltest_copy(Node,Level,LeadNode) ");
            //        sbExecSQL.Append("VALUES ");
            //        foreach (DataRow dr in dtResult.Rows)
            //        {
            //            for (int count = 0; count < intNodeCount; count++)
            //            {
            //                sbExecSQL.Append("(" + intIndex + "," + level + "," + Convert.ToInt32(dr["Node"]) + "),");
            //                intIndex++;
            //            }
            //        }
            //        sbExecSQL.Length = sbExecSQL.Length - 1;
            //        intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            //    }
            //}


            DataTable dtResult = GetLevel(4);
            if (dtResult.Rows.Count > 0)
            {
                intIndex = 1112;
                StringBuilder sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT Traversaltest_copy(Node,Level,LeadNode) ");
                sbExecSQL.Append("VALUES ");
                foreach (DataRow dr in dtResult.Rows)
                {
                    for (int count = 0; count < intNodeCount; count++)
                    {
                        sbExecSQL.Append("(" + intIndex + ",5," + Convert.ToInt32(dr["Node"]) + "),");
                        intIndex++;
                    }
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void InserDevice1()
        {
            StringBuilder sbQuerySQL = new StringBuilder();
            StringBuilder sbExecSQL = new StringBuilder();
            int intResult=0;
            DataTable dtResult;
            int intDevCount = 111111;
            int intMaxValue = 10000;

            sbQuerySQL.Append("SELECT node FROM Traversaltest ");
            dtResult = DataBaseOperAt.QuerySQL(sbQuerySQL.ToString()).Tables[0];
            intDevCount = dtResult.Rows.Count;
            int intCount = intDevCount / intMaxValue;
            
            for (int i = 0; i <= intCount; i++)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT INTO Traversaltest1(DevID,Node) ");
                sbExecSQL.Append("VALUES ");
                for (int index = 0; index < intMaxValue; index++)
                {
                    int Temp_intIndex = (intMaxValue * i) + index;
                    if (Temp_intIndex >= intDevCount)
                    {
                        break;
                    }
                    sbExecSQL.AppendFormat("({0},{1}),", dtResult.Rows[Temp_intIndex]["Node"], dtResult.Rows[Temp_intIndex]["Node"]);
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void ExecSQLTest3()
        {
            int intIndex = 2;
            int intResult = 0;
            int intLevel = 2;
            int intLevelCount = 7;
            int intNodeCount = 10;
            int Temp_intIndex = 1;
            int ineLevelIndex = 1;

            StringBuilder sbExecSQL = new StringBuilder();
            sbExecSQL.Append("INSERT Traversaltest(Node,Level,LeadNode) ");
            sbExecSQL.Append("VALUES ");
            for (int i = 1; i < 15; i++)
            {
                sbExecSQL.Append("(" + i + "," + i + "),");
            }
            sbExecSQL.Length = sbExecSQL.Length - 1;
            intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            Assert.AreEqual(intResult, 1);
        }


        [TestMethod()]
        public void ExecSQLTest4()
        {
            int intIndex = 2;
            int intResult = 0;
            int intLevel = 2;
            int intLevelCount = 6;
            int intNodeCount = 10;
            int Temp_intIndex = 1;
            int ineLevelIndex = 1;

            string strNode = "0001";
            for (int level = 1; level < intLevelCount; level++)
            {
                DataTable dtResult = GetLevel4(level - 1);
                if (dtResult.Rows.Count > 0)
                {
                    StringBuilder sbExecSQL = new StringBuilder();
                    sbExecSQL.Append("INSERT Traversaltest4(Node,Level,LeadNode) ");
                    sbExecSQL.Append("VALUES ");
                    
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        string strTemp_Code = Convert.ToString(dr["Node"]);
                        Temp_intIndex = 1;
                      
                        for (int count = 0; count < intNodeCount; count++)
                        {
                            strNode = strTemp_Code + Temp_intIndex.ToString().PadLeft(4, '0');
                            sbExecSQL.Append("('" + strNode + "'," + level + ",'" + Convert.ToString(dr["Node"]) + "'),");
                            Temp_intIndex++;
                        }
                    }
                    sbExecSQL.Length = sbExecSQL.Length - 1;
                    try
                    {
                        intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                    }
                }
            }

            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void ExecSQLTest5()
        {
            int intIndex = 2;
            int intResult = 0;
            int intLevel = 2;
            int intLevelCount = 7;
            int intNodeCount = 10;
            int Temp_intIndex = 1;
            int ineLevelIndex = 1;

            string strNode = "0001";
            for (int level = 6; level < intLevelCount; level++)
            {
                DataTable dtResult = GetLevel4Temp(level - 1,5000,0);
                if (dtResult.Rows.Count > 0)
                {
                    StringBuilder sbExecSQL = new StringBuilder();
                    sbExecSQL.Append("INSERT Traversaltest4(Node,Level,LeadNode) ");
                    sbExecSQL.Append("VALUES ");

                    foreach (DataRow dr in dtResult.Rows)
                    {
                        string strTemp_Code = Convert.ToString(dr["Node"]);
                        Temp_intIndex = 1;

                        for (int count = 0; count < intNodeCount; count++)
                        {
                            strNode = strTemp_Code + Temp_intIndex.ToString().PadLeft(4, '0');
                            sbExecSQL.Append("('" + strNode + "'," + level + ",'" + Convert.ToString(dr["Node"]) + "'),");
                            Temp_intIndex++;
                        }
                    }
                    sbExecSQL.Length = sbExecSQL.Length - 1;
                    intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
                }
                dtResult = GetLevel4Temp(level - 1, 5000, 1);
                if (dtResult.Rows.Count > 0)
                {
                    StringBuilder sbExecSQL = new StringBuilder();
                    sbExecSQL.Append("INSERT Traversaltest4(Node,Level,LeadNode) ");
                    sbExecSQL.Append("VALUES ");

                    foreach (DataRow dr in dtResult.Rows)
                    {
                        string strTemp_Code = Convert.ToString(dr["Node"]);
                        Temp_intIndex = 1;

                        for (int count = 0; count < intNodeCount; count++)
                        {
                            strNode = strTemp_Code + Temp_intIndex.ToString().PadLeft(4, '0');
                            sbExecSQL.Append("('" + strNode + "'," + level + ",'" + Convert.ToString(dr["Node"]) + "'),");
                            Temp_intIndex++;
                        }
                    }
                    sbExecSQL.Length = sbExecSQL.Length - 1;
                    intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
                 
                }
            }

            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void InserDevice2()
        {
            StringBuilder sbQuerySQL = new StringBuilder();
            StringBuilder sbExecSQL = new StringBuilder();
            int intResult = 0;
            DataTable dtResult;
            int intDevCount = 111111;
            int intMaxValue = 10000;

            sbQuerySQL.Append("SELECT node FROM Traversaltest4 ");
            dtResult = DataBaseOperAt.QuerySQL(sbQuerySQL.ToString()).Tables[0];
            intDevCount = dtResult.Rows.Count;
            int intCount = intDevCount / intMaxValue;

            for (int i = 0; i <= intCount; i++)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT INTO Traversaltest5(DevID,Node) ");
                sbExecSQL.Append("VALUES ");
                for (int index = 0; index < intMaxValue; index++)
                {
                    int Temp_intIndex = (intMaxValue * i) + index;
                    if (Temp_intIndex >= intDevCount)
                    {
                        break;
                    }
                    sbExecSQL.AppendFormat("({0},'{1}'),", Temp_intIndex + 1, dtResult.Rows[Temp_intIndex]["Node"]);
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void QueryTest()
        {
            string Temp_strResult = Convert.ToString(DataBaseOperAt.QuerySQL1(" SELECT queryChildrenAreaInfo(2);").Tables[0].Rows[0][0]);
            int intCount = Temp_strResult.Split(',').Length;
            Assert.AreEqual(intCount, 1);
            //StringBuilder sbQuery = new StringBuilder();
            //sbQuery.Append("SELECT * FROM traversaltest1 ");
            //sbQuery.Append("WHERE NODE IN (" + Temp_strResult + ")");
            //DataTable dtResult = DataBaseOperAt.QuerySQL(sbQuery.ToString()).Tables[0];
            //Assert.AreEqual(dtResult.Rows.Count,1);

        }
        public DataTable GetLevel(int intLevel)
        {
            StringBuilder sbQuerySQL = new StringBuilder();
            sbQuerySQL.Append("SELECT * FROM Traversaltest6 ");
            sbQuerySQL.Append("WHERE Level=" + intLevel);
            return DataBaseOperAt.QuerySQL(sbQuerySQL.ToString()).Tables[0];
        }

        public DataTable GetLevel4(int intLevel)
        {
            StringBuilder sbQuerySQL = new StringBuilder();
            sbQuerySQL.Append("SELECT * FROM Traversaltest4 ");
            sbQuerySQL.Append("WHERE Level=" + intLevel);
            return DataBaseOperAt.QuerySQL(sbQuerySQL.ToString()).Tables[0];
        }
        public DataTable GetLevel4Temp(int intLevel, int intLimit, int intOffset)
        {
            StringBuilder sbQuerySQL = new StringBuilder();
            sbQuerySQL.Append("SELECT * FROM Traversaltest4 ");
            sbQuerySQL.Append("WHERE Level=" + intLevel);
            sbQuerySQL.AppendFormat(" LIMIT {0},{1}", intOffset, intLimit);
            return DataBaseOperAt.QuerySQL(sbQuerySQL.ToString()).Tables[0];
        }


        [TestMethod()]
        public void InserNodeTest()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            int intIndex = 2;
            int intResult = 0;
            int intLevel = 2;
            int intLevelCount = 12;
            int intNodeCount = 2;
            int Temp_intIndex = 1;
            int ineLevelIndex = 1;

            for (int level = 1; level < intLevelCount; level++)
            {
                DataTable dtResult = GetLevel(level - 1);
                if (dtResult.Rows.Count > 0)
                {
                    sbExecSQL = new StringBuilder();
                    sbExecSQL.Append("INSERT traversaltest6(Node,level,pNode) ");
                    sbExecSQL.Append("VALUES ");
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        for (int count = 0; count < intNodeCount; count++)
                        {
                            sbExecSQL.Append("(" + intIndex + "," + level + "," + Convert.ToInt32(dr["Node"]) + "),");
                            intIndex++;
                        }
                    }
                    sbExecSQL.Length = sbExecSQL.Length - 1;
                    intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
                }
            }
            Assert.AreEqual(intResult, 1);
        }


    }
}