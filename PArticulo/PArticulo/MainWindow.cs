using System;
using Gtk;
using System.Collections;
using SerpisAd;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		fillTreeView ();


		newAction.Activated += delegate {
			new ArticuloView();
		};
		//newAction.Activated += newActionActivated;
		refreshAction.Activated += delegate(object sender, EventArgs e) {

			fillTreeView();
	    };
		deleteAction.Activated += delegate {

			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			IList row = (IList)treeView.Model.GetValue (treeIter, 0);
			Console.WriteLine ("Click en delete action id={0}", row [0]);
		};
	}

//	void newActionActivated (object sender, EventArgs e)
//	{
//		new ArticuloView ();
//	}
	private void fillTreeView(){
		//Primero tenemos que borrar las columnas existentes en el treeView porque sino se repiten
		removeAllColumns(treeView);
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	private static void removeAllColumns(TreeView treeView){
		TreeViewColumn[] treeViewColumns = treeView.Columns;
		foreach (TreeViewColumn treeViewColumn in treeViewColumns)
			treeView.RemoveColumn (treeViewColumn);
	}
	//private static void 

}
