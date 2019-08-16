using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class DatabaseReader
    {
        private readonly BinaryReader _reader;
        private State _state;

        private Issue12Header _issue12Header;

        private ArchetypeReader _archetypeReader;
        private RecordHeader _archetypeHeader;        
        private int _archetypeIndex;

        private PowerSetReader _powersetReader;
        private RecordHeader _powersetHeader;
        private int _powersetIndex;

        private PowerHeader _powerHeader;
        private PowerReader _powerReader;
        private int _powerIndex;

        private enum State
        {
            Start,            
            Archetypes,
            Powersets,
            Powers,
            Summons,
            End,
        }

        public DatabaseReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public bool Read()
        {
            switch (_state)
            {
                case State.End:
                    return false;

                case State.Start:
                    _issue12Header = new Issue12HeaderReader(_reader).Read();
                    OnIssue12HeaderRead?.Invoke(_issue12Header);
                    _state = State.Archetypes;
                    return true;

                case State.Archetypes:
                    if (_archetypeHeader == null)
                    {
                        _archetypeHeader = new RecordHeaderReader(_reader).Read();
                        OnArchetypeHeaderRead?.Invoke(_archetypeHeader);
                        _archetypeIndex = 0;
                        return true;
                    }

                    if (_archetypeHeader.Count < _archetypeIndex)
                        return false;

                    if (_archetypeReader == null)
                        _archetypeReader = new ArchetypeReader(_reader);

                    var archetype = _archetypeReader.Read();
                    OnArchetypeRead?.Invoke(archetype);
                    _archetypeIndex++;
                    if (_archetypeIndex > _archetypeHeader.Count)
                        _state = State.Powersets;
                    
                    return true;

                case State.Powersets:
                    if (_powersetHeader == null)
                    {
                        _powersetHeader = new RecordHeaderReader(_reader).Read();
                        OnPowerSetHeaderRead?.Invoke(_powersetHeader);
                        _powersetIndex = 0;
                        return true;
                    }

                    if (_powersetHeader.Count < _powersetIndex)
                        return false;

                    if (_powersetReader == null)
                        _powersetReader = new PowerSetReader(_reader);

                    var powerset = _powersetReader.Read();
                    OnPowerSetRead?.Invoke(powerset);
                    _powersetIndex++;
                    if (_powersetIndex > _powersetHeader.Count)
                        _state = State.Powers;

                    return true;

                case State.Powers:
                    if (_powerHeader == null)
                    {
                        _powerHeader = new PowerHeaderReader(_reader).Read();
                        OnPowersHeaderRead?.Invoke(_powerHeader);
                        _powerIndex = 0;
                        return true;
                    }

                    if (_powerHeader.Count < _powerIndex)
                        return false;

                    if (_powerReader == null)
                        _powerReader = new PowerReader(_reader);

                    var power = _powerReader.Read();
                    OnPowerRead?.Invoke(power);
                    _powerIndex++;
                    if (_powerIndex > _powerHeader.Count)
                        _state = State.Summons;

                    return true;

                case State.Summons:
                    return false;
                
            }
            return false;
        }

        public event Action<Issue12Header> OnIssue12HeaderRead;

        // archetypes
        public event Action<RecordHeader> OnArchetypeHeaderRead;
        public event Action<Archetype> OnArchetypeRead;        

        // power sets
        public event Action<RecordHeader> OnPowerSetHeaderRead;
        public event Action<PowerSet> OnPowerSetRead;

        // powers
        public event Action<PowerHeader> OnPowersHeaderRead;
        public event Action<Power> OnPowerRead;
    }
}
