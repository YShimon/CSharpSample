//-----------------------------------------------------------------------
// <copyright file="LinqSampleBehavior001.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample.SampleCode
{
    using System;
    using System.Linq;
    using CSharpSample.DataFactory;
    using CVL.Extentions;

    /// <summary>
    /// SampleBehavior001 Class
    /// </summary>
    public class LinqSampleBehavior001
    {
        /// <summary>
        /// Perform Basic Function
        /// </summary>
        public static void SampleData001_BasicBehaviorOfLinq()
        {
            // Create Sample Data
            var sampleData001 = new DataFactory<SampleData001>().Create();

            // --------------------------------------------------
            // 要素の取得（単一）
            // --------------------------------------------------
            // ElementAtの動作
            Console.WriteLine("\nsampleData.ElementAtで取得した値を表示します 。");
            Console.WriteLine($"sampleData.ElementAt(0).Idの値={sampleData001.ElementAt(0).Id}");
            Console.WriteLine($"sampleData.ElementAt(1).Idの値={sampleData001.ElementAt(1).Id}");

            // ElementAtOrDefaultの動作
            Console.WriteLine("\nsampleData.ElementAtOrDefaultで取得した値を表示します 。");
            Console.WriteLine($"sampleData.ElementAtDefault(0).Idの値={sampleData001.ElementAtOrDefault(0).Id}");
            Console.WriteLine($"sampleData.ElementAtDefault(1).Idの値={sampleData001.ElementAtOrDefault(1).Id}");
            try
            {
                Console.WriteLine($"sampleData.ElementAtDefault(6).Idの値={sampleData001.ElementAtOrDefault(6).Id}");
            }
            catch
            {
                Console.WriteLine("sampleData.ElementAtOrDefault(6).Idは、NULLなので、Exceptionが発生します。");
                Console.WriteLine("Exeptionを回避するには、sampleData.ElementAtOrDefault(6)?.Idとします。");
                Console.WriteLine($"sampleData.ElementAtDefault(6).Idの値={sampleData001.ElementAtOrDefault(6)?.Id}");
            }

            // First
            Console.WriteLine("\nsampleData.First()で取得した値を表示します。");
            Console.WriteLine($"sampleData.First().Idの値={sampleData001.First().Id}");
            Console.WriteLine($"sampleData.First(x => x.Id > 2).Idの値={sampleData001.First(x => x.Id > 2).Id}");
            Console.WriteLine($"sampleData.First(x => x.LinkId < 10).Idの値={sampleData001.First(x => x.LinkId < 10).Id}");

            // FirstOrDefault
            Console.WriteLine("\nsampleData.FirstOrDefault()で取得した値を表示します。");
            Console.WriteLine($"sampleData.FirstOrDefault().Idの値={sampleData001.FirstOrDefault().Id}");
            Console.WriteLine($"sampleData.FirstOrDefault(x => x.Id > 2).Idの値={sampleData001.FirstOrDefault(x => x.Id > 2).Id}");
            Console.WriteLine($"sampleData.FirstOrDefault(x => x.Id < 10).Idの値={sampleData001.FirstOrDefault(x => x.Id < 10).Id}");

            // Last
            Console.WriteLine("\nsampleData.Last()で取得した値を表示します。");
            Console.WriteLine($"sampleData.Last().Idの値={sampleData001.Last().Id}");
            Console.WriteLine($"sampleData.Last(x => x.LinkId == 10).Idの値={sampleData001.Last(x => x?.LinkId == 10).Id}");

            // LastOrDefault
            Console.WriteLine("\nsampleData.LastOrDefault()で取得した値を表示します。");
            Console.WriteLine($"sampleData.LastOrDefault().Idの値={sampleData001.LastOrDefault().Id}");
            Console.WriteLine($"sampleData.LastOrDefault(x => x.LinkId == 10).Idの値={sampleData001.LastOrDefault(x => x?.LinkId == 10).Id}");

            // Single
            Console.WriteLine("\nsampleData.Single()で取得した値を表示します。");
            Console.WriteLine($"sampleData.Single(x => x?.Id == 1).LinkIdの値={sampleData001.Single(x => x?.Id == 1).LinkId}");
            try
            {
                Console.WriteLine($"sampleData.Single(x => x?.LinkId == 10).Idの値={sampleData001.Single(x => x?.LinkId == 10).Id}");
            }
            catch
            {
                Console.WriteLine("sampleData.Single(x => x?.LinkId == 10).Idは、複数の要素が含まれるので、Exceptionが発生します。");
            }

            // SingleOrDefault
            Console.WriteLine("\nsampleData.SingleOrDefault()で取得した値を表示します。");
            Console.WriteLine($"sampleData.SingleOrDefault(x => x?.Id == 1).LinkIdの値={sampleData001.SingleOrDefault(x => x?.Id == 1).LinkId}");
            try
            {
                Console.WriteLine($"sampleData.SingleOrDefault(x => x?.LinkId == 10).Idの値={sampleData001.SingleOrDefault(x => x?.LinkId == 10).Id}");
            }
            catch
            {
                Console.WriteLine("sampleData.SingleOrDefault(x => x?.LinkId == 10).Idは、複数の要素が含まれるので、Exceptionが発生します。");
            }

            // --------------------------------------------------
            // 要素の取得（複数）
            // --------------------------------------------------
            // Whereの動作(sampleDataのIdのリストを取得 SampleData001がnullでない要素のみを取得)
            Console.WriteLine("\nsampleData.Where(x => x != null)で取得した値を表示します 。");
            sampleData001
                .Where(x => x != null)
                .ForEach(x => { Console.WriteLine($"sampleDataのIdの値:{x?.Id}"); });

            // Distinct
            Console.WriteLine("\nDistinct()による重複のない要素を表示します。");
            foreach (var linKId in sampleData001.Select(x => x?.LinkId).Distinct().OrderBy(x => x))
            {
                Console.WriteLine($"Distinct()による重複のないLinkId(OrderByによりソート済):{linKId}");
            }            

            // Skip
            Console.WriteLine("\nSkip(3)による要素を表示します（先頭の３つの要素をスキップ）。");
            foreach (var sample in sampleData001.Skip(3))
            {
                Console.WriteLine($"Skip(3)による要素の表示 Id:{sample?.Id}");
            }
            
            // SkipWhile
            Console.WriteLine("\nSkipWhile(x => x.Id < 6)による要素を表示します（Id < 6）となる要素をskipし残りの要素を取得）。");
            foreach (var sample in sampleData001.SkipWhile(x => x.Id < 6))
            {
                Console.WriteLine($"SkipWhile(x => x.Id < 6)による要素の表示 Id:{sample?.Id} LinkId:{sample?.LinkId}");
            }

            // Take
            Console.WriteLine("\nTake(2)による要素を表示します（先頭の２つの要素を取得）。");
            foreach (var sample in sampleData001.Take(2))
            {
                Console.WriteLine($"Take(2)による要素の表示 Id:{sample?.Id} LinkId:{sample?.LinkId}");
            }

            // TakeWhile
            Console.WriteLine("\nTakeWhile(x => x.LinkId == 10)による要素を表示します（LinkId == 10の要素を取得）。");
            foreach (var sample in sampleData001.TakeWhile(x => x.LinkId == 10))
            {
                Console.WriteLine($"TakeWhile(x => x.LinkId == 10)による要素の表示 Id:{sample?.Id} LinkId:{sample?.LinkId}");
            }

            // --------------------------------------------------
            // 集計
            // --------------------------------------------------
            // Max
            Console.WriteLine("\nMax(x => x?.Id)による要素を表示します。（複数の要素は戻せない）");
            Console.WriteLine($"Max(x => x?.Id)による要素の表示 Max Id:{sampleData001.Max(x => x?.Id)}");

            // Min
            Console.WriteLine("\nMin(x => x?.Id)による要素を表示します。（複数の要素は戻せない）");
            Console.WriteLine($"Min(x => x?.Id)による要素の表示 Min Id:{sampleData001.Min(x => x?.Id)}");

            // Average
            Console.WriteLine("\nAverage(x => x?.Id)による要素を表示します。（複数の要素は戻せない）");
            Console.WriteLine($"Average(x => x?.Id)による結果の表示 Average:{sampleData001.Average(x => x?.Id)} =(1 + 2 + ... 6 + 8)/ 7 （Nullの要素は個数にカウントされていない）");

            // Sum
            Console.WriteLine("\nSum(x => x.Id)による要素を表示します。（複数の要素は戻せない）");
            Console.WriteLine($"Sum(x => x.Id)による結果の表示 Id:{sampleData001.Sum(x => x?.Id)} =(1 + 2 + ... 6 + 8)（Nullの要素はカウントされていない）");
            Console.WriteLine($"Where(x => x?.Id == 100).Sum(x => x.Id)による結果の表示 Sum:{sampleData001.Where(x => x?.Id == 100).Sum(x => x.Id)} =(0)（該当要素がない場合は、0）");

            // Count
            Console.WriteLine("\nCount(x => x.LinkId == 10)による要素を表示します。（複数の要素は戻せない）");
            Console.WriteLine($"Count(x => x.LinkId == 10)による結果の表示 Count:{sampleData001.Count(x => x?.LinkId == 10)}");

            // Aggregate
            Console.WriteLine("\nAggregate((x, y) => x + y)｛和の計算｝による結果を表示します。（nullの要素を削除する拡張メソッドを追加している）");
            Console.WriteLine($"Aggregate((x, y) => x + y)による結果の表示 Select(x => x?.Id).Where(x => x != null).Aggregate(Sum):{sampleData001.Select(x => x?.Id).Where(x => x != null).Aggregate((x, y) => x + y)}");

            // --------------------------------------------------
            // 判定
            // --------------------------------------------------
            // All
            Console.WriteLine("\nAll(x => x?.Id >= 0)の結果（全ての条件を満たしていのか判定します）を表示します。");
            Console.WriteLine($"All(x => x?.Id >= 0) {sampleData001.All(x => x?.Id >= 0)}");
            Console.WriteLine("All(x => x?.Id >= 0 || x == null)の結果（全ての条件を満たしていのか判定します）を表示します。");
            Console.WriteLine($"All(x => x?.Id >= 0 || x == null) {sampleData001.All(x => x?.Id >= 0 || x == null)}");

            // Any
            Console.WriteLine("\nAny(x => x?.Id == 1)の結果（いづれかの条件を満たしていのか判定します）を表示します。");
            Console.WriteLine($"Any(x => x?.Id == 1) {sampleData001.Any(x => x?.Id == 1)}");
            Console.WriteLine("Any(x => x?.Id == 7)の結果（いづれかの条件を満たしていのか判定します）を表示します。");
            Console.WriteLine($"Any(x => x?.Id == 7) {sampleData001.Any(x => x?.Id == 7)}");

            // Contains
            Console.WriteLine("\nContains()の結果（指定した要素が含まれているのか判定します）を表示します。");
            Console.WriteLine($"Contains(new SampleData001 {{ Id = 1, LinkId = 10, }}) : {sampleData001.Contains(new SampleData001 { Id = 1, LinkId = 10, })} (Trueにならない！！)");
            Console.WriteLine($"Contains(new SampleData001.ElementAt(0)) : {sampleData001.Contains(sampleData001.ElementAt(0))}");

            // SequenceEqual
            var sampleData02 = new DataFactory<SampleData001>().Create();
            Console.WriteLine("\nSequenceEqual()の結果（２つのシーケンスが等しいのか判定します）を表示します。");
            Console.WriteLine($"SquencEqual(sampleData02) : {sampleData001.SequenceEqual(sampleData02)}　（Trueにならない！！）");
            var sampleArr01 = new[] { 01, 02, 03 };
            Console.WriteLine($"sampleArr01.SquencEqual(new[] {{ 01, 02, 03 }}) : {sampleArr01.SequenceEqual(new[] { 01, 02, 03 })}　（Trueになる）");

            // --------------------------------------------------
            // 集合
            // --------------------------------------------------
            // Union
            Console.WriteLine("\nUnion()の結果（２つのシーケンスの和集合）を表示します。");
            var additionalSampleData = new[] { new SampleData001 { Id = 100, LinkId = 200, } };
            foreach (var sample in sampleData001.Union(additionalSampleData))
            {
                Console.WriteLine($"Union(additionalSampleData) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // Except
            Console.WriteLine("\nExcept()の結果（シーケンスの差集合）を表示します。");
            foreach (var sample in sampleData001.Except(new[] { sampleData001.ElementAt(0) }))
            {
                Console.WriteLine($"Expect(new[] {{ sampleData.ElementAt(0) }}) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // Intersect
            Console.WriteLine("\nIntersect()の結果（シーケンスの積集合）を表示します。");
            foreach (var sample in sampleData001.Intersect(new[] { sampleData001.ElementAt(0), sampleData001.ElementAt(7) }))
            {
                Console.WriteLine($"Intersect(new[] {{ sampleData.ElementAt(0), sampleData.ElementAt(7) }}) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // --------------------------------------------------
            // ソート
            // --------------------------------------------------
            // OrderBy
            Console.WriteLine("\nOrderBy()の結果（LinkIdで昇順にソート。nullのデータは排除しています）を表示します。");
            foreach (var sample in sampleData001.Where(x => x != null && x?.LinkId != null).OrderBy(x => x?.LinkId))
            {
                Console.WriteLine($"OrderBy(x => x.LinkId) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // OrderByDescending
            Console.WriteLine("\nOrderByDescending()の結果（Idで降順にソート。nullのデータは排除しています）を表示します。");
            foreach (var sample in sampleData001.Where(x => x != null).OrderByDescending(x => x.Id))
            {
                Console.WriteLine($"OrderByDescending(x => x.Id) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // ThenBy
            Console.WriteLine("\nOrderByDescending().ThenBy()の結果（LinkIdで降順にソート。同一LinkIdの場合、Idで昇順にソート。nullのデータは排除しています）を表示します。");
            foreach (var sample in sampleData001.Where(x => x != null && x?.LinkId != null).OrderByDescending(x => x.LinkId).ThenBy(x => x.Id))
            {
                Console.WriteLine($"OrderByDescending(x => x.Id).ThenBy(x => x.LinkId) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // ThenByDescending
            Console.WriteLine("\nOrderByDescending().ThenByDescending()の結果（LinkIdで降順にソート。同一LinkIdの場合、Idで降順にソート。nullのデータは排除しています）を表示します。");
            foreach (var sample in sampleData001.Where(x => x != null && x?.LinkId != null).OrderByDescending(x => x.LinkId).ThenByDescending(x => x.Id))
            {
                Console.WriteLine($"OrderByDescending(x => x.Id).ThenByDescending(x => x.LinkId) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // Reverse
            Console.WriteLine("\nReverse()の結果を表示します。");
            foreach (var sample in sampleData001.Reverse())
            {
                Console.WriteLine($"OrderByDescending(x => x.Id).ThenByDescending(x => x.LinkId) Id: {sample?.Id} LinkId : {sample?.LinkId}");
            }

            // --------------------------------------------------
            // 射影
            // --------------------------------------------------
            // Selectの動作(sampleDataのIdのリストを取得)
            Console.WriteLine("\nSelect(x => x?.Id)の結果を表示します。");
            foreach (var id in sampleData001.Select(x => x?.Id))
            {
                Console.WriteLine($"Select(x => x?.Id) Id:{id}");
            }

            // GroupBy
            Console.WriteLine("\nGroupBy(x => x?.LinkId)の結果を表示します。");
            foreach (var sample in sampleData001.GroupBy(x => x?.LinkId))
            {
                Console.WriteLine($"GroupBy(x => x?.LinkId) Key:{sample?.Key}");
                foreach (var value in sample)
                {
                    Console.WriteLine($"GroupBy(x => x?.LinkId) value.Id:{value?.Id} value.LinkId : {value?.LinkId}");
                }
            }

            // SelectMany
            Console.WriteLine("\n一旦GroupBy(x => x?.LinkId)でグループ化した後にSelectMany(x => x)で取得した結果を表示します。");
            var sampleGrouupBy = sampleData001.GroupBy(x => x?.LinkId);
            foreach (var sample in sampleGrouupBy.SelectMany(x => x))
            {
                Console.WriteLine($"SelectMany(x => x) Id:{sample?.Id} LinkId : {sample?.LinkId}");
            }

            // --------------------------------------------------
            // 結合
            // --------------------------------------------------
            // Create Sample Data
            var sampleData002 = new DataFactory<SampleData002>().Create();

            // Join (Nullがあると結合できない)
            Console.WriteLine("\nJoin(sampleData001_02, x => x.LinkId, y => y.LinkId, (x, y))の結果を表示します。");
            var sampleData001_02 = sampleData001.Where(x => x != null && x.LinkId != null);
            foreach (var sample in sampleData002.Join(sampleData001_02, x => x.LinkId, y => y.LinkId, (x, y) => new { y.LinkId, x.Comment }))
            {
                Console.WriteLine($"sampleData002.Join(sampleData001_02...) LinkId:{sample.LinkId} Comment : {sample.Comment}");
            }

            // GroupJoin
            Console.WriteLine("\nsampleData002.GroupJoin(sampleData001_02, outer => outer.LinkId...)の結果を表示します。");
            var linkIds = sampleData002.GroupJoin(
                    sampleData001_02,
                    outer => outer.LinkId,
                    inner => inner.LinkId,
                    (outer, IdCollection) => new { LinkId = outer.LinkId, Ids = IdCollection });
            foreach (var sample in linkIds)
            {
                Console.WriteLine($"sampleData002.GroupJoin(sampleData001...) LinkId:{sample.LinkId}");
                foreach (var id in sample.Ids)
                {
                    Console.WriteLine($"   Id:{id.Id}");
                }
            }

            // Concat
            Console.WriteLine("\nsampleData002.Concat(sampleData002_02)の結果を表示します。");
            var sampleData002_02 = sampleData002.Select(x => 
            {
                return new SampleData002 { LinkId = x.LinkId * 2, Comment = x.Comment + " : Modify" };
            });
            foreach (var sample in sampleData002.Concat(sampleData002_02))
            {
                Console.WriteLine($"sampleData002.Concat(sampleData002_02) LinkId:{sample.LinkId} Comment:{sample.Comment}");
            }

            // Zip
            foreach (var sample in sampleData002.Zip(sampleData002_02, (outer1, outer2) => outer1.Comment + "+" + outer2.Comment))
            {
                Console.WriteLine($"sampleData002.Zip(sampleData002_02, (outer1, outer2) => outer1.Comment ...) Comment:{sample}");
            }

            // DefaultIfEmpty
            Console.WriteLine("\nsampleData001.DefaultIfEmpty()の結果を表示します。");
            foreach (var sample in sampleData001.DefaultIfEmpty())
            {
                Console.WriteLine($"sampleData001.DefaultIfEmpty() Id:{sample?.Id} Comment:{sample?.LinkId}");
            }

            // --------------------------------------------------
            // 変換
            // --------------------------------------------------
            // OfType
            Console.WriteLine("\nsampleData001.OfType<int>()の結果を表示します。");
            foreach (var sample in sampleData001.Select(x => x?.Id).OfType<int>())
            {
                Console.WriteLine($"sampleData001.Select(x => x?.Id).OfType<int>() Id:{sample}");
            }

            // Cast
            Console.WriteLine("\nsampleData001.Cast<int>()の結果を表示します。");
            try
            {
                foreach (var sample in sampleData001.Where(x => x != null).Select(x => x.LinkId).Cast<string>())
                {
                    Console.WriteLine($" sampleData001...Cast<string>() LinkId(string):{sample}");
                }
            }
            catch
            {
                Console.WriteLine("sampleData.Where(x => x != null)...に、Castできない要素が含まれるので、Exceptionが発生します。");
            }

            // ToArray
            Console.WriteLine("\nsampleData002.Select(x => x.LinkId).ToArray()の結果(型名)を表示します。");
            var sampleData002ToArray = sampleData002.Select(x => x.LinkId).ToArray();
            Console.WriteLine($"Type of sampleData002ToArray : {sampleData002ToArray.GetType().Name}");

            // ToDictionary
            Console.WriteLine("\nsampleData002.ToDictionary()の結果を表示します。");
            foreach (var sample in sampleData001.Where(x => x != null && x.LinkId != null).ToDictionary(x => x.Id, y => y.LinkId))
            {
                Console.WriteLine($"sampleData001.ToDictionary() Key(Id):{sample.Key} Value(LinkId) : {sample.Value}");
            }

            // ToList
            Console.WriteLine("\nsampleData001.ToList()の結果(型名)を表示します。");
            var sampleData001ToList = sampleData002.ToList();
            Console.WriteLine($"Type of sampleData001ToList ; {sampleData001ToList.GetType().Name}");

            // ToLookup
            Console.WriteLine("\nsampleData002.ToLookup()の結果を表示します。");
            foreach (var sample in sampleData002.ToLookup(x => x.LinkId))
            {
                Console.WriteLine($"Key : {sample.Key}");
                foreach (var item in sample)
                {
                    Console.WriteLine($" Value : LinkId : {item.LinkId} Comment : {item.Comment}");
                }
            }

            // ToDo:AsEnumerable
            Console.WriteLine("\nint[] {1,2,3} => AsEnumerable()の結果を表示します。");
            int[] arrayOfInt = new int[] { 1, 2, 3 };
            foreach (var item in arrayOfInt.AsEnumerable())
            {
                Console.WriteLine($"Value : {item}");
            }

            // --------------------------------------------------
            // sampleDataの表示
            // --------------------------------------------------
            // sampleData001の表示
            Console.WriteLine("\nsampleData001を表示します。");
            foreach (var data in sampleData001)
            {
                Console.WriteLine($"sampleData001.Id:{data?.Id} LinkId:{data?.LinkId}");
            }

            // sampleData002の表示
            Console.WriteLine("\nsampleData002を表示します。");
            foreach (var data in sampleData002)
            {
                Console.WriteLine($"sampleData001.Id:{data.LinkId} LinkId:{data.Comment}");
            }
        }
    }
}
