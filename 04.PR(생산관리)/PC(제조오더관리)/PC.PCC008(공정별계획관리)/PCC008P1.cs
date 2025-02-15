﻿#region 작성정보
/*********************************************************************/
// 단위업무명 : 공정별계획관리
// 작 성 자 : 이 태 규
// 작 성 일 : 2013-02-05
// 작성내용 : 공정별계획관리
// 수 정 일 :
// 수 정 자 :
// 수정내용 :
// 비    고 :
/*********************************************************************/
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace PC.PCC008
{  
    public partial class PCC008P1 : UIForm.FPCOMM1
    {
        #region 변수선언
        string strWo_No = "", strProcSeq = "";
        #endregion

        #region 생성자
        public PCC008P1(string Wo_No, string ProcSeq)
        {
            strWo_No = Wo_No;
            strProcSeq = ProcSeq;

            InitializeComponent();           
        }
        #endregion

        #region Form Load 시
        private void PCC045P1_Load(object sender, System.EventArgs e)
        {
            this.Text = "부품내역";
            //GroupBo x1 초기화
            SystemBase.Validation.GroupBox_Setting(groupBox1);

            txtWorkOrderNo.Text = strWo_No;
            txtProcSeq.Text = strProcSeq;

            UIForm.Buttons.ReButton("000000000001", BtnNew, BtnSearch, BtnRCopy, BtnRowIns, BtnCancel, BtnDel, BtnDelete, BtnInsert, BtnExcel, BtnPrint, BtnHelp, BtnClose);
            string Query = " usp_PCC008 @pTYPE = 'S3'";
            Query += ", @pBIZ_CD = '" + SystemBase.Base.gstrBIZCD + "' ";
            Query += ", @pWORKORDER_NO = '" + strWo_No + "' ";
            Query += ", @pPROC_SEQ = '" + strProcSeq + "' ";
            Query += ", @pCO_CD = '" + SystemBase.Base.gstrCOMCD + "' ";

            UIForm.FPMake.grdCommSheet(fpSpread1, Query, G1Head1, G1Head2, G1Head3, G1Width, G1Align, G1Type, G1Color, G1Etc, G1HeadCnt, false, false, 0, 0, true);
		
        }
        #endregion
        
    }
}
