using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.SampleCode.Entity
{
    /// <summary>
    /// 家計簿クラスのエンティティ
    /// TableアトリビュートにはSystem.Data.Linqへの参照が必要
    /// </summary>
    [Table(Name = "dbo.HouseholdAccount")]
    class HouseholdAccount
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "int NOT NULL IDENTITY")]
        public int Id { get; set; }

        [Column(CanBeNull =true)]
        public　DateTime? Date { get; set; }

        [Column(CanBeNull =true)]
        public string Item { get; set; }

        [Column(CanBeNull =true)]
        public string Memo { get; set; }

        [Column(CanBeNull =true)]
        public int? Payment { get; set; }

        [Column(CanBeNull =true)]
        public int? Withdrawal { get; set; }
    }
}
