// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2015-03-16 09:47:20Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class Main : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public Main(string connectionString) : 
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public Main(string connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<TBlJob> TBlJob
	{
		get
		{
			return this.GetTable<TBlJob>();
		}
	}
	
	public Table<TBlJobDetail> TBlJobDetail
	{
		get
		{
			return this.GetTable<TBlJobDetail>();
		}
	}
}

#region Start MONO_STRICT
#if MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection, new DbLinq.Sqlite.SqliteVendor())
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, IVendor sqlDialect) : 
			base(connection, sqlDialect)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
			base(connection, mappingSource, sqlDialect)
	{
		this.OnCreated();
	}
}
#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
#endregion

[Table(Name="main.tbl_job")]
public partial class TBlJob : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private System.DateTime _data;
	
	private int _durAtA;
	
	private int _id;
	
	private int _inTeRvAllOmAsSimO;
	
	private int _inTeRvAllOmInimO;
	
	private int _numErosEnsorI;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDataChanged();
		
		partial void OnDataChanging(System.DateTime value);
		
		partial void OnDURatAChanged();
		
		partial void OnDURatAChanging(int value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnInTeRvAllOMasSimOChanged();
		
		partial void OnInTeRvAllOMasSimOChanging(int value);
		
		partial void OnInTeRvAllOMinimOChanged();
		
		partial void OnInTeRvAllOMinimOChanging(int value);
		
		partial void OnNumEROSensorIChanged();
		
		partial void OnNumEROSensorIChanging(int value);
		#endregion
	
	
	public TBlJob()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_data", Name="data", DbType="DATE", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime Data
	{
		get
		{
			return this._data;
		}
		set
		{
			if ((_data != value))
			{
				this.OnDataChanging(value);
				this.SendPropertyChanging();
				this._data = value;
				this.SendPropertyChanged("Data");
				this.OnDataChanged();
			}
		}
	}
	
	[Column(Storage="_durAtA", Name="durata", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int DURatA
	{
		get
		{
			return this._durAtA;
		}
		set
		{
			if ((_durAtA != value))
			{
				this.OnDURatAChanging(value);
				this.SendPropertyChanging();
				this._durAtA = value;
				this.SendPropertyChanged("DURatA");
				this.OnDURatAChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_inTeRvAllOmAsSimO", Name="intervallo_massimo", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int InTeRvAllOMasSimO
	{
		get
		{
			return this._inTeRvAllOmAsSimO;
		}
		set
		{
			if ((_inTeRvAllOmAsSimO != value))
			{
				this.OnInTeRvAllOMasSimOChanging(value);
				this.SendPropertyChanging();
				this._inTeRvAllOmAsSimO = value;
				this.SendPropertyChanged("InTeRvAllOMasSimO");
				this.OnInTeRvAllOMasSimOChanged();
			}
		}
	}
	
	[Column(Storage="_inTeRvAllOmInimO", Name="intervallo_minimo", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int InTeRvAllOMinimO
	{
		get
		{
			return this._inTeRvAllOmInimO;
		}
		set
		{
			if ((_inTeRvAllOmInimO != value))
			{
				this.OnInTeRvAllOMinimOChanging(value);
				this.SendPropertyChanging();
				this._inTeRvAllOmInimO = value;
				this.SendPropertyChanged("InTeRvAllOMinimO");
				this.OnInTeRvAllOMinimOChanged();
			}
		}
	}
	
	[Column(Storage="_numErosEnsorI", Name="numero_sensori", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int NumEROSensorI
	{
		get
		{
			return this._numErosEnsorI;
		}
		set
		{
			if ((_numErosEnsorI != value))
			{
				this.OnNumEROSensorIChanging(value);
				this.SendPropertyChanging();
				this._numErosEnsorI = value;
				this.SendPropertyChanged("NumEROSensorI");
				this.OnNumEROSensorIChanged();
			}
		}
	}
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="main.tbl_job_detail")]
public partial class TBlJobDetail : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private System.DateTime _dataAtTivaZIonE;
	
	private System.DateTime _dataDiSatTivaZIonE;
	
	private int _id;
	
	private int _idjOb;
	
	private int _sensorE;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDataAtTIVAzIonEChanged();
		
		partial void OnDataAtTIVAzIonEChanging(System.DateTime value);
		
		partial void OnDataDiSatTIVAzIonEChanged();
		
		partial void OnDataDiSatTIVAzIonEChanging(System.DateTime value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnIDJobChanged();
		
		partial void OnIDJobChanging(int value);
		
		partial void OnSensorEChanged();
		
		partial void OnSensorEChanging(int value);
		#endregion
	
	
	public TBlJobDetail()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_dataAtTivaZIonE", Name="data_attivazione", DbType="DATE", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime DataAtTIVAzIonE
	{
		get
		{
			return this._dataAtTivaZIonE;
		}
		set
		{
			if ((_dataAtTivaZIonE != value))
			{
				this.OnDataAtTIVAzIonEChanging(value);
				this.SendPropertyChanging();
				this._dataAtTivaZIonE = value;
				this.SendPropertyChanged("DataAtTIVAzIonE");
				this.OnDataAtTIVAzIonEChanged();
			}
		}
	}
	
	[Column(Storage="_dataDiSatTivaZIonE", Name="data_disattivazione", DbType="DATE", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime DataDiSatTIVAzIonE
	{
		get
		{
			return this._dataDiSatTivaZIonE;
		}
		set
		{
			if ((_dataDiSatTivaZIonE != value))
			{
				this.OnDataDiSatTIVAzIonEChanging(value);
				this.SendPropertyChanging();
				this._dataDiSatTivaZIonE = value;
				this.SendPropertyChanged("DataDiSatTIVAzIonE");
				this.OnDataDiSatTIVAzIonEChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_idjOb", Name="id_job", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int IDJob
	{
		get
		{
			return this._idjOb;
		}
		set
		{
			if ((_idjOb != value))
			{
				this.OnIDJobChanging(value);
				this.SendPropertyChanging();
				this._idjOb = value;
				this.SendPropertyChanged("IDJob");
				this.OnIDJobChanged();
			}
		}
	}
	
	[Column(Storage="_sensorE", Name="sensore", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int SensorE
	{
		get
		{
			return this._sensorE;
		}
		set
		{
			if ((_sensorE != value))
			{
				this.OnSensorEChanging(value);
				this.SendPropertyChanging();
				this._sensorE = value;
				this.SendPropertyChanged("SensorE");
				this.OnSensorEChanged();
			}
		}
	}
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}
