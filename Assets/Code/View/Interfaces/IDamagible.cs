using System;

namespace ShipsInSpace
{
    public interface IDamagible 
    {
        Action<int> OnDamageTaken { get; }

        void TakeDamage(int damage);
    }
}
