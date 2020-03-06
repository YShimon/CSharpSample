using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Extentions;
using Linq.Types;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unhandled Exceptionのハンドラ登録
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // サンプル番号の取得
            var maxEnum = Enum.GetNames(typeof(LinqSampleType)).Length;
            var sampleNo = args.Length == 0 ? maxEnum : args[0].ToIntOrDefault(0);
            while (sampleNo >= maxEnum)
            {
                Console.Write($"サンプル番号を入力して下さい(または、Ctr+Cでプログラムを終了します)[0-{maxEnum - 1}]:");
                sampleNo = Console.ReadLine().ToIntOrDefault(maxEnum);

                if (sampleNo >= maxEnum)
                {
                    Console.WriteLine("Usage : Linq [SampleNumber]");
                    Console.WriteLine("\tSampleNumber :=");
                    Enum.GetNames(typeof(LinqSampleType))
                        .Select((x, y) => { return new { Name = x, Index = y }; })
                        .ForEach(x =>
                        {
                            Console.WriteLine($"\t\t{x.Index} => {x.Name}");
                        });
                    Console.WriteLine("");
                }
            }

            // サンプルコードの実行
            PerformSampleCode((LinqSampleType)sampleNo);
        }

        /// <summary>
        /// サンプルデータ001
        /// </summary>
        private static IEnumerable<SampleData001> sampleData001 = new SampleData001[]
        {
            new SampleData001() { Id = 1, LinkId = 10, },
            new SampleData001() { Id = 3, LinkId = 10, },
            new SampleData001() { Id = 2, LinkId = 10, },
            new SampleData001() { Id = 4, LinkId = 5, },
            new SampleData001() { Id = 5, LinkId = 5, },
            new SampleData001() { Id = 6, },
            null,
            new SampleData001() { Id = 8, LinkId = 8, },
        };

        /// <summary>
        /// サンプルデータ002
        /// </summary>
        private readonly IEnumerable<SampleData002> sampleData002 = new SampleData002[]
        {
            new SampleData002 { LinkId = 5, Comment = "Comment(LinkId == 5)", },
            new SampleData002 { LinkId = 5, Comment = "Comment(LinkId != 7)", },
            new SampleData002 { LinkId = 10, Comment = "Comment(LinkId == 10)", },
        };

        /// <summary>
        /// UnhandledException例外ハンドラ
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("[Unhandled Exception]Program Unsuccessfuly Finished");
            Environment.Exit(-1);
        }

        /// <summary>
        /// Sample001データをコンソールに表示
        /// </summary>
        private static void ShowSample001()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("入力データ(sample001)は下記になります");
            Console.WriteLine("------------------------------");

            sampleData001
                .Select((x, y) => { return new { Data = x, Index = y }; })
                .ForEach(x =>
                {
                    var isNull = x.Data == null ? "(sampleData001 is null)" : string.Empty;
                    Console.WriteLine($"\t[{x.Index}] \tId:{x.Data?.Id}  \tLinkId:{x.Data?.LinkId} \t{isNull}");
                });

            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// サンプルコードを実行
        /// </summary>
        /// <param name="exampleNo">サンプル番号</param>
        /// <returns>実行ステータス</returns>
        private static bool PerformSampleCode(LinqSampleType exampleNo)
        {
            switch (exampleNo)
            {
                // --------------------------------------------------
                // 要素の取得（単一）
                // --------------------------------------------------
                case LinqSampleType.ElementAt:
                    ElementAt();
                    break;

                case LinqSampleType.ElementAtOrDefault:
                    ElementAtOrDefault();
                    break;

                case LinqSampleType.First:
                    First();
                    break;

                case LinqSampleType.FirstOrDefault:
                    FirstOrDefault();
                    break;

                case LinqSampleType.Last:
                    Last();
                    break;

                case LinqSampleType.LastOrDefault:
                    LastOrDefault();
                    break;

                case LinqSampleType.Single:
                    Single();
                    break;

                case LinqSampleType.SingleOrDefault:
                    SingleOrDefault();
                    break;

                // --------------------------------------------------
                // 要素の取得（複数）
                // --------------------------------------------------
                case LinqSampleType.Where:
                    Where();
                    break;

                case LinqSampleType.Distinct:
                    Distinct();
                    break;

                case LinqSampleType.Skip:
                    Skip();
                    break;

                default:
                    throw new Exception("不正なサンプル番号が指定されました。");
            }

            return true;
        }

        /// <summary>
        /// これから消えていくメソッド
        /// </summary>
        private void Sample()
        {
#if false
            // --------------------------------------------------
            // 要素の取得（複数）
            // --------------------------------------------------
            
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
#endif
        }

        // --------------------------------------------------
        // 要素の取得（単一）
        // --------------------------------------------------

        /// <summary>
        /// 要素の取得（単一） ElementAtのサンプル
        /// </summary>
        private static void ElementAt()
        {
            // コレクションsaampleDataからインデックスを指定して値を取得する
            // インデックスが範囲外の場合は、例外発生（例外を発生させたくない場合は、ElementAtOrDefaultを利用する）
            var elementAt0 = sampleData001.ElementAt(0).Id;
            var elementAt1 = sampleData001.ElementAt(1).Id;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.ElementAtのサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.ElementAt(0).Id = {elementAt0}");
            Console.WriteLine($"\tsampleData.ElementAt(1)    = {elementAt1}");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("インデックスが範囲外(sampleData001.ElementAt(10))の値を取得しようとすると、例外が発生します");
            Console.WriteLine($"{Environment.NewLine}");

            // 配列が範囲外のため、例外が発生します
            // ちなみに、_(アンダーバー)は廃棄を意味しています
            _ = sampleData001.ElementAt(10);
        }

        /// <summary>
        /// 要素の取得（単一） ElementAtOrDefaultのサンプル
        /// </summary>
        private static void ElementAtOrDefault()
        {
            // コレクションsaampleDataからインデックスを指定して値を取得する
            // インデックスが範囲外の場合は、規定値を戻す
            var elementAtOrDefault00 = sampleData001.ElementAtOrDefault(0).Id;
            var elementAtOrDefault01 = sampleData001.ElementAtOrDefault(1);
            var elementAtOrDefault10 = sampleData001.ElementAtOrDefault(10);

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.ElementAtOrDefaultのサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.ElementAtOrDefault(0).Id = {elementAtOrDefault00}");
            Console.WriteLine($"\tsampleData.ElementAtOrDefault(1)    = {elementAtOrDefault01}");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("インデックスが範囲外(sampleData001.ElementAtOrDefault(10))の値を取得しようとすると、Nullが取得されます");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"\tsampleData.ElementAtOrDefault(10)   = {elementAtOrDefault10}");
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（単一） Firstのサンプル
        /// </summary>
        private static void First()
        {
            // コレクション先頭の値を取得する(ラムダ式により条件設定可能)
            // コレクション要素数が0の場合は、例外発生（例外を発生させたくない場合は、FirstOrDefaultを利用する）
            var first0 = sampleData001.First().Id;
            var first1 = sampleData001.First(x => x.Id > 2).Id;
            var first2 = sampleData001.First(x => x.LinkId < 10).Id;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.First()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.First().Id = {first0}");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("Firstにラムダ式を設定することにより条件設定が可能です");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"\tsampleData.First(x => x.Id > 2).Id      = {first1}");
            Console.WriteLine($"\tsampleData.First(x => x.LinkId < 10).Id = {first2}");
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（単一） FirstOrDefaultのサンプル
        /// </summary>
        private static void FirstOrDefault()
        {
            // コレクション先頭の値を取得する(ラムダ式により条件設定可能)
            // コレクション要素数が0の場合は、規定値(null)を戻す
            var firstOrDefault0 = sampleData001.FirstOrDefault().Id;
            var firstOrDefault1 = sampleData001.FirstOrDefault(x => x.Id > 2).Id;
            var firstOrDefault2 = sampleData001.FirstOrDefault(x => x.Id < 10).Id;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.FirstOrDefault()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.FirstOrDefault().Id = {firstOrDefault0}");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("FirstOrDefaultにラムダ式を設定することにより条件設定が可能です");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"\tsampleData.FirstOrDefault(x => x.Id > 2).Id  = {firstOrDefault1}");
            Console.WriteLine($"\tsampleData.FirstOrDefault(x => x.Id < 10).Id = {firstOrDefault2}");
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（単一） Lastのサンプル
        /// </summary>
        private static void Last()
        {
            // コレクション最後の値を取得する(ラムダ式により条件設定可能)
            // コレクション要素数が0の場合は、例外発生（例外を発生させたくない場合は、LastOrDefaultを利用する）
            var last0 = sampleData001.Last().Id;
            var last1 = sampleData001.Last(x => x?.LinkId == 10).Id;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.Last()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\nsampleData.Last()で取得した値を表示します");
            Console.WriteLine($"\tsampleData.Last().Id                    = {last0}");
            Console.WriteLine($"\tsampleData.Last(x => x.LinkId == 10).Id = {last1}");
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（単一） LastOrDefaultのサンプル
        /// </summary>
        private static void LastOrDefault()
        {
            // コレクション最後の値を取得する(ラムダ式により条件設定可能)
            // コレクション要素数が0の場合は、規定値(null)を戻す
            var lastOrDefault0 = sampleData001.LastOrDefault().Id;
            var lastOrDefault1 = sampleData001.LastOrDefault(x => x?.LinkId == 10).Id;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.LastOrDefault()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.LastOrDefault().Id                    = {lastOrDefault0}");
            Console.WriteLine($"\tsampleData.LastOrDefault(x => x.LinkId == 10).Id = {lastOrDefault1}");
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（単一） Singleのサンプル
        /// </summary>
        private static void Single()
        {
            // コレクションから単一の値を取得する(ラムダ式により条件設定可能)
            // 取得結果の要素数が1以外の場合は、例外発生
            var single0 = sampleData001.Single(x => x?.Id == 1).LinkId;

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.Single()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.Single(x => x?.Id == 1).LinkId = {single0}");
            Console.WriteLine($"{Environment.NewLine}");

            // 要素数が複数のため、例外が発生します
            _ = sampleData001.Single(x => x?.LinkId == 10).Id;
        }

        /// <summary>
        /// 要素の取得（単一） SingleOrDefault
        /// </summary>
        private static void SingleOrDefault()
        {
            // コレクションから単一の値を取得する(ラムダ式により条件設定可能)
            var singleOrDefult1 = sampleData001.SingleOrDefault(x => x?.Id == 1).LinkId;

            // 取得結果の要素数が0個の場合は、規定値(null)を戻す
            var singleOrDefult2 = sampleData001.SingleOrDefault(x => x?.Id == 7);

            // 取り扱いデータを表示します
            ShowSample001();

            // 結果を表示します
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.SingleOrDefault()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tsampleData.SingleOrDefault(x => x?.Id == 1).LinkId = {singleOrDefult1}");
            Console.WriteLine($"\tsampleData.SingleOrDefault(x => x?.Id == 7)        = {singleOrDefult2}");
            Console.WriteLine($"{Environment.NewLine}");

            // 要素数が複数の場合、例外が発生します
            _ = sampleData001.SingleOrDefault(x => x?.LinkId == 10).Id;
        }

        // --------------------------------------------------
        // 要素の取得（複数）
        // --------------------------------------------------

        /// <summary>
        /// 要素の取得（複数）
        /// Where : 条件に合う要素を取得
        /// </summary>
        private static void Where()
        {
            // Whereの動作(nullでない要素のみを取得)
            var where1 = sampleData001.Where(x => x != null);

            // Whereの動作(Id==1とならない要素のみを取得)
            var where2 = sampleData001.Where(x => x != null && x?.Id != 1);

            // 取り扱いデータを表示します
            ShowSample001();

            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.Where()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\nsampleData.Where(x => x != null)で取得した値を表示します");
            where1.ForEach(x => { Console.WriteLine($"\tId = {x?.Id}, \t LinkId = {x?.LinkId}"); });
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("\nsampleData.Where(x => x != null && x?.Id != 1)で取得した値を表示します");
            where2.ForEach(x => { Console.WriteLine($"\tId = {x?.Id}, \t LinkId = {x?.LinkId}"); });
            Console.WriteLine($"{Environment.NewLine}");
        }

        /// <summary>
        /// 要素の取得（複数）
        /// Distinct : 重複のない要素を取得
        /// </summary>
        private static void Distinct()
        {
            // Disttinctの動作(重複しないようにLinkIdを取得)
            var linkId = sampleData001.Select(x => x?.LinkId).Distinct();

            // 取り扱いデータを表示します
            ShowSample001();

            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.Distinct()のサンプルです");
            Console.WriteLine("------------------------------");
            Console.WriteLine("sampleData001.Select(x => x?.LinkId).Distinct()で取得した値を表示します");
            linkId.ForEach(x => { Console.WriteLine($"\tLinkId(OrderByによりソート済) = {x}"); });
        }

        /// <summary>
        /// 要素の取得（複数）
        /// Skip : 先頭のN個の要素をスキップして取得
        /// </summary>
        private static void Skip()
        {
            // Skipの動作(先頭の3個の要素をスキップして取得)
            var skip = sampleData001.Skip(3);

            // 取り扱いデータを表示します
            ShowSample001();

            Console.WriteLine("------------------------------");
            Console.WriteLine("Enumerable.Skip()のサンプルです");
            Console.WriteLine("\tSkip(3)により先頭の３つの要素をスキップして取得");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\nsampleData001.Skip(3)で取得した値を表示します");
            skip.ForEach(x => { Console.WriteLine($"\tId = {x?.Id}, \t LinkId = {x?.LinkId}"); });
        }
    }
}

