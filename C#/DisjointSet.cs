    class Disjoint_Set
    {
        public readonly int[] DS;

        public Disjoint_Set(int capacity)
        {
            DS = new int[capacity];
            for (int i = 0; i < capacity; i++)
                DS[i] = i;
        }

        public int Root(int i)
        {
            if (DS[i] != i)
                DS[i] = Root(DS[i]);
            return DS[i];
        }

        public bool Find(int i, int j)
        {
            return Root(i) == Root(j);
        }

        public void Unite(int i, int j)
        {
            DS[Root(i)] = Root(j);
        }
    }
    
