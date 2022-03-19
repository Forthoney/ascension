namespace Enemy
{
    public class StationaryMovement : Movement
    {
        void Update()
        {
            if (!CanSeePlayer()) return;
            
            FaceTarget();
        }
    }
}
