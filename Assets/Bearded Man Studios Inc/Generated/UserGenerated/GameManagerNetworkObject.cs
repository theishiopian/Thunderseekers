using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0]")]
	public partial class GameManagerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 1;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private int _gamestate;
		public event FieldEvent<int> gamestateChanged;
		public Interpolated<int> gamestateInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int gamestate
		{
			get { return _gamestate; }
			set
			{
				// Don't do anything if the value is the same
				if (_gamestate == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_gamestate = value;
				hasDirtyFields = true;
			}
		}

		public void SetgamestateDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_gamestate(ulong timestep)
		{
			if (gamestateChanged != null) gamestateChanged(_gamestate, timestep);
			if (fieldAltered != null) fieldAltered("gamestate", _gamestate, timestep);
		}
		[ForgeGeneratedField]
		private int _playercount;
		public event FieldEvent<int> playercountChanged;
		public Interpolated<int> playercountInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int playercount
		{
			get { return _playercount; }
			set
			{
				// Don't do anything if the value is the same
				if (_playercount == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_playercount = value;
				hasDirtyFields = true;
			}
		}

		public void SetplayercountDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_playercount(ulong timestep)
		{
			if (playercountChanged != null) playercountChanged(_playercount, timestep);
			if (fieldAltered != null) fieldAltered("playercount", _playercount, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			gamestateInterpolation.current = gamestateInterpolation.target;
			playercountInterpolation.current = playercountInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _gamestate);
			UnityObjectMapper.Instance.MapBytes(data, _playercount);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_gamestate = UnityObjectMapper.Instance.Map<int>(payload);
			gamestateInterpolation.current = _gamestate;
			gamestateInterpolation.target = _gamestate;
			RunChange_gamestate(timestep);
			_playercount = UnityObjectMapper.Instance.Map<int>(payload);
			playercountInterpolation.current = _playercount;
			playercountInterpolation.target = _playercount;
			RunChange_playercount(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _gamestate);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _playercount);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (gamestateInterpolation.Enabled)
				{
					gamestateInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					gamestateInterpolation.Timestep = timestep;
				}
				else
				{
					_gamestate = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_gamestate(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (playercountInterpolation.Enabled)
				{
					playercountInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					playercountInterpolation.Timestep = timestep;
				}
				else
				{
					_playercount = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_playercount(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (gamestateInterpolation.Enabled && !gamestateInterpolation.current.UnityNear(gamestateInterpolation.target, 0.0015f))
			{
				_gamestate = (int)gamestateInterpolation.Interpolate();
				//RunChange_gamestate(gamestateInterpolation.Timestep);
			}
			if (playercountInterpolation.Enabled && !playercountInterpolation.current.UnityNear(playercountInterpolation.target, 0.0015f))
			{
				_playercount = (int)playercountInterpolation.Interpolate();
				//RunChange_playercount(playercountInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public GameManagerNetworkObject() : base() { Initialize(); }
		public GameManagerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public GameManagerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
