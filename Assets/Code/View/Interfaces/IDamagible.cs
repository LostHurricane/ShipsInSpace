using System;

namespace ShipsInSpace
{
    public interface IDamagible : IView
    {
        Action<int> OnDamageTaken { get; set; }

        void TakeDamage(int damage);
    }
}
