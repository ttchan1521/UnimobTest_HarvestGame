using UnityEngine;

public static class TransformExtension
{
    public static Vector3 MoveAlongArc(Vector3 startPos, Vector3 endPos, float t, float arcHeight = 2f)
    {
        // Linear interpolation
        Vector3 currentPos = Vector3.Lerp(startPos, endPos, t);
        
        // Thêm arc (parabola) - cao nhất ở giữa
        float arcProgress = t * (1 - t) * 4f; // *4 để normalize peak
        currentPos.y += arcProgress * arcHeight;
        
        return currentPos;
    }
    
    // Hoặc version trả về position thay vì set trực tiếp
    public static Vector3 GetArcPosition(Vector3 startPos, Vector3 endPos, float t, float arcHeight = 2f)
    {
        Vector3 currentPos = Vector3.Lerp(startPos, endPos, t);
        float arcProgress = t * (1 - t) * 4f;
        currentPos.y += arcProgress * arcHeight;
        return currentPos;
    }
}