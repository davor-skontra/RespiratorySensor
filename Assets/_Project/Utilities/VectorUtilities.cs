using System;
using UnityEngine;

namespace Utilities
{
    public static class VectorUtilities
    {
        // Vector 4
        public static Vector4 WhereX(this Vector4 self, float x) => new Vector4(x, self.y, self.z, self.w);
        public static Vector4 WhereY(this Vector4 self, float y) => new Vector4(self.x, y, self.z, self.w);
        public static Vector4 WhereZ(this Vector4 self, float z) => new Vector4(self.x, self.y, z, self.w);
        public static Vector4 WhereW(this Vector4 self, float w) => new Vector4(self.x, self.y, self.z, w);

        public static Vector4 WhereX(this Vector4 self, Func<float, float> modifier) =>
            new Vector4(modifier(self.x), self.y, self.z, self.w);

        public static Vector4 WhereY(this Vector4 self, Func<float, float> modifier) =>
            new Vector4(self.x, modifier(self.y), self.z, self.w);

        public static Vector4 WhereZ(this Vector4 self, Func<float, float> modifier) =>
            new Vector4(self.x, self.y, modifier(self.z), self.w);

        public static Vector4 WhereW(this Vector4 self, Func<float, float> modifier) =>
            new Vector4(self.x, self.y, self.z, modifier(self.w));

        // Vector 3
        public static Vector3 WhereX(this Vector3 self, float x) => new Vector3(x, self.y, self.z);
        public static Vector3 WhereY(this Vector3 self, float y) => new Vector3(self.x, y, self.z);
        public static Vector3 WhereZ(this Vector3 self, float z) => new Vector3(self.x, self.y, z);

        public static Vector3 WhereX(this Vector3 self, Func<float, float> modifier) =>
            new Vector3(modifier(self.x), self.y, self.z);

        public static Vector3 WhereY(this Vector3 self, Func<float, float> modifier) =>
            new Vector3(self.x, modifier(self.y), self.z);

        public static Vector3 WhereZ(this Vector3 self, Func<float, float> modifier) =>
            new Vector3(self.x, self.y, modifier(self.z));

        // Vector 2
        public static Vector2 WhereX(this Vector2 self, float x) => new Vector2(x, self.y);
        public static Vector2 WhereY(this Vector2 self, float y) => new Vector2(self.x, y);

        public static Vector2 WhereX(this Vector2 self, Func<float, float> modifier) =>
            new Vector2(modifier(self.x), self.y);

        public static Vector2 WhereY(this Vector2 self, Func<float, float> modifier) =>
            new Vector2(self.x, modifier(self.y));
    }
}