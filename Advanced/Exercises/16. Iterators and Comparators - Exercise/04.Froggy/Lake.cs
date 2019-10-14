namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private List<int> froggyStone;

        public Lake(List<int> input)
        {
            this.froggyStone = new List<int>(input);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < froggyStone.Count; i += 2)
            {
                if (i % 2 == 0)
                {
                    yield return this.froggyStone[i];
                }
            }

            for (int i = froggyStone.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return this.froggyStone[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
