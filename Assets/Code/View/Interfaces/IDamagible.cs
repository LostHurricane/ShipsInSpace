using System;

namespace ShipsInSpace
{
    public interface IDamagible : IView
    {
        Action<IDamagible, int> OnDamageTaken { get; set; }

        void TakeDamage(int damage);
    }
}
