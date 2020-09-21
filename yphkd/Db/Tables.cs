﻿using System;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Newtonsoft.Json;
using yphkd.Model.Definitions;
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
    public class TableDefinitionTable
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "max_players")]
        public int MaxPlayers { get; set; }

        [JsonProperty(PropertyName = "title_en")]
        public string TitleEn { get; set; }

        [JsonProperty(PropertyName = "chipin_coins")]
        public int ChipinCoins { get; set; }

        [JsonProperty(PropertyName = "is_del")]
        public int IsDel { get; set; }

        [JsonProperty(PropertyName = "table_type")]
        public int TableType { get; set; }

        
        


        public static TableDefinition FromDictionary(DictionaryObject d)
        {
            TableDefinition o = new TableDefinition();
            if (d.Contains("id"))
            {
                o.Id = d.GetInt("id");
            }
            if (d.Contains("max_players"))
            {
                o.MaxPlayers = d.GetInt("max_players");
            }
            if (d.Contains("title_en"))
            {
                o.TitleEn = d.GetString("title_en");
            }
            if (d.Contains("chipin_coins"))
            {
                o.ChipinCoins = d.GetInt("chipin_coins");
            }
            if (d.Contains("is_del"))
            {
                o.IsDel = d.GetInt("is_del");
            }
            if (d.Contains("table_type"))
            {
                o.TableType = d.GetInt("table_type");
            }
           
            
            return o;
        }

        public MutableDocument ToMutableDocument()
        {
            MutableDocument md = new MutableDocument("table_def_" + this.Id.ToString());
            if (this.Id != null)
            {
                md.SetInt("id", this.Id);
            }
            if (this.MaxPlayers != null)
            {
                md.SetInt("max_players", this.MaxPlayers);
            }
            if (this.TitleEn != null)
            {
                md.SetString("title_en", this.TitleEn);
            }

            if (this.ChipinCoins != null)
            {
                md.SetInt("chipin_coins", this.ChipinCoins);
            }
            if (this.IsDel != null)
            {
                md.SetInt("is_del", this.IsDel);
            }
            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            md.SetString("type", "table_def");
            return md;
        }
        public static TableDefinition GetById(int Id)
        {
            TableDefinition o = null;

            using (var query = QueryBuilder.Select(SelectResult.All())
              .From(DataSource.Database(DbHelper.GetDatabase()))
              .Where(Expression.Property("id").EqualTo(Expression.Int(Id))
              .And(Expression.Property("type").EqualTo(Expression.String("table_def")))))
            {
                IResultSet rs = query.Execute();
                if (rs == null)
                {
                    return null;
                }

                List<Result> ls = rs.AllResults();
                if (ls.Count == 0)
                {
                    return null;
                }

                if (ls.First() == null)
                {
                    return null;
                }

                DictionaryObject row = ls.First().GetDictionary(0);
                o = TableDefinition.FromDictionary(row);
            }

            return o;
        }
        
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class GameTableDefinitionTable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "table_def_id")]
        public int TableDefId { get; set; }

        [JsonProperty(PropertyName = "table_type")]
        public int TableType { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "player1_id")]
        public string Player1Id { get; set; }

        [JsonProperty(PropertyName = "player2_id")]
        public string Player2Id { get; set; }

        [JsonProperty(PropertyName = "player3_id")]
        public string Player3Id { get; set; }

        [JsonProperty(PropertyName = "player4_id")]
        public string Player4Id { get; set; }

        [JsonProperty(PropertyName = "player5_id")]
        public string Player5Id { get; set; }

        [JsonProperty(PropertyName = "player1_symbol")]
        public int Player1Symbol { get; set; }

        [JsonProperty(PropertyName = "player2_symbol")]
        public int Player2Symbol { get; set; }

        [JsonProperty(PropertyName = "player3_symbol")]
        public int Player3Symbol { get; set; }

        [JsonProperty(PropertyName = "player4_symbol")]
        public int Player4Symbol { get; set; }

        [JsonProperty(PropertyName = "player5_symbol")]
        public int Player5Symbol { get; set; }

        [JsonProperty(PropertyName = "update_dt")]
        public DateTime? UpdateDt { get; set; }

        [JsonProperty(PropertyName = "dt")]
        public DateTime? Dt { get; set; }

        [JsonProperty(PropertyName = "expire_dt")]
        public DateTime? ExpireDt { get; set; }

        [JsonProperty(PropertyName = "winner_round_1")]
        public string WinnerRound1 { get; set; }

        [JsonProperty(PropertyName = "winner_round_2")]
        public string WinnerRound2 { get; set; }

        [JsonProperty(PropertyName = "winner_round_3")]
        public string WinnerRound3 { get; set; }

        [JsonProperty(PropertyName = "winner_round_4")]
        public string WinnerRound4 { get; set; }

        [JsonProperty(PropertyName = "winner1_coins_earned")]
        public int Winner1CoinsEarned { get; set; }

        [JsonProperty(PropertyName = "winner2_coins_earned")]
        public int Winner2CoinsEarned { get; set; }

        [JsonProperty(PropertyName = "winner3_coins_earned")]
        public int Winner3CoinsEarned { get; set; }

        [JsonProperty(PropertyName = "winner4_coins_earned")]
        public int Winner4CoinsEarned { get; set; }


        public static GameTableDefinition FromDictionary(DictionaryObject d)
        {
            GameTableDefinition o = new GameTableDefinition();
            if (d.Contains("id"))
            {
                o.Id = d.GetString("id");
            }
            if (d.Contains("table_def_id"))
            {
                o.TableType = d.GetInt("table_def_id");
            }
            if (d.Contains("table_type"))
            {
                o.TableType = d.GetInt("table_type");
            }
            if (d.Contains("status"))
            {
                o.TableType = d.GetInt("status");
            }



            if (d.Contains("player1_id"))
            {
                o.Id = d.GetString("player1_id");
            }
            if (d.Contains("player2_id"))
            {
                o.Id = d.GetString("player2_id");
            }
            if (d.Contains("player3_id"))
            {
                o.Id = d.GetString("player3_id");
            }
            if (d.Contains("player4_id"))
            {
                o.Id = d.GetString("player4_id");
            }
            if (d.Contains("player5_id"))
            {
                o.Id = d.GetString("player5_id");
            }


            if (d.Contains("player1_symbol"))
            {
                o.TableType = d.GetInt("player1_symbol");
            }
            if (d.Contains("player2_symbol"))
            {
                o.TableType = d.GetInt("player2_symbol");
            }
            if (d.Contains("player3_symbol"))
            {
                o.TableType = d.GetInt("player3_symbol");
            }
            if (d.Contains("player4_symbol"))
            {
                o.TableType = d.GetInt("player4_symbol");
            }
            if (d.Contains("player5_symbol"))
            {
                o.TableType = d.GetInt("player5_symbol");
            }

            if (d.Contains("winner_round_1"))
            {
                o.Id = d.GetString("winner_round_1");
            }
            if (d.Contains("winner_round_2"))
            {
                o.Id = d.GetString("winner_round_2");
            }
            if (d.Contains("winner_round_3"))
            {
                o.Id = d.GetString("winner_round_3");
            }
            if (d.Contains("winner_round_4"))
            {
                o.Id = d.GetString("winner_round_4");
            }


            if (d.Contains("winner1_coins_earned"))
            {
                o.TableType = d.GetInt("winner1_coins_earned");
            }
            if (d.Contains("winner2_coins_earned"))
            {
                o.TableType = d.GetInt("winner2_coins_earned");
            }
            if (d.Contains("winner3_coins_earned"))
            {
                o.TableType = d.GetInt("winner3_coins_earned");
            }
            if (d.Contains("winner4_coins_earned"))
            {
                o.TableType = d.GetInt("winner4_coins_earned");
            }

            return o;
        }

        public MutableDocument ToMutableDocument()
        {
            MutableDocument md = new MutableDocument("game_table_" + this.Id.ToString());
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }
           
            if (this.TableDefId != null)
            {
                md.SetInt("table_def_id", this.TableType);
            }
            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("status", this.Id);
            }



            if (this.TableType != null)
            {
                md.SetInt("player1_id", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("player2_id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("player3_id", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("player4_id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("player5_id", this.TableType);
            }



            if (this.Id != null)
            {
                md.SetString("player1_symbol", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("player2_symbol", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("player3_symbol", this.Id);
            }
            if (this.TableType != null)
            {
                md.SetInt("player4_symbol", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("player5_symbol", this.Id);
            }




            if (this.TableType != null)
            {
                md.SetInt("winner_round_1", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("winner_round_2", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("winner_round_3", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }
            if (this.Id != null)
            {
                md.SetString("id", this.Id);
            }

            if (this.TableType != null)
            {
                md.SetInt("table_type", this.TableType);
            }

            md.SetString("type", "game_table");
            return md;
        }
        public static GameTableDefinition GetById(String Id)
        {
            GameTableDefinition o = null;

            using (var query = QueryBuilder.Select(SelectResult.All())
              .From(DataSource.Database(DbHelper.GetDatabase()))
              .Where(Expression.Property("id").EqualTo(Expression.String(Id))
              .And(Expression.Property("type").EqualTo(Expression.String("game_table")))))
            {
                IResultSet rs = query.Execute();
                if (rs == null)
                {
                    return null;
                }

                List<Result> ls = rs.AllResults();
                if (ls.Count == 0)
                {
                    return null;
                }

                if (ls.First() == null)
                {
                    return null;
                }

                DictionaryObject row = ls.First().GetDictionary(0);
                o = GameTableDefinition.FromDictionary(row);
            }

            return o;
        }

    }
}
