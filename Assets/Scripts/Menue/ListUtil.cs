using System;
using System.Collections.Generic;

public static class ListUtil
{

    /// <summary>
    /// Returns a subset of the list
    /// </summary>
    /// <typeparam name="T">any</typeparam>
    /// <param name="collection">Collection from which a page should be returned</param>
    /// <param name="page">which page, starting from 1</param>
    /// <param name="size">how many recipes each page</param>
    /// <returns>recipes on the page, else empty list</returns>
    /// 
    public static List<T> getPage<T>(List<T> collection, int page, int size)
    {
        int PageCount = getPages(collection,size);

        //Bereich ist vollkommen außerhalb
        if (page < 1 || page > PageCount)
        {
            return new List<T>();
        }
        //Bereich ist teilweise innerhalb (letzte Seite und letzte Seite hat weniger Einträge als die anderen)
        else if (page == PageCount && collection.Count % size != 0)
        {
            return collection.GetRange((page - 1) * size, collection.Count % size);
        }
        //Bereich ist vollkommen innerhalb
        return collection.GetRange((page - 1) * size, size);
    }

    public static int getPages<T>(List<T> collection, int size)
    {
        int PageCount;
        if (collection.Count % size == 0)
        {
            PageCount = collection.Count / size;
        }
        else
        {
            PageCount = (collection.Count - (collection.Count % size)) / size + 1;
        }

        return PageCount;
    }

}
