using System.Reflection;

namespace AutoColumnListViewDemo;

internal class AutoColumnListView : ListView
{
    public Type? ItemType { get; set; }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (ItemType != null)
        {
            BuildColumns();
        }
    }

    private void BuildColumns()
    {
        Columns.Clear();

        if (ItemType is null)
        {
            return;
        }

        PropertyInfo[] properties = ItemType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            Columns.Add(property.Name);
        }
    }
}
