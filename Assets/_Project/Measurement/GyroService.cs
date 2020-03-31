using UnityEngine;

namespace Measurement
{
    public interface IGyroService
    {
        Vector3 Gravity { get; }
    }
    
    public class GyroService: IGyroService
    {
        public Vector3 Gravity => Input.gyro.gravity;
    }
}