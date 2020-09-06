using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static yphkd.Utils;

namespace yphkd.Db
{
    public class Tables
    {
        public Tables()
        {
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class CountryTable
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "img")]
        public string Image { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }


        //public static Country FromDictionary(DictionaryObject d)
        //{
        //    Country o = new Country();
        //    if (d.Contains("id"))
        //    {
        //        o.Id = d.GetInt("id");
        //    }
        //    if (d.Contains("img"))
        //    {
        //        o.Image = d.GetString("img");
        //    }
        //    if (d.Contains("title"))
        //    {
        //        o.Title = d.GetString("title");
        //    }

        //    return o;
        //}

        //public MutableDocument ToMutableDocument()
        //{
        //    MutableDocument md = new MutableDocument("country_" + this.Id.ToString());
        //    if (this.Id != null)
        //    {
        //        md.SetInt("id", this.Id);
        //    }
        //    if (this.Image != null)
        //    {
        //        md.SetString("img", this.Image);
        //    }
        //    if (this.Title != null)
        //    {
        //        md.SetString("title", this.Title);
        //    }

        //    md.SetString("type", "country");
        //    return md;
        //}


        //public static Country GetById(int Id)
        //{
        //    Country o = null;

        //    using (var query = QueryBuilder.Select(SelectResult.All())
        //      .From(DataSource.Database(DbHelper.GetDatabase()))
        //      .Where(Expression.Property("id").EqualTo(Expression.Int(Id))
        //      .And(Expression.Property("type").EqualTo(Expression.String("country")))))
        //    {
        //        IResultSet rs = query.Execute();
        //        if (rs == null)
        //        {
        //            return null;
        //        }

        //        List<Result> ls = rs.AllResults();
        //        if (ls.Count == 0)
        //        {
        //            return null;
        //        }

        //        if (ls.First() == null)
        //        {
        //            return null;
        //        }

        //        DictionaryObject row = ls.First().GetDictionary(0);
        //        o = Country.FromDictionary(row);
        //    }

        //    return o;
        //}

        //public static List<Country> GetListByImage(string Image)
        //{
        //    List<Country> l = null;

        //    using (var query = QueryBuilder.Select(SelectResult.All())
        //      .From(DataSource.Database(DbHelper.GetDatabase()))
        //      .Where(Expression.Property("img").EqualTo(Expression.String(Image))
        //      .And(Expression.Property("type").EqualTo(Expression.String("country")))))
        //    {
        //        IResultSet rs = query.Execute();
        //        if (rs == null)
        //        {
        //            return null;
        //        }

        //        List<Result> ls = rs.AllResults();
        //        if (ls.Count == 0)
        //        {
        //            return null;
        //        }

        //        l = new List<Country>();
        //        foreach (Result row in ls)
        //        {
        //            Country o = Country.FromDictionary(row.GetDictionary(0));
        //            l.Add(o);
        //        }
        //    }

        //    return l;
        //}

        //public static List<Country> GetListByTitle(string Title)
        //{
        //    List<Country> l = null;

        //    using (var query = QueryBuilder.Select(SelectResult.All())
        //      .From(DataSource.Database(DbHelper.GetDatabase()))
        //      .Where(Expression.Property("title").EqualTo(Expression.String(TitleEn))
        //      .And(Expression.Property("type").EqualTo(Expression.String("country")))))
        //    {
        //        IResultSet rs = query.Execute();
        //        if (rs == null)
        //        {
        //            return null;
        //        }

        //        List<Result> ls = rs.AllResults();
        //        if (ls.Count == 0)
        //        {
        //            return null;
        //        }

        //        l = new List<Country>();
        //        foreach (Result row in ls)
        //        {
        //            Country o = Country.FromDictionary(row.GetDictionary(0));
        //            l.Add(o);
        //        }
        //    }

        //    return l;
        //}


    }
    [JsonObject(MemberSerialization.OptIn)]
    public class GameTableTypeDefinitionTable
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "table_type")]
        public int TableType { get; set; }

        [JsonProperty (PropertyName = "coins")]
        public int Coins { get; set; }

        [JsonProperty(PropertyName = "img")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "number_of_players")]
        public string NumberOfPlayers { get; set; }
    }
}
