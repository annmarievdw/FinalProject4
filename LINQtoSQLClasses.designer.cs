﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject4
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GoalsProject")]
	public partial class LINQtoSQLClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAppointment(Appointment instance);
    partial void UpdateAppointment(Appointment instance);
    partial void DeleteAppointment(Appointment instance);
    partial void InsertProgressGoal(ProgressGoal instance);
    partial void UpdateProgressGoal(ProgressGoal instance);
    partial void DeleteProgressGoal(ProgressGoal instance);
    partial void InsertToDoList(ToDoList instance);
    partial void UpdateToDoList(ToDoList instance);
    partial void DeleteToDoList(ToDoList instance);
    #endregion
		
		public LINQtoSQLClassesDataContext() : 
				base(global::FinalProject4.Properties.Settings.Default.GoalsProjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LINQtoSQLClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQtoSQLClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQtoSQLClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQtoSQLClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Appointment> Appointments
		{
			get
			{
				return this.GetTable<Appointment>();
			}
		}
		
		public System.Data.Linq.Table<ProgressGoal> ProgressGoals
		{
			get
			{
				return this.GetTable<ProgressGoal>();
			}
		}
		
		public System.Data.Linq.Table<ToDoList> ToDoLists
		{
			get
			{
				return this.GetTable<ToDoList>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Appointment")]
	public partial class Appointment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Subject;
		
		private string _Goal;
		
		private System.Nullable<System.DateTime> _ApptTime;
		
		private EntityRef<ProgressGoal> _ProgressGoal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnGoalChanging(string value);
    partial void OnGoalChanged();
    partial void OnApptTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnApptTimeChanged();
    #endregion
		
		public Appointment()
		{
			this._ProgressGoal = default(EntityRef<ProgressGoal>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="VarChar(50)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged("Subject");
					this.OnSubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Goal", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Goal
		{
			get
			{
				return this._Goal;
			}
			set
			{
				if ((this._Goal != value))
				{
					if (this._ProgressGoal.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGoalChanging(value);
					this.SendPropertyChanging();
					this._Goal = value;
					this.SendPropertyChanged("Goal");
					this.OnGoalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApptTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> ApptTime
		{
			get
			{
				return this._ApptTime;
			}
			set
			{
				if ((this._ApptTime != value))
				{
					this.OnApptTimeChanging(value);
					this.SendPropertyChanging();
					this._ApptTime = value;
					this.SendPropertyChanged("ApptTime");
					this.OnApptTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProgressGoal_Appointment", Storage="_ProgressGoal", ThisKey="Goal", OtherKey="Goal", IsForeignKey=true)]
		public ProgressGoal ProgressGoal
		{
			get
			{
				return this._ProgressGoal.Entity;
			}
			set
			{
				ProgressGoal previousValue = this._ProgressGoal.Entity;
				if (((previousValue != value) 
							|| (this._ProgressGoal.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProgressGoal.Entity = null;
						previousValue.Appointments.Remove(this);
					}
					this._ProgressGoal.Entity = value;
					if ((value != null))
					{
						value.Appointments.Add(this);
						this._Goal = value.Goal;
					}
					else
					{
						this._Goal = default(string);
					}
					this.SendPropertyChanged("ProgressGoal");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProgressGoal")]
	public partial class ProgressGoal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Goal;
		
		private EntitySet<Appointment> _Appointments;
		
		private EntitySet<ToDoList> _ToDoLists;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnGoalChanging(string value);
    partial void OnGoalChanged();
    #endregion
		
		public ProgressGoal()
		{
			this._Appointments = new EntitySet<Appointment>(new Action<Appointment>(this.attach_Appointments), new Action<Appointment>(this.detach_Appointments));
			this._ToDoLists = new EntitySet<ToDoList>(new Action<ToDoList>(this.attach_ToDoLists), new Action<ToDoList>(this.detach_ToDoLists));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Goal", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Goal
		{
			get
			{
				return this._Goal;
			}
			set
			{
				if ((this._Goal != value))
				{
					this.OnGoalChanging(value);
					this.SendPropertyChanging();
					this._Goal = value;
					this.SendPropertyChanged("Goal");
					this.OnGoalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProgressGoal_Appointment", Storage="_Appointments", ThisKey="Goal", OtherKey="Goal")]
		public EntitySet<Appointment> Appointments
		{
			get
			{
				return this._Appointments;
			}
			set
			{
				this._Appointments.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProgressGoal_ToDoList", Storage="_ToDoLists", ThisKey="Goal", OtherKey="Goal")]
		public EntitySet<ToDoList> ToDoLists
		{
			get
			{
				return this._ToDoLists;
			}
			set
			{
				this._ToDoLists.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Appointments(Appointment entity)
		{
			this.SendPropertyChanging();
			entity.ProgressGoal = this;
		}
		
		private void detach_Appointments(Appointment entity)
		{
			this.SendPropertyChanging();
			entity.ProgressGoal = null;
		}
		
		private void attach_ToDoLists(ToDoList entity)
		{
			this.SendPropertyChanging();
			entity.ProgressGoal = this;
		}
		
		private void detach_ToDoLists(ToDoList entity)
		{
			this.SendPropertyChanging();
			entity.ProgressGoal = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ToDoList")]
	public partial class ToDoList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Subject;
		
		private string _Goal;
		
		private EntityRef<ProgressGoal> _ProgressGoal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnGoalChanging(string value);
    partial void OnGoalChanged();
    #endregion
		
		public ToDoList()
		{
			this._ProgressGoal = default(EntityRef<ProgressGoal>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="VarChar(50)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged("Subject");
					this.OnSubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Goal", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Goal
		{
			get
			{
				return this._Goal;
			}
			set
			{
				if ((this._Goal != value))
				{
					if (this._ProgressGoal.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGoalChanging(value);
					this.SendPropertyChanging();
					this._Goal = value;
					this.SendPropertyChanged("Goal");
					this.OnGoalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProgressGoal_ToDoList", Storage="_ProgressGoal", ThisKey="Goal", OtherKey="Goal", IsForeignKey=true)]
		public ProgressGoal ProgressGoal
		{
			get
			{
				return this._ProgressGoal.Entity;
			}
			set
			{
				ProgressGoal previousValue = this._ProgressGoal.Entity;
				if (((previousValue != value) 
							|| (this._ProgressGoal.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProgressGoal.Entity = null;
						previousValue.ToDoLists.Remove(this);
					}
					this._ProgressGoal.Entity = value;
					if ((value != null))
					{
						value.ToDoLists.Add(this);
						this._Goal = value.Goal;
					}
					else
					{
						this._Goal = default(string);
					}
					this.SendPropertyChanged("ProgressGoal");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
