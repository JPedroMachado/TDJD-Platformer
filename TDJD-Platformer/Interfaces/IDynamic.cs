using Microsoft.Xna.Framework;

namespace TDJD_Platformer.Interfaces
{
    public interface IDynamic
    {
        float GravityAcceleration { get; set; }
        float MaxGravityAcceleration { get; }
        Vector2 Velocity { get; }
    }
}
