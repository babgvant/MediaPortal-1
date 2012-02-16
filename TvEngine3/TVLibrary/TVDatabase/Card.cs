#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Collections.Generic;
using Gentle.Framework;
using MediaPortal.CoreServices;

namespace TvDatabase
{
  ///
  /// Enumerator for selecting Network provider 
  /// 
  public enum DbNetworkProvider
  {
    Generic,
    DVBT,
    DVBS,
    DVBC,
    ATSC
  }

  /// <summary>
  /// Instances of this class represent the properties and methods of a row in the table <b>Card</b>.
  /// </summary>
  [TableName("Card")]
  public class Card : Persistent, IComparable
  {
    #region Members

    private bool isChanged;
    [TableColumn("idCard", NotNull = true), PrimaryKey(AutoGenerated = true)] private int idCard;
    [TableColumn("devicePath", NotNull = true)] private string devicePath;
    [TableColumn("name", NotNull = true)] private string name;
    [TableColumn("priority", NotNull = true)] private int priority;
    [TableColumn("grabEPG", NotNull = true)] private bool grabEPG;
    [TableColumn("lastEpgGrab", NotNull = true)] private DateTime lastEpgGrab;
    [TableColumn("recordingFolder", NotNull = true)] private string recordingFolder;
    [TableColumn("idServer", NotNull = true), ForeignKey("Server", "idServer")] private int idServer;
    [TableColumn("enabled", NotNull = true)] private bool enabled;
    [TableColumn("camType", NotNull = true)] private int camType;
    [TableColumn("timeshiftingFolder", NotNull = true)] private string timeshiftingFolder;
    [TableColumn("recordingFormat", NotNull = true)] private int recordingFormat;
    [TableColumn("decryptLimit", NotNull = true)] private int decryptLimit;
    [TableColumn("preload", NotNull = true)] private bool preloadCard;
    [TableColumn("stopgraph", NotNull = true)] private bool stopGraph;

    [TableColumn("CAM", NotNull = true)] private bool caModule;
    [TableColumn("NetProvider", NotNull = true)] private int NetProvider;

    #endregion

    #region Constructors

    /// <summary>
    /// For backwards compatibility: do *not* use.
    /// </summary>
    [System.Obsolete("Use the constructor that provides access to all parameters.")]
    public Card(string devicePath, string name, int priority, bool grabEPG, DateTime lastEpgGrab, string recordingFolder,
                int idServer, bool enabled, int camType, string timeshiftingFolder, int recordingFormat,
                int decryptLimit, int netProvider)
    {
      isChanged = true;
      this.devicePath = devicePath;
      this.name = name;
      this.priority = priority;
      this.grabEPG = grabEPG;
      this.lastEpgGrab = lastEpgGrab;
      this.recordingFolder = recordingFolder;
      this.idServer = idServer;
      this.enabled = enabled;
      this.camType = camType;
      this.timeshiftingFolder = timeshiftingFolder;
      this.recordingFormat = recordingFormat;
      this.decryptLimit = decryptLimit;
      this.preloadCard = false;
      this.stopGraph = true;
      this.caModule = false;
      this.NetProvider = netProvider;
    }

    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public Card(string devicePath, string name, int priority, bool grabEPG, DateTime lastEpgGrab, string recordingFolder,
                int idServer, bool enabled, int camType, string timeshiftingFolder, int recordingFormat,
                int decryptLimit, bool preloadCard, bool stopGraph, bool caModule, int netProvider)
    {
      isChanged = true;
      this.devicePath = devicePath;
      this.name = name;
      this.priority = priority;
      this.grabEPG = grabEPG;
      this.lastEpgGrab = lastEpgGrab;
      this.recordingFolder = recordingFolder;
      this.idServer = idServer;
      this.enabled = enabled;
      this.camType = camType;
      this.timeshiftingFolder = timeshiftingFolder;
      this.recordingFormat = recordingFormat;
      this.decryptLimit = decryptLimit;
      this.preloadCard = preloadCard;
      this.stopGraph = stopGraph;
      this.caModule = caModule;
      this.NetProvider = netProvider;
    }

    /// <summary> 
    /// Create an object from an existing row of data. This will be used by Gentle to 
    /// construct objects from retrieved rows. 
    /// </summary> 
    public Card(int idCard, string devicePath, string name, int priority, bool grabEPG, DateTime lastEpgGrab,
                string recordingFolder, int idServer, bool enabled, int camType, string timeshiftingFolder,
                int recordingFormat, int decryptLimit, bool preloadCard, bool stopGraph, bool caModule, int netProvider)
    {
      this.idCard = idCard;
      this.devicePath = devicePath;
      this.name = name;
      this.priority = priority;
      this.grabEPG = grabEPG;
      this.lastEpgGrab = lastEpgGrab;
      this.recordingFolder = recordingFolder;
      this.idServer = idServer;
      this.enabled = enabled;
      this.camType = camType;
      this.timeshiftingFolder = timeshiftingFolder;
      this.recordingFormat = recordingFormat;
      this.decryptLimit = decryptLimit;
      this.preloadCard = preloadCard;
      this.stopGraph = stopGraph;
      this.caModule = caModule;
      this.NetProvider = netProvider;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Indicates whether the entity is changed and requires saving or not.
    /// </summary>
    public bool IsChanged
    {
      get { return isChanged; }
    }

    /// <summary>
    /// Property relating to database column preload
    /// </summary>
    public bool PreloadCard
    {
      get { return preloadCard; }
      set
      {
        isChanged |= preloadCard != value;
        preloadCard = value;
      }
    }

    /// <summary>
    /// Property relating to database column stopGraph
    /// </summary>
    public bool StopGraph
    {
      get { return stopGraph; }
      set
      {
        isChanged |= stopGraph != value;
        stopGraph = value;
      }
    }

    /// <summary>
    /// Property relating to database column idCard
    /// </summary>
    public int IdCard
    {
      get { return idCard; }
    }


    /// <summary>
    /// Property relating to database column idCard
    /// </summary>
    public int DecryptLimit
    {
      get { return decryptLimit; }
      set
      {
        isChanged |= decryptLimit != value;
        decryptLimit = value;
      }
    }

    /// <summary>
    /// Property relating to database column CAM
    /// </summary>
    public bool CAM
    {
      get { return caModule; }
      set
      {
        isChanged |= caModule != value;
        caModule = value;
      }
    }

    /// <summary>
    /// Property relating to database column recordingFormat
    /// </summary>
    public int RecordingFormat
    {
      get { return recordingFormat; }
      set
      {
        isChanged |= recordingFormat != value;
        recordingFormat = value;
      }
    }

    /// <summary>
    /// Property relating to database column devicePath
    /// </summary>
    public string DevicePath
    {
      get { return devicePath; }
      set
      {
        isChanged |= devicePath != value;
        devicePath = value;
      }
    }

    /// <summary>
    /// Property relating to database column name
    /// </summary>
    public string Name
    {
      get { return name; }
      set
      {
        isChanged |= name != value;
        name = value;
      }
    }

    /// <summary>
    /// Property relating to database column priority
    /// </summary>
    public int Priority
    {
      get { return priority; }
      set
      {
        isChanged |= priority != value;
        priority = value;
      }
    }

    /// <summary>
    /// Property relating to database column grabEPG
    /// </summary>
    public bool GrabEPG
    {
      get { return grabEPG; }
      set
      {
        isChanged |= grabEPG != value;
        grabEPG = value;
      }
    }

    /// <summary>
    /// Property relating to database column lastEpgGrab
    /// </summary>
    public DateTime LastEpgGrab
    {
      get { return lastEpgGrab; }
      set
      {
        isChanged |= lastEpgGrab != value;
        lastEpgGrab = value;
      }
    }

    /// <summary>
    /// Property relating to database column recordingFolder
    /// </summary>
    public string RecordingFolder
    {
      get { return recordingFolder; }
      set
      {
        isChanged |= recordingFolder != value;
        recordingFolder = value;
      }
    }

    /// <summary>
    /// Property relating to database column timeshiftingFolder
    /// </summary>
    public string TimeShiftFolder
    {
      get { return timeshiftingFolder; }
      set
      {
        isChanged |= timeshiftingFolder != value;
        timeshiftingFolder = value;
      }
    }

    /// <summary>
    /// Property relating to database column idServer
    /// </summary>
    public int IdServer
    {
      get { return idServer; }
      set
      {
        isChanged |= idServer != value;
        idServer = value;
      }
    }

    /// <summary>
    /// Property relating to database column enabled
    /// </summary>
    public bool Enabled
    {
      get { return enabled; }
      set
      {
        isChanged |= enabled != value;
        enabled = value;
      }
    }

    /// <summary>
    /// Property relating to database column idServer
    /// </summary>
    public int CamType
    {
      get { return camType; }
      set
      {
        isChanged |= camType != value;
        camType = value;
      }
    }

    /// <summary>
    /// Read Only property indicating if a card can record multiple stream from a same transponder 
    /// </summary>
    public bool supportSubChannels
    {
      get { return supportsSubChannels(); }
    }

    public int netProvider
    {
      get { return NetProvider; }
      set
      {
        isChanged |= NetProvider != value;
        NetProvider = value;
      }
    }

    #endregion

    #region Storage and Retrieval

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call.
    /// The List is sorted by the card's priority.
    /// </summary>
    public static IList<Card> ListAll()
    {
      List<Card> allCards = new List<Card>();
      Broker.RetrieveList<Card>(allCards);
      allCards.Sort(); // sort list by IComparable implementation, which takes care about priorities
      return allCards;
    }

    /// <summary>
    /// Retrieves an entity given it's id.
    /// </summary>
    public static Card Retrieve(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (Card), true, "idCard", id);
      return Broker.RetrieveInstance<Card>(key);
    }

    /// <summary>
    /// Retrieves an entity given it's id, using Gentle.Framework.Key class.
    /// This allows retrieval based on multi-column keys.
    /// </summary>
    public static Card Retrieve(Key key)
    {
      return Broker.RetrieveInstance<Card>(key);
    }

    /// <summary>
    /// Persists the entity if it was never persisted or was changed.
    /// </summary>
    public override void Persist()
    {
      if (IsChanged || !IsPersisted)
      {
        try
        {
          base.Persist();
        }
        catch (Exception ex)
        {
          GlobalServiceProvider.Instance.Get<ILogger>().Error("Exception in Card.Persist() with Message {0}", ex.Message);
          return;
        }
        isChanged = false;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Checks if a card can view a specific channel
    /// </summary>
    /// <param name="channelId">Channel id</param>
    /// <returns>true/false</returns>
    public bool canViewTvChannel(int channelId)
    {
      IList<ChannelMap> _cardChannels = ReferringChannelMap();
      foreach (ChannelMap _cmap in _cardChannels)
      {
        if (channelId == _cmap.IdChannel && !_cmap.EpgOnly)
        {
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Checks if a card can tune a specific channel
    /// </summary>
    /// <param name="channelId">Channel id</param>
    /// <returns>true/false</returns>
    public bool canTuneTvChannel(int channelId)
    {
      IList<ChannelMap> _cardChannels = ReferringChannelMap();
      foreach (ChannelMap _cmap in _cardChannels)
      {
        if (channelId == _cmap.IdChannel)
        {
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Checks if a card can view multiple channels from a same transponder
    /// </summary>
    /// <returns>true/false</returns>
    public bool supportsSubChannels()
    {
      return true;
    }

    #endregion

    #region Relations

    /// <summary>
    /// Get a list of ChannelMap referring to the current entity.
    /// </summary>
    public IList<ChannelMap> ReferringChannelMap()
    {
      //select * from 'foreigntable'
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (ChannelMap));

      // where foreigntable.foreignkey = ourprimarykey
      sb.AddConstraint(Operator.Equals, "idCard", idCard);

      // passing true indicates that we'd like a list of elements, i.e. that no primary key
      // constraints from the type being retrieved should be added to the statement
      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<ChannelMap>(stmt.Execute());

      // TODO In the end, a GentleList should be returned instead of an arraylist
      //return new GentleList( typeof(ChannelMap), this );
    }

    public IList<CardGroupMap> ReferringCardGroupMap()
    {
      //select * from 'foreigntable'
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (CardGroupMap));

      // where foreigntable.foreignkey = ourprimarykey
      sb.AddConstraint(Operator.Equals, "idCard", idCard);

      // passing true indicates that we'd like a list of elements, i.e. that no primary key
      // constraints from the type being retrieved should be added to the statement
      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<CardGroupMap>(stmt.Execute());

      // TODO In the end, a GentleList should be returned instead of an arraylist
      //return new GentleList( typeof(ChannelMap), this );
    }

    /// <summary>
    /// Get a list of ChannelMap referring to the current entity.
    /// </summary>
    public IList<DiSEqCMotor> ReferringDiSEqCMotor()
    {
      //select * from 'foreigntable'
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (DiSEqCMotor));

      // where foreigntable.foreignkey = ourprimarykey
      sb.AddConstraint(Operator.Equals, "idCard", idCard);

      // passing true indicates that we'd like a list of elements, i.e. that no primary key
      // constraints from the type being retrieved should be added to the statement
      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<DiSEqCMotor>(stmt.Execute());

      // TODO In the end, a GentleList should be returned instead of an arraylist
      //return new GentleList( typeof(ChannelMap), this );
    }

    /// <summary>
    ///
    /// </summary>
    public Server ReferencedServer()
    {
      return Server.Retrieve(IdServer);
    }

    #endregion

    public void Delete()
    {
      IList<ChannelMap> list = ReferringChannelMap();
      foreach (ChannelMap map in list)
      {
        map.Delete();
      }

      IList<CardGroupMap> listCardGroupMap = ReferringCardGroupMap();
      foreach (CardGroupMap cardGroupMap in listCardGroupMap)
      {
        cardGroupMap.Remove();
      }

      IList<DiSEqCMotor> listDiSEqCMotor = ReferringDiSEqCMotor();
      foreach (DiSEqCMotor disEqc in listDiSEqCMotor)
      {
        disEqc.Remove();
      }

      Remove();
    }

    #region IComparable Member

    /// <summary>
    /// Compares Cards by their priority.
    /// </summary>
    /// <param name="obj">Card to comapare with</param>
    /// <returns>Result</returns>
    public int CompareTo(object obj)
    {
      if (obj == null) return 1;
      return -priority.CompareTo(((Card)obj).priority); //sort by priority member in descending order
    }

    #endregion
  }
}