using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;

namespace Chapter7
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		/*
		protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
		{
			if (e.AffectedRows == 0)
			{
				Label1.Text="データの更新に失敗しました"；
			}
			else
			{
				Label1.Text = "データの更新に成功しました";
			}
		}
		*/

		// 戻り値の型は IEnumerable に変更できますが、// のページングと
		//並べ替えをサポートするには、次のパラメーターを追加する必要があります:
//     int maximumRows
//     int startRowIndex
//     out int totalRowCount
//     string sortByExpression

		// ID パラメーター名は、コントロールに設定されている DataKeyNames 値に一致する必要があります
		public void GridView1_UpdateItem(int EmployeeId)
		{
		
			Chapter7.Employee item = null;
			// ここに項目を読み込みます。例: item = MyDataLayer.Find(id);
			var context = new MyModel();
			item = context.Employees.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
			if (item == null)
			{
				// 項目が見つかりませんでした
				ModelState.AddModelError("", String.Format("ID {0} の項目が見つかりませんでした", EmployeeId));
				return;
			}

			TryUpdateModel(item);
			if (ModelState.IsValid)
			{
				context.SaveChanges();
				
			}
		}

		// 戻り値の型は IEnumerable に変更できますが、// のページングと
		//並べ替えをサポートするには、次のパラメーターを追加する必要があります:
//     int maximumRows
//     int startRowIndex
//     out int totalRowCount
//     string sortByExpression
		// 戻り値の型は IEnumerable に変更できますが、// のページングと
		//並べ替えをサポートするには、次のパラメーターを追加する必要があります:
//     int maximumRows
//     int startRowIndex
//     out int totalRowCount
//     string sortByExpression
public IQueryable<Chapter7.Employee> GridView1_GetData1([Control("NameTB")] string name)
		{
			var context = new MyModel();
			if (string.IsNullOrWhiteSpace(name))
			{
				return context.Employees;
			}
			else
			{
				return context.Employees.Where(x => x.Name.Contains(name));
			}
			
		}
		public IQueryable<Department> GetDepartmentData()
		{
			var context = new MyModel();
			return context.Departments;
		}

		// ID パラメーター名は、コントロールに設定されている DataKeyNames 値に一致する必要があります
		public void GridView1_DeleteItem(int EmployeeId)
		{
			var context = new MyModel();
			var item = context.Employees.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
			context.Employees.Remove(item);
			context.SaveChanges();
		}
		/*
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Department] WHERE [DepartmentId] = @original_DepartmentId AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL))" InsertCommand="INSERT INTO [Department] ([DepartmentId], [Name]) VALUES (@DepartmentId, @Name)" OldValuesParameterFormatString="original_{0}" OnUpdated="SqlDataSource1_Updated" SelectCommand="SELECT * FROM [Department]" UpdateCommand="UPDATE [Department] SET [Name] = @Name WHERE [DepartmentId] = @original_DepartmentId AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL))">
<DeleteParameters>
<asp:Parameter Name="original_DepartmentId" Type="Int32" />
<asp:Parameter Name="original_Name" Type="String" />
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="DepartmentId" Type="Int32" />
<asp:Parameter Name="Name" Type="String" />
</InsertParameters>
<UpdateParameters>
<asp:Parameter Name="Name" Type="String" />
<asp:Parameter Name="original_DepartmentId" Type="Int32" />
<asp:Parameter Name="original_Name" Type="String" />
</UpdateParameters>
</asp:SqlDataSource>
*/
	}
}
 