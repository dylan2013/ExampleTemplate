using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace ExampleTemplate
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            RibbonBarItem Print = FISCA.Presentation.MotherForm.RibbonBarItems["學生", "資料統計"];
            Print["報表"]["社團相關報表"]["社團幹部證明單"].Enable = 社團幹部證明單權限;
            Print["報表"]["社團相關報表"]["社團幹部證明單"].Click += delegate
            {
                CadreProveReport cpr = new CadreProveReport();
                cpr.ShowDialog();
            };

            Catalog detail1 = RoleAclSource.Instance["學生"]["報表"];
            detail1.Add(new RibbonFeature(社團幹部證明單, "社團幹部證明單"));
        }

        static public string 社團幹部證明單 { get { return "K12.Club.Universal.CadreProveReport.cs"; } }
        static public bool 社團幹部證明單權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[社團幹部證明單].Executable;
            }
        }
    }
}
