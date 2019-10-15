namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Lake : IEnumerable<int>
    {
        private List<int> froggyStone;

        public Lake(List<int> input)
        {
            this.froggyStone = new List<int>(input);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.froggyStone.Count; i += 2)
            {
                if (i % 2 == 0)
                {
                    yield return this.froggyStone[i];
                }
            }

            int num;

            if (this.froggyStone.Count % 2 == 0)
            {
                num = 1;
            }
            else
            {
                num = 2;
            }

            for (int i = this.froggyStone.Count - num; i >= 0; i-=2)
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
