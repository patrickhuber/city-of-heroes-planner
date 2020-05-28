using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementDatabaseReader
    {
        private readonly BinaryReader _reader;

        private EnhancementDatabaseHeader _header;        

        private int _enhancementCount;
        private int _enhancementSetCount;
        private EnhancementReader _enhancementReader;

        private int _enhancementIndex;
        private int _enhancementSetIndex;
        private EnhancementSetReader _enhancementSetReader;

        private State _state;

        private enum State
        {
            Start,
            Enhancements,
            EnhancementSets,
            End,
        }
        private static readonly int IndexNotInitialized = -1;

        public EnhancementDatabaseReader(BinaryReader reader)
        {
            _reader = reader;            
            _enhancementIndex = IndexNotInitialized;
            _enhancementSetIndex = IndexNotInitialized;
        }

        public bool Read()
        {
            switch (_state)
            {
                case State.End:
                    return false;

                case State.Start:
                    _header = new EnhancementDatabaseHeader();
                    // TODO: convert to reader
                    _header.Prefix = _reader.ReadString();
                    _header.Version = _reader.ReadSingle();
                    _state = State.Enhancements;
                    OnHeaderRead?.Invoke(_header);
                    return true;

                case State.Enhancements:
                    if (!IndexIsInitialized(_enhancementIndex))
                    {
                        _enhancementIndex = 0;
                        _enhancementCount = _reader.ReadInt32();
                    }

                    if (_enhancementCount < _enhancementIndex)
                        return false;

                    if (_enhancementReader == null)                    
                        _enhancementReader = new EnhancementReader(_reader);

                    var enhancement = _enhancementReader.Read();
                    OnEnhancementRead?.Invoke(enhancement);
                    _enhancementIndex++;
                    if (_enhancementIndex > _enhancementCount)
                    {
                        _state = State.EnhancementSets;
                        OnEnhancementsCompleted?.Invoke();
                    }
                    return true;

                case State.EnhancementSets:
                    if (!IndexIsInitialized(_enhancementSetIndex))
                    {
                        _enhancementSetIndex = 0;
                        _enhancementSetCount = _reader.ReadInt32();
                    }

                    if (_enhancementSetCount < _enhancementSetIndex)
                        return false;

                    if (_enhancementSetReader == null)
                        _enhancementSetReader = new EnhancementSetReader(_reader);

                    var enhancementSet = _enhancementSetReader.Read();
                    OnEnhancementSetRead?.Invoke(enhancementSet);
                    _enhancementSetIndex++;

                    if (_enhancementSetIndex > _enhancementSetCount)
                    {
                        _state = State.End;
                        OnEnhancementSetsCompleted?.Invoke();
                        return false;
                    }

                    return true;
            }
            return false;
        }

        private static bool IndexIsInitialized(int index)
        {
            return index != IndexNotInitialized;
        }

        public event Action<EnhancementDatabaseHeader> OnHeaderRead;
        public event Action<Enhancement> OnEnhancementRead;
        public event Action OnEnhancementsCompleted;
        public event Action<EnhancementSet> OnEnhancementSetRead;
        public event Action OnEnhancementSetsCompleted;
    }
}
