using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]")]
	public partial class PlayerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 2;

		private byte[] _dirtyFields = new byte[3];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0f, Enabled = false };
		public Vector3 position
		{
			get { return _position; }
			set
			{
				// Don't do anything if the value is the same
				if (_position == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_position = value;
				hasDirtyFields = true;
			}
		}

		public void SetpositionDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_position(ulong timestep)
		{
			if (positionChanged != null) positionChanged(_position, timestep);
			if (fieldAltered != null) fieldAltered("position", _position, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rotation;
		public event FieldEvent<Quaternion> rotationChanged;
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0f, Enabled = false };
		public Quaternion rotation
		{
			get { return _rotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_rotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_rotation(ulong timestep)
		{
			if (rotationChanged != null) rotationChanged(_rotation, timestep);
			if (fieldAltered != null) fieldAltered("rotation", _rotation, timestep);
		}
		[ForgeGeneratedField]
		private float _health;
		public event FieldEvent<float> healthChanged;
		public InterpolateFloat healthInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float health
		{
			get { return _health; }
			set
			{
				// Don't do anything if the value is the same
				if (_health == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_health = value;
				hasDirtyFields = true;
			}
		}

		public void SethealthDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_health(ulong timestep)
		{
			if (healthChanged != null) healthChanged(_health, timestep);
			if (fieldAltered != null) fieldAltered("health", _health, timestep);
		}
		[ForgeGeneratedField]
		private bool _primaryfire;
		public event FieldEvent<bool> primaryfireChanged;
		public Interpolated<bool> primaryfireInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool primaryfire
		{
			get { return _primaryfire; }
			set
			{
				// Don't do anything if the value is the same
				if (_primaryfire == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_primaryfire = value;
				hasDirtyFields = true;
			}
		}

		public void SetprimaryfireDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_primaryfire(ulong timestep)
		{
			if (primaryfireChanged != null) primaryfireChanged(_primaryfire, timestep);
			if (fieldAltered != null) fieldAltered("primaryfire", _primaryfire, timestep);
		}
		[ForgeGeneratedField]
		private bool _secondaryfire;
		public event FieldEvent<bool> secondaryfireChanged;
		public Interpolated<bool> secondaryfireInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool secondaryfire
		{
			get { return _secondaryfire; }
			set
			{
				// Don't do anything if the value is the same
				if (_secondaryfire == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_secondaryfire = value;
				hasDirtyFields = true;
			}
		}

		public void SetsecondaryfireDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_secondaryfire(ulong timestep)
		{
			if (secondaryfireChanged != null) secondaryfireChanged(_secondaryfire, timestep);
			if (fieldAltered != null) fieldAltered("secondaryfire", _secondaryfire, timestep);
		}
		[ForgeGeneratedField]
		private bool _tertiaryfire;
		public event FieldEvent<bool> tertiaryfireChanged;
		public Interpolated<bool> tertiaryfireInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool tertiaryfire
		{
			get { return _tertiaryfire; }
			set
			{
				// Don't do anything if the value is the same
				if (_tertiaryfire == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_tertiaryfire = value;
				hasDirtyFields = true;
			}
		}

		public void SettertiaryfireDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_tertiaryfire(ulong timestep)
		{
			if (tertiaryfireChanged != null) tertiaryfireChanged(_tertiaryfire, timestep);
			if (fieldAltered != null) fieldAltered("tertiaryfire", _tertiaryfire, timestep);
		}
		[ForgeGeneratedField]
		private bool _dodge;
		public event FieldEvent<bool> dodgeChanged;
		public Interpolated<bool> dodgeInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool dodge
		{
			get { return _dodge; }
			set
			{
				// Don't do anything if the value is the same
				if (_dodge == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x40;
				_dodge = value;
				hasDirtyFields = true;
			}
		}

		public void SetdodgeDirty()
		{
			_dirtyFields[0] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_dodge(ulong timestep)
		{
			if (dodgeChanged != null) dodgeChanged(_dodge, timestep);
			if (fieldAltered != null) fieldAltered("dodge", _dodge, timestep);
		}
		[ForgeGeneratedField]
		private bool _flares;
		public event FieldEvent<bool> flaresChanged;
		public Interpolated<bool> flaresInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool flares
		{
			get { return _flares; }
			set
			{
				// Don't do anything if the value is the same
				if (_flares == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x80;
				_flares = value;
				hasDirtyFields = true;
			}
		}

		public void SetflaresDirty()
		{
			_dirtyFields[0] |= 0x80;
			hasDirtyFields = true;
		}

		private void RunChange_flares(ulong timestep)
		{
			if (flaresChanged != null) flaresChanged(_flares, timestep);
			if (fieldAltered != null) fieldAltered("flares", _flares, timestep);
		}
		[ForgeGeneratedField]
		private Vector2 _move_input;
		public event FieldEvent<Vector2> move_inputChanged;
		public InterpolateVector2 move_inputInterpolation = new InterpolateVector2() { LerpT = 0f, Enabled = false };
		public Vector2 move_input
		{
			get { return _move_input; }
			set
			{
				// Don't do anything if the value is the same
				if (_move_input == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x1;
				_move_input = value;
				hasDirtyFields = true;
			}
		}

		public void Setmove_inputDirty()
		{
			_dirtyFields[1] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_move_input(ulong timestep)
		{
			if (move_inputChanged != null) move_inputChanged(_move_input, timestep);
			if (fieldAltered != null) fieldAltered("move_input", _move_input, timestep);
		}
		[ForgeGeneratedField]
		private Vector2 _aim;
		public event FieldEvent<Vector2> aimChanged;
		public InterpolateVector2 aimInterpolation = new InterpolateVector2() { LerpT = 0f, Enabled = false };
		public Vector2 aim
		{
			get { return _aim; }
			set
			{
				// Don't do anything if the value is the same
				if (_aim == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x2;
				_aim = value;
				hasDirtyFields = true;
			}
		}

		public void SetaimDirty()
		{
			_dirtyFields[1] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_aim(ulong timestep)
		{
			if (aimChanged != null) aimChanged(_aim, timestep);
			if (fieldAltered != null) fieldAltered("aim", _aim, timestep);
		}
		[ForgeGeneratedField]
		private bool _movetoggle;
		public event FieldEvent<bool> movetoggleChanged;
		public Interpolated<bool> movetoggleInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool movetoggle
		{
			get { return _movetoggle; }
			set
			{
				// Don't do anything if the value is the same
				if (_movetoggle == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x4;
				_movetoggle = value;
				hasDirtyFields = true;
			}
		}

		public void SetmovetoggleDirty()
		{
			_dirtyFields[1] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_movetoggle(ulong timestep)
		{
			if (movetoggleChanged != null) movetoggleChanged(_movetoggle, timestep);
			if (fieldAltered != null) fieldAltered("movetoggle", _movetoggle, timestep);
		}
		[ForgeGeneratedField]
		private bool _mapzoomtoggle;
		public event FieldEvent<bool> mapzoomtoggleChanged;
		public Interpolated<bool> mapzoomtoggleInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool mapzoomtoggle
		{
			get { return _mapzoomtoggle; }
			set
			{
				// Don't do anything if the value is the same
				if (_mapzoomtoggle == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x8;
				_mapzoomtoggle = value;
				hasDirtyFields = true;
			}
		}

		public void SetmapzoomtoggleDirty()
		{
			_dirtyFields[1] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_mapzoomtoggle(ulong timestep)
		{
			if (mapzoomtoggleChanged != null) mapzoomtoggleChanged(_mapzoomtoggle, timestep);
			if (fieldAltered != null) fieldAltered("mapzoomtoggle", _mapzoomtoggle, timestep);
		}
		[ForgeGeneratedField]
		private bool _cyclecamerazoom;
		public event FieldEvent<bool> cyclecamerazoomChanged;
		public Interpolated<bool> cyclecamerazoomInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool cyclecamerazoom
		{
			get { return _cyclecamerazoom; }
			set
			{
				// Don't do anything if the value is the same
				if (_cyclecamerazoom == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x10;
				_cyclecamerazoom = value;
				hasDirtyFields = true;
			}
		}

		public void SetcyclecamerazoomDirty()
		{
			_dirtyFields[1] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_cyclecamerazoom(ulong timestep)
		{
			if (cyclecamerazoomChanged != null) cyclecamerazoomChanged(_cyclecamerazoom, timestep);
			if (fieldAltered != null) fieldAltered("cyclecamerazoom", _cyclecamerazoom, timestep);
		}
		[ForgeGeneratedField]
		private float _zoom;
		public event FieldEvent<float> zoomChanged;
		public InterpolateFloat zoomInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float zoom
		{
			get { return _zoom; }
			set
			{
				// Don't do anything if the value is the same
				if (_zoom == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x20;
				_zoom = value;
				hasDirtyFields = true;
			}
		}

		public void SetzoomDirty()
		{
			_dirtyFields[1] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_zoom(ulong timestep)
		{
			if (zoomChanged != null) zoomChanged(_zoom, timestep);
			if (fieldAltered != null) fieldAltered("zoom", _zoom, timestep);
		}
		[ForgeGeneratedField]
		private bool _lockon;
		public event FieldEvent<bool> lockonChanged;
		public Interpolated<bool> lockonInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool lockon
		{
			get { return _lockon; }
			set
			{
				// Don't do anything if the value is the same
				if (_lockon == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x40;
				_lockon = value;
				hasDirtyFields = true;
			}
		}

		public void SetlockonDirty()
		{
			_dirtyFields[1] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_lockon(ulong timestep)
		{
			if (lockonChanged != null) lockonChanged(_lockon, timestep);
			if (fieldAltered != null) fieldAltered("lockon", _lockon, timestep);
		}
		[ForgeGeneratedField]
		private bool _sysup;
		public event FieldEvent<bool> sysupChanged;
		public Interpolated<bool> sysupInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool sysup
		{
			get { return _sysup; }
			set
			{
				// Don't do anything if the value is the same
				if (_sysup == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x80;
				_sysup = value;
				hasDirtyFields = true;
			}
		}

		public void SetsysupDirty()
		{
			_dirtyFields[1] |= 0x80;
			hasDirtyFields = true;
		}

		private void RunChange_sysup(ulong timestep)
		{
			if (sysupChanged != null) sysupChanged(_sysup, timestep);
			if (fieldAltered != null) fieldAltered("sysup", _sysup, timestep);
		}
		[ForgeGeneratedField]
		private byte _sysdown;
		public event FieldEvent<byte> sysdownChanged;
		public Interpolated<byte> sysdownInterpolation = new Interpolated<byte>() { LerpT = 0f, Enabled = false };
		public byte sysdown
		{
			get { return _sysdown; }
			set
			{
				// Don't do anything if the value is the same
				if (_sysdown == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[2] |= 0x1;
				_sysdown = value;
				hasDirtyFields = true;
			}
		}

		public void SetsysdownDirty()
		{
			_dirtyFields[2] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_sysdown(ulong timestep)
		{
			if (sysdownChanged != null) sysdownChanged(_sysdown, timestep);
			if (fieldAltered != null) fieldAltered("sysdown", _sysdown, timestep);
		}
		[ForgeGeneratedField]
		private byte _sysleft;
		public event FieldEvent<byte> sysleftChanged;
		public Interpolated<byte> sysleftInterpolation = new Interpolated<byte>() { LerpT = 0f, Enabled = false };
		public byte sysleft
		{
			get { return _sysleft; }
			set
			{
				// Don't do anything if the value is the same
				if (_sysleft == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[2] |= 0x2;
				_sysleft = value;
				hasDirtyFields = true;
			}
		}

		public void SetsysleftDirty()
		{
			_dirtyFields[2] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_sysleft(ulong timestep)
		{
			if (sysleftChanged != null) sysleftChanged(_sysleft, timestep);
			if (fieldAltered != null) fieldAltered("sysleft", _sysleft, timestep);
		}
		[ForgeGeneratedField]
		private byte _sysright;
		public event FieldEvent<byte> sysrightChanged;
		public Interpolated<byte> sysrightInterpolation = new Interpolated<byte>() { LerpT = 0f, Enabled = false };
		public byte sysright
		{
			get { return _sysright; }
			set
			{
				// Don't do anything if the value is the same
				if (_sysright == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[2] |= 0x4;
				_sysright = value;
				hasDirtyFields = true;
			}
		}

		public void SetsysrightDirty()
		{
			_dirtyFields[2] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_sysright(ulong timestep)
		{
			if (sysrightChanged != null) sysrightChanged(_sysright, timestep);
			if (fieldAltered != null) fieldAltered("sysright", _sysright, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			positionInterpolation.current = positionInterpolation.target;
			rotationInterpolation.current = rotationInterpolation.target;
			healthInterpolation.current = healthInterpolation.target;
			primaryfireInterpolation.current = primaryfireInterpolation.target;
			secondaryfireInterpolation.current = secondaryfireInterpolation.target;
			tertiaryfireInterpolation.current = tertiaryfireInterpolation.target;
			dodgeInterpolation.current = dodgeInterpolation.target;
			flaresInterpolation.current = flaresInterpolation.target;
			move_inputInterpolation.current = move_inputInterpolation.target;
			aimInterpolation.current = aimInterpolation.target;
			movetoggleInterpolation.current = movetoggleInterpolation.target;
			mapzoomtoggleInterpolation.current = mapzoomtoggleInterpolation.target;
			cyclecamerazoomInterpolation.current = cyclecamerazoomInterpolation.target;
			zoomInterpolation.current = zoomInterpolation.target;
			lockonInterpolation.current = lockonInterpolation.target;
			sysupInterpolation.current = sysupInterpolation.target;
			sysdownInterpolation.current = sysdownInterpolation.target;
			sysleftInterpolation.current = sysleftInterpolation.target;
			sysrightInterpolation.current = sysrightInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _health);
			UnityObjectMapper.Instance.MapBytes(data, _primaryfire);
			UnityObjectMapper.Instance.MapBytes(data, _secondaryfire);
			UnityObjectMapper.Instance.MapBytes(data, _tertiaryfire);
			UnityObjectMapper.Instance.MapBytes(data, _dodge);
			UnityObjectMapper.Instance.MapBytes(data, _flares);
			UnityObjectMapper.Instance.MapBytes(data, _move_input);
			UnityObjectMapper.Instance.MapBytes(data, _aim);
			UnityObjectMapper.Instance.MapBytes(data, _movetoggle);
			UnityObjectMapper.Instance.MapBytes(data, _mapzoomtoggle);
			UnityObjectMapper.Instance.MapBytes(data, _cyclecamerazoom);
			UnityObjectMapper.Instance.MapBytes(data, _zoom);
			UnityObjectMapper.Instance.MapBytes(data, _lockon);
			UnityObjectMapper.Instance.MapBytes(data, _sysup);
			UnityObjectMapper.Instance.MapBytes(data, _sysdown);
			UnityObjectMapper.Instance.MapBytes(data, _sysleft);
			UnityObjectMapper.Instance.MapBytes(data, _sysright);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_position = UnityObjectMapper.Instance.Map<Vector3>(payload);
			positionInterpolation.current = _position;
			positionInterpolation.target = _position;
			RunChange_position(timestep);
			_rotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rotationInterpolation.current = _rotation;
			rotationInterpolation.target = _rotation;
			RunChange_rotation(timestep);
			_health = UnityObjectMapper.Instance.Map<float>(payload);
			healthInterpolation.current = _health;
			healthInterpolation.target = _health;
			RunChange_health(timestep);
			_primaryfire = UnityObjectMapper.Instance.Map<bool>(payload);
			primaryfireInterpolation.current = _primaryfire;
			primaryfireInterpolation.target = _primaryfire;
			RunChange_primaryfire(timestep);
			_secondaryfire = UnityObjectMapper.Instance.Map<bool>(payload);
			secondaryfireInterpolation.current = _secondaryfire;
			secondaryfireInterpolation.target = _secondaryfire;
			RunChange_secondaryfire(timestep);
			_tertiaryfire = UnityObjectMapper.Instance.Map<bool>(payload);
			tertiaryfireInterpolation.current = _tertiaryfire;
			tertiaryfireInterpolation.target = _tertiaryfire;
			RunChange_tertiaryfire(timestep);
			_dodge = UnityObjectMapper.Instance.Map<bool>(payload);
			dodgeInterpolation.current = _dodge;
			dodgeInterpolation.target = _dodge;
			RunChange_dodge(timestep);
			_flares = UnityObjectMapper.Instance.Map<bool>(payload);
			flaresInterpolation.current = _flares;
			flaresInterpolation.target = _flares;
			RunChange_flares(timestep);
			_move_input = UnityObjectMapper.Instance.Map<Vector2>(payload);
			move_inputInterpolation.current = _move_input;
			move_inputInterpolation.target = _move_input;
			RunChange_move_input(timestep);
			_aim = UnityObjectMapper.Instance.Map<Vector2>(payload);
			aimInterpolation.current = _aim;
			aimInterpolation.target = _aim;
			RunChange_aim(timestep);
			_movetoggle = UnityObjectMapper.Instance.Map<bool>(payload);
			movetoggleInterpolation.current = _movetoggle;
			movetoggleInterpolation.target = _movetoggle;
			RunChange_movetoggle(timestep);
			_mapzoomtoggle = UnityObjectMapper.Instance.Map<bool>(payload);
			mapzoomtoggleInterpolation.current = _mapzoomtoggle;
			mapzoomtoggleInterpolation.target = _mapzoomtoggle;
			RunChange_mapzoomtoggle(timestep);
			_cyclecamerazoom = UnityObjectMapper.Instance.Map<bool>(payload);
			cyclecamerazoomInterpolation.current = _cyclecamerazoom;
			cyclecamerazoomInterpolation.target = _cyclecamerazoom;
			RunChange_cyclecamerazoom(timestep);
			_zoom = UnityObjectMapper.Instance.Map<float>(payload);
			zoomInterpolation.current = _zoom;
			zoomInterpolation.target = _zoom;
			RunChange_zoom(timestep);
			_lockon = UnityObjectMapper.Instance.Map<bool>(payload);
			lockonInterpolation.current = _lockon;
			lockonInterpolation.target = _lockon;
			RunChange_lockon(timestep);
			_sysup = UnityObjectMapper.Instance.Map<bool>(payload);
			sysupInterpolation.current = _sysup;
			sysupInterpolation.target = _sysup;
			RunChange_sysup(timestep);
			_sysdown = UnityObjectMapper.Instance.Map<byte>(payload);
			sysdownInterpolation.current = _sysdown;
			sysdownInterpolation.target = _sysdown;
			RunChange_sysdown(timestep);
			_sysleft = UnityObjectMapper.Instance.Map<byte>(payload);
			sysleftInterpolation.current = _sysleft;
			sysleftInterpolation.target = _sysleft;
			RunChange_sysleft(timestep);
			_sysright = UnityObjectMapper.Instance.Map<byte>(payload);
			sysrightInterpolation.current = _sysright;
			sysrightInterpolation.target = _sysright;
			RunChange_sysright(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _position);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _health);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _primaryfire);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _secondaryfire);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _tertiaryfire);
			if ((0x40 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _dodge);
			if ((0x80 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _flares);
			if ((0x1 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _move_input);
			if ((0x2 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _aim);
			if ((0x4 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _movetoggle);
			if ((0x8 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _mapzoomtoggle);
			if ((0x10 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _cyclecamerazoom);
			if ((0x20 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _zoom);
			if ((0x40 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _lockon);
			if ((0x80 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _sysup);
			if ((0x1 & _dirtyFields[2]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _sysdown);
			if ((0x2 & _dirtyFields[2]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _sysleft);
			if ((0x4 & _dirtyFields[2]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _sysright);

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
				if (positionInterpolation.Enabled)
				{
					positionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					positionInterpolation.Timestep = timestep;
				}
				else
				{
					_position = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_position(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (rotationInterpolation.Enabled)
				{
					rotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (healthInterpolation.Enabled)
				{
					healthInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					healthInterpolation.Timestep = timestep;
				}
				else
				{
					_health = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_health(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (primaryfireInterpolation.Enabled)
				{
					primaryfireInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					primaryfireInterpolation.Timestep = timestep;
				}
				else
				{
					_primaryfire = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_primaryfire(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (secondaryfireInterpolation.Enabled)
				{
					secondaryfireInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					secondaryfireInterpolation.Timestep = timestep;
				}
				else
				{
					_secondaryfire = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_secondaryfire(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (tertiaryfireInterpolation.Enabled)
				{
					tertiaryfireInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					tertiaryfireInterpolation.Timestep = timestep;
				}
				else
				{
					_tertiaryfire = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_tertiaryfire(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[0]) != 0)
			{
				if (dodgeInterpolation.Enabled)
				{
					dodgeInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					dodgeInterpolation.Timestep = timestep;
				}
				else
				{
					_dodge = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_dodge(timestep);
				}
			}
			if ((0x80 & readDirtyFlags[0]) != 0)
			{
				if (flaresInterpolation.Enabled)
				{
					flaresInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					flaresInterpolation.Timestep = timestep;
				}
				else
				{
					_flares = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_flares(timestep);
				}
			}
			if ((0x1 & readDirtyFlags[1]) != 0)
			{
				if (move_inputInterpolation.Enabled)
				{
					move_inputInterpolation.target = UnityObjectMapper.Instance.Map<Vector2>(data);
					move_inputInterpolation.Timestep = timestep;
				}
				else
				{
					_move_input = UnityObjectMapper.Instance.Map<Vector2>(data);
					RunChange_move_input(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[1]) != 0)
			{
				if (aimInterpolation.Enabled)
				{
					aimInterpolation.target = UnityObjectMapper.Instance.Map<Vector2>(data);
					aimInterpolation.Timestep = timestep;
				}
				else
				{
					_aim = UnityObjectMapper.Instance.Map<Vector2>(data);
					RunChange_aim(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[1]) != 0)
			{
				if (movetoggleInterpolation.Enabled)
				{
					movetoggleInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					movetoggleInterpolation.Timestep = timestep;
				}
				else
				{
					_movetoggle = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_movetoggle(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[1]) != 0)
			{
				if (mapzoomtoggleInterpolation.Enabled)
				{
					mapzoomtoggleInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					mapzoomtoggleInterpolation.Timestep = timestep;
				}
				else
				{
					_mapzoomtoggle = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_mapzoomtoggle(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[1]) != 0)
			{
				if (cyclecamerazoomInterpolation.Enabled)
				{
					cyclecamerazoomInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					cyclecamerazoomInterpolation.Timestep = timestep;
				}
				else
				{
					_cyclecamerazoom = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_cyclecamerazoom(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[1]) != 0)
			{
				if (zoomInterpolation.Enabled)
				{
					zoomInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					zoomInterpolation.Timestep = timestep;
				}
				else
				{
					_zoom = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_zoom(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[1]) != 0)
			{
				if (lockonInterpolation.Enabled)
				{
					lockonInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					lockonInterpolation.Timestep = timestep;
				}
				else
				{
					_lockon = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_lockon(timestep);
				}
			}
			if ((0x80 & readDirtyFlags[1]) != 0)
			{
				if (sysupInterpolation.Enabled)
				{
					sysupInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					sysupInterpolation.Timestep = timestep;
				}
				else
				{
					_sysup = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_sysup(timestep);
				}
			}
			if ((0x1 & readDirtyFlags[2]) != 0)
			{
				if (sysdownInterpolation.Enabled)
				{
					sysdownInterpolation.target = UnityObjectMapper.Instance.Map<byte>(data);
					sysdownInterpolation.Timestep = timestep;
				}
				else
				{
					_sysdown = UnityObjectMapper.Instance.Map<byte>(data);
					RunChange_sysdown(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[2]) != 0)
			{
				if (sysleftInterpolation.Enabled)
				{
					sysleftInterpolation.target = UnityObjectMapper.Instance.Map<byte>(data);
					sysleftInterpolation.Timestep = timestep;
				}
				else
				{
					_sysleft = UnityObjectMapper.Instance.Map<byte>(data);
					RunChange_sysleft(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[2]) != 0)
			{
				if (sysrightInterpolation.Enabled)
				{
					sysrightInterpolation.target = UnityObjectMapper.Instance.Map<byte>(data);
					sysrightInterpolation.Timestep = timestep;
				}
				else
				{
					_sysright = UnityObjectMapper.Instance.Map<byte>(data);
					RunChange_sysright(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (positionInterpolation.Enabled && !positionInterpolation.current.UnityNear(positionInterpolation.target, 0.0015f))
			{
				_position = (Vector3)positionInterpolation.Interpolate();
				//RunChange_position(positionInterpolation.Timestep);
			}
			if (rotationInterpolation.Enabled && !rotationInterpolation.current.UnityNear(rotationInterpolation.target, 0.0015f))
			{
				_rotation = (Quaternion)rotationInterpolation.Interpolate();
				//RunChange_rotation(rotationInterpolation.Timestep);
			}
			if (healthInterpolation.Enabled && !healthInterpolation.current.UnityNear(healthInterpolation.target, 0.0015f))
			{
				_health = (float)healthInterpolation.Interpolate();
				//RunChange_health(healthInterpolation.Timestep);
			}
			if (primaryfireInterpolation.Enabled && !primaryfireInterpolation.current.UnityNear(primaryfireInterpolation.target, 0.0015f))
			{
				_primaryfire = (bool)primaryfireInterpolation.Interpolate();
				//RunChange_primaryfire(primaryfireInterpolation.Timestep);
			}
			if (secondaryfireInterpolation.Enabled && !secondaryfireInterpolation.current.UnityNear(secondaryfireInterpolation.target, 0.0015f))
			{
				_secondaryfire = (bool)secondaryfireInterpolation.Interpolate();
				//RunChange_secondaryfire(secondaryfireInterpolation.Timestep);
			}
			if (tertiaryfireInterpolation.Enabled && !tertiaryfireInterpolation.current.UnityNear(tertiaryfireInterpolation.target, 0.0015f))
			{
				_tertiaryfire = (bool)tertiaryfireInterpolation.Interpolate();
				//RunChange_tertiaryfire(tertiaryfireInterpolation.Timestep);
			}
			if (dodgeInterpolation.Enabled && !dodgeInterpolation.current.UnityNear(dodgeInterpolation.target, 0.0015f))
			{
				_dodge = (bool)dodgeInterpolation.Interpolate();
				//RunChange_dodge(dodgeInterpolation.Timestep);
			}
			if (flaresInterpolation.Enabled && !flaresInterpolation.current.UnityNear(flaresInterpolation.target, 0.0015f))
			{
				_flares = (bool)flaresInterpolation.Interpolate();
				//RunChange_flares(flaresInterpolation.Timestep);
			}
			if (move_inputInterpolation.Enabled && !move_inputInterpolation.current.UnityNear(move_inputInterpolation.target, 0.0015f))
			{
				_move_input = (Vector2)move_inputInterpolation.Interpolate();
				//RunChange_move_input(move_inputInterpolation.Timestep);
			}
			if (aimInterpolation.Enabled && !aimInterpolation.current.UnityNear(aimInterpolation.target, 0.0015f))
			{
				_aim = (Vector2)aimInterpolation.Interpolate();
				//RunChange_aim(aimInterpolation.Timestep);
			}
			if (movetoggleInterpolation.Enabled && !movetoggleInterpolation.current.UnityNear(movetoggleInterpolation.target, 0.0015f))
			{
				_movetoggle = (bool)movetoggleInterpolation.Interpolate();
				//RunChange_movetoggle(movetoggleInterpolation.Timestep);
			}
			if (mapzoomtoggleInterpolation.Enabled && !mapzoomtoggleInterpolation.current.UnityNear(mapzoomtoggleInterpolation.target, 0.0015f))
			{
				_mapzoomtoggle = (bool)mapzoomtoggleInterpolation.Interpolate();
				//RunChange_mapzoomtoggle(mapzoomtoggleInterpolation.Timestep);
			}
			if (cyclecamerazoomInterpolation.Enabled && !cyclecamerazoomInterpolation.current.UnityNear(cyclecamerazoomInterpolation.target, 0.0015f))
			{
				_cyclecamerazoom = (bool)cyclecamerazoomInterpolation.Interpolate();
				//RunChange_cyclecamerazoom(cyclecamerazoomInterpolation.Timestep);
			}
			if (zoomInterpolation.Enabled && !zoomInterpolation.current.UnityNear(zoomInterpolation.target, 0.0015f))
			{
				_zoom = (float)zoomInterpolation.Interpolate();
				//RunChange_zoom(zoomInterpolation.Timestep);
			}
			if (lockonInterpolation.Enabled && !lockonInterpolation.current.UnityNear(lockonInterpolation.target, 0.0015f))
			{
				_lockon = (bool)lockonInterpolation.Interpolate();
				//RunChange_lockon(lockonInterpolation.Timestep);
			}
			if (sysupInterpolation.Enabled && !sysupInterpolation.current.UnityNear(sysupInterpolation.target, 0.0015f))
			{
				_sysup = (bool)sysupInterpolation.Interpolate();
				//RunChange_sysup(sysupInterpolation.Timestep);
			}
			if (sysdownInterpolation.Enabled && !sysdownInterpolation.current.UnityNear(sysdownInterpolation.target, 0.0015f))
			{
				_sysdown = (byte)sysdownInterpolation.Interpolate();
				//RunChange_sysdown(sysdownInterpolation.Timestep);
			}
			if (sysleftInterpolation.Enabled && !sysleftInterpolation.current.UnityNear(sysleftInterpolation.target, 0.0015f))
			{
				_sysleft = (byte)sysleftInterpolation.Interpolate();
				//RunChange_sysleft(sysleftInterpolation.Timestep);
			}
			if (sysrightInterpolation.Enabled && !sysrightInterpolation.current.UnityNear(sysrightInterpolation.target, 0.0015f))
			{
				_sysright = (byte)sysrightInterpolation.Interpolate();
				//RunChange_sysright(sysrightInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[3];

		}

		public PlayerNetworkObject() : base() { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
