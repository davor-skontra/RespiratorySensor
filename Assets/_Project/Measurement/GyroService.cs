using UnityEngine;

namespace Measurement
{
    public interface IGravityDirectionProvider
    {
        Vector3 Down { get; }
    }

    public class GravityDirectionProvider : IGravityDirectionProvider
    {
        private readonly bool _useGyro;

        public GravityDirectionProvider()
        {
            _useGyro = SystemInfo.supportsGyroscope;

            if (_useGyro)
            {
                Input.gyro.enabled = true;
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public Vector3 Down => _useGyro
            ? Input.gyro.gravity
            : Input.acceleration;

        public Vector2 Up => -Down;
    }
}