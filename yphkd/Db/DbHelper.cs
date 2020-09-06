using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Couchbase.Lite;
using Couchbase.Lite.Logging;
using Couchbase.Lite.Sync;
using Easy.MessageHub;
using Microsoft.AppCenter.Crashes;
using yphkd.Events;

namespace yphkd.Db
{
    public class DbHelper
    {
        private static Database db = null;
        private static Replicator replicator = null;

        private static bool replConfigured = false;
        private static string dbName = "";
        private static string remUri = null;

        private static ReplicatorConfiguration replConfig = null;
        private static ListenerToken lt;

        private static string _localDb = null;
        private static string _uri = null;
        private static bool _doPull;
        private static bool _doPush;
        private static bool _doContinous;
        private static bool _sendEvents;
        private static string _userID;
        private static string _passwd;
        private static string _channel;

        private static IMessageHub _hub;

        public static Database GetDatabase()
        {
            if (db == null)
            {
                db = new Database(dbName);
            }

            return db;
        }

        public static void closeDatabase()
        {
            try
            {
                if (db != null)
                {
                    db.Close();
                    db = null;
                }
            }
            catch (Exception ex)
            {
                Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
            }
        }

        public static void setupReplication(string localDb, string uri, bool doPull, bool doPush, bool doContinous, bool sendEvents, string userID, string passwd, string channel)
        {
            // DbHelper.setupReplication(AppConstants.CB_BASE_LDB, AppConstants.CB_BASE_URL, true, false, true, true, AppConstants.CB_BASE_USER, AppConstants.CB_BASE_PASS, null);
            if (localDb == null || uri == null)
            {
                return;
            }

            if (_localDb == null || _uri == null)
            {
                _localDb = localDb;
                _uri = uri;
                _doPull = doPull;
                _doPush = doPush;
                _doContinous = doContinous;
                _sendEvents = sendEvents;
                _userID = userID;
                _passwd = passwd;
                _channel = channel;
            }

            // TODO: May be set some system-wide lock??
            replConfigured = false;

            RestartReplication();
        }

        public static void init(string uri)
        {
            //setupReplication("db", uri, true, false, false, false, null, null, null);
        }

        public static bool isReplicationConfigured()
        {
            if (replConfigured == false || _localDb == null || _uri == null)
            {
                return replConfigured;
            }
            else
            {
                return true;
            }
        }

        public static void StopReplication()
        {
            try
            {
                if (db != null && replicator != null)
                {
                    replicator.Stop();

                    while (replicator.Status.Activity != ReplicatorActivityLevel.Stopped)
                    {
                        Thread.Sleep(500);
                    }

                    Thread.Sleep(500);
                    replicator.RemoveChangeListener(lt);

                    replicator = null;
                    replConfig = null;
                    Console.WriteLine("Replication stopped.");
                }
            }
            catch (Exception ex)
            {
                Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
            }
        }

        public static void RestartReplication()
        {
            if (_localDb == null || _uri == null)
            {
                return;
            }

            dbName = _localDb;
            remUri = _uri;

            _hub = new MessageHub();

            try
            {
                db = GetDatabase();
                if (db != null && (replicator == null || (replicator.Status.Activity != ReplicatorActivityLevel.Busy && replicator.Status.Activity != ReplicatorActivityLevel.Connecting)))
                {
                    Database.SetLogLevel(LogDomain.All, LogLevel.Error);
                    Database.SetLogLevel(LogDomain.Replicator, LogLevel.Debug);

                    URLEndpoint targetEndpoint = new URLEndpoint(new Uri(_uri));
                    replConfig = new ReplicatorConfiguration(db, targetEndpoint);

                    if (_userID != null && _passwd != null)
                    {
                        replConfig.Authenticator = new BasicAuthenticator(_userID, _passwd);
                    }

                    if (_channel != null)
                    {
                        List<string> chnls = new List<string>();
                        chnls.Add(_channel);
                        replConfig.Channels = chnls.ToArray();
                    }

                    if (_doContinous)
                    {
                        // use this config for repl. full bucket
                        replConfig.Continuous = true;
                    }
                    else
                    {
                        replConfig.Continuous = false;
                    }

                    if (_doPull)
                    {
                        if (_doPush)
                        {
                            replConfig.ReplicatorType = ReplicatorType.PushAndPull;
                        }
                        else
                        {
                            replConfig.ReplicatorType = ReplicatorType.Pull;
                        }
                    }
                    else
                    {
                        if (_doPush)
                        {
                            replConfig.ReplicatorType = ReplicatorType.Push;
                        }
                        else
                        {
                            Console.WriteLine("Error: You have set both Push & Pull to be false");
                        }
                    }

                    replicator = new Replicator(replConfig);

                    lt = replicator.AddChangeListener((sender, args) =>
                    {
                        try
                        {
                            if (args.Status.Activity == ReplicatorActivityLevel.Stopped)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.STOPPED, db.Count));
                                    //_hub.Publish(new DatabaseUpdatedMessage());
                                }

                                Console.WriteLine("Replication stopped");

                            }
                            else if (args.Status.Activity == ReplicatorActivityLevel.Offline)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.OFFLINE));
                                }

                                Console.WriteLine("Replication ** offline **");
                            }
                            else if (args.Status.Activity == ReplicatorActivityLevel.Connecting)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.CONNECTING));
                                }

                                Console.WriteLine("Replication connecting");
                            }
                            else if (args.Status.Activity == ReplicatorActivityLevel.Idle)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.IDLE, db.Count));
                                    _hub.Publish(new DatabaseUpdatedMessage());
                                }

                                Console.WriteLine("Replication ^^ idle ^^");

                            }
                            else if (args.Status.Activity == ReplicatorActivityLevel.Busy)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.BUSY, db.Count, args.Status.Progress.Completed, args.Status.Progress.Total));
                                }

                                Console.WriteLine("Replication __ busy __ comp:" + args.Status.Progress.Completed + " / " + args.Status.Progress.Total);
                            }
                            else
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.UNKNOWN));
                                }

                                Console.WriteLine("Replication ???");
                            }

                            if (args.Status.Error != null)
                            {
                                if (_sendEvents)
                                {
                                    //_hub.Publish(new ReplicationStatusEvent(ReplicationStatusEvent.ERROR, args.Status.Error.Message));
                                }

                                var properties = new Dictionary<string, string>
                                {
                                    { "Origin", "RepStatusError" }
                                };

                                Console.WriteLine("Error " + args.Status.Error);

                                string errMsg = args.Status.Error.Message;
                                if (errMsg != null && (errMsg.Contains("Document update conflict") || errMsg.Contains("error on remote server")))
                                {
                                    // https://forums.couchbase.com/t/document-update-conflict/20044
                                    // As per above link, these 'exceptions' are ignoreable
                                }
                                else
                                {
                                    Crashes.TrackError(args.Status.Error, properties);
                                }                                
                            }
                        }
                        catch (Exception ex)
                        {
                            Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);

                        }
                    });

                    replConfigured = true;
                    replicator.Start();
                } 
            }
            catch (Exception ex)
            {
                Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
            }
        }

    }
}
