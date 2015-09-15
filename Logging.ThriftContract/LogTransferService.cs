/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;
namespace Logging.ThriftContract
{

    public partial class LogTransferService
    {
        public interface Iface
        {
            void Log(List<TLogEntity> logEntities);
#if SILVERLIGHT
    IAsyncResult Begin_Log(AsyncCallback callback, object state, List<TLogEntity> logEntities);
    void End_Log(IAsyncResult asyncResult);
#endif
        }

        public class Client : IDisposable, Iface
        {
            public Client(TProtocol prot) : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                iprot_ = iprot;
                oprot_ = oprot;
            }

            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected int seqid_;

            public TProtocol InputProtocol
            {
                get { return iprot_; }
            }
            public TProtocol OutputProtocol
            {
                get { return oprot_; }
            }


            #region " IDisposable Support "
            private bool _IsDisposed;

            // IDisposable
            public void Dispose()
            {
                Dispose(true);
            }


            protected virtual void Dispose(bool disposing)
            {
                if (!_IsDisposed)
                {
                    if (disposing)
                    {
                        if (iprot_ != null)
                        {
                            ((IDisposable)iprot_).Dispose();
                        }
                        if (oprot_ != null)
                        {
                            ((IDisposable)oprot_).Dispose();
                        }
                    }
                }
                _IsDisposed = true;
            }
            #endregion



#if SILVERLIGHT
    public IAsyncResult Begin_Log(AsyncCallback callback, object state, List<TLogEntity> logEntities)
    {
      return send_Log(callback, state, logEntities);
    }

    public void End_Log(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      recv_Log();
    }

#endif

            public void Log(List<TLogEntity> logEntities)
            {
#if !SILVERLIGHT
                send_Log(logEntities);
                recv_Log();

#else
      var asyncResult = Begin_Log(null, null, logEntities);
      End_Log(asyncResult);

#endif
            }
#if SILVERLIGHT
    public IAsyncResult send_Log(AsyncCallback callback, object state, List<TLogEntity> logEntities)
#else
            public void send_Log(List<TLogEntity> logEntities)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("Log", TMessageType.Call, seqid_));
                Log_args args = new Log_args();
                args.LogEntities = logEntities;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public void recv_Log()
            {
                TMessage msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                Log_result result = new Log_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                return;
            }

        }
        public class Processor : TProcessor
        {
            public Processor(Iface iface)
            {
                iface_ = iface;
                processMap_["Log"] = Log_Process;
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
            private Iface iface_;
            protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage msg = iprot.ReadMessageBegin();
                    ProcessFunction fn;
                    processMap_.TryGetValue(msg.Name, out fn);
                    if (fn == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void Log_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Log_args args = new Log_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                Log_result result = new Log_result();
                iface_.Log(args.LogEntities);
                oprot.WriteMessageBegin(new TMessage("Log", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Log_args : TBase
        {
            private List<TLogEntity> _logEntities;

            public List<TLogEntity> LogEntities
            {
                get
                {
                    return _logEntities;
                }
                set
                {
                    __isset.logEntities = true;
                    this._logEntities = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool logEntities;
            }

            public Log_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.List)
                            {
                                {
                                    LogEntities = new List<TLogEntity>();
                                    TList _list5 = iprot.ReadListBegin();
                                    for (int _i6 = 0; _i6 < _list5.Count; ++_i6)
                                    {
                                        TLogEntity _elem7;
                                        _elem7 = new TLogEntity();
                                        _elem7.Read(iprot);
                                        LogEntities.Add(_elem7);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("Log_args");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (LogEntities != null && __isset.logEntities)
                {
                    field.Name = "logEntities";
                    field.Type = TType.List;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteListBegin(new TList(TType.Struct, LogEntities.Count));
                        foreach (TLogEntity _iter8 in LogEntities)
                        {
                            _iter8.Write(oprot);
                        }
                        oprot.WriteListEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("Log_args(");
                bool __first = true;
                if (LogEntities != null && __isset.logEntities)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("LogEntities: ");
                    __sb.Append(LogEntities);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Log_result : TBase
        {

            public Log_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("Log_result");
                oprot.WriteStructBegin(struc);

                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("Log_result(");
                __sb.Append(")");
                return __sb.ToString();
            }

        }

    }
}