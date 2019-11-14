namespace CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    public interface IAddable
    {
        int Add(string item);

        string Remove();

        int Index { get; }

        List<String> Collection { get; }
    }
}