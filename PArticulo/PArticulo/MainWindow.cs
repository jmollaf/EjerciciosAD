using System;
using Gtk;

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
	
	}

//	void newActionActivated (object sender, EventArgs e)
//	{
//		new ArticuloView ();
//	}
	private void fillTreeView(){
		//Primero tenemos que borrar las columnas existentes en el treeView porque sino se repiten
		TreeViewColumn[] treeViewColumns = treeView.Columns;
		foreach (TreeViewColumn treeViewColumn in treeViewColumns)
			treeView.RemoveColumn (treeViewColumn);
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
