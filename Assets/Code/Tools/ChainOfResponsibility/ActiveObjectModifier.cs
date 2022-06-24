namespace ShipsInSpace
{
    public class ActiveObjectModifier
    {

        protected ActiveObjectModifier Next;

        public void Add(ActiveObjectModifier nextMod)
        {
            if (Next != null)
            {
                Next.Add(nextMod);
            }
            else
            {
                Next = nextMod;
            }
        }
        public virtual void Handle() => Next?.Handle();

    }
}
