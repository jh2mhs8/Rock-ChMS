using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class Plugins_JayHackett_PageListEF : Rock.Web.UI.RockBlock
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTreeViewControl();
        }
    }

    private void BindTreeViewControl()
    {

        DataSet ds = GetDataSet("Select Id, Name, ParentPageId from Page");
        DataRow[] Rows = ds.Tables[0].Select("ParentPageId Is Null");
        for (int i = 0; i < Rows.Length; i++)
        {
            TreeNode root = new TreeNode(Rows[i]["Name"].ToString(), Rows[i]["Id"].ToString());
            root.SelectAction = TreeNodeSelectAction.Expand;
            CreateNode(root, ds.Tables[0]);
            tvDataSet.Nodes.Add(root);
        }


    }

    public void CreateNode(TreeNode node, DataTable Dt)
    {
        DataRow[] Rows = Dt.Select("ParentPageId =" + node.Value);

        if (Rows.Length == 0)
        {
            return;
        }

        for (int i = 0; i < Rows.Length; i++)
        {
            TreeNode ChildNode = new TreeNode(Rows[i]["Name"].ToString(), Rows[i]["Id"].ToString());
            node.NavigateUrl = "../RockWeb/page/" + Rows[i]["ParentPageId"].ToString();
            ChildNode.NavigateUrl = "../RockWeb/page/" + Rows[i]["Id"].ToString();
            node.ChildNodes.Add(ChildNode);
            CreateNode(ChildNode, Dt);
        }

    }

    private DataSet GetDataSet(string Query)
    {
        DataSet Ds = new DataSet();
        string strCon = ConfigurationManager.ConnectionStrings["RockContext"].ConnectionString;
        SqlConnection Con = new SqlConnection(strCon);
        SqlDataAdapter Da = new SqlDataAdapter(Query, Con);
        Da.Fill(Ds);
        return Ds;
    }
}